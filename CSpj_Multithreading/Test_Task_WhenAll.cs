using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSpj_Multithreading
{
    class Test_Task_WhenAll
    {
        public static void SubMain()
        {
            List<Task<int>> tasks = new List<Task<int>>();

            for (int i = 0; i < 5; i++)
                tasks.Add(Task.Run<int>(() =>
                {
                    Console.WriteLine($"任务开始执行");
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    return new Random().Next(0, 10);
                }));

            Task<int[]> taskOne = Task.WhenAll(tasks);

            taskOne.Wait();

            foreach (var item in taskOne.Result)
                Console.WriteLine(item);

            Console.ReadKey();

            Console.ReadKey();
        }
    }
}
