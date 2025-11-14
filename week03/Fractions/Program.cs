using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Fractions Project.");

        // --- Testing Representation Methods (GetFractionString and GetDecimalValue) ---
        Console.WriteLine("\n--- Testing Representation Methods ---");

        // 1. Test 1/1 (using no-parameter constructor)
        Fraction fractionOne = new Fraction();
        Console.WriteLine(fractionOne.GetFractionString());
        Console.WriteLine(fractionOne.GetDecimalValue());

        // 2. Test 5/1 (using one-parameter constructor)
        Fraction fractionFive = new Fraction(5);
        Console.WriteLine(fractionFive.GetFractionString());
        Console.WriteLine(fractionFive.GetDecimalValue());

        // 3. Test 3/4 (using two-parameter constructor)
        Fraction fractionThreeFourths = new Fraction(3, 4);
        Console.WriteLine(fractionThreeFourths.GetFractionString());
        Console.WriteLine(fractionThreeFourths.GetDecimalValue());
        
        // 4. Test 1/3 (using two-parameter constructor)
        Fraction fractionOneThird = new Fraction(1, 3);
        Console.WriteLine(fractionOneThird.GetFractionString());
        Console.WriteLine(fractionOneThird.GetDecimalValue());
    }
}