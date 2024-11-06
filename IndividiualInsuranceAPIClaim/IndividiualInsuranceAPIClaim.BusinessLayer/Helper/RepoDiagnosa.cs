using IndividiualInsuranceAPIClaim.DataAccess.Context;
using IndividiualInsuranceAPIClaim.DataAccess.Models.Claim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividiualInsuranceAPIClaim.BusinessLayer.Helper
{
    public class RepoDiagnosa
    {
        private readonly ClaimContext _context;

        public RepoDiagnosa(ClaimContext context)
        {
            _context = context;
        }

        public async Task<List<msDiagnosa>> Get()
        {
            List<msDiagnosa> objRes = new List<msDiagnosa>();
            objRes = _context.msDiagnosa.ToList();
            return objRes;
        }
        public async Task<msDiagnosa> GetByID(string ID)
        {
            msDiagnosa objRes = new msDiagnosa();
            objRes = _context.msDiagnosa.Where(t => t.DiagonosaCode == ID).FirstOrDefault();
            return objRes;
        }
    }
}
