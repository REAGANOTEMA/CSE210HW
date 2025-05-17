using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry.GetDisplayText());
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.GetSavableText());
            }
        }
        Console.WriteLine("Journal saved.");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            _entries.Add(Entry.FromSavedText(line));
        }
        Console.WriteLine("Journal loaded.");
    }
}
