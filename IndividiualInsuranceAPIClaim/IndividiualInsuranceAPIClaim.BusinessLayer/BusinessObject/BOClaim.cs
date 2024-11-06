using IndividiualInsuranceAPIClaim.BusinessLayer.BindingModel;
using IndividiualInsuranceAPIClaim.BusinessLayer.Helper;
using IndividiualInsuranceAPIClaim.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividiualInsuranceAPIClaim.BusinessLayer.BusinessObject
{
    public class BOClaim
    {
        private ClaimContext _claimContext;
        private MembershipContext _membershipContext;
        RepoClaim repo;

        public BOClaim(ClaimContext claimContext, MembershipContext membershipContext)
        {
            _claimContext = claimContext;
            _membershipContext = membershipContext;
            repo = new RepoClaim(_claimContext, _membershipContext);
        }
        public async Task<BResInsertClaim> Insert(BReqInsertClaim request)
        {
            BResInsertClaim result = new BResInsertClaim();
            try
            {
                result = await repo.Insert(request);
            }
            catch (Exception ex)
            {
                result.ResultCode = "00";
                result.ResultMessage = ex.Message.ToString();
                result.Data = null;
            }
            return result;
        }

        public async Task<BResInsertClaim> GetById(string ID)
        {
            BResInsertClaim result = new BResInsertClaim();
            try
            {
                result = await repo.GetByID(ID);
            }
            catch (Exception ex)
            {
                result.ResultCode = "00";
                result.ResultMessage = ex.Message.ToString();
                result.Data = null;
            }
            return result;
        }
        public async Task<BResInsertClaim> Get()
        {
            BResInsertClaim result = new BResInsertClaim();
            try
            {
                result = await repo.Get();
            }
            catch (Exception ex)
            {
                result.ResultCode = "00";
                result.ResultMessage = ex.Message.ToString();
                result.Data = null;
            }
            return result;
        }
    }
}
