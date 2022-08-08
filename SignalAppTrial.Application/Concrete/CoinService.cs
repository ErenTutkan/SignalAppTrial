using SignalAppTrial.Application.Abstract;
using SignalAppTrial.DataAccess.Abstract;
using SignalAppTrial.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalAppTrial.Application.Concrete
{
    public class CoinService : ICoinService
    {
        private readonly ICoinRepository _coinRepository;

        public CoinService(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
        }

        public async Task Add(Coin coin)
        {
          _coinRepository.Add(coin);
           
        }

        public async Task<Coin> Get(string coinId)
        {
            var result = _coinRepository.GetById(coinId);
            return result;
        }

        public async Task<List<Coin>> GetAll()
        {
            var result = _coinRepository.GetListAll();
            return result;
        }

        public Task Update(Coin coin)
        {
            _coinRepository.Update(coin);
            return Task.CompletedTask;
        }
    }
}
