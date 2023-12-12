using System;

namespace RecMultiply
{
    class Program
    {
        // A function that takes two integers and returns their product using addition and recursion
        static int Multiply(int a, int b)
        {
            // Base case: if either a or b is zero, the product is zero
            if (a == 0 || b == 0)
            {
                return 0;
            }

            // Recursive case: if b is positive, add a to the product of a and b-1
            if (b > 0)
            {
                return a + Multiply(a, b - 1);
            }

            // Recursive case: if b is negative, subtract a from the product of a and b+1
            if (b < 0)
            {
                return -a + Multiply(a, b + 1);
            }

            // This line should never be reached
            return 0;
        }

        static void Main(string[] args)
        {
            // Ask the user for a and b
            Console.WriteLine("Please enter the first number:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the second number:");
            int b = int.Parse(Console.ReadLine());

            // Call the multiply function with a and b
            int result = Multiply(a, b);

            // Print the result
            Console.WriteLine($"The product of {a} and {b} is {result}.");
        }
    }
}