using IndividiualInsuranceAPIClaim.BusinessLayer.BindingModel;
using IndividiualInsuranceAPIClaim.DataAccess.Context;
using IndividiualInsuranceAPIClaim.DataAccess.Models.Claim;
using IndividiualInsuranceAPIClaim.DataAccess.Models.Membership;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividiualInsuranceAPIClaim.BusinessLayer.Helper
{
    public class RepoClaim
    {
        private readonly ClaimContext _context;
        private readonly MembershipContext _membershipContext;

        public RepoClaim(ClaimContext context, MembershipContext membershipContext)
        {
            _context = context;
            _membershipContext = membershipContext;
        }

        public async Task<BResInsertClaim> Insert(BReqInsertClaim request)
        {
            BResInsertClaim result = new BResInsertClaim();
            Guid id = Guid.NewGuid();

            var plafond = _membershipContext.TblPeserta.Where(s => s.CardNumber == request.CardNumber).Select(s => s.Plafond).FirstOrDefault();

            if(Convert.ToInt32(plafond) > Convert.ToInt32(request.Cost))
            {
                trClaim param = new trClaim();
                param.ID = id;
                param.CardNumber = request.CardNumber;
                param.DiagonosaCode = request.DiagonosaCode;
                param.Cost = request.Cost;
                param.TreatmentDate = request.TreatmentDate;
                param.CreatedBy = request.CreatedBy;
                param.CreatedDate = request.CreatedDate;
                _context.Add(param);


                var existingData = _membershipContext.TblPeserta.Where(t => t.CardNumber == request.CardNumber).FirstOrDefault();
                if(existingData != null)
                {
                    decimal newPlafond = Convert.ToDecimal(existingData.Plafond) - Convert.ToDecimal(request.Cost);
                    //var peserta = new TblPeserta { Plafond = newPlafond };
                    //_membershipContext.Entry(existingData).CurrentValues.SetValues(peserta);
                    (from p in _membershipContext.TblPeserta
                     where p.CardNumber == request.CardNumber
                     select p)
                     .ToList()
                     .ForEach(x => x.Plafond = newPlafond);
                    
                }
                _context.SaveChanges();
                _membershipContext.SaveChanges();

                var data = (from claim in _context.trClaim
                            join diagnosa in _context.msDiagnosa on claim.DiagonosaCode equals diagnosa.DiagonosaCode
                            where claim.ID == id
                            select new
                            {
                                ID = claim.ID,
                                CardNumber = claim.CardNumber,
                                Diagnosa = diagnosa.DiagonsaName,
                                Cost = claim.Cost,
                                TreatmentDate = claim.TreatmentDate,
                                CreatedBy = claim.CreatedBy,
                                CreatedDate = claim.CreatedDate
                            }).FirstOrDefault();

                result.ResultCode = "01";
                result.ResultMessage = "Save Successfully";
                result.Data = data;
            }
            else
            {
                result.ResultCode = "00";
                result.ResultMessage = "Save Failed, Limit anda tidak cukup.";
                result.Data = null;
            }

            return result;
        }

        public async Task<BResInsertClaim> GetByID(string ID)
        {
            BResInsertClaim result = new BResInsertClaim();
            
            var data = (from claim in _context.trClaim
                        join diagnosa in _context.msDiagnosa on claim.DiagonosaCode equals diagnosa.DiagonosaCode
                        where claim.ID.ToString() == ID
                        select new
                        {
                            ID = claim.ID,
                            CardNumber = claim.CardNumber,
                            Diagnosa = diagnosa.DiagonsaName,
                            Cost = claim.Cost,
                            TreatmentDate = claim.TreatmentDate,
                            CreatedBy = claim.CreatedBy,
                            CreatedDate = claim.CreatedDate
                        }).FirstOrDefault();

            result.ResultCode = "01";
            result.ResultMessage = "Save Successfully";
            result.Data = data;

            return result;
        }

        public async Task<BResInsertClaim> Get()
        {
            BResInsertClaim result = new BResInsertClaim();

            var data = (from claim in _context.trClaim
                        join diagnosa in _context.msDiagnosa on claim.DiagonosaCode equals diagnosa.DiagonosaCode
                        select new
                        {
                            ID = claim.ID,
                            CardNumber = claim.CardNumber,
                            Diagnosa = diagnosa.DiagonsaName,
                            Cost = claim.Cost,
                            TreatmentDate = claim.TreatmentDate,
                            CreatedBy = claim.CreatedBy,
                            CreatedDate = claim.CreatedDate
                        }).ToList();

            result.ResultCode = "01";
            result.ResultMessage = "Save Successfully";
            result.Data = data;

            return result;
        }
    }
}
