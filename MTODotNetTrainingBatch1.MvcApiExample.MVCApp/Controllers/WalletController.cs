using Microsoft.AspNetCore.Mvc;
using MTODotNetTrainingBatch1.MvcApiExample.MVCApp.Services;

namespace MTODotNetTrainingBatch1.MvcApiExample.MVCApp.Controllers
{
    public class WalletController : Controller
    {
        private readonly WalletService _walletService;

        public WalletController(WalletService walletService)
        {
            _walletService = walletService;
        }

        [ActionName("Index")]
        public async Task<IActionResult> WalletIndexAsync()
        {
            List<Models.WalletModel> list = await _walletService.GetWallets();
            return View("WalletIndex",list);
        }
    }
}
