using SignalAppTrial.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalAppTrial.Application.Abstract
{
    public interface ICoinService
    {
        Task<List<Coin>> GetAll();
        Task<Coin> Get(string coinId);
        Task Add(Coin coin);
        Task Update(Coin coin);
       
    }
}
