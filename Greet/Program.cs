using System;

namespace Greeting
{
    class Program
    {
        // A method that takes the first name and last name and returns the initials
        static string Abbrivate(string firstName, string lastName)
        {
            // Get the first character of the first name and the last name
            char firstInitial = firstName[0];
            char lastInitial = lastName[0];

            // Convert them to uppercase
            firstInitial = char.ToUpper(firstInitial);
            lastInitial = char.ToUpper(lastInitial);

            // Return them as a string
            return $"{firstInitial}.{lastInitial}";
        }

        // A method that takes the first name and last name and prints a greeting message
        static void Greet(string firstName, string lastName)
        {
            // Get the current time
            DateTime now = DateTime.Now;

            // Get the hour of the day
            int hour = now.Hour;

            // Get the initials of the name
            string initials = Abbrivate(firstName, lastName);

            // Declare a variable to store the greeting
            string greeting = "";

            // Check the hour and assign the appropriate greeting
            if (hour >= 5 && hour < 12)
            {
                // It is morning
                greeting = "Good morning";
            }
            else if (hour >= 12 && hour < 18)
            {
                // It is afternoon
                greeting = "Good afternoon";
            }
            else if (hour >= 18 && hour < 22)
            {
                // It is evening
                greeting = "Good evening";
            }
            else
            {
                // It is night
                greeting = "Good night";
            }

            // Print the greeting message with the initials
            Console.WriteLine($"{greeting} {initials}!");
        }

        static void Main(string[] args)
        {
            // Ask the user for their first name and last name
            Console.WriteLine("Please enter your first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Please enter your last name:");
            string lastName = Console.ReadLine();

            // Call the greet method with the user's name
            Greet(firstName, lastName);
        }
    }
}
