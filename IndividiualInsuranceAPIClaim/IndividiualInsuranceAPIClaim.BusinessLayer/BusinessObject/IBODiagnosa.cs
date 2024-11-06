using IndividiualInsuranceAPIClaim.DataAccess.Models.Claim;

namespace IndividiualInsuranceAPIClaim.BusinessLayer.BusinessObject
{
    public interface IBODiagnosa
    {
        Task<List<msDiagnosa>> Get();
        Task<msDiagnosa> GetById(string ID);
    }
}