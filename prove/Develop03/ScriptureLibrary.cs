using System;
using System.Collections.Generic;
using System.Linq;

public class ScriptureLibrary
{
    private List<Scripture> _scriptures;
    private Random _random;

    public ScriptureLibrary()
    {
        _scriptures = new List<Scripture>();
        _random = new Random();
    }

    public void AddScripture(Reference reference, string text)
    {
        _scriptures.Add(new Scripture(reference, text));
    }

    public Scripture GetRandomScripture()
    {
        int index = _random.Next(_scriptures.Count);
        return _scriptures[index];
    }

    public Scripture GetScriptureByIndex(int index)
    {
        if (index < 0 || index >= _scriptures.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }
        return _scriptures[index];
    }

    public int GetScriptureCount()
    {
        return _scriptures.Count;
    }

    public bool AllScripturesMemorized()
    {
        return _scriptures.All(scripture => scripture.IsCompletelyHidden());
    }

    public void ResetMemorization()
    {
        foreach (var scripture in _scriptures)
        {
            scripture.ResetWords();
        }
    }
}
