using System;
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

        private int attemptsLeft;
        internal string answerString;

        /// <summary>
        /// Game play for MasterMind game
        /// </summary>
        public void GamePlay()
        {
            Console.WriteLine(Messages.WelcomeMessage);
            Console.WriteLine(Messages.Line);
            Console.WriteLine(Messages.Rules, Constant.AnswerLength);

            while (true)
            {
                try
                {
                    Console.WriteLine(Messages.EnterNumber, attemptsLeft);
                    var input = Console.ReadLine();

                    input.InputNotNullOrWhiteSpace();

                    if (CheckQuit(input))
                    {
                        return;
                    }

                    var guess = new Guess(input, answerString);

                    attemptsLeft--;

                    var response = guess.Response;

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

        private void Initialize()
        {
            attemptsLeft = Constant.InitialAttempts;
            SetAnswer();
        }

        private void SetAnswer()
        {
            var random = new Random();
            var answerBuilder = new StringBuilder();

            for (var index = 0; index < Constant.AnswerLength; index++)
            {
                answerBuilder.Append(random.Next(1, 7));
            }

            answerString = answerBuilder.ToString();
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
