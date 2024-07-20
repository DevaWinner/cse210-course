using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public static class GoalFileHandler
{
    public static void SaveToFile(string fileName, int score, List<Goal> goals)
    {
        var data = new SaveData
        {
            Score = score,
            Goals = new List<GoalData>()
        };

        foreach (var goal in goals)
        {
            var goalData = new GoalData
            {
                Type = goal.GetType().Name,
                Data = JsonSerializer.Serialize(goal, new JsonSerializerOptions { WriteIndented = true, IncludeFields = true })
            };
            data.Goals.Add(goalData);
        }

        var options = new JsonSerializerOptions { WriteIndented = true, IncludeFields = true };
        string jsonString = JsonSerializer.Serialize(data, options);
        File.WriteAllText(fileName, jsonString);
    }

    public static (int, List<Goal>) LoadFromFile(string fileName)
    {
        string jsonString = File.ReadAllText(fileName);
        var data = JsonSerializer.Deserialize<SaveData>(jsonString, new JsonSerializerOptions { IncludeFields = true });

        var goals = new List<Goal>();
        foreach (var goal in data.Goals)
        {
            switch (goal.Type)
            {
                case "SimpleGoal":
                    var simpleGoal = JsonSerializer.Deserialize<SimpleGoal>(goal.Data, new JsonSerializerOptions { IncludeFields = true });
                    goals.Add(simpleGoal);
                    break;
                case "EternalGoal":
                    var eternalGoal = JsonSerializer.Deserialize<EternalGoal>(goal.Data, new JsonSerializerOptions { IncludeFields = true });
                    goals.Add(eternalGoal);
                    break;
                case "ChecklistGoal":
                    var checklistGoal = JsonSerializer.Deserialize<ChecklistGoal>(goal.Data, new JsonSerializerOptions { IncludeFields = true });
                    goals.Add(checklistGoal);
                    break;
            }
        }

        return (data.Score, goals);
    }

    private class SaveData
    {
        public int Score { get; set; }
        public List<GoalData> Goals { get; set; }
    }

    private class GoalData
    {
        public string Type { get; set; }
        public string Data { get; set; }
    }
}
