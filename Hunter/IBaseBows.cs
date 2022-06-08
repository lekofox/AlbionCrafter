using AlbionCrafter.Mats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionCrafter.Hunter
{
    public interface IBaseBows
    {
         int PlanksQuantity { get; set; }
         double SellPrice { get; set; }
         string Type{ get; set; }
         Materials[] Mats { get; set; }


        public double CraftPayback(double resourceReturn, double craftFee, double emptyJournal, double fullJournal)
        {
            {

                double resourceCost = 0;

                foreach (Materials m in this.Mats)
                {
                    switch (m.Type)
                    {
                        case "Plank":
                            resourceCost += m.BuyPrice * PlanksQuantity - (m.BuyPrice * PlanksQuantity * (resourceReturn / 100));
                            break;
                      
                        case "Artifact":
                            resourceCost += m.BuyPrice;
                            break;


                    }
                }
                double result = SellPrice + (fullJournal * 0.7) - (resourceCost + craftFee + emptyJournal);
                return result;
            }
        }
    
    };

}
