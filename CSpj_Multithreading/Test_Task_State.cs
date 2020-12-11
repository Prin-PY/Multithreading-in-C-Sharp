using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSpj_Multithreading
{
    class Test_Task_State
    {

        public static void SubMain()
        {
            // 正常任务
            Task task1 = new Task(() =>
            {
            });
            task1.Start();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            ShowTaskState(task1);


            // 未完成任务
            Task task2 = new Task(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(3));

                throw new Exception();
            });
            task2.Start();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            ShowTaskState(task2);


            // 异常任务
            Task task3 = new Task(() =>
            {
                throw new Exception();
            });
            task3.Start();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            ShowTaskState(task3);


            Thread.Sleep(TimeSpan.FromSeconds(1));

            CancellationTokenSource cts = new CancellationTokenSource();
            // 取消任务
            Task task4 = new Task(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));
            }, cts.Token);
            task4.Start();
            cts.Cancel();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            ShowTaskState(task4);
            Console.ReadKey();
        }

        public static void ShowTaskState(Task task)
        {
            Console.WriteLine("Task ID: " + task.Id);
            Console.WriteLine("Task Status: " + task.Status);
            Console.WriteLine("Task AsyncState: " + task.AsyncState);
            Console.WriteLine("IsFaulted: " + task.IsFaulted);
            Console.WriteLine("IsCanceled: " + task.IsCanceled);
            Console.WriteLine("IsCompleted: " + task.IsCompleted);
            Console.WriteLine("IsCompletedSuccessfully: " + task.IsCompletedSuccessfully);


            if (task.IsCanceled == false && task.IsFaulted == false)
                Console.WriteLine("没有异常发生");
            else if (task.IsCanceled == true)
                Console.WriteLine("任务被取消");
            else
                Console.WriteLine("任务引发了未经处理的异常");

            Console.WriteLine("任务是否完成：" + task.IsCompleted);
            Console.WriteLine("-------------------");
            Console.WriteLine();


        }
    }
}
