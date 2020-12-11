using System;
using System.Threading;
using System.Diagnostics;

namespace CSpj_Multithreading
{
    class Test_Thread_TimeOfNew10Thread
    {
        public static void SubMain()
        {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 10; i++)
                    new Thread(() => { }).Start();
                watch.Stop();
                Console.WriteLine("创建 10 个线程需要花费时间(毫秒)：" + watch.ElapsedMilliseconds);
                Console.ReadKey();
        }
    }
}
