using AlbionCrafter.Mats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionCrafter.Hunter
{
    public class Bow : Bows
    {
        public Bow(double sellPrice, Materials[] mats, int planksQuantity = 32) : base(planksQuantity, sellPrice, mats)
        {
            this.PlanksQuantity = planksQuantity;
            this.SellPrice = sellPrice;
            this.Mats = mats;
               

        }

        public virtual double CraftPayback(double resourceReturn, double craftFee, double emptyJournal, double fullJournal)
        {
            double resourceCost = 0;

            foreach (Materials m in this.Mats)
            {
                switch (m.Type)
                {
                    case "Plank":
                        resourceCost += m.BuyPrice * PlanksQuantity - ((m.BuyPrice * PlanksQuantity) * resourceReturn / 100);
                        break;
                  


                }
            }
            double result = this.SellPrice + (fullJournal * 0.7) - (resourceCost + craftFee + emptyJournal);
            return result;
        }


    }
}
