// Author: Reagan Otema
using System;

class Exercise1_Variables
{
    static void Main()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Enter your age: ");
        int age = int.Parse(Console.ReadLine());

        Console.WriteLine($"Hello, {name}! You are {age} years old.");
    }
}
