using System;
using System.Threading;
using System.Threading.Tasks;

namespace CSpj_Multithreading
{
    class Test_Task_GlobalTaskException
    {

        public static void SubMain()
        {
            TaskScheduler.UnobservedTaskException += MyTaskException;

            Task.Factory.StartNew(() =>
            {
                throw new Exception();
                //throw new ArgumentNullException();
            });
            Thread.Sleep(100);
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("Done");
            Console.ReadKey();
        }
        public static void MyTaskException(object sender, UnobservedTaskExceptionEventArgs eventArgs)
        {
            // eventArgs.SetObserved();
            ((AggregateException)eventArgs.Exception).Handle(ex =>
            {
                Console.WriteLine("Exception type: {0}", ex.GetType());
                return true;
            });
        }

    }
}
