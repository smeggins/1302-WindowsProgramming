using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MegaDeathMountain
{
    public class ConsoleKeyLogger : IKeyLogger
    {
        private ConsoleKey key;
        public ConsoleKey Key {  get { return key; } set { key = value; }  }

        public virtual void UpdateKeyAsync(ConsoleKey key = ConsoleKey.F19)
        {
            Task UpdateKeyTask = Task.Run(() =>
            {
                while (true)
                {
                    if (Console.KeyAvailable == true)
                    {
                        this.Key = Console.ReadKey(true).Key;
                        CheckForCriticalTasks();
                    }
                }
            });
        }

        public virtual void CheckForCriticalTasks()
        {
            this.ExitOnESCAsync();
        }

        private void ExitOnESCAsync()
        {
            if (this.Key == ConsoleKey.Escape)
            {
                Processor.ExitGame();
            }
        }
    }
}
