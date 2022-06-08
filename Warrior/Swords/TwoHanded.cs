﻿using AlbionCrafter.Mats;

namespace AlbionCrafter.Warrior
{
    public  class TwoHanded : IBaseSwords
        
    {
        public int LeatherQuantity { get; set; }
        public int BarQuantity { get; set; }
        public double SellPrice { get; set; }
        public string Type { get ; set; }
        public Materials[] Mats { get; set; }

        public TwoHanded(Materials[] mats , double sellPrice, string Type, int leatherQuantity = 12, int barQuantity = 20)

        {
            this.LeatherQuantity = leatherQuantity;
            this.BarQuantity = barQuantity; 
            this.SellPrice = sellPrice;
            this.Type = Type;
            this.Mats = mats;
        } 
        public TwoHanded(Materials[] mats , double sellPrice, int leatherQuantity = 12, int barQuantity = 20)

        {
            this.LeatherQuantity = leatherQuantity;
            this.BarQuantity = barQuantity; 
            this.SellPrice = sellPrice;
            this.Mats = mats;
        }
        public double CraftPayback(double resourceReturn, double craftFee, double emptyJournal, double fullJournal)
        {

            double resourceCost = 0;

            foreach (Materials m in this.Mats)
            {
                switch (m.Type)
                {
                    case "Leather":
                        resourceCost += m.BuyPrice * LeatherQuantity - ((m.BuyPrice * LeatherQuantity) * (resourceReturn / 100));
                        break;
                    case "Bar":
                        resourceCost += m.BuyPrice * BarQuantity - ((m.BuyPrice * BarQuantity) * (resourceReturn / 100));
                        break;

                    case "Artifact":
                        resourceCost += m.BuyPrice;
                        break;


                }
            }
            double result = this.SellPrice + (fullJournal * 0.7) - (resourceCost + craftFee + emptyJournal);
            return result;
        }
    }

}
