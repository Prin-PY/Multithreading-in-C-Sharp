using System;
using System.Threading;

namespace CSpj_Multithreading
{

    class Program
    {
        static void Main(string[] args)
        {
            //TestLock.SubMain();
            //TestAutoResetEvent.SubMain();

            //NOT Supported:
            //TestAbortThread.SubMain();

            //TestTimeOfNewThread.SubMain();
            //TestThreadPool.SubMain();
            //TestTackNewAndCancel.SubMain();
            //TestSubTask.SubMain();
            //Test_Task_TaskResult.SubMain();

            //Test_Task_GlobalTaskException.SubMain();
            //Test_Task_State.SubMain();
            //Test_Task_ContinueWith.SubMain();
            //Test_Task_WhenAll.SubMain();

            Test_SyncAndAsyncClass.SubMain();
        }

    }
}
