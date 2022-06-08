using AlbionCrafter.Mats;


namespace AlbionCrafter.Warrior.Swords.SwordService
{
    internal class SwordCrafterService
    {


        public static void GeneralProfitCraft()
        {
            List<IBaseSwords> swordPool = new();
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

            foreach (IBaseSwords swords in swordPool)
            {
                Console.WriteLine($" \nYour profit is at least { swords.CraftPayback(resourceReturn, 2800, journalBuyPrice, journalSellPrice).ToString("f2") } silver per craft of {swords.Type}");
            }

            Console.WriteLine($" \n You should probably craft {orderedSwordPool[0].Type} for profit");
        }
        public static void SpecificProfitCraft()
        {
            Console.WriteLine("Type the buy price of an empty blacksmith's journal");
            double journalBuyPrice = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Type the sell price of a full blacksmith's journal");
            double journalSellPrice = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Type the buy price of the bar");
            double barBuyPrice = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Type the buy price of the leather");
            double leatherBuyPrice = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Type the return rate for materials");
            double returnRate = Convert.ToDouble(Console.ReadLine());

            bool swordCraftChoiceError = true;

            while (swordCraftChoiceError)
            {
                Console.WriteLine("The sword you wanna know the profit is one handed or two handed?");
                Console.WriteLine("1 - One handed\n2 - Two handed");
                int swordCraftChoice = Convert.ToInt32(Console.ReadLine());

                if (swordCraftChoice == 1)
                {
                    bool oneHandedSwordTypeError = true;
                    while (oneHandedSwordTypeError)
                    {
                        Console.WriteLine("The sword is clarent or broad? \n 1 - Clarent \n 2 - Broad");
                        int oneHandedSwordType = Convert.ToInt32(Console.ReadLine());

                        if (oneHandedSwordType == 1)
                        {
                            Console.WriteLine("Type the buy price of the Clarent artifact");
                            double artifactPrice = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Type the sell price of the Clarent sword");
                            Materials[] materials = new Materials[] { new Materials(leatherBuyPrice, "Leather"), new Materials(barBuyPrice, "Bar"), new Materials(artifactPrice, "Artifact") };
                            double result = new OneHanded(materials, (double)Convert.ToDouble(Console.ReadLine()), "Clarent").CraftPayback(returnRate, 2800, journalBuyPrice, journalSellPrice);
                            Console.WriteLine($"Your profit per craft is {result:F2}");
                            oneHandedSwordTypeError = false;

                        }
                        else if (oneHandedSwordType == 2)
                        {
                            Console.WriteLine("Type the sell price of Broadsword");
                            double sellPrice = Convert.ToDouble(Console.ReadLine());
                            Materials[] materials = new Materials[] { new Materials(leatherBuyPrice, "Leather"), new Materials(barBuyPrice, "Bar") };
                            double result = new OneHanded(materials, sellPrice).CraftPayback(returnRate, 2800, journalBuyPrice, journalSellPrice);
                            Console.WriteLine($"Your profit per craft is {result:F2}");
                            oneHandedSwordTypeError = false;
                        }
                        else
                        {
                            Console.WriteLine("Try a valid option.");
                            oneHandedSwordTypeError = true;
                        }
                    }
                }
                else if (swordCraftChoice == 2)
                {
                    bool swordChoiceError = true;
                    while (swordChoiceError)
                    {
                        Console.WriteLine("What is your sword? \n 1 - Dual \n 2 - Kingmaker \n 3 - Galatine \n 4 - Claymore \n 5 - Carving");
                        int swordType = Convert.ToInt32(Console.ReadLine());
                        switch (swordType)
                        {
                            case 1:
                            case 4:
                                Console.WriteLine("Type the sell price of the sword");
                                double sellPrice = Convert.ToDouble(Console.ReadLine());
                                Materials[] materials = new Materials[] { new Materials(leatherBuyPrice, "Leather"), new Materials(barBuyPrice, "Bar") };
                                double result = new TwoHanded(materials, sellPrice).CraftPayback(returnRate, 2800, journalBuyPrice, journalSellPrice);
                                Console.WriteLine($"Your profit per craft is {result:F2}");
                                swordChoiceError = false;
                                break;

                            case 2:
                            case 3:
                            case 5:
                                Console.WriteLine("Type the artifact buy price");
                                double artifactPrice = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Type the sell price of the sword");
                                double price = Convert.ToDouble(Console.ReadLine());
                                Materials[] mats = new Materials[] { new Materials(leatherBuyPrice, "Leather"), new Materials(barBuyPrice, "Bar"), new Materials(artifactPrice, "Artifact") }; ;
                                double res = new TwoHanded(mats, price).CraftPayback(returnRate, 2800, journalBuyPrice, journalSellPrice);
                                Console.WriteLine($"Your profit per craft is {res:F2}");
                                swordChoiceError = false;
                                break;

                            default:
                                Console.WriteLine("Try a valid option \n");
                                swordChoiceError = true;
                                break;
                        }
                    }
                    break;
                }
                break;
            }
        }
    }
}
