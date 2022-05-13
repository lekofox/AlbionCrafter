using AlbionCrafter.Mats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionCrafter.Hunter
{
    public class Bows
    {
        public int PlanksQuantity;
        public double SellPrice;
        public Materials[] Mats;

        public Bows(int planksQuantity, double sellPrice, Materials[] mats)
        {
            PlanksQuantity = planksQuantity;
            SellPrice = sellPrice;
            Mats = mats;
        }

        public virtual double CraftPayback(double resourceReturn, double craftFee, double emptyJournal, double fullJournal)
        {
            return resourceReturn;
        }
    }

}
