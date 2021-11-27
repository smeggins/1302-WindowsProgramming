using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDeathMountain
{
    public sealed class Randomizer
    {
        Random RNG;

        private static readonly Lazy<Randomizer> instance =
            new Lazy<Randomizer>(() => new Randomizer());

        private Randomizer()
        {
            RNG = new Random();
        }

        public static Randomizer Instance
        {
            get
            {
                return instance.Value;
            }
        }

        public int RandomNumber(int min, int max) { return RNG.Next(min, max+1); }
        public int RandomNumber(int max) { return RNG.Next(max+1); }
    }
}
