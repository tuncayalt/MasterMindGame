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
                string.Empty.InputNotNullOrWhiteSpace();
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
                "a".InputNotNullOrWhiteSpace();
            }
            catch (GameException exception)
            {
                gameExceptionMessage = exception.Message;
            }

            // Assert
            Assert.AreEqual(string.Empty, gameExceptionMessage);
        }

        [TestMethod]
        public void Tools_CheckInteger_ArgumentNull_ThrowsGameException()
        {
            // Arrange
            var gameExceptionMessage = string.Empty;

            // Act
            try
            {
                Tools.CheckInteger(null);
            }
            catch (GameException exception)
            {
                gameExceptionMessage = exception.Message;
            }

            // Assert
            Assert.AreEqual("You did not enter a number.", gameExceptionMessage);
        }

        [TestMethod]
        public void Tools_CheckInteger_ArgumentEmpty_ThrowsGameException()
        {
            // Arrange
            var gameExceptionMessage = string.Empty;

            // Act
            try
            {
                Tools.CheckInteger(string.Empty);
            }
            catch (GameException exception)
            {
                gameExceptionMessage = exception.Message;
            }

            // Assert
            Assert.AreEqual("You did not enter a number.", gameExceptionMessage);
        }

        [TestMethod]
        public void Tools_CheckInteger_ArgumentNotDigit_ThrowsGameException()
        {
            // Arrange
            var gameExceptionMessage = string.Empty;

            // Act
            try
            {
                Tools.CheckInteger("a");
            }
            catch (GameException exception)
            {
                gameExceptionMessage = exception.Message;
            }

            // Assert
            Assert.AreEqual("You did not enter a number.", gameExceptionMessage);
        }

        [TestMethod]
        public void Tools_CheckInteger_ArgumentDigitsBetween1And6_NormalFlow()
        {
            // Arrange
            var gameExceptionMessage = string.Empty;

            // Act
            try
            {
                Tools.CheckInteger("1263");
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
