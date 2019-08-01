using MasterMind.DisplayBehaviors;

namespace MasterMind
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(new DisplayOnConsole());
            game.GamePlay();
        }
    }
}
