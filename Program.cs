
using AlbionCrafter.Warrior.Swords.SwordService;

Console.WriteLine("Select the weapon tree (number): ");
Console.WriteLine("1 - Warrior");
Console.WriteLine("2 - Hunter");
int craftTree = Convert.ToInt32(Console.ReadLine());


if (craftTree == 1)
{
    Console.WriteLine("Select the weapon to craft (number): ");
    Console.WriteLine("1 - Swords");

    int weaponChoice = Convert.ToInt32(Console.ReadLine());
    switch (weaponChoice)
    {
        case 1:
            bool craftChoiceError = true;
            while (craftChoiceError)
            {
                Console.WriteLine("Do you want to know the specific profit for a weapon or the most profitable weapon?");
                Console.WriteLine(" 1 - Specific \n 2 - Most profitable");
                int craftChoice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (craftChoice)
                {
                    case 2:
                        GeneralSwordCrafterService.Craft();
                        craftChoiceError = false;
                        break;

                    case 1:
                        SpecificSwordService.Craft();
                        craftChoiceError = false;
                        break;

                    default:
                        Console.WriteLine("Try a valid option");
                        craftChoiceError = true;
                        break;
                }
            }
            break;

        default:
            Console.WriteLine("Try a valid option");
            break;
    }
}
else
{
    Console.WriteLine("Try a valid option");
}
