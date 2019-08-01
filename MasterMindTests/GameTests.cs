using MasterMind;
using MasterMind.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MasterMindTests
{
    [TestClass]
    public class GameTests
    {
        private Game _game;

        [TestInitialize]
        public void Setup()
        {
            _game = new Game();
        }

        [TestMethod]
        public void Game_ShouldExist()
        {
            // Arrange, Act, Assert
            Assert.IsNotNull(_game);
        }

        [TestMethod]
        public void Game_Guess_ArgumentNull_ThrowsGameException()
        {
            // Arrange
            var gameExceptionMessage = string.Empty;

            // Act
            try
            {
                var guess = new Guess(null, "1234");
            }
            catch (GameException exception)
            {
                gameExceptionMessage = exception.Message;
            }

            // Assert
            Assert.AreEqual("You did not enter a number.", gameExceptionMessage);
        }

        [TestMethod]
        public void Game_Guess_ArgumentEmpty_ThrowsGameException()
        {
            // Arrange
            var gameExceptionMessage = string.Empty;

            // Act
            try
            {
                var guess = new Guess(string.Empty, "1234");
            }
            catch (GameException exception)
            {
                gameExceptionMessage = exception.Message;
            }

            // Assert
            Assert.AreEqual("You did not enter a number.", gameExceptionMessage);
        }

        [TestMethod]
        public void Game_Guess_ArgumentNotDigit_ThrowsGameException()
        {
            // Arrange
            var gameExceptionMessage = string.Empty;

            // Act
            try
            {
                var guess = new Guess("a", "1234");
            }
            catch (GameException exception)
            {
                gameExceptionMessage = exception.Message;
            }

            // Assert
            Assert.AreEqual("You did not enter a number.", gameExceptionMessage);
        }

        [TestMethod]
        public void Game_Guess_ArgumentMoreThan4Digits_ThrowsGameException()
        {
            // Arrange
            var gameExceptionMessage = string.Empty;

            // Act
            try
            {
                var guess = new Guess("12345", "1234");
            }
            catch (GameException exception)
            {
                gameExceptionMessage = exception.Message;
            }

            // Assert
            Assert.AreEqual("The number is not 4 digits.", gameExceptionMessage);
        }

        [TestMethod]
        public void Game_Guess_ArgumentLessThan4Digits_ThrowsGameException()
        {
            // Arrange
            var gameExceptionMessage = string.Empty;

            // Act
            try
            {
                var guess = new Guess("123", "1234");
            }
            catch (GameException exception)
            {
                gameExceptionMessage = exception.Message;
            }

            // Assert
            Assert.AreEqual("The number is not 4 digits.", gameExceptionMessage);
        }

        [TestMethod]
        public void Game_Guess_ArgumentNotBetween1And6_ThrowsGameException()
        {
            // Arrange
            var gameExceptionMessage = string.Empty;

            // Act
            try
            {
                var guess = new Guess("1273", "1234");
            }
            catch (GameException exception)
            {
                gameExceptionMessage = exception.Message;
            }

            // Assert
            Assert.AreEqual("The digits must be between 1 and 6.", gameExceptionMessage);
        }

        [TestMethod]
        public void Game_Guess_ArgumentNoDigitsAreSame_NoOutput()
        {
            // Arrange
            _game.answerString = "1212";

            // Act
            var actual = new Guess("3434", _game.answerString);

            // Assert
            Assert.AreEqual(string.Empty, actual.Response.ResponseMessage);
        }

        [TestMethod]
        public void Game_Guess_Argument1DigitIsSameNotInPlace_1Minus()
        {
            // Arrange
            _game.answerString = "1212";

            // Act
            var actual = new Guess("3431", _game.answerString);


            // Assert
            Assert.AreEqual("-", actual.Response.ResponseMessage);
        }

        [TestMethod]
        public void Game_Guess_Argument1DigitIsSameInPlace_1Plus()
        {
            // Arrange
            _game.answerString = "1212";

            // Act
            var actual = new Guess("4235", _game.answerString);

            // Assert
            Assert.AreEqual("+", actual.Response.ResponseMessage);
        }

        [TestMethod]
        public void Game_Guess_Argument2DigitsSame1InPlace1Not_1Plus1Minus()
        {
            // Arrange
            _game.answerString = "1212";

            // Act
            var actual = new Guess("1135", _game.answerString);

            // Assert
            Assert.AreEqual("+-", actual.Response.ResponseMessage);
        }

        [TestMethod]
        public void Game_Guess_Argument2DigitsSame2NotInPlace_2Minus()
        {
            // Arrange
            _game.answerString = "1212";

            // Act
            var actual = new Guess("2135", _game.answerString);

            // Assert
            Assert.AreEqual("--", actual.Response.ResponseMessage);
        }

        [TestMethod]
        public void Game_Guess_Argument2DigitsSame2InPlace_2Plus()
        {
            // Arrange
            _game.answerString = "1212";

            // Act
            var actual = new Guess("3512", _game.answerString);

            // Assert
            Assert.AreEqual("++", actual.Response.ResponseMessage);
        }

        [TestMethod]
        public void Game_Guess_Argument3DigitsSame2InPlace_2Plus1Minus()
        {
            // Arrange
            _game.answerString = "1212";

            // Act
            var actual = new Guess("2512", _game.answerString);

            // Assert
            Assert.AreEqual("++-", actual.Response.ResponseMessage);
        }

        [TestMethod]
        public void Game_Guess_Argument4DigitsSame2InPlace_2Plus2Minus()
        {
            // Arrange
            _game.answerString = "1212";

            // Act
            var actual = new Guess("2112", _game.answerString);

            // Assert
            Assert.AreEqual("++--", actual.Response.ResponseMessage);
        }

        [TestMethod]
        public void Game_Guess_Argument3DigitsSame3InPlace_3Plus()
        {
            // Arrange
            _game.answerString = "1561";

            // Act
            var actual = new Guess("1661", _game.answerString);

            // Assert
            Assert.AreEqual("+++", actual.Response.ResponseMessage);
        }

        [TestMethod]
        public void Game_Guess_ArgumentSameNonInPlace_4Minus()
        {
            // Arrange
            _game.answerString = "1212";

            // Act
            var actual = new Guess("2121", _game.answerString);

            // Assert
            Assert.AreEqual("----", actual.Response.ResponseMessage);
        }

        [TestMethod]
        public void Game_Guess_ArgumentSameInPlace_GameWon()
        {
            // Arrange
            _game.answerString = "1212";

            // Act
            var actual = new Guess("1212", _game.answerString);

            // Assert
            Assert.AreEqual("You guessed the number correctly! ", actual.Response.ResponseMessage);
        }
    }
}
