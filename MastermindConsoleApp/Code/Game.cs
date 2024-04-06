using System;

namespace Mastermind
{
    /// <summary>
    /// Represents the Mastermind game logic.
    /// </summary>
    internal class Game
    {
        private int[] secretCode;

        /// <summary>
        /// Starts the Mastermind game.
        /// </summary>
        public void StartGame()
        {
            GenerateSecretCode();

            // Sets the max attempts for the game and keeps track of what attempt the player is at
            for (int attempts = 1; attempts <= 10; attempts++)
            {
                Console.WriteLine($"\nAttempt {attempts}: ");
                Console.WriteLine("Enter your guess: ");
                string guessString = Console.ReadLine();

                int[] guess = ParseGuess(guessString);
                if (guess == null) // If the guess comes back as null after error checking the attempt count does not iterate
                {
                    attempts--;
                    continue;
                }

                // Runs if player guesses correctly
                if (IsCorrectGuess(guess))
                {
                    Console.WriteLine("\nCongratulations! You guessed the correct number!");
                    PrintArray(secretCode);
                    if (PlayAgain())
                    {
                        StartGame(); // Restarts the game if the player wants to play again.
                    }
                    else
                    {
                        return; // Exits the game if the player doesn't want to play again.
                    }
                }
                // Runs if the player does not guess correctly
                else
                {
                    PrintHint(guess);
                }
            }

            // runs if the player has run out of attempts without guessing correctly.
            Console.WriteLine("\nSorry, you've used all your attempts.  \nThe correct number was: ");
            PrintArray(secretCode);
            if (PlayAgain())
            {
                StartGame(); // Restarts the game if the player wants to play again.
            }
            else
            {
                return; // Exits the game if the player doesn't want to play again.
            }
        }

        /// <summary>
        /// Generates a random 4-digit secret code for the game.
        /// </summary>
        private void GenerateSecretCode()
        {
            // makes an array of 4 random digits between 1 and 6
            Random random = new Random();
            secretCode = new int[4];
            for (int i = 0; i < 4; i++)
            {
                secretCode[i] = random.Next(1, 7);
            }
        }

        /// <summary>
        /// Asks the player if they want to play the game again.
        /// </summary>
        /// <returns>True if the player wants to play again; otherwise, false.</returns>
        private bool PlayAgain()
        {
            Console.WriteLine("\nDo you want to play again? (yes/no): ");
            string response = Console.ReadLine().Trim().ToLower();
            return response == "yes";
        }

        /// <summary>
        /// Parses the user input string into an integer array representing the guess.
        /// </summary>
        /// <param name="guessString">The string input by the player.</param>
        /// <returns>An integer array representing the player's guess.</returns>
        private int[] ParseGuess(string guessString)
        {
            // Error Handling for length of guess
            int[] guess = new int[4];
            if (guessString.Length != 4)
            {
                Console.WriteLine("Invalid Input. Please enter a 4-digit number.");
                return null;
            }

            // Error Handling for digits inputted
            for (int i = 0; i < 4; i++)
            {
                if (!int.TryParse(guessString[i].ToString(), out guess[i]) || guess[i] < 1 || guess[i] > 6)
                {
                    Console.WriteLine("Invalid Input. Please enter a 4-digit number with digits between 1 and 6.");
                    return null;
                }
            }
            return guess;
        }

        /// <summary>
        /// Checks if the player's guess matches the secret code.
        /// </summary>
        /// <param name="guess">The player's guess.</param>
        /// <returns>True if the guess is correct; otherwise, false.</returns>
        private bool IsCorrectGuess(int[] guess)
        {
            // Checks the guess to see if it is correct or not
            for (int i = 0; i < 4; i++)
            {
                if (secretCode[i] != guess[i])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Prints the hint based on the player's guess.
        /// </summary>
        /// <param name="guess">The player's guess.</param>
        private void PrintHint(int[] guess)
        {
            int correctPositions = 0;
            int incorrectPositions = 0;

            // Check for correct digits in correct positions
            for (int i = 0; i < 4; i++)
            {
                if (secretCode[i] == guess[i])
                {
                    correctPositions++;
                    guess[i] = -1; // Mark this digit as used
                }
            }

            // Check for correct digits in the wrong position
            for (int i = 0; i < 4; i++)
            {
                if (guess[i] == -1) continue; // Skip digits already checked
                for (int j = 0; j < 4; j++)
                {
                    if (secretCode[j] == guess[i])
                    {
                        incorrectPositions++;
                        guess[i] = -1; // Mark this digit as used
                        break;
                    }
                }
            }

            // Print the hint
            Console.WriteLine("Hint: ");
            for (int i = 0; i < correctPositions; i++) // Prints '+' first
            {
                Console.Write("+");
            }
            for (int i = 0; i < incorrectPositions; i++) // Prints '-' Second
            {
                Console.Write("-");
            }
            Console.WriteLine("");
        }

        /// <summary>
        /// Prints the elements of an array.
        /// </summary>
        /// <param name="array">The array to print.</param>
        private void PrintArray(int[] array)
        {
            foreach (int element in array)
            {
                Console.Write(element);
            }
        }
    }
}
