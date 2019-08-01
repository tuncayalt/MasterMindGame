using System;

namespace MasterMind.Exceptions
{
    public class GameException : Exception
    {
        public GameException(string message) : base(message)
        {
        }
    }
}
