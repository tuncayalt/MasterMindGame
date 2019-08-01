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
                _game.Guess(null);
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
                _game.Guess(string.Empty);
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
                _game.Guess("a");
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
                _game.Guess("12345");
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
                _game.Guess("123");
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
                _game.Guess("1273");
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
            var actual = _game.Guess("3434");
            

            // Assert
            Assert.AreEqual(string.Empty, actual.ResponseMessage);
        }

        [TestMethod]
        public void Game_Guess_Argument1DigitIsSameNotInPlace_1Minus()
        {
            // Arrange
            _game.answerString = "1212";

            // Act
            var actual = _game.Guess("3431");


            // Assert
            Assert.AreEqual("-", actual.ResponseMessage);
        }

        [TestMethod]
        public void Game_Guess_Argument1DigitIsSameInPlace_1Plus()
        {
            // Arrange
            _game.answerString = "1212";

            // Act
            var actual = _game.Guess("4235");


            // Assert
            Assert.AreEqual("+", actual.ResponseMessage);
        }

        [TestMethod]
        public void Game_Guess_Argument2DigitsSame1InPlace1Not_1Plus1Minus()
        {
            // Arrange
            _game.answerString = "1212";

            // Act
            var actual = _game.Guess("1135");


            // Assert
            Assert.AreEqual("+-", actual.ResponseMessage);
        }

        [TestMethod]
        public void Game_Guess_Argument2DigitsSame2NotInPlace_2Minus()
        {
            // Arrange
            _game.answerString = "1212";

            // Act
            var actual = _game.Guess("2135");


            // Assert
            Assert.AreEqual("--", actual.ResponseMessage);
        }

        [TestMethod]
        public void Game_Guess_Argument2DigitsSame2InPlace_2Plus()
        {
            // Arrange
            _game.answerString = "1212";

            // Act
            var actual = _game.Guess("3512");


            // Assert
            Assert.AreEqual("++", actual.ResponseMessage);
        }

        [TestMethod]
        public void Game_Guess_Argument3DigitsSame2InPlace_2Plus1Minus()
        {
            // Arrange
            _game.answerString = "1212";

            // Act
            var actual = _game.Guess("2512");


            // Assert
            Assert.AreEqual("++-", actual.ResponseMessage);
        }

        [TestMethod]
        public void Game_Guess_Argument4DigitsSame2InPlace_2Plus2Minus()
        {
            // Arrange
            _game.answerString = "1212";

            // Act
            var actual = _game.Guess("2112");


            // Assert
            Assert.AreEqual("++--", actual.ResponseMessage);
        }

        [TestMethod]
        public void Game_Guess_Argument3DigitsSame3InPlace_3Plus()
        {
            // Arrange
            _game.answerString = "1561";

            // Act
            var actual = _game.Guess("1661");


            // Assert
            Assert.AreEqual("+++", actual.ResponseMessage);
        }

        [TestMethod]
        public void Game_Guess_ArgumentSameNonInPlace_4Minus()
        {
            // Arrange
            _game.answerString = "1212";

            // Act
            var actual = _game.Guess("2121");


            // Assert
            Assert.AreEqual("----", actual.ResponseMessage);
        }

        [TestMethod]
        public void Game_Guess_ArgumentSameInPlace_GameWon()
        {
            // Arrange
            _game.answerString = "1212";

            // Act
            var actual = _game.Guess("1212");


            // Assert
            Assert.AreEqual("You guessed the number correctly! ", actual.ResponseMessage);
        }
    }
}
