using System.Text.Json.Serialization;
using MTODotNetTrainingBatch1.MvcApiExample.MVCApp.Models;
using Newtonsoft.Json;

namespace MTODotNetTrainingBatch1.MvcApiExample.MVCApp.Services
{
    public class WalletService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public WalletService(HttpClient httpClient,IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _httpClient.BaseAddress = new Uri(_configuration.GetValue<string>("ApiUrl")!);
        }

        public async Task<List<WalletModel>> GetWallets()
        {
           var response = await _httpClient.GetAsync("api/Wallet");
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                List<WalletModel> result = JsonConvert.DeserializeObject<List<WalletModel>>(jsonStr)!;
                return result;
            }
            else
            {
                throw new Exception("Fail to retrieve wallet.");
            }
        }
    }
}
