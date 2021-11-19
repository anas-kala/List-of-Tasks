using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks_2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Method();
            Console.WriteLine("breakfast is ready");
            Console.ReadKey();

        }

        static async Task<string> MakingBread()
        {
            string str = "";
            await Task.Run(()=> {
                Console.WriteLine("bread is being made");
                Thread.Sleep(1000);
                str= "Bread is ready";
            });
            return str;
        }

        static async Task<string> MakingEgg()
        {
            string str = "";
            await Task.Run(() => {
                Console.WriteLine("Egg is being made");
                Thread.Sleep(1000);
                str = "Egg is ready";
            });
            return str;
        }

        static async Task<string> MakingCoffe()
        {
            string str = "";
            await Task.Run(() => {
                Console.WriteLine("Coffee is being made");
                Thread.Sleep(1000);
                str = "Coffee is ready";
            });
            return str;
        }

        static void Method()
        {
            List<Task<string>> list = new List<Task<string>>();
            var ts = MakingBread();
            var tm=MakingEgg();
            var ss=MakingCoffe();
            list.Add(ts);
            list.Add(tm);
            list.Add(ss);

            Task.WaitAll(list.ToArray());
        }
    }
}
