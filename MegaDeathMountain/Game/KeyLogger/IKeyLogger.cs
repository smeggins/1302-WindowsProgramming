using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDeathMountain
{
    public interface IKeyLogger
    {
        public ConsoleKey Key { get; set; }
        public void UpdateKeyAsync(ConsoleKey key = ConsoleKey.F19);
        public void CheckForCriticalTasks();
        public void ClearKey()
        {
            Key = ConsoleKey.F24;
        }
    }
}
