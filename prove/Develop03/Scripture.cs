using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
        _random = new Random();
    }

    public void HideRandomWords(int numberToHide)
    {
        var wordsToHide = _words.Where(word => !word.IsHidden()).ToList();
        if (wordsToHide.Count == 0) return;

        for (int i = 0; i < numberToHide && wordsToHide.Count > 0; i++)
        {
            int index = _random.Next(wordsToHide.Count);
            wordsToHide[index].Hide();
            wordsToHide.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        return $"{_reference.GetDisplayText()}\n" + string.Join(" ", _words.Select(word => word.GetDisplayText()));
    }

    public string GetReferenceText()
    {
        return _reference.GetDisplayText();
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    public void ResetWords()
    {
        foreach (var word in _words)
        {
            word.Show();
        }
    }
}
