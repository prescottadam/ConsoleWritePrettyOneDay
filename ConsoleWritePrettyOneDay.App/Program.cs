using System.Threading;
using System.Threading.Tasks;
using Console = System.Console;

namespace ConsoleWritePrettyOneDay.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Spinner.Wait(() => Thread.Sleep(5000), "waiting for sleep");

            var task = Task.Run(() => Thread.Sleep(4000));
            Spinner.Wait(task, "waiting for task");

            Console.ReadLine();
        }
    }
}
