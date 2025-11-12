using System;

public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    public string Date
    {
        get { return _date; }
        set { _date = value; }
    }

    public string PromptText
    {
        get { return _promptText; }
        set { _promptText = value; }
    }

    public string EntryText
    {
        get { return _entryText; }
        set { _entryText = value; }
    }

    public Entry()
    {

    }

    // Method to display the entry
    public void Display()
    {
        Console.WriteLine($"\nDate: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"> {_entryText}");
    }

    // Method to get a string representation for saving to a file
    public string GetStringRepresentation()
    {
        // Using the | as a separator character
        return $"{_date}|{_promptText}|{_entryText}";
    }
}