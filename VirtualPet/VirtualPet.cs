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
            ThirstLevel = 50;
            BoredomLevel = 50;
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
                HungerLevel = 0;
                Console.WriteLine("\n - {0}'s hunger level is {1}/100", name, HungerLevel);
                HungerLevel += Tick();
                Console.WriteLine("\n - {0}'s thirst level is {1}/100", name, ThirstLevel);
                Console.WriteLine("\n - {0}'s boredom level is {1}/100", name, BoredomLevel);
            }
            else if (ThirstLevel < 0)
            {
                Console.WriteLine("\n - {0}'s thirst Level is {1}/100", name, ThirstLevel);
                ThirstLevel += Tick();
            }
            else
            {
                HungerLevel += Tick();
                ThirstLevel += Tick();
                Console.WriteLine("\n - {0}'s hunger level is {1}/100", name, HungerLevel);
                Console.WriteLine("\n - {0}'s thirst level is {1}/100", name, ThirstLevel);
                Console.WriteLine("\n - {0}'s boredom level is {1}/100", name, BoredomLevel);
            }
            petWaste();
        }

        static int overFeedNumber;
        public void FeedPet() // Feeds Pet
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("(treat -----------snack-------------medium meal-----------full meal)\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  10    20    30    40    50     60     70     80     90     100\n");
            Console.ResetColor();
            Console.WriteLine("{0}'s hunger level is {1}", name, HungerLevel);
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
            petWaste();
        }

        public void petWaste() // Pet waste when full or extra full
        {
            if ((HungerLevel >= 25 && HungerLevel <= 30) || (HungerLevel >= 5 && HungerLevel <= 10))
            {
                HungerLevel += (Tick() * 4);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n *** {0} had to take care of some personal business ***", name);
                Console.WriteLine("\n             New hunger level is {0}/100", HungerLevel);
                Console.ResetColor();
            }
            if ((ThirstLevel >= 25 && ThirstLevel <= 38) || (ThirstLevel >= 5 && ThirstLevel <= 12))
            {
                ThirstLevel += (Tick() * 3);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n *** {0} had to take care of some personal business ***", name);
                Console.WriteLine("\n             New thirst level is {0}/100", ThirstLevel);
                Console.ResetColor();
            }
        }

        static int overWater;
        public void WaterPet()// Gives pet water
        {
            if (ThirstLevel == 0)
            {
                Console.WriteLine("{0} is not thirsty and doesn't want to drink water", name);
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("-----------------------------------------------------------------");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("  10    20    30    40    50     60     70     80     90     100\n");
                Console.ResetColor();
                Console.WriteLine("\nHow much water do you want to give {0}?\n", name);
                ThirstLevel -= Convert.ToInt32(Console.ReadLine());
                if (ThirstLevel < 0)
                {
                    overWater = ((ThirstLevel) * -1);
                    Console.WriteLine("You have given {0} too much water. You went {1} past {0}'s water intake", name, overWater);
                }
                else
                {
                    Console.WriteLine("{0}'s new thirst level is {1}/100\n", name, ThirstLevel);
                }
            }

        }
    }
}
