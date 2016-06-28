using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace VirtualPet
{
    class Program
    {
        //static VirtualPet myNewPet = new VirtualPet();
        static int Menu()
        {
            string menuChoiceString = "0";
            while (menuChoiceString != "1")

            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\n\nMAIN MENU");
                Console.ResetColor();
                Console.WriteLine("                                           \"\",_o");
                Console.WriteLine("1. Show Pet stats                !       ( (  _)");
                Console.WriteLine("2. Feed your pet                 `\\ ,,,,_'),)=~ ");
                Console.WriteLine("3. Give water to your pet         (          )  ");
                Console.WriteLine("4. Play with your pet              ,   ,,,,  ,  ");
                Console.WriteLine("5. Change the name of your pet     ) ,)   < (   ");
                Console.WriteLine("6. Exit                           < <      \",\\  ");
                Console.WriteLine("                                   \",)      \"_) ");
                Console.WriteLine("Choose a number from the menu\n");
                menuChoiceString = Console.ReadLine();

                // Doesn't let user enter a char or string.
                if (menuChoiceString == "1" || menuChoiceString == "2" || menuChoiceString == "3"
                    || menuChoiceString == "4" || menuChoiceString == "5" || menuChoiceString == "6")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nPlease choose a number from the menu. (1, 2, 3, 4, 5, 6)");
                }
            }
            int menuChoice = Convert.ToInt32(menuChoiceString);
            return menuChoice;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME AND THANK YOU FOR ADOPTING A PUPPY!");
            Console.WriteLine("\nPlease enter the name of your new puppy:\n");
            VirtualPet myPet = new VirtualPet(Console.ReadLine());
            myPet.PetImage();
            Console.WriteLine();
            Thread.Sleep(500);
            Console.WriteLine("\n{0} is so happy to be your new pet!", myPet.GetName());
            Console.WriteLine("\nEnjoy your time with {0} :)", myPet.GetName());
            myPet.TimeGoesBy();
            int choice = 1;
            while (choice != 6)
            {
                // Checks levels before looping back to Menu to make sure pet is well and alive.
                if (myPet.BoredomLevel > 100)
                {
                    Console.WriteLine("\n{0}'s boredom level went over 100. \n\n{0} was too sad and left. :(", myPet.GetName());
                    break;
                }
                if (myPet.PetBadFoodLevels())
                {
                    Console.WriteLine("{0}'s Feeding levels were bad. \nAnimal Services has taken {0} away. :(", myPet.GetName());
                    break;
                }
                if (myPet.PetTooMuchWater())
                {
                    Console.WriteLine("\n{0} was dehydrated. \n\nAnimal Services has taken {0} away. :(", myPet.GetName());
                    break;
                }

                // Menu will show after checking for healthy stats
                choice = Menu();
                if (choice == 1)
                {
                    myPet.Stats();
                }
                else if (choice == 2)
                {
                    myPet.FeedPet();
                }
                else if (choice == 3)
                {
                    myPet.WaterPet();
                }
                else if (choice == 4)
                {
                    myPet.PlayWithPet();
                }
                else if (choice == 5)
                {
                    myPet.ChangeName();
                }
                else if (choice == 6)
                {
                    Console.WriteLine("\nThank you for taking care of {0}.\n", myPet.GetName());
                    Console.WriteLine("Press any key to exit");
                }
                else
                {
                    Console.WriteLine("\nPlease enter a number between 1 and 4\n");
                }
            }
            Console.ReadKey();
        }
    }
}
