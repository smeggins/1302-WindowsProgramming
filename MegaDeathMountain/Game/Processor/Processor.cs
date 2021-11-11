using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDeathMountain
{
    class Processor
    {
        Player Player;
        List<Enemy> Enemies;

        public Processor(Player player, List<Enemy> enemies)
        {
            Player = player;
            Enemies = enemies;
        }
    }
}
