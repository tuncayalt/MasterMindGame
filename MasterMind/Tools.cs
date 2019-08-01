using System.Collections.Generic;
using MasterMind.Constants;
using MasterMind.Exceptions;

namespace MasterMind
{
    internal static class Tools
    {
        internal static void CheckInput(string guess, int answerLength)
        {
            var guessInt = CheckInteger(guess);
            CheckFormat(guessInt, answerLength);
        }

        internal static void CheckFormat(int guess, int answerLength)
        {
            if (guess < 1000 || guess >= 10000)
            {
                throw new GameException(string.Format(Messages.NumberOfDigitsError, answerLength));
            }

            var guessString = guess.ToString();

            var set = new HashSet<char>
            {
                '1', '2', '3', '4', '5', '6'
            };

            foreach (var ch in guessString)
            {
                if (!set.Contains(ch))
                {
                    throw new GameException(Messages.NotBetween1And6);
                }
            }
        }

        private static int CheckInteger(string guess)
        {
            if (!int.TryParse(guess, out var guessedNumber))
            {
                throw new GameException(Messages.NotInteger);
            }

            foreach (var ch in guess)
            {
                if (!char.IsDigit(ch))
                {
                    throw new GameException(Messages.NotInteger);
                }
            }

            return guessedNumber;
        }

        internal static void InputNotNullOrWhiteSpace(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new GameException(Messages.InputNullOrWhiteSpace);
            }
        }
    }
}
