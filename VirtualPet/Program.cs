using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPet
{
    class Program
    {
        static int showMenu()
        {
            Console.WriteLine("3. MAIN MENU");
            Console.WriteLine("\n1. Feed your pet");
            Console.WriteLine("2. Give water to your pet");
            Console.WriteLine("3. Play with your pet");
            Console.WriteLine("4. Exit");

            Console.WriteLine("\nChoose a number from the menu");
            int menuChoice = Convert.ToInt32(Console.ReadLine());
            return menuChoice;
        }
        static void FeedPet()
        {
            Console.WriteLine("Your pet has been fed\n");

        }
        static void Main(string[] args)
        {
            int choice = 0;
            while (choice != 4)
            {
                choice = showMenu();
                if (choice == 1)
                {
                    Console.WriteLine();
                    FeedPet();
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
