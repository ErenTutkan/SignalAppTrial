using CoinGecko.Clients;
using Newtonsoft.Json;
using SignalAppTrial.Application.Abstract;
using SignalAppTrial.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SignalAppTrial.Application.Concrete
{
    public class CoinGeckoService : ICoinGeckoService
    {
        private readonly ICoinService _coinService;

        public CoinGeckoService(ICoinService coinService)
        {
            _coinService = coinService;
        }

        public async Task GetAll()
        {
            HttpClient httpClient = new HttpClient();
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
            PingClient pingClient = new PingClient(httpClient, serializerSettings);
            CoinsClient coin = new CoinsClient(httpClient, serializerSettings);
            SearchClient searchClient = new SearchClient(httpClient, serializerSettings);
            // Check CoinGecko API status
            if ((await pingClient.GetPingAsync()).GeckoSays != string.Empty)
            {
                // Getting current price of tether in usd
                string[] nullArray = { };
                string vsCurrencies = "usd";
                var result = await coin.GetCoinMarkets(vsCurrencies, nullArray, "market_cap_desc",200,1,false,"24h");
                
                foreach (var item in result)
                {
                    var coinModel = new Coin
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Symbol = item.Symbol,
                        Image = item.Image,
                        Market_Cap_Rank = (int)item.MarketCapRank,
                        Current_Price = (double)item.CurrentPrice,
                        Total_Volume = (double)item.TotalVolume,
                        High_24_Hour = (double)item.High24H,
                        Low_24_Hour = (double)item.Low24H,
                        Price_Change_24_Hour = (double)item.PriceChange24H,
                        Price_Change_Percentage_24_Hour = (double)item.PriceChangePercentage24H
                    };
                    if(_coinService.Get(coinModel.Id) != null)
                    {
                        await _coinService.Update(coinModel);
                    }
                    else
                    {
                        await _coinService.Add(coinModel);
                    }
                   
                }
               
            }
           
        }
    }
}
