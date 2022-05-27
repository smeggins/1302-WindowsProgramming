using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorations
{
    /// <summary>
    /// Used in the Threading class in SharedAndLocalState()
    /// </summary>
    class ThreadSafe
    {
        public static bool _done;
        static readonly object _locker = new object();

        public static void Go()
        {
            // this effectivle only allows 1 thread through it at a time.
            // this means if a thread is already inside of lock
            // the new thread will wait until it finishes before it continues into lock it'self
            lock(_locker)
            {
                if (!_done)
                {
                    _done = true;
                    Console.WriteLine("done with the Threadsafe Go");
                }
            }
        }
    }
}
