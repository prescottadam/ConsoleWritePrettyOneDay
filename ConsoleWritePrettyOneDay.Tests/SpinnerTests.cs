using System;
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
    }
}
