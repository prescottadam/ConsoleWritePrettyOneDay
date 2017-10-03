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
            Console.WriteLine("A SPINNER FOLLOWED BY A WRITELINE");
            Spinner.Wait(() => Thread.Sleep(1000));
            Console.WriteLine();
            Console.WriteLine("---");

            Console.WriteLine("A SPINNER WRAPPED BY WRITE & WRITELINE");
            Console.Write("Waiting:");
            Spinner.Wait(() => Thread.Sleep(1000));
            Console.WriteLine("DONE");
            Console.WriteLine("---");

            Console.WriteLine("A LAMBDA SPINNER W/ MESSAGE");
            Spinner.Wait(() => Thread.Sleep(1000), "waiting for sleep");
            Console.WriteLine("---");

            Console.WriteLine("A TASK SPINNER W/ MESSAGE");
            var task = Task.Run(() => Thread.Sleep(1000));
            Spinner.Wait(task, "waiting for task");
            Console.WriteLine("---");

            Console.WriteLine("A SPINNER W/ TASK THAT WRITES TO CONSOLE");
            Spinner.Wait(() =>
                Task
                    .Run(new Action(() =>
                    {
                        Thread.Sleep(250);
                        Console.WriteLine("1");
                        Thread.Sleep(250);
                        Console.WriteLine("2");
                        Thread.Sleep(250);
                        Console.WriteLine("3");
                    }))
                    .Wait());
            Console.WriteLine("---");

            Console.WriteLine("A SPINNER W/ TASK THAT WRITES TO CONSOLE AND MESSAGE");
            Spinner.Wait(() =>
                Task
                    .Run(new Action(() =>
                    {
                        Thread.Sleep(250);
                        Console.WriteLine("1");
                        Thread.Sleep(250);
                        Console.WriteLine("2");
                        Thread.Sleep(250);
                        Console.WriteLine("3");
                    }))
                    .Wait(), "waiting for work that writes to console");
            Console.WriteLine("---");

            Console.WriteLine();
            Console.WriteLine("Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
