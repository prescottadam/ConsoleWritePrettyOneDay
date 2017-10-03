using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ConsoleWritePrettyOneDay.Tests
{
    [TestFixture]
    public class SpinnerTests
    {
        [Test]
        public void Wait_ExecutesAction()
        {
            // ARRANGE
            bool result = false;
            Action action = () => {
                result = true;
            };

            // ACT
            Spinner.Wait(action);

            // ASSERT
            Assert.IsTrue(result);
        }

        [Test]
        public void Wait_ThrowException_WhenActionThrowsException()
        {
            void Test()
            {
                // ARRANGE
                Action action = () =>
                {
                    throw new ApplicationException();
                };

                // ACT
                Spinner.Wait(action);
            }

            // ASSERT
            Assert.Throws(typeof(ApplicationException), Test);
        }

        [Test]
        public void Wait_ExecutesTask()
        {
            // ARRANGE
            bool result = false;
            Task task = Task.Run(() => {
                result = true;
            });

            // ACT
            Spinner.Wait(task);

            // ASSERT
            Assert.IsTrue(result);
        }

        [Test]
        public void Wait_DoesNotThrowException_WhenTaskThrowsException()
        {
            // ARRANGE
            Task task = Task.Run(() => {
                throw new ApplicationException();
            });

            // ACT
            Spinner.Wait(task);

            // ASSERT
            Assert.IsTrue(task.IsFaulted);
            Assert.IsTrue(task.Exception is AggregateException);
        }
    }
}
