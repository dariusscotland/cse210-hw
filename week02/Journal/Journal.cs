using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    // Method to add a new entry to the journal
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    // Method to display all entries in the journal
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\n--- Your journal is currently empty. ---");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
        Console.WriteLine("\n");
    }

    // Method to save the journal to a file
    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    // Call the Entry method to get the formatted string
                    outputFile.WriteLine(entry.GetStringRepresentation());
                }
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError saving file: {ex.Message}");
        }
    }

    // Method to load the journal from a file
    public void LoadFromFile(string filename)
    {
        try
        {
            // Read all lines from the file
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                // Use the pipe | as the separator
                string[] parts = line.Split('|');

                if (parts.Length == 3)
                {
                    // Create a new Entry object and set its properties
                    Entry entry = new Entry
                    {
                        Date = parts[0],
                        PromptText = parts[1],
                        EntryText = parts[2]
                    };
                    
                    // Add the reconstructed entry to the journal
                    _entries.Add(entry);
                }
            }
            
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"\nFile not found: {filename}. Please check the filename.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError loading file: {ex.Message}");
        }
    }
}