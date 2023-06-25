using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika2023
{
    static class Randomizer
    {
        private static Random rand = new Random();
        public static int Rand(int min, int max)
        {
            lock (rand)
            {
                return rand.Next(min, max + 1);
            }
        }
    }
}
