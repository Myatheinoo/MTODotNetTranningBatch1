using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTODotNetTrainingBatch1.MvcApiExample.DatabaseShared.Models;

namespace MTODotNetTrainingBatch1.MvcApiExample.RestApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public WalletController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetWalletAsync()
        {
            List<TblWallet> list = await _appDbContext.TblWallets.ToListAsync();
            return Ok(list);
        }
    }
}
