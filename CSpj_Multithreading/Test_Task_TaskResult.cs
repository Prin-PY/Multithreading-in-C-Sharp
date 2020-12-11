using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSpj_Multithreading
{
    class Test_Task_TaskResult
    {
        public static void SubMain()
        {
            // *******************************
            Task<int> task = new Task<int>(() =>
            {
                for(int i=0; i<6; i++)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(0.1));
                    Console.WriteLine(i+1);
                }

                return 666;
            });
            // 执行
            task.Start();

            int number = task.Result;
            Console.WriteLine(number);

            // *******************************
            task = Task.Factory.StartNew<int>(() =>
            {
                return 777;
            });


            number = task.Result;
            Console.WriteLine(number);


            // *******************************
            task = Task.Run<int>(() =>
            {
                return 888;
            });
            number = task.Result;
            Console.WriteLine(number);

            number = Task.Factory.StartNew<int>(() =>
            {
                for (int i = 0; i < 9; i++)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(0.1));
                    Console.WriteLine(i+1);
                }
                return 999;
            }).Result;
            Console.WriteLine(number);


            Console.ReadKey();
        }
    }
}
