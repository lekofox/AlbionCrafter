using AlbionCrafter.Mats;


namespace AlbionCrafter.Warrior.Swords.SwordService
{
    internal class GeneralSwordCrafterService
    {


        public static void Craft()
        {
            List<BaseSwords> swordPool = new();
            string[] typeCounter = new string[] { "Dual", "Kingmaker", "Galatine", "Broadsword", "Clarent", "Claymore", "Carving" };
            Console.WriteLine("Type the buy price of an empty blacksmith's journal");
            double journalBuyPrice = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Type the sell price of a full blacksmith's journal");
            double journalSellPrice = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Type the buy price of the bar");
            double barBuyPrice = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Type the buy price of the leather");
            double leatherBuyPrice = Convert.ToDouble(Console.ReadLine());
            foreach (string s in typeCounter)
            {
                Console.WriteLine($"Insert the sell price of {s}");
                double swordSellPrice = Convert.ToDouble(Console.ReadLine());

                if (s == "Carving" || s == "Kingmaker" || s == "Galatine")
                {
                    Console.WriteLine("Type the buy price of the artifact");
                    double artifactPrice = Convert.ToDouble(Console.ReadLine());
                    Materials[] materials = new Materials[] { new Materials(leatherBuyPrice, "Leather"), new Materials(barBuyPrice, "Bar"), new Materials(artifactPrice, "Artifact") };
                    swordPool.Add(new TwoHanded(materials, swordSellPrice, s));
                }
                else if (s == "Clarent")
                {
                    Console.WriteLine("Type the buy price of the artifact");
                    double artifactPrice = Convert.ToDouble(Console.ReadLine());
                    Materials[] materials = new Materials[] { new Materials(leatherBuyPrice, "Leather"), new Materials(barBuyPrice, "Bar"), new Materials(artifactPrice, "Artifact") };
                    swordPool.Add(new OneHanded(materials, swordSellPrice, s));
                }
                else
                {

                    if (s == "Claymore" || s == "Dual")
                    {
                        Materials[] materials = new Materials[] { new Materials(leatherBuyPrice, "Leather"), new Materials(barBuyPrice, "Bar") };
                        swordPool.Add(new TwoHanded(materials, swordSellPrice, s));
                    }
                    else if (s == "Broadsword")
                    {
                        Materials[] oneHandedMaterials = new Materials[] { new Materials(leatherBuyPrice, "Leather"), new Materials(barBuyPrice, "Bar") };
                        swordPool.Add(new OneHanded(oneHandedMaterials, swordSellPrice, s));
                    }

                }

            };
            Console.Write("Insert the percentage of the resource return rate: ");
            double resourceReturn = Convert.ToDouble(Console.ReadLine());

            var orderedSwordPool = swordPool.OrderByDescending(sword => sword.CraftPayback(resourceReturn, 2800, journalBuyPrice, journalSellPrice)).ToList();

            foreach (BaseSwords swords in swordPool)
            {
                Console.WriteLine($" \nYour profit is at least { swords.CraftPayback(resourceReturn, 2800, journalBuyPrice, journalSellPrice).ToString("f2") } silver per craft of {swords.Type}");
            }

            Console.WriteLine($" \n You should probably craft {orderedSwordPool[0].Type} for profit");
        }
    }
}
