using System; 
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSpj_Multithreading
{
    class Test_Task_ContinueWith
    {

        public static void SubMain()
        {

            Console.WriteLine("-----------");
            Console.WriteLine("Main ThreadID: " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("-----------");

            Task task = new Task(() =>
            {
                Console.WriteLine("-----------");
                Console.WriteLine("Original Task");
                Console.WriteLine("ThreadID: " + Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("-----------");

                Thread.Sleep(TimeSpan.FromSeconds(1));
            });

            //任务①
            task.ContinueWith(t =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("-----------");
                    Console.WriteLine($"任务1 ");
                    Console.WriteLine("Task ID: " + t.Id);

                    Console.WriteLine("Thread ID: " + Thread.CurrentThread.ManagedThreadId);
                    Console.WriteLine("-----------");

                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
            });

            //任务②
            task.ContinueWith(t =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("-----------");
                    Console.WriteLine($"任务2");
                    Console.WriteLine("Task ID: " + t.Id);
                    Console.WriteLine("ThreadID: " + Thread.CurrentThread.ManagedThreadId);
                    Console.WriteLine("-----------");

                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
            });

            //任务① 和 任务② 属于同级并行任务


            Console.WriteLine("Task ID: " + task.Id);
            task.Start();
            Thread.Sleep(TimeSpan.FromSeconds(10));

        }

    }
}
