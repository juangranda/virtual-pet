using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPet
{
    class VirtualPet
    {
        Random random = new Random();
        private string name { get; set; }
        public int HungerLevel { get; set; }
        public int ThirstLevel { get; set; }
        public int BoredomLevel { get; set; }

        public VirtualPet(string Name)
        {
            this.name = Name;
            HungerLevel = 50;
            ThirstLevel = 0;
            BoredomLevel = 0;
        }

        public void SetName(string Name)
        {
            this.name = Name;
        }
        public string GetName()
        {
            return name;
        }

        public int Tick() //random number generator used to increase levels of Hunger, Thirst, Boredom.
        {
            int tick = random.Next(1, 8);
            return tick;
        }

        public void Stats() //Shows pet stats. Increments numbers every time using Tick()
        {
            if (HungerLevel < 0)
            {
                Console.WriteLine("\n - {0}'s Hunger Level is {1}/100", name, HungerLevel);
                HungerLevel += Tick();
            }
            else
            {
                HungerLevel += Tick();
                Console.WriteLine("\n - {0}'s hunger level is {1}/100", name, HungerLevel);
                Console.WriteLine("\n - {0}'s thirst level is {1}/100", name, ThirstLevel);
                Console.WriteLine("\n - {0}'s boredom level is {1}/100", name, BoredomLevel);
            }
        }

        static int overFeedNumber;
        public void FeedPet() //Feeds Pet
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("(treat -----------snack-------------medium meal-----------full meal)\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  10    20    30    40    50     60     70     80     90     100\n");
            Console.ResetColor();
            Console.WriteLine("\nHow much food do you want to feed {0}?\n", name);
            HungerLevel -= Convert.ToInt32(Console.ReadLine());
            if (HungerLevel < 0)
            {
                overFeedNumber = ((HungerLevel) * -1);
                Console.WriteLine("You have overfed {0} by {1}", name, overFeedNumber);
            }
            else
            {
                Console.WriteLine("\n{0} has been fed\n", name);
                Console.WriteLine("{0}'s hunger level is {1}/100\n", name, HungerLevel);
            }
        }
    }
}
