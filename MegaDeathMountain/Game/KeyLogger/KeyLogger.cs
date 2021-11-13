using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDeathMountain
{
    public static class KeyLogger
    {
        public static ConsoleKey Key;

        public static void UpdateKeyAsync()
        {
            Task UpdateKeyTask = Task.Run(() =>
            {
                while (true)
                {
                    if (Console.KeyAvailable == true)
                    {
                        KeyLogger.Key = Console.ReadKey(true).Key;
                        CheckForCriticalTasks();
                    }
                }
            });
        }

        public static void CheckForCriticalTasks()
        {
            ExitOnESCAsync();
        }

        private static void ExitOnESCAsync()
        {
            if (KeyLogger.Key == ConsoleKey.Escape)
            {
                Processor.ExitGame();
            }
        }
    }
}
