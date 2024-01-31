using System;
using System.Collections.Generic;
using System.Text;

namespace journal
{
    public class Journal
    {
        public List<Entry> Entries { get; set; }

        public Journal()
        {
            Entries = new List<Entry>();
        }

        public Journal(List<Entry> entries)
        {
            Entries = entries;
        }

        public void Display()
        {
            foreach (var entry in Entries)
            {
                entry.Display();
            }
        }

        public void AddEntry(Entry entry)
        {
            Entries.Add(entry);
        }

        public string Export()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var entry in Entries)
            {
                sb.AppendLine(entry.Export());
            }
            return sb.ToString();
        }

        public void Import(string data)
        {
            string[] lines = data.Split('\n');
            foreach (var line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    Entries.Add(new Entry(parts[2], parts[1], parts[0]));
                }
            }
        }
    }
}