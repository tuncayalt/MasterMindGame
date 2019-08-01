using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using MasterMind.Constants;
using MasterMind.Exceptions;
using MasterMind.Responses;

[assembly: InternalsVisibleTo("MasterMindTests")]

namespace MasterMind
{
    /// <summary>
    /// MasterMind Game
    /// </summary>
    public class Game
    {
        public Game()
        {
            Initialize();
        }

        private const int InitialAttempts = 10;
        private const int AnswerLength = 4;
        private int attemptsLeft;
        internal string answerString;

        /// <summary>
        /// Gameplay for MasterMind game
        /// </summary>
        public void GamePlay()
        {
            Console.WriteLine(Messages.WelcomeMessage);
            Console.WriteLine(Messages.Line);
            Console.WriteLine(Messages.Rules, AnswerLength);

            while (true)
            {
                try
                {
                    Console.WriteLine(Messages.EnterNumber, attemptsLeft);
                    var input = Console.ReadLine();

                    Tools.InputNotNullOrWhiteSpace(input);

                    if (CheckQuit(input))
                    {
                        return;
                    }

                    var response = Guess(input);

                    Console.WriteLine(response.ResponseMessage);

                    if (response.ResponseCode == ResponseCode.Success)
                    {
                        Console.WriteLine(Messages.SuccessRestart);
                        Restart();
                        return;
                    }

                    if (attemptsLeft <= 0)
                    {
                        Console.WriteLine(Messages.AttemptsOver);
                        Restart();
                        return;
                    }
                }
                catch (GameException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Guess the answer once.
        /// </summary>
        /// <param name="guess"></param>
        /// <returns></returns>
        public Response Guess(string guess)
        {
            Tools.CheckInput(guess, AnswerLength);

            attemptsLeft--;

            return Evaluate(guess);
        }

        private void Initialize()
        {
            attemptsLeft = InitialAttempts;
            SetAnswer();
        }

        private void SetAnswer()
        {
            var random = new Random();
            var answerBuilder = new StringBuilder();

            for (var index = 0; index < AnswerLength; index++)
            {
                answerBuilder.Append(random.Next(1, 7));
            }

            answerString = answerBuilder.ToString();
        }

        private Response Evaluate(string guess)
        {
            if (guess.Equals(answerString))
            {
                return new Response
                {
                    ResponseCode = ResponseCode.Success,
                    ResponseMessage = Messages.GuessedRight
                };
            }

            return EvaluateWrongGuess(guess);
        }

        private Response EvaluateWrongGuess(string guess)
        {
            var tempAnswer = answerString.ToCharArray();
            var tempGuess = guess.ToCharArray();
            var message = new StringBuilder();
            var plusCount = 0;
            var minusCount = 0;

            for (var index = 0; index < answerString.Length; index++)
            {
                if (guess[index].Equals(tempAnswer[index]))
                {
                    plusCount++;
                    tempAnswer[index] = '+';
                    tempGuess[index] = 'a';
                }
            }

            for (var index = 0; index < answerString.Length; index++)
            {
                if (tempAnswer.Contains(tempGuess[index]))
                {
                    minusCount++;
                    var minusIndex = Array.IndexOf(tempAnswer, tempGuess[index]);
                    tempAnswer[minusIndex] = '-';
                    tempGuess[index] = 'a';
                }
            }

            message.Append('+', plusCount);
            message.Append('-', minusCount);

            return new Response
            {
                ResponseCode = ResponseCode.GuessError,
                ResponseMessage = message.ToString()
            };
        }

        private void Restart()
        {
            var restart = Console.ReadLine();
            if (restart.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                Initialize();
                GamePlay();
            }
        }

        private bool CheckQuit(string input)
        {
            if (input.Equals("Q", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(Messages.Quit);
                return true;
            }

            return false;
        }
    }
}
