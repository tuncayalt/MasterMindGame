namespace MasterMind.DisplayBehaviors
{
    /// <summary>
    /// Display behavior of the game.
    /// </summary>
    public interface IDisplayBehavior
    {
        void DisplayLine(string message);
        string GetInput();
    }
}
