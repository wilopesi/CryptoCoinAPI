using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApplication.Contexts.Model
{
    public class Coin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double Current_Price { get; set; }
        public double Market_Cap { get; set; }
        public string ImageLink { get; set; }
    }
}
