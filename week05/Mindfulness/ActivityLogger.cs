using System;
using System.Collections.Generic;
using System.IO;

class ActivityLogger
{
    private List<string> logs = new List<string>();

    public void Log(string activityName, int duration)
    {
        logs.Add($"{DateTime.Now}: {activityName} for {duration} seconds");
    }

    public void SaveLog()
    {
        File.AppendAllLines("activity_log.txt", logs);
    }
}