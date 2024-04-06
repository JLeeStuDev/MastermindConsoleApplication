using System;

namespace Mastermind
{
    /// <summary>
    /// Entry point of the Mastermind game console application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method to start the Mastermind game.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mastermind - C# Console Edition!"); // Title message
            Console.WriteLine("Guess the 4-digit number.  Each digit is between 1 and 6.\n"); // Subtitle
            Console.WriteLine("For each guess that you make, a '-' will show for each digit that is correct but in the wrong position.\n" +
                "A '+' will show for each digit that is correct and in the correct position.\n" +
                "Nothing will print out for incorrect digits guessed.\n" +
                "You have 10 attempts to guess the correct number before you lose the game.\n"); // Rules
            Console.WriteLine("System output may not directly correlate '+' and '-' to the digit positions that users' guess."); // Disclaimer

            Game mastermindGame = new Game();
            mastermindGame.StartGame();
        }
    }
}
