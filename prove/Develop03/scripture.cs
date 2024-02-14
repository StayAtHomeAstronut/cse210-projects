using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
    private Reference reference;
    private string text;
    private List<Word> words;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        this.text = text;
        words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.WriteLine(reference);
        Console.WriteLine(string.Join(" ", words.Select(word => word.IsHidden ? "_____" : word.Text)));
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int visibleWordsCount = words.Count(w => !w.IsHidden);
        int wordsToHide = Math.Min(random.Next(1, 4), visibleWordsCount); // Hide between 1 and 3 words or the remaining visible words

        int wordsHidden = 0;
        while (wordsHidden < wordsToHide)
        {
            int index = random.Next(0, words.Count);
            if (!words[index].IsHidden)
            {
                words[index].Hide();
                wordsHidden++;
            }
        }
    }
    
    public bool AllWordsHidden()
    {
        return words.All(word => word.IsHidden);
    }
}