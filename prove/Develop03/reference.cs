using System;
using System.Collections.Generic;
using System.Linq;

class Reference
{
    private string Book { get; set; }
    private int StartChapter { get; set; }
    private int EndChapter { get; set; }
    private int StartVerse { get; set; }
    private int EndVerse { get; set; }

    public Reference(string reference)
    {
        ParseReference(reference);
    }

    private void ParseReference(string reference)
    {
        // Split the reference into parts ("Proverbs 3:5-6" becomes ["Proverbs", "3:5-6"])
        string[] parts = reference.Split(' ');

        Book = parts[0];

        string[] chapterVerse = parts[1].Split(':');
        int startChapter = int.Parse(chapterVerse[0]);
        string[] startEndVerse = chapterVerse[1].Split('-');
        int startVerse = int.Parse(startEndVerse[0]);
        int endVerse = startVerse; // If only one verse is specified

        if (startEndVerse.Length > 1)
        {
            // If a range of verses is specified ("3:5-6")
            endVerse = int.Parse(startEndVerse[1]);
        }

        StartChapter = startChapter;
        EndChapter = startChapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        if (StartVerse == EndVerse)
        {
            return $"{Book} {StartChapter}:{StartVerse}";
        }
        else
        {
            return $"{Book} {StartChapter}:{StartVerse}-{EndVerse}";
        }
    }
}