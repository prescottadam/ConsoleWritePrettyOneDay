using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ConsoleWritePrettyOneDay
{
    public static class Spinner
    {
        private static char[] _chars = new[] { '|', '/', '-', '\\', '|', '/', '-', '\\' };

        /// <summary>
        /// Displays a spinner while the provided <paramref name="action"/> is performed.
        /// If provided, <paramref name="message"/> will be displayed along with the elapsed time in milliseconds.
        /// </summary>
        public static void Wait(Action action, string message = null)
        {
            Wait(Task.Run(action), message);
        }

        /// <summary>
        /// Displays a spinner while the provided <paramref name="task"/> is executed.
        /// If provided, <paramref name="message"/> will be displayed along with the elapsed time in milliseconds.
        /// </summary>
        public static void Wait(Task task, string message = null)
        {
            WaitAsync(task, message).Wait();
        }

        /// <summary>
        /// Displays a spinner while the provided <paramref name="task"/> is executed.
        /// If provided, <paramref name="message"/> will be displayed along with the elapsed time in milliseconds.
        /// </summary>
        /// <returns></returns>
        public static async Task WaitAsync(Task task, string message = null)
        {
            int index = 0;
            int max = _chars.Length;

            if (!string.IsNullOrWhiteSpace(message) && !message.EndsWith(" "))
            {
                message += " ";
            }

            var timer = new Stopwatch();
            timer.Start();
            while (!task.IsCompleted)
            {
                await Task.Delay(35);
                index = ++index % max;
                Console.Write($"\r{message}{_chars[index]}");
            }
            timer.Stop();
            Console.WriteLine($"\r{message}[{(timer.ElapsedMilliseconds / 1000m).ToString("0.0##")}s]");
        }
    }
}
