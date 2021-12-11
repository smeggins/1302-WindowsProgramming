using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDeathMountain
{
    public sealed class NPCNames
    {
        List<string> Names;
        Random RNG = new Random();
        private static readonly Lazy<NPCNames> instance =
            new Lazy<NPCNames>(() => new NPCNames());

        private NPCNames()
        {
            Names = new List<string>()
            {
                "Jim Jam",
                "Indiana Jones",
                "Anna Banana",
                "Nicholas Tesla",
                "Larry Laugher",
                "Civilian"
            };
        }

        public static NPCNames Instance
        {
            get
            {
                return instance.Value;
            }
        }

        public string getRandomName() { return Names[RNG.Next(0, Names.Count)]; }
    }
}
