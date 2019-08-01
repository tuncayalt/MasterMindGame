using MasterMind.Constants;
using MasterMind.Exceptions;

namespace MasterMind
{
    internal static class Tools
    {
        internal static void CheckInteger(string guess)
        {
            if (!int.TryParse(guess, out _))
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
        }

        internal static void InputNotNullOrWhiteSpace(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new GameException(Messages.InputNullOrWhiteSpace);
            }
        }
    }
}
