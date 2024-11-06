using IndividiualInsuranceAPIClaim.BusinessLayer.BindingModel;

namespace IndividiualInsuranceAPIClaim.BusinessLayer.BusinessObject
{
    public interface IBOClaim
    {
        Task<BResInsertClaim> Get();
        Task<BResInsertClaim> GetById(string ID);
        Task<BResInsertClaim> Insert(BReqInsertClaim request);
    }
}