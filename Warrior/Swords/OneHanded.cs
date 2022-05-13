using AlbionCrafter.Mats;
 

namespace AlbionCrafter.Warrior
{
    public partial class OneHanded : BaseSwords
    {
        public OneHanded(Materials[] mats, double sellPrice, string Type, int leatherQuantity = 8, int barQuantity = 16) : base(leatherQuantity, barQuantity, mats)

        {
            this.LeatherQuantity = leatherQuantity;
            this.BarQuantity = barQuantity;
            this.SellPrice = sellPrice;
            this.Type = Type;
            this.Mats = mats;
        }
            public OneHanded(Materials[] mats, double sellPrice,  int leatherQuantity = 8, int barQuantity = 16) : base(leatherQuantity, barQuantity, mats)

        {
            this.LeatherQuantity = leatherQuantity;
            this.BarQuantity = barQuantity;
            this.SellPrice = sellPrice;
           
            this.Mats = mats;
        }


       
        public override double CraftPayback(double resourceReturn, double craftFee, double emptyJournal, double fullJournal)
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
            double result = this.SellPrice + (fullJournal * 0.55) - (resourceCost + craftFee + emptyJournal);
       
            return result;
        }
    }
}
