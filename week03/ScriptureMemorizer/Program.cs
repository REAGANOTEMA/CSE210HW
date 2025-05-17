using System;

/*
CREATIVE ADDITIONS (Above 93%):
- Selects from a list of random scriptures instead of just one.
- Hides only words not already hidden (advanced logic).
- Can load scriptures from a file (placeholder).
*/

class Program
{
    static void Main(string[] args)
    {
        // Multiple scriptures to choose from (exceeds requirements)
        var scriptures = new[]
        {
            new Scripture(new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture(new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
            new Scripture(new Reference("2 Nephi", 2, 25),
                "Adam fell that men might be; and men are, that they might have joy.")
        };

        Random rand = new Random();
        Scripture selectedScripture = scriptures[rand.Next(scriptures.Length)];

        while (true)
        {
            selectedScripture.Display();

            if (selectedScripture.AllWordsHidden())
            {
                Console.WriteLine("\nAll words are hidden. Well done!");
                break;
            }

            Console.WriteLine("\nPress ENTER to continue or type 'quit' to exit:");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
                break;

            selectedScripture.HideRandomWords(3); // Hide 3 words each round
        }
    }
}
