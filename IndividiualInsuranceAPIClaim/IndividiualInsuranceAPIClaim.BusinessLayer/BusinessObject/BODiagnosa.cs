using IndividiualInsuranceAPIClaim.BusinessLayer.Helper;
using IndividiualInsuranceAPIClaim.DataAccess.Context;
using IndividiualInsuranceAPIClaim.DataAccess.Models.Claim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividiualInsuranceAPIClaim.BusinessLayer.BusinessObject
{
    public class BODiagnosa : IBODiagnosa
    {
        private ClaimContext _claimContext;
        RepoDiagnosa repo;
        public BODiagnosa(ClaimContext claimContext)
        {
            _claimContext = claimContext;
            repo = new RepoDiagnosa(claimContext);
        }

        public async Task<List<msDiagnosa>> Get()
        {
            List<msDiagnosa> result = new List<msDiagnosa>();
            try
            {
                result = await repo.Get();
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public async Task<msDiagnosa> GetById(string ID)
        {
            msDiagnosa result = new msDiagnosa();
            try
            {
                result = await repo.GetByID(ID);
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
