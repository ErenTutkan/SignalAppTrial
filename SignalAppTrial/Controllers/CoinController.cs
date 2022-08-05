using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CoinGecko.Clients;
namespace SignalAppTrial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            

            HttpClient httpClient = new HttpClient();
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings();

            PingClient pingClient = new PingClient(httpClient, serializerSettings);
           CoinsClient coinsClient = new CoinsClient(httpClient,serializerSettings);

            // Check CoinGecko API status
            if ((await pingClient.GetPingAsync()).GeckoSays != string.Empty)
            {
                // Getting current price of tether in usd
                var result = await coinsClient.GetCoinMarkets("Usd");
                return Ok(result);
            }
            return BadRequest();

        }
    }
}
