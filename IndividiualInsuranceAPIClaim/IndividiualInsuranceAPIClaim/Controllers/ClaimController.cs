using IndividiualInsuranceAPIClaim.BusinessLayer.BindingModel;
using IndividiualInsuranceAPIClaim.BusinessLayer.BusinessObject;
using IndividiualInsuranceAPIClaim.DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace IndividiualInsuranceAPIClaim.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ClaimController : Controller
    {
        private IConfiguration _configuration;
        private readonly BOClaim _boClaim;
        private readonly ClaimContext _claimContext;
        private readonly MembershipContext _membershipContext;
        BResInsertClaim result = new BResInsertClaim();
        public ClaimController(IConfiguration configuration, ClaimContext claimContext, MembershipContext membershipContext)
        {
            _configuration = configuration;
            _boClaim = new BOClaim(claimContext, membershipContext);
        }
        [HttpPost]
        public async Task<IActionResult> InsertClaim(BReqInsertClaim request)
        {
            result = await _boClaim.Insert(request);
            return new OkObjectResult(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetClaimByID(string ID)
        {
            result = await _boClaim.GetById(ID);
            return new OkObjectResult(result);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            result = await _boClaim.Get();
            return new OkObjectResult(result);
        }
    }
}
