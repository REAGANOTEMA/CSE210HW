// Author: Reagan Otema
using System;

class Exercise5_Functions
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        int result = Square(number);
        Console.WriteLine($"The square of {number} is {result}.");
    }

    static int Square(int num)
    {
        return num * num;
    }
}
