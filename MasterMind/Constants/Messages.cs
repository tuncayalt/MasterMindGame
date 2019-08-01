namespace MasterMind.Constants
{
    public static class Messages
    {
        // Normal messages
        public const string WelcomeMessage = "Welcome to MasterMind!";
        public const string Line = "----------------------";
        public const string Rules = "Please enter a {0} digit number (all digits between 1 and 6) to guess the answer. You can enter Q(q) any time to quit.";
        public const string EnterNumber = "Please enter your guess. You have {0} attempts left.";
        public const string Quit = "Quitting the game.";
        public const string GuessedRight = "You guessed the number correctly! ";
        public const string SuccessRestart = "Enter Y(y) to restart or any key to quit.";

        // Error messages
        public const string InputNullOrWhiteSpace = "You entered an invalid number.";
        public const string NotInteger = "You did not enter a number.";
        public const string NumberOfDigitsError = "The number is not {0} digits.";
        public const string NotBetween1And6 = "The digits must be between 1 and 6.";
        public const string AttemptsOver = "You are out of attempts. Enter Y(y) to restart or any key to quit.";
    }
}
