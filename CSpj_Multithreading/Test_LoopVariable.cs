using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSpj_Multithreading
{
    class Test_LoopVariable
    {
        public static void SubMain()
        {
            for (int i = 0; i < 5; i++)
            {
                int tmp = i;
                new Thread(() =>
                {
                    Console.WriteLine($"i = {tmp}");
                }).Start();
            }

            Console.ReadKey();
        }
    }
}
