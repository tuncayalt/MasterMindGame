using System;

namespace MasterMind.DisplayBehaviors
{
    public class DisplayOnConsole : IDisplayBehavior
    {
        /// <summary>
        /// Displays on the console.
        /// </summary>
        /// <param name="message"></param>
        public void DisplayLine(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Gets input from Console.
        /// </summary>
        /// <returns></returns>
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
