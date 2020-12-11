using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSpj_Multithreading
{
    class MySyncAndAsyncClass<TResult>
    {

        private Task<TResult> task;

        private Func<TResult> _func;

        bool isCompleted = false;
        private TResult _result;

        public TResult Result
        {
            get
            {
                if (isCompleted)
                    return _result;
                return task.Result;
            }
        }

        public MySyncAndAsyncClass(Func<TResult> func)
        {
            _func = func;
            task = new Task<TResult>(func);
            
        }

        public TResult GetResult()
        {
            _result =  _func.Invoke();
            isCompleted = true;
            return _result;
        }

        public void RunAsync()
        {
            Task.Factory.StartNew(()=>
                {
                    task.Start();
                    _result = task.Result;
                    isCompleted = true;
                }
            );
        }

       

    }

    class Test_SyncAndAsyncClass
    {
        public static void SubMain()
        {
            MySyncAndAsyncClass<string> myTask1 = new MySyncAndAsyncClass<string>(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(3));
                return "Task1 completed";
            }
            );
            Console.WriteLine(myTask1.GetResult());

            MySyncAndAsyncClass<string> myTask2 = new MySyncAndAsyncClass<string>(() =>
            {
                Thread.Sleep(3000);
                return "Task2 completed";
            });

            myTask2.RunAsync();
            Console.WriteLine("Task2 Run");
            Console.WriteLine(myTask2.Result);
            Console.ReadKey();
        }
    }
}
