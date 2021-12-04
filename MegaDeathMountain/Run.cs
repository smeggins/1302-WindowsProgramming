using System;
using MegaDeathMountain;
using System.Threading.Tasks;

namespace MegaDeathMountain
{
    class Run
    {
        static async Task Main(string[] args)
        {
            Processor game = new Processor(new ConsoleKeyLogger(), new ConsoleLogger());
            await game.StartConsoleGame();
        }
    }
}
