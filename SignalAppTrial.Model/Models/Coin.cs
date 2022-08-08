using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalAppTrial.Model.Models
{
    public class Coin
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public Uri Image { get; set; }
        public int Market_Cap_Rank { get; set; }
        public double Current_Price { get; set; }
        public double Total_Volume { get; set; }
        public double High_24_Hour { get; set; }
        public double Low_24_Hour { get; set; }
        public double Price_Change_24_Hour { get; set; }
        public double Price_Change_Percentage_24_Hour { get; set; }
    }
}
