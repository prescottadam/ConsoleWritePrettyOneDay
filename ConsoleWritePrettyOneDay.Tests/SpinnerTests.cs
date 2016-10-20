using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleWritePrettyOneDay.Tests
{
    [TestClass]
    public class SpinnerTests
    {
        [TestMethod]
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

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void Wait_ThrowException_WhenActionThrowsException()
        {
            // ARRANGE
            Action action = () => {
                throw new ApplicationException();
            };

            // ACT
            Spinner.Wait(action);

            // ASSERT
        }

        [TestMethod]
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

        [TestMethod]
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
