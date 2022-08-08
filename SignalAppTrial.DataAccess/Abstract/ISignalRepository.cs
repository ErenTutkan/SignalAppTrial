using SignalAppTrial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalAppTrial.DataAccess.Abstract
{
    public interface ISignalRepository
    {
        Task<List<Signal>> GetAll();
    }
}
