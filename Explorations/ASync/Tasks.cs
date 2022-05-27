using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Explorations
{
    /// <summary>
    /// When compared to threads a task is a higher level absstraction,
    /// It represents a concurrent operation that might or might not be backed by a thread
    /// The threads used by task are taken from the pool of threads .net sets asaide on start-up 
    /// 
    /// Note: Tasks & threads should be try catched to handle if the os or
    /// .net can't assign another thread
    /// 
    /// </summary>
    public static class Tasks
    {

        public static void TaskBasics()
        {
            Task.Run(() => Console.WriteLine("first task"));
            Console.ReadLine();

            // The following is the same as above
            new Thread(() => Console.WriteLine("thread run")).Start();

            // This uses the .Net thread pool
            Task task = Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("task run");
            });
            Console.WriteLine(task.IsCompleted);
            task.Wait(); // this blocks until task is complete

            // You can return a value from a task
            // Task<int> will return an int 
            Task<int> task2 = Task.Run(() =>
            {
                Console.WriteLine("Task 2 doing something to return an int");
                return 31;
            });
            
            // assigns the return of task 2  
            int result = task2.Result;
            Console.WriteLine($"Result of task 2: {result}");

            // Below is same as thread sleep
            Task.Delay(2000).ContinueWith(a => Console.WriteLine("after delay"));

            int[] arr = new int[] { 12, 34, 56, 78, 90 };

            var getCalcAwaiter = GetCalculatedNumAsync(arr, 0, 2).GetAwaiter();
            getCalcAwaiter.OnCompleted(() =>
            {
                Console.WriteLine($"Result of Async Calc: {getCalcAwaiter.GetResult()}");
            });
        }

        /// <summary>
        /// In a normal method the body is executed and then a value is returned. this is syncronise
        /// ASync is when most or all of the work can happen after the return.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static Task<int> GetCalculatedNumAsync(int[] arr, int start, int end)
        {
            // creates and runs a task in its return
            return Task.Run(() =>
            {
                int sum = 0;
                for (int i = start; i < end; i++)
                {
                    sum = sum + arr[i];
                }
                return sum;
            });
        }

        /// <summary>
        /// Functionally the same as the method below (BetterExecuteTaskAsync)
        /// </summary>
        public static Task<int> ExecuteTaskAsync(int start, int end)
        {
            return Task.Run(() =>
           {
               Console.WriteLine("The better way");
               return 17;
           });
        }

        /// <summary>
        /// Functionally the same as the above code.
        /// Must retrun a Task to use async
        /// </summary>
        public static async Task<int> BetterExecuteTaskAsync(int start, int end)
        {
            Console.WriteLine("The better way");
            return 17;
        }

        // We don't need to explicitly return a task
        // the compiller manufactures a task and signals it when the mehod completes
        public static async Task AsyncExampleGo(int start, int end)
        {
            await ExecuteTaskAsync(0, 30);
            Console.WriteLine("doneskies");
        }



        public static void Test()
        {
            TaskBasics();
        }
    }
}
