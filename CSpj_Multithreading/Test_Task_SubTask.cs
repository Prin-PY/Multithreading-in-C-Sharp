using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CSpj_Multithreading
{
    class Test_Task_SubTask
    {
        public static void SubMain()
        {
            // 父子任务
            Task task = new Task(() =>
            {
                // TaskCreationOptions.AttachedToParent
                // 将此任务附加到父任务中
                // 父任务需要等待所有子任务完成后，才能算完成
                Task task1 = new Task(() =>
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine("     内层任务1");
                        Thread.Sleep(TimeSpan.FromSeconds(0.5));
                    }
                }, TaskCreationOptions.AttachedToParent);
                task1.Start();

                Console.WriteLine("最外层任务");
                Thread.Sleep(TimeSpan.FromSeconds(1));
            });

            task.Start();
            task.Wait();
            Console.WriteLine("Done");

            Console.ReadKey();
        }
    }
}
