using System;
using System.Threading;
using System.Threading.Tasks;
using Console = System.Console;

namespace ConsoleWritePrettyOneDay.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Spinner.Wait(() => Thread.Sleep(2000), "waiting for sleep");

            var task = Task.Run(() => Thread.Sleep(2000));
            Spinner.Wait(task, "waiting for task");

            Spinner.Wait(() =>
                Task
                    .Run(new Action(() =>
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine("1");
                        Thread.Sleep(1000);
                        Console.WriteLine("2");
                        Thread.Sleep(1000);
                        Console.WriteLine("3");
                    }))
                    .Wait(), "waiting for work that writes to console");

            Console.WriteLine();
            Console.WriteLine("Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
