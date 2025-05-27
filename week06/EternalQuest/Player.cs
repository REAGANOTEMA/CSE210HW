using System;
using System.Collections.Generic;

public class Player
{
    public int TotalPoints { get; private set; }
    private List<string> _badges = new List<string>();

    public void AddPoints(int points)
    {
        TotalPoints += points;
        UpdateLevelAndBadges();
    }

    public string GetLevel()
    {
        if (TotalPoints < 1000) return "Novice";
        if (TotalPoints < 5000) return "Hero";
        return "Legend";
    }

    private void UpdateLevelAndBadges()
    {
        if (TotalPoints >= 1000 && !_badges.Contains("1000 Points Badge"))
        {
            _badges.Add("1000 Points Badge");
            Console.WriteLine("🏅 You earned the '1000 Points Badge'!");
        }
        if (TotalPoints >= 5000 && !_badges.Contains("5000 Points Badge"))
        {
            _badges.Add("5000 Points Badge");
            Console.WriteLine("🏅 You earned the '5000 Points Badge'!");
        }
    }

    public void ShowStatus()
    {
        Console.WriteLine($"Total Points: {TotalPoints} | Level: {GetLevel()}");
        Console.WriteLine("Badges: " + (_badges.Count > 0 ? string.Join(", ", _badges) : "None"));
    }
}
