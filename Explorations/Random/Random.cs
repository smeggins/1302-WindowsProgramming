using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Explorations
{
    class RandomExamples
    {
        public static void CryptoRandomizer()
        {
            var rand = RandomNumberGenerator.Create();
            byte[] bytes = new byte[32];
            rand.GetBytes(bytes);

            int i = BitConverter.ToInt32(bytes, 0);
        }

        public static void NormalRandomizer()
        {
            // uses system time as seed
            Random rand = new Random();

            // uses 2 as random seed
            Random rand2 = new Random(2);

            var randnum = rand.Next(10);
        }

        public static void GUIDTheBetterSeedOption()
        {
            // makes a unique hexadecimal number.
            // thats a unique 128 bit integer
            // can be used across computer and apps as unique identifier
            var guid = Guid.NewGuid();

            // every object in .net has a hashcode method
            var hashCode = guid.GetHashCode();

        }
    }
}
