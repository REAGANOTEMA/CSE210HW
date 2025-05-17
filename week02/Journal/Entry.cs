using System;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public Entry(string prompt, string response)
    {
        Date = DateTime.Now.ToShortDateString();
        Prompt = prompt;
        Response = response;
    }

    public string GetDisplayText()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }

    public string GetSavableText()
    {
        return $"{Date}|{Prompt}|{Response}";
    }

    public static Entry FromSavedText(string line)
    {
        string[] parts = line.Split('|');
        return new Entry(parts[1], parts[2]) { Date = parts[0] };
    }
}
