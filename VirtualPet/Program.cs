using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("\n1. Feed your pet");
            Console.WriteLine("2. Give water to your pet");
            Console.WriteLine("3. Play with your pet");
            Console.WriteLine("4. Show Pet stats");
            Console.WriteLine("5. Exit");

            Console.WriteLine("\nChoose a number from the menu");
            int menuChoice = Convert.ToInt32(Console.ReadLine());
            return menuChoice;
        }
        static void Main(string[] args)
        {
            VirtualPet myPet = new VirtualPet();
            int choice = 1;
            while (choice != 5)
            {
                choice = Menu();
                if (choice == 1)
                {
                    myPet.FeedPet2();
                }
                else if (choice == 4)
                {
                    myPet.Stats();
                }
                else if (choice == 5)
                {
                    Console.WriteLine("\nThank you for taking care of your pet.\n");
                    Console.WriteLine("\nPress any key to exit");
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
