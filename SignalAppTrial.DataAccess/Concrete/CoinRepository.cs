﻿using SignalAppTrial.DataAccess.Abstract;
using SignalAppTrial.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalAppTrial.DataAccess.Concrete
{
    public class CoinRepository:GenericRepository<Coin>, ICoinRepository
    {
    }
}
