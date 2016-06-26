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
        static int Menu()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\nMAIN MENU");
            Console.ResetColor();
            Console.WriteLine("\n1. Show Pet stats");
            Console.WriteLine("2. Feed your pet");
            Console.WriteLine("3. Give water to your pet");
            Console.WriteLine("4. Play with your pet");
            Console.WriteLine("5. Exit");
            Console.WriteLine("\nChoose a number from the menu");
            int menuChoice = Convert.ToInt32(Console.ReadLine());
            return menuChoice;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME AND THANK YOU FOR ADOPTING A PUPPY!");
            Console.WriteLine("\nPlease enter the name of your new puppy:\n");
            VirtualPet myPet = new VirtualPet(Console.ReadLine());
            Console.WriteLine("\n{0} is so happy to be your new pet!", myPet.GetName());
            Console.WriteLine("\nEnjoy your time with {0} :)", myPet.GetName());
            myPet.TimeGoesBy();

            int choice = 1;
            while (choice != 5)
            {
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
