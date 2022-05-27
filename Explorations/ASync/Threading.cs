using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Explorations
{
    /// <summary>
    /// Thread is a low level tool for creating concurrency
    /// When  you create a thread it queries the OS for an availible thread
    /// (unlike task which pulls from a pool of threads .net generates on startup)
    /// 
    /// NOTE: threads don't throw exceptions
    /// </summary>
    public class Threading
    {
        private static bool _done = false;
        public void ThreadBasics()
        {
            // kick off a thread run with Printe 1302
            Thread t = new Thread(PrintHashTag); // assigned 1302 method

            t.Start(); // starts the thread

            var isAlive = t.IsAlive;// True until the thread ends

            //Thread.CurrentThread.ThreadState returns the threads current state when asked
            Console.Write("Current Thread State before sleep: " + Thread.CurrentThread.ThreadState);

            //Simultaniously do something else here
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("*");
                Console.Write(Thread.CurrentThread.ManagedThreadId);// managed thread id gives you the thread id given to it by .net
            }
        }

        public void ThreadJoin()
        {
            // kick off a thread run with Printe 1302
            Thread t = new Thread(PrintHashTag); // assigned 1302 method

            t.Start(); // starts the thread

            var isAlive = t.IsAlive;// True until the thread ends

            Console.WriteLine($"wait for the other thread to finish {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"BEFORE t.Join(). Thread is Alive:  {t.IsAlive}");
            
            t.Join(); // Forces the rest of the program to wait until threat t finishes. 
            
            Console.WriteLine($"AFTER t.Join(). Thread is has eneded. Is Alive:  {t.IsAlive}");
            //Simultaniously do something else here
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("*");
                Console.Write(Thread.CurrentThread.ManagedThreadId);// managed thread id gives you the thread id given to it by .net
            }
        }

        public void ThreadSleep()
        {
            Thread t = new Thread(PrintHashTag); 

            t.Start(); 

            var isAlive = t.IsAlive;

            
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("*");
                //Pauses your thread for X milliseconds then resumes
                // can also be described as "thread is blocked"
                Thread.Sleep(1000);
                Console.Write(Thread.CurrentThread.ManagedThreadId);
            }
        }

        public void ThreadYield()
        {
            Thread t = new Thread(PrintHashTag);

            t.Start();

            var isAlive = t.IsAlive;

            // The below options indicate to the OS that if it needs the resources being
            // used by this thread, voluntarily relinquish its resources to the OS
            Thread.Yield(); // this thread volunarily relinquishes its time slice to the os
            Thread.Sleep(0); // Does the exact same thing as Thread.Yield()
            // Thread.Join() also does this when it completes the thread. returning its
            // alloted resources back to the OS


            for (int i = 0; i < 1000; i++)
            {
                Console.Write("*");
                Console.Write(Thread.CurrentThread.ManagedThreadId);
            }
        }

        public void PrintHashTag()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("#");
                Console.Write(Thread.CurrentThread.ManagedThreadId);
            }
        }

        public void SharedAndLocalState()
        {
            // CLR = COMMON LANGUAGE RUNTIME assings each thread its on memory stack
            new Thread(Go).Start();//secondary thread
            Go(); // main thread

            bool done = false;
            // when a method is assigned to a new thread it essentially creates a Threadstart
            // we are using lambda to create our own threadstart method. we then assign it to 
            // a new thread and we start it.
            ThreadStart act = () =>
            {
                if (!done)
                {
                    done = true;
                    Console.WriteLine("Done in Lambda");
                }
            };
            new Thread(act).Start();// starts thread 
            act(); // starts as if it was a method

            // assigns a method from a class to a thread
            var threadTest = new ThreadTest();
            new Thread(threadTest.Go).Start();
            threadTest.Go();

            //Threadsafe Version
            new Thread(ThreadSafe.Go).Start();
            ThreadSafe.Go();
        }
        public static void Go()
        {
            if (!_done)
            {
                _done = true;

                int a = 1;
                for (int i = 0; i < 5; i++)
                {
                    Console.Write("?");
                    a = (a + i) * i;
                }
                Console.WriteLine("Done in GO()");
            }
        }

        public static void Test()
        {
            Threading Threading = new Threading();
            //Threading.ThreadJoin();
            //Threading.ThreadSleep();
            //Threading.ThreadYield();
            Threading.SharedAndLocalState();
        }
    }

    public class ThreadTest
    {
        public bool _done;

        public void Go()
        {
            if (!_done)
            {
                _done = true;

                Console.WriteLine("ThreadTest is done");
            }
        }
    }
}
