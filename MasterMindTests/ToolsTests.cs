using MasterMind;
using MasterMind.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MasterMindTests
{
    [TestClass]
    public class ToolsTests
    {
        [TestMethod]
        public void Tools_InputNotNullOrWhiteSpace_ArgumentNull_ThrowsGameException()
        {
            // Arrange
            var gameExceptionMessage = string.Empty;

            // Act
            try
            {
                Tools.InputNotNullOrWhiteSpace(null);
            }
            catch (GameException exception)
            {
                gameExceptionMessage = exception.Message;
            }

            // Assert
            Assert.AreEqual("You entered an invalid number.", gameExceptionMessage);
        }

        [TestMethod]
        public void Tools_InputNotNullOrWhiteSpace_ArgumentEmpty_ThrowsGameException()
        {
            // Arrange
            var gameExceptionMessage = string.Empty;

            // Act
            try
            {
                Tools.InputNotNullOrWhiteSpace(string.Empty);
            }
            catch (GameException exception)
            {
                gameExceptionMessage = exception.Message;
            }

            // Assert
            Assert.AreEqual("You entered an invalid number.", gameExceptionMessage);
        }

        [TestMethod]
        public void Tools_InputNotNullOrWhiteSpace_ArgumentNotNullOrEmpty_DoesNotThrowGameException()
        {
            // Arrange
            var gameExceptionMessage = string.Empty;

            // Act
            try
            {
                Tools.InputNotNullOrWhiteSpace("a");
            }
            catch (GameException exception)
            {
                gameExceptionMessage = exception.Message;
            }

            // Assert
            Assert.AreEqual(string.Empty, gameExceptionMessage);
        }

        [TestMethod]
        public void Tools_CheckInput_ArgumentNull_ThrowsGameException()
        {
            // Arrange
            var gameExceptionMessage = string.Empty;

            // Act
            try
            {
                Tools.CheckInput(null, 4);
            }
            catch (GameException exception)
            {
                gameExceptionMessage = exception.Message;
            }

            // Assert
            Assert.AreEqual("You did not enter a number.", gameExceptionMessage);
        }

        [TestMethod]
        public void Tools_CheckInput_ArgumentEmpty_ThrowsGameException()
        {
            // Arrange
            var gameExceptionMessage = string.Empty;

            // Act
            try
            {
                Tools.CheckInput(string.Empty, 4);
            }
            catch (GameException exception)
            {
                gameExceptionMessage = exception.Message;
            }

            // Assert
            Assert.AreEqual("You did not enter a number.", gameExceptionMessage);
        }

        [TestMethod]
        public void Tools_CheckInput_ArgumentNotDigit_ThrowsGameException()
        {
            // Arrange
            var gameExceptionMessage = string.Empty;

            // Act
            try
            {
                Tools.CheckInput("a", 4);
            }
            catch (GameException exception)
            {
                gameExceptionMessage = exception.Message;
            }

            // Assert
            Assert.AreEqual("You did not enter a number.", gameExceptionMessage);
        }

        [TestMethod]
        public void Tools_CheckInput_ArgumentMoreThan4Digits_ThrowsGameException()
        {
            // Arrange
            var gameExceptionMessage = string.Empty;

            // Act
            try
            {
                Tools.CheckInput("12345", 4);
            }
            catch (GameException exception)
            {
                gameExceptionMessage = exception.Message;
            }

            // Assert
            Assert.AreEqual("The number is not 4 digits.", gameExceptionMessage);
        }

        [TestMethod]
        public void Tools_CheckInput_ArgumentLessThan4Digits_ThrowsGameException()
        {
            // Arrange
            var gameExceptionMessage = string.Empty;

            // Act
            try
            {
                Tools.CheckInput("125", 4);
            }
            catch (GameException exception)
            {
                gameExceptionMessage = exception.Message;
            }

            // Assert
            Assert.AreEqual("The number is not 4 digits.", gameExceptionMessage);
        }

        [TestMethod]
        public void Tools_CheckInput_ArgumentNotBetween1And6_ThrowsGameException()
        {
            // Arrange
            var gameExceptionMessage = string.Empty;

            // Act
            try
            {
                Tools.CheckInput("1273" ,4);
            }
            catch (GameException exception)
            {
                gameExceptionMessage = exception.Message;
            }

            // Assert
            Assert.AreEqual("The digits must be between 1 and 6.", gameExceptionMessage);
        }

        [TestMethod]
        public void Tools_CheckInput_ArgumentDigitsBetween1And6_NormalFlow()
        {
            // Arrange
            var gameExceptionMessage = string.Empty;

            // Act
            try
            {
                Tools.CheckInput("1263", 4);
            }
            catch (GameException exception)
            {
                gameExceptionMessage = exception.Message;
            }

            // Assert
            Assert.AreEqual(string.Empty, gameExceptionMessage);
        }
    }
}
