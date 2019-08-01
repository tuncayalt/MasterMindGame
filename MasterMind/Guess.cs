using System;
using System.Text;
using System.Linq;
using MasterMind.Constants;
using MasterMind.Responses;

namespace MasterMind
{
    internal class Guess
    {
        internal Guess(string input, string answerString, int answerLength)
        {
            _answerString = answerString;
            Tools.CheckInput(input, answerLength);
            Response = Evaluate(input);
        }

        private readonly string _answerString;
        internal Response Response { get; set; }

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
    }
}