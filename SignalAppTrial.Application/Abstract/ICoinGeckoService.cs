using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalAppTrial.Application.Abstract
{
    public interface ICoinGeckoService
    {
        Task GetAll();
    }
}
