using IndividiualInsuranceAPIClaim.BusinessLayer.BusinessObject;
using IndividiualInsuranceAPIClaim.DataAccess.Context;
using IndividiualInsuranceAPIClaim.DataAccess.Models.Claim;
using Microsoft.AspNetCore.Mvc;

namespace IndividiualInsuranceAPIClaim.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DiagnosaController : Controller
    {
        private IConfiguration _configuration;
        List<msDiagnosa> ArrResult = new List<msDiagnosa>();
        msDiagnosa result = new msDiagnosa();
        BODiagnosa _boDiagnosa;
        private readonly ClaimContext _claimContext;

        public DiagnosaController(IConfiguration configuration, ClaimContext claimContext)
        {
            _configuration = configuration;
            _claimContext = claimContext;
            _boDiagnosa = new BODiagnosa(_claimContext);
        }

        [HttpGet]
        public async Task<IActionResult> GetDiagnosa()
        {
            ArrResult = await _boDiagnosa.Get();
            return new OkObjectResult(ArrResult);
        }
        [HttpGet]
        public async Task<IActionResult> GetDiagnosaById(string ID)
        {
            result = await _boDiagnosa.GetById(ID);
            return new OkObjectResult(result);
        }
    }
}
