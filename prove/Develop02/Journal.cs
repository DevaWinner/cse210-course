using System.Text.Json;

public class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter sw = new StreamWriter(file, append: false))
        {
            foreach (var entry in _entries)
            {
                sw.WriteLine($"{entry.Date}~{entry.PromptText}~{entry.EntryText}");
            }
        }
    }

    public void LoadFromFile(string file)
    {
        _entries.Clear();
        try
        {
            using (StreamReader sr = new StreamReader(file))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split('~');
                    var entry = new Entry(line[0], line[1], line[2]);
                    _entries.Add(entry);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading file: {e.Message}");
        }
    }

    public void SaveToJson(string file)
    {
        string jsonString = JsonSerializer.Serialize(_entries);
        File.WriteAllText(file, jsonString);
    }

    public void LoadFromJson(string file)
    {
        try
        {
            string jsonString = File.ReadAllText(file);
            _entries = JsonSerializer.Deserialize<List<Entry>>(jsonString);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading from JSON: {e.Message}");
        }
    }
}
