using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaDeathMountain;
using System.Windows.Forms;

namespace MegaDeathMountainShared
{
    public static class KeyEvents
    {
        public static bool EnterCheck()
        {
            return Processor.keyLogger.Key == ConsoleKey.Enter;
        }

        public static void WaitForEnter()
        {
            while (!KeyEvents.EnterCheck())
            {

            }
            Processor.keyLogger.ClearKey();
        }

        public static void ExitGameCheck(ConsoleKey key)
        {
            if (key == ConsoleKey.Escape)
            {
                Application.Exit();
            }
        }

        public static void MovePlayer(ConsoleKey key)
        {
            // TODO Implement
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    break;
                case ConsoleKey.DownArrow:
                    break;
                case ConsoleKey.LeftArrow:
                    break;
                case ConsoleKey.RightArrow:
                    break;
            }
            Processor.keyLogger.ClearKey();
        }
    }
}
