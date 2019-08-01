using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MasterMind.Constants;
using MasterMind.Exceptions;
using MasterMind.Responses;

namespace MasterMind
{
    internal class Guess
    {
        internal Guess(string input, string answerString)
        {
            _answerString = answerString;
            CheckInput(input);
            Response = Evaluate(input);
        }

        private readonly string _answerString;
        internal Response Response { get; set; }

        private static readonly HashSet<char> ValidNumbers = new HashSet<char>
        {
            '1', '2', '3', '4', '5', '6'
        };

        private Response Evaluate(string guess)
        {
            if (guess.Equals(_answerString))
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
            var tempAnswer = _answerString.ToCharArray();
            var tempGuess = guess.ToCharArray();
            var message = new StringBuilder();
            var plusCount = 0;
            var minusCount = 0;

            for (var index = 0; index < _answerString.Length; index++)
            {
                if (guess[index].Equals(tempAnswer[index]))
                {
                    plusCount++;
                    tempAnswer[index] = '+';
                    tempGuess[index] = 'a';
                }
            }

            for (var index = 0; index < _answerString.Length; index++)
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

        private static void CheckInput(string guess)
        {
            Tools.CheckInteger(guess);
            CheckFormat(guess);
        }

        private static void CheckFormat(string guess)
        {
            if (guess.Length != Constant.AnswerLength)
            {
                throw new GameException(string.Format(Messages.NumberOfDigitsError, Constant.AnswerLength));
            }

            foreach (var ch in guess)
            {
                if (!ValidNumbers.Contains(ch))
                {
                    throw new GameException(Messages.NotBetween1And6);
                }
            }
        }
    }
}