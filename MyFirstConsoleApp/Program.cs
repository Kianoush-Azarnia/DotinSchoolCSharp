using System;
using dataHelper;

namespace MyFirstConsoleApp
{
    class Program
    {
        static void Main(String[] args)
        {
            var csv = "John,Doe,M,25\nJane,Doe,F,30\nBob,Smith,M,40\nAlice,Smith,F,35";
            var (maleAvgAge, femaleAvgAge) = dataHelper.DataHelper.GetAverageAgeBySex(csv);

            Console.WriteLine($"Male average age: {maleAvgAge}");
            Console.WriteLine($"Female average age: {femaleAvgAge}");

        }

}

}

