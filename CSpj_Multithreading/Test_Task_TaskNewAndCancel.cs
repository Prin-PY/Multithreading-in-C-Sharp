using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSpj_Multithreading
{
    class Test_Task_TaskNewAndCancel
    {
        public static void SubMain()
        {
            Console.WriteLine("任务开始启动，按下任意键，取消执行任务");
            CancellationTokenSource cts = new CancellationTokenSource();
            Task.Factory.StartNew(MyTask, cts.Token);

            Console.ReadKey();

            cts.Cancel();       // 取消任务
            Console.ReadKey();
        }

        // public delegate void TimerCallback(object? state);
        private static void MyTask()
        {
            Console.WriteLine(" 开始执行");
            int i = 0;
            while (true)
            {
                Console.WriteLine($" 第{i}次任务");
                Thread.Sleep(TimeSpan.FromSeconds(0.1));

                Console.WriteLine("     执行中");
                Thread.Sleep(TimeSpan.FromSeconds(0.1));

                Console.WriteLine("     执行结束");
                i++;
            }
        }
    }
}
