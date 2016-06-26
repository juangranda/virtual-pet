using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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
            BoredomLevel = 62;
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

        public void TimeGoesBy()
        {
            Console.Write("\n. ");
            Thread.Sleep(400);
            Console.Write(". ");
            Thread.Sleep(400);
            Console.Write(". ");
            Thread.Sleep(400);
            Console.Write(". ");
            Thread.Sleep(400);
            Console.Write(". \n");
            Thread.Sleep(400);
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
                ThirstLevel = 0;
                Console.WriteLine("\n - {0}'s thirst Level is {1}/100", name, ThirstLevel);
                ThirstLevel += Tick();
                Console.WriteLine("\n - {0}'s hunger level is {1}/100", name, HungerLevel);
                Console.WriteLine("\n - {0}'s boredom level is {1}/100", name, BoredomLevel);
            }
            else
            {
                HungerLevel += Tick();
                ThirstLevel += Tick();
                BoredomLevel += Tick();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("\n{0}'s LEVELS:", name);
                Console.ResetColor();
                Console.WriteLine("\n - Hunger: {0}/100", HungerLevel);
                Console.WriteLine("\n - Thirst: {0}/100", ThirstLevel);
                Console.WriteLine("\n - Boredom: {0}/100", BoredomLevel);
            }
            petWaste();
        }

        static int overFeedNumber;
        public void FeedPet() // Feeds Pet
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            //Console.WriteLine("(treat -----------snack-------------medium meal-----------full meal)\n");
            Console.WriteLine(" ..... <-----------HEALTHY RANGE-----------> ..................... \n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  10    20    30    40    50     60     70     80     90     100\n");
            Console.ResetColor();
            Console.WriteLine("{0}'s hunger level is {1}", name, HungerLevel);
            Console.WriteLine("\nHow much food do you want to feed {0}?\n", name);
            HungerLevel -= Convert.ToInt32(Console.ReadLine());
            ThirstLevel += Tick();
            Console.Write("\n. ");
            Thread.Sleep(400);
            Console.Write(". ");
            Thread.Sleep(400);
            Console.Write(". \n");
            Thread.Sleep(400);
            if (HungerLevel < 0)
            {
                overFeedNumber = ((HungerLevel) * -1);
                Console.WriteLine("\nYou have overfed {0} by {1}", name, overFeedNumber);
                Console.WriteLine("\n{0} is extremelly full and doesn't like to be overfed :(", name);
            }
            else
            {
                Console.WriteLine("\n{0} has been fed\n", name);
                Console.WriteLine("{0}'s hunger level is {1}/100\n", name, HungerLevel);
            }
            Thread.Sleep(1000);
            petWaste();
            Thread.Sleep(1500);
        }

        public void petWaste() // Pet waste when full of food or water
        {
            if ((HungerLevel >= 1 && HungerLevel <= 6) || (HungerLevel >= 10 && 
                HungerLevel <= 22) || (HungerLevel >= 40 && HungerLevel <= 50))
            {
                HungerLevel += (Tick() * 4);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n *** {0} had to take care of some personal business ***", name);
                Console.WriteLine("\n             New hunger level is {0}/100", HungerLevel);
                Console.ResetColor();
            }
            if ((ThirstLevel >= 3 && ThirstLevel <= 12) || (ThirstLevel >= 15 
                && ThirstLevel <= 28) || (ThirstLevel >= 42 && ThirstLevel <= 50))
            {
                ThirstLevel += (Tick() * 3);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n *** {0} had to take care of some personal business ***", name);
                Console.WriteLine("\n             New thirst level is {0}/100", ThirstLevel);
                Console.ResetColor();
            }
        }

        static int overWater;
        public void WaterPet() // Gives pet water
        {
            if (ThirstLevel == 0)
            {
                Console.WriteLine("{0} is not thirsty and doesn't want to drink water", name);
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("  10    20    30    40    50     60     70     80     90     100\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(" ...  <---------HEALTHY RANGE-------->  ......................... ");
                Console.ResetColor();
                Console.WriteLine("\n{0}'s thirst level is {1}", name, ThirstLevel);
                Console.WriteLine("\nHow much water do you want to give {0}?\n", name);
                ThirstLevel -= Convert.ToInt32(Console.ReadLine());
                Console.Write("\n. ");
                Thread.Sleep(400);
                Console.Write(". ");
                Thread.Sleep(400);
                Console.Write(". ");
                Thread.Sleep(400);
                if (ThirstLevel < 0)
                {
                    overWater = ((ThirstLevel) * -1);
                    Console.WriteLine("\nYou have given {0} too much water. \nYou went {1} past {0}'s water intake", name, overWater);
                }
                else
                {
                    Console.WriteLine("{0}'s new thirst level is {1}/100\n", name, ThirstLevel);
                }
                Thread.Sleep(1000);
            }
            petWaste();
            Thread.Sleep(1500);
        }

        /// Options for pet activities. Used inside <see cref="PlayWithPet"/>
        private int PlayMenu() 
        {
            Console.WriteLine("\nWhat do you want to do with {0}?\n", name);
            Console.WriteLine("     1. Go for a walk");
            Console.WriteLine("     2. Play Catch");
            Console.WriteLine("     3. Take {0} to the park", name);
            Console.WriteLine("     4. Go back to the main menu");
            int playOption = Convert.ToInt32(Console.ReadLine());
            return playOption;
        }

        private void ManThrowingBall() // Time based graphic of playing catch
        {
            Console.WriteLine("\n   o ");
            Console.WriteLine(" '- \\-- ");
            Console.Write("   || ");
            Thread.Sleep(400);
            Console.Write("    . ");
            Thread.Sleep(400);
            Console.Write(". ");
            Thread.Sleep(400);
            Console.Write(". ");
            Thread.Sleep(400);
            Console.Write(". ");
            Thread.Sleep(400);
            Console.Write(". \n");
            Thread.Sleep(400);
        } 

        public void PlayWithPet() // Play with pet and reduce boredom and other levels
        {
            int playChoice = 0;
            while (playChoice != 4)
            {
                playChoice = PlayMenu();
                if (playChoice == 1)
                {
                    BoredomLevel = BoredomLevel / 2;
                    ThirstLevel += Tick() * 2;
                    HungerLevel += Tick();
                    TimeGoesBy();
                    Console.WriteLine("\n{0} loved going for a walk!", name);
                    Thread.Sleep(1200);
                    Console.WriteLine("\nNew boredom level is {0}/100\n", BoredomLevel);
                    Thread.Sleep(1200);
                    Console.WriteLine("New thirst level is {0}/100\n", ThirstLevel);
                    Thread.Sleep(1200);
                    Console.WriteLine("New hunger level is {0}/100\n", HungerLevel);
                    Thread.Sleep(1200);
                    break;
                }
                else if (playChoice == 2)
                {
                    BoredomLevel = BoredomLevel / 3;
                    ThirstLevel += Tick() * 3;
                    HungerLevel += Tick();
                    ManThrowingBall();
                    Console.WriteLine("\n{0} loved playing catch!", name);
                    Thread.Sleep(1200);
                    Console.WriteLine("\nNew boredom level is {0}/100\n", BoredomLevel);
                    Thread.Sleep(1200);
                    Console.WriteLine("New thirst level is {0}/100\n", ThirstLevel);
                    Thread.Sleep(1200);
                    Console.WriteLine("New hunger level is {0}/100\n", HungerLevel);
                    Thread.Sleep(1200);
                    break;
                }
                else if (playChoice == 3)
                {
                    BoredomLevel = BoredomLevel / 2;
                    ThirstLevel += Tick() * 2;
                    HungerLevel += Tick();
                    TimeGoesBy();
                    Console.WriteLine("\n{0} loved the park!", name);
                    Thread.Sleep(1200);
                    Console.WriteLine("\nNew boredom level is {0}/100\n", BoredomLevel);
                    Console.WriteLine("New thirst level is {0}/100\n", ThirstLevel);
                    Thread.Sleep(1200);
                    Console.WriteLine("New hunger level is {0}/100\n", HungerLevel);
                    Thread.Sleep(1200);
                    break;
                }
                else if (!(playChoice >= 1 && playChoice <= 4))
                {
                    Console.WriteLine("\nPlease choose a number from the menu (1, 2, 3, 4)");
                }
            }
            petWaste();
        } 
    }
}
