// Author: Reagan Otema
using System;
using System.Collections.Generic;

class Exercise4_Lists
{
    static void Main()
    {
        List<string> fruits = new List<string>();

        Console.WriteLine("Enter 3 fruits:");
        for (int i = 0; i < 3; i++)
        {
            Console.Write("Fruit: ");
            fruits.Add(Console.ReadLine());
        }

        Console.WriteLine("\nYou entered:");
        foreach (string fruit in fruits)
        {
            Console.WriteLine(fruit);
        }
    }
}
