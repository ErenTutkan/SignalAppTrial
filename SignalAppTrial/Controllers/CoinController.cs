using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CoinGecko.Clients;
using SignalAppTrial.Application.Abstract;

namespace SignalAppTrial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinController : ControllerBase
    {
        private readonly ICoinGeckoService _coinGeckoService;
        private readonly ICoinService _coinService;

        public CoinController(ICoinGeckoService coinGeckoService, ICoinService coinService)
        {
            _coinGeckoService = coinGeckoService;
            _coinService = coinService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result=await _coinService.GetAll();
            return Ok(result);

        }
    }
}
