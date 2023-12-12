using System;
using System.Collections.Generic; // To use the Stack class

namespace PrintVertical
{
    class Program
    {
        // A stack to store the digits of the number
        static Stack<int> digits = new Stack<int>();

        // A recursive function that takes a number and pushes its digits to the stack
        static void PushDigits(int num)
        {
            // Base case: if the number is zero, do nothing
            if (num == 0)
            {
                return;
            }

            // Recursive case: push the last digit of the number to the stack and then call the function with the number divided by 10
            digits.Push(num % 10);
            PushDigits(num / 10);
        }

        // A function that pops and prints the digits from the stack
        static void PrintDigits()
        {
            // Loop until the stack is empty
            while (digits.Count > 0)
            {
                // Pop and print the top digit from the stack
                Console.WriteLine(digits.Pop());
            }
        }

        static void Main(string[] args)
        {
            // Ask the user for a number
            Console.WriteLine("Please enter a number:");
            int num = int.Parse(Console.ReadLine());

            // Call the push digits function with the number
            PushDigits(num);

            // Call the print digits function
            PrintDigits();
        }
    }
}
