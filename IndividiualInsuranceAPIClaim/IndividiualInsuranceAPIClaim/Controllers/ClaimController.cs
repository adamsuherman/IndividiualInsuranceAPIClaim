using Microsoft.AspNetCore.Mvc;

namespace IndividiualInsuranceAPIClaim.Controllers
{
    public class ClaimController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
