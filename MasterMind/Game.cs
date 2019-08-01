using System;
using System.Runtime.CompilerServices;
using System.Text;
using MasterMind.Constants;
using MasterMind.DisplayBehaviors;
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
        private readonly IDisplayBehavior _display;

        public Game(IDisplayBehavior display)
        {
            _display = display ?? throw new ArgumentNullException(nameof(display));
            Initialize();
        }

        private int attemptsLeft;
        internal string answerString;

        /// <summary>
        /// Game play for MasterMind game
        /// </summary>
        public void GamePlay()
        {
            _display.DisplayLine(Messages.WelcomeMessage);
            _display.DisplayLine(Messages.Line);
            _display.DisplayLine(string.Format(Messages.Rules, Constant.AnswerLength));

            while (true)
            {
                try
                {
                    _display.DisplayLine(string.Format(Messages.EnterNumber, attemptsLeft));
                    var input = Console.ReadLine();

                    input.InputNotNullOrWhiteSpace();

                    if (CheckQuit(input))
                    {
                        return;
                    }

                    var guess = new Guess(input, answerString);

                    attemptsLeft--;

                    var response = guess.Response;

                    _display.DisplayLine(response.ResponseMessage);

                    if (response.ResponseCode == ResponseCode.Success)
                    {
                        _display.DisplayLine(Messages.SuccessRestart);
                        Restart();
                        return;
                    }

                    if (attemptsLeft <= 0)
                    {
                        _display.DisplayLine(Messages.AttemptsOver);
                        Restart();
                        return;
                    }
                }
                catch (GameException ex)
                {
                    _display.DisplayLine(ex.Message);
                }
                catch (Exception ex)
                {
                    _display.DisplayLine(ex.ToString());
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
                _display.DisplayLine(Messages.Quit);
                return true;
            }

            return false;
        }
    }
}
