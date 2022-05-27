using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MegaDeathMountain;

namespace MegaDeathMountainShared
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static async Task Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Processor GameProcessor = new Processor(new FormsKeyLogger(), new WriteLogger());
            

            Game GameCanvas = new Game();
            GameController Game = new GameController(GameCanvas);

            Game.StartFormGame(GameCanvas, GameProcessor);
            Application.Run(GameCanvas);
        }


    }
}
