using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        string[] wordStrings = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        _words = new List<Word>();
        foreach (string wordText in wordStrings)
        {
            _words.Add(new Word(wordText));
        }
    }

    public string GetDisplayText()
    {
        string text = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()} {text}";
    }

    public void HideRandomWords(int numberToHide)
    {
        // 1. Find all words that are NOT yet hidden.
        List<Word> unhiddenWords = _words.Where(w => !w.IsHidden()).ToList();

        // 2. Determine how many words we can actually hide.
        int count = Math.Min(numberToHide, unhiddenWords.Count);

        // 3. Randomly select and hide words from the unhidden list.
        for (int i = 0; i < count; i++)
        {
            // Check if there are still unhidden words to select from
            if (unhiddenWords.Count == 0) break;

            // Select a random index
            int indexToHide = _random.Next(0, unhiddenWords.Count);
            
            // Get the word object and hide it
            Word wordToHide = unhiddenWords[indexToHide];
            wordToHide.Hide();

            // Remove the word from the list so it cannot be selected again in this iteration
            unhiddenWords.RemoveAt(indexToHide);
        }
    }

    public bool IsCompletelyHidden()
    {

        return _words.All(w => w.IsHidden());
    }
}