
using SignalAppTrial.DataAccess.Abstract;
using SignalAppTrial.Models;

namespace SignalAppTrial.Repository
{
    public class SignalRepository:ISignalRepository
    {
        List<Signal> signals=new List<Signal>()
        {
            new Signal(){Id=1,Data="The first target hit at $23219 for $BTC Bitcoin long buy position opened by the PARYTE Scalp algorithm."},
            new Signal(){Id=2,Data="$BTC Bitcoin value may increase from $22739.8, according to the PARYTE Scalp algorithm."},
            new Signal(){Id=3,Data="$BTC Bitcoin value at the support and oversold at $22453.1, according to the PARYTE Bollinger algorithm." },
            new Signal(){Id=4,Data="The first target hit at $23467 for $BTC Bitcoin long buy position opened by the PARYTE Scalp algorithm."},
            new Signal(){Id=5,Data="The last target hit at $1669.42 for $ETH Ethereum long buy position opened by the PARYTE Scalp algorithm."},
            new Signal(){Id=6,Data="The first target hit at $1648.14 for $ETH Ethereum long buy position opened by the PARYTE Scalp algorithm."},
            new Signal(){Id=7,Data="$ETH Ethereum value may increase from $1605.62, according to the PARYTE Scalp algorithm."},
            new Signal(){Id=8,Data="$BTC Bitcoin value may increase from $22898, according to the PARYTE Scalp algorithm."},
            new Signal(){Id=9,Data="The first target hit at $1564.82 for $ETH Ethereum short sell position opened by the PARYTE Scalp algorithm."},
            new Signal(){Id=10,Data="$ETH Ethereum value bottomed and oversold at $1593.52, according to the PARYTE Bollinger algorithm."},
            new Signal(){Id=11,Data="$ETH Ethereum value bottomed and oversold at $1599.52, according to the PARYTE Bollinger algorithm."},
            new Signal(){Id=12,Data="$ETH Ethereum value may decrease from $1588.26, according to the PARYTE Scalp algorithm."},
            new Signal(){Id=13,Data="The last target hit at $1587.38 for $ETH Ethereum short sell position opened by the PARYTE Scalp algorithm."},
            new Signal(){Id=14,Data="$ETH Ethereum value bottomed and oversold at $1630.28, according to the PARYTE Bollinger algorithm."},
            new Signal(){Id=15,Data="$ETH Ethereum value bottomed and oversold at $1640.45, according to the PARYTE Bollinger algorithm."},
            new Signal(){Id=16,Data="The first target hit at $1608.54 for $ETH Ethereum short sell position opened by the PARYTE Scalp algorithm."},
            new Signal(){Id=17,Data="$BTC Bitcoin value bottomed and oversold at $22945, according to the PARYTE Bollinger algorithm."},
            new Signal(){Id=18,Data="$ETH Ethereum value may decrease from $1629.4, according to the PARYTE Scalp algorithm."},
            new Signal(){Id=19,Data="$ETH Ethereum value may decrease from $1634.93, according to the PARYTE Scalp algorithm."},
            new Signal(){Id=20,Data="$ETH Ethereum value may decrease from $1634.93, according to the PARYTE Scalp algorithm."},
        };

        public Task<List<Signal>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
