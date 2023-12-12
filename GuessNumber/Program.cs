using System;

namespace GuessNumber
{
    class Program
    {
        // Generate a random number between min and max (inclusive)
        static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max + 1);
        }

        // Check if a number is even or odd
        static string EvenOrOdd(int num)
        {
            if (num % 2 == 0)
            {
                return "even";
            }
            else
            {
                return "odd";
            }
        }

        // Shuffle the digits of a number and return them as a string
        static string ShuffleDigits(int num)
        {
            Random random = new Random();
            char[] digits = num.ToString().ToCharArray();
            for (int i = 0; i < digits.Length; i++)
            {
                int j = random.Next(i, digits.Length);
                char temp = digits[i];
                digits[i] = digits[j];
                digits[j] = temp;
            }
            return new string(digits);
        }

        // Play the game with the given mode and number of guesses
        static void PlayGame(string mode, int guesses)
        {
            // Initialize the game variables
            int min = 0;
            int max = 1000;
            int number = RandomNumber(min, max); // The secret number
            int guess = -1; // The user's guess
            int count = 0; // The number of guesses made
            bool win = false; // Whether the user has won or not
            bool help = false; // Whether the user has used help or not

            // Print the game instructions
            Console.WriteLine($"You have chosen {mode} mode. You have {guesses} guesses to find the secret number between {min} and {max}.");
            Console.WriteLine("Enter your guess or type 'menu' to return to the main menu.");

            // Loop until the user wins, loses, or quits
            while (!win && count < guesses)
            {
                // Read the user's input
                string input = Console.ReadLine();

                // Check if the user wants to quit
                if (input == "menu")
                {
                    Console.WriteLine("Returning to the main menu...");
                    return;
                }

                // Check if the input is a valid number
                if (int.TryParse(input, out guess))
                {
                    // Increment the guess count
                    count++;

                    // Check if the guess is correct
                    if (guess == number)
                    {
                        // The user has won
                        win = true;
                        Console.WriteLine($"You got it! The secret number was {number}.");
                        Console.WriteLine($"You took {count} guesses to find it.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        // The guess is wrong
                        Console.WriteLine("Wrong guess.");

                        // Give feedback based on the mode
                        if (mode == "easy")
                        {
                            // Tell the user if the guess is too high or too low
                            if (guess > number)
                            {
                                Console.WriteLine("Your guess is too high.");
                            }
                            else
                            {
                                Console.WriteLine("Your guess is too low.");
                            }
                        }
                        else if (mode == "normal" || mode == "hard")
                        {
                            if (mode == "normal")
                            {
                                // Tell the user if the guess is too high or too low
                                if (guess > number)
                                {
                                    Console.WriteLine("Your guess is too high.");
                                }
                                else
                                {
                                    Console.WriteLine("Your guess is too low.");
                                }
                            }
                            // Check if the user has lost half of their guesses
                            if (count == guesses / 2)
                            {
                                // Ask the user if they want help
                                Console.WriteLine("You have lost half of your guesses. Do you want help? (y/n)");
                                string answer = Console.ReadLine();

                                // Check the answer
                                if (answer == "y")
                                {
                                    // The user wants help
                                    help = true;

                                    // Deduct two guesses from the user
                                    count += 2;

                                    // Give a hint about the number being even or odd
                                    Console.WriteLine($"The secret number is {EvenOrOdd(number)}.");
                                }
                                else
                                {
                                    // The user does not want help
                                    Console.WriteLine("OK, no help then.");
                                }
                            }

                            // Check if the user has lost three-fourths of their guesses
                            if (count == guesses * 3 / 4)
                            {
                                // Ask the user if they want help
                                Console.WriteLine("You have lost three-fourths of your guesses. Do you want help? (y/n)");
                                string answer = Console.ReadLine();

                                // Check the answer
                                if (answer == "y")
                                {
                                    // The user wants help
                                    help = true;

                                    // Deduct two guesses from the user
                                    count += 2;

                                    // Give a hint about the digits of the number
                                    Console.WriteLine($"The digits of the secret number are {ShuffleDigits(number)}.");
                                }
                                else
                                {
                                    // The user does not want help
                                    Console.WriteLine("OK, no help then.");
                                }
                            }
                        }

                        // Tell the user how many guesses they have left
                        Console.WriteLine($"You have {guesses - count} guesses left.");
                    }
                }
                else
                {
                    // The input is not a valid number
                    Console.WriteLine("Invalid input. Please enter a number or type 'menu' to quit.");
                }
            }

            // Check if the user has lost
            if (!win)
            {
                // The user has lost
                Console.WriteLine($"You have run out of guesses. The secret number was {number}.");
                Console.WriteLine("Game over.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            // Update the best record if the user has won
            if (win)
            {
                // Check if the user has beaten the previous best record or if there is no previous record
                if (count < bestRecord || bestRecord == 0)
                {
                    // Update the best record
                    bestRecord = count;

                    // Update the best mode
                    bestMode = mode;

                    // Update the best help
                    if (help)
                    {
                        bestHelp = "with hints";
                    }
                    else
                    {
                        bestHelp = "without hints";
                    }

                    // Congratulate the user
                    Console.WriteLine("Congratulations! You have set a new best record!");
                }
            }
        }

        // The best record variables
        static int bestRecord = 0; // The minimum number of guesses
        static string bestMode = "None"; // The game mode
        static string bestHelp = "None"; // Whether the user used help or not

        static void Main(string[] args)
        {
            // Print the welcome message
            Console.WriteLine("Welcome to the Guess Number game!");
            Console.WriteLine("In this game, you have to guess a secret number within a certain range and a certain number of guesses.");
            Console.WriteLine("You can choose from three modes: easy, normal, and hard.");
            Console.WriteLine("In easy mode, you can guess as many times as you want and you will get feedback on whether your guess is too high or too low.");
            Console.WriteLine("In normal mode, you have 20 guesses and you can get hints after losing half or three-fourths of your guesses, but each hint will cost you two guesses.");
            Console.WriteLine("In hard mode, you have 10 guesses and the secret number can be any integer. You can also get hints, but they will cost you two guesses as well.");
            Console.WriteLine("You can also keep track of your best record, which is the minimum number of guesses you took to find the secret number in any mode.");
            Console.WriteLine("Have fun and good luck!");

            // Loop until the user quits
            while (true)
            {
                // Print the main menu
                Console.WriteLine("Main menu:");
                Console.WriteLine("1. Play new game");
                Console.WriteLine("2. Exit");
                Console.WriteLine($"Best record: {bestRecord} guesses ({bestMode} mode - {bestHelp})");

                // Read the user's choice
                string choice = Console.ReadLine();

                // Check the choice
                if (choice == "1")
                {
                    // The user wants to play a new game
                    Console.WriteLine("Choose your mode:");
                    Console.WriteLine("1. Easy");
                    Console.WriteLine("2. Normal");
                    Console.WriteLine("3. Hard");

                    // Read the user's mode
                    string mode = Console.ReadLine();

                    // Check the mode
                    if (mode == "1")
                    {
                        // The user chose easy mode
                        PlayGame("easy", int.MaxValue);
                    }
                    else if (mode == "2")
                    {
                        // The user chose normal mode
                        PlayGame("normal", 20);
                    }
                    else if (mode == "3")
                    {
                        // The user chose hard mode
                        PlayGame("hard", 16);
                    }
                    else
                    {
                        // The user entered an invalid mode
                        Console.WriteLine("Invalid mode. Please enter 1, 2, or 3.");
                    }
                }
                else if (choice == "2")
                {
                    // The user wants to exit
                    Console.WriteLine("Thank you for playing. Goodbye!");
                    break;
                }
                else
                {
                    // The user entered an invalid choice
                    Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                }
            }
        }
    }
}

