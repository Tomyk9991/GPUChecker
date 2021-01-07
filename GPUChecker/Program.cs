using System;
using System.Threading.Tasks;

namespace GPUChecker
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            Website[] websites =
            {
                new Caseking(),
                new Mindfactory(),
            };

            while (true)
            {
                Console.Clear();
                foreach (var website in websites)
                {
                    website.CheckAndPrint();
                }

                System.Threading.Thread.Sleep(300_000);
            }
        }
    }
}