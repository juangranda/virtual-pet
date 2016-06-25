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
        private int hungerLevel;
        public int HungerLevel
        {
            get
            {
                return hungerLevel;
            }
            set
            {
                hungerLevel = value;
            }
        }               
        public int ThirstLevel { get; set; }
        public int BoredomLevel { get; set; }

        public VirtualPet()
        {
            HungerLevel = Food();
            ThirstLevel = 0;
            BoredomLevel = 0;
        }

        public int Tick()
        {
            int tick = random.Next(1, 8);
            return tick;
        }

        public int Food()
        {
            int _food = 50;
            return _food;
        }

        public void Stats()
        {
            if (HungerLevel < 0)
            {
                Console.WriteLine("\n - Your pet Hunger Level is {0}/100", HungerLevel);
                HungerLevel += Tick();
            }
            else
            {
                HungerLevel += Tick();
                Console.WriteLine("\n - Your pet Hunger Level is {0}/100", HungerLevel);
                Console.WriteLine("\n - Your pet Thirst Level is {0}/100", ThirstLevel);
                Console.WriteLine("\n - Your pet Boredom Level is {0}/100", BoredomLevel);
            }
        }

        static int overFeedNumber;
        public void FeedPet2()
        {
            Console.WriteLine();
            Console.WriteLine("How much food do you want to feed your dog?\n");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("(treat -----------snack-------------medium meal-----------full meal)\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  10    20    30    40    50     60     70     80     90     100\n");
            Console.ResetColor();
            HungerLevel -= Convert.ToInt32(Console.ReadLine());
            if (HungerLevel < 0)
            {
                overFeedNumber = ((HungerLevel) * -1);
                Console.WriteLine("You have overfed your pet by {0}", overFeedNumber);
            }
            else
            {
                Console.WriteLine("\nYour pet has been fed\n");
                Console.WriteLine("Your pet's Hunger Level is {0}/100\n", HungerLevel);
            }
        }
    }
}
