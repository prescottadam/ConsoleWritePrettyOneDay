using System;
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
            var task = Task.Run(action);
            Wait(task, message);

            if (task.IsFaulted)
            {
                throw task.Exception?.InnerException ?? task.Exception;
            }
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
        public static async Task WaitAsync(Task task, string message = null)
        {
            var index = 0;
            var max = _chars.Length;

            var cursorLeft = Console.CursorLeft;
            var cursorTop = Console.CursorTop;
            var cursorVisible = Console.CursorVisible;

            if (!string.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine($"{message}");
            }

            while (!task.IsCompleted)
            {
                await Task.Delay(35);
                index = ++index % max;
                Console.Write(_chars[index]);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                Console.CursorVisible = false;
            }

            Console.Write(" ");
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            Console.CursorVisible = cursorVisible;
        }

        /// <summary>
        /// Moves the console cursor to the previous line.
        /// </summary>
        private static void MoveCursorToPreviousLine()
        {
            try
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }
            catch
            {
                // ignore exceptions
            }
        }
    }
}
