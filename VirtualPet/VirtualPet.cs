using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPet
{
    class VirtualPet
    {
        public int HungerLevel { get; set; }
        public int ThirstLevel { get; set; }
        public int BoredomLevel { get; set; }

        public VirtualPet()
        {
            HungerLevel = 5;
            ThirstLevel = 5;
            BoredomLevel = 5;
        }

       
    }
}
