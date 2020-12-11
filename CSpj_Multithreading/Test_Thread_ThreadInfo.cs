using System;
using System.Threading;

namespace CSpj_Multithreading
{
    class Test_Thread_ThreadInfo
    {
        static void SubMain()
        {
            Thread thread = new Thread(ShowThreadInfo);
            thread.Name = "Test";
            thread.Start();

            Console.ReadKey();

            Test_Thread_ThreadState.SubMain();
        }

        public static void ShowThreadInfo()
        {
            Thread currentThread = Thread.CurrentThread;
            Console.WriteLine("线程标识：" + currentThread.Name);
            Console.WriteLine("当前地域：" + currentThread.CurrentCulture.Name);  // 当前地域
            Console.WriteLine("线程执行状态：" + currentThread.IsAlive);
            Console.WriteLine("是否为后台线程：" + currentThread.IsBackground);
            Console.WriteLine("是否为线程池线程: " + currentThread.IsThreadPoolThread);
            Console.WriteLine("线程状态: " + currentThread.ThreadState);
        }
    }
}
