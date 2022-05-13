using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionCrafter.Mats
{
    public class Materials
    {
        public double BuyPrice;
        public string Type;

        public Materials(double buyPrice, string type)
        {
            BuyPrice = buyPrice;
            Type = type;
        }
    }
}
