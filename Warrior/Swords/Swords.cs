using AlbionCrafter.Mats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionCrafter
{
    public class BaseSwords
    {
        public int LeatherQuantity;
        public int BarQuantity;
        public double SellPrice;
        public string Type;
        public Materials[] Mats;
        

        public BaseSwords(int leatherQuantity, int barQuantity, Materials[] mats)
        {
            this.LeatherQuantity = leatherQuantity;
            this.BarQuantity = barQuantity;
            this.Mats = mats;
        }

        public virtual double CraftPayback(double resourceReturn, double craftFee, double emptyJournal, double fullJournal)
        {
            return resourceReturn;
        }
    }
}
