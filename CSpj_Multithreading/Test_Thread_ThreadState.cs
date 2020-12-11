using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CSpj_Multithreading
{
    class Test_Thread_ThreadState
    {

        public static void SubMain()
        {
            Thread newThread =
                new Thread(new ThreadStart(ThreadMethod));

            Console.WriteLine("ThreadState: {0}", newThread.ThreadState);
            Console.WriteLine("IsAlive: {0}", newThread.IsAlive);

            Console.WriteLine("-----------------------------");
            newThread.Start();
            // Wait for newThread to start and go to sleep.
            Thread.Sleep(300);
            Console.WriteLine("ThreadState: {0}", newThread.ThreadState);
            Console.WriteLine("IsAlive: {0}", newThread.IsAlive);

            Console.WriteLine("-----------------------------");

            // Wait for newThread to restart.
            Thread.Sleep(1000);
            Console.WriteLine("ThreadState: {0}", newThread.ThreadState);
            Console.WriteLine("IsAlive: {0}", newThread.IsAlive);

        }

        static void ThreadMethod()
        {
            Thread.Sleep(1000);
        }
    }
}
