using Microsoft.AspNetCore.Mvc;

namespace MTODotNetTrainingBatch1.MvcApiExample.RestApi.Controllers
{
    public class WalletController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
