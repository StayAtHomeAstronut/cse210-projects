using System;
using System.Collections.Generic;
using System.Text;

namespace journal
{
    public class Entry
    {
        public string Response { get; set; }
        public string Prompt { get; set; }
        public string Date { get; set; }

        public Entry(string response, string prompt)
        {
            Response = response;
            Prompt = prompt;
            Date = DateTime.Now.ToString();
        }

        public Entry(string response, string prompt, string date)
        {
            Response = response;
            Prompt = prompt;
            Date = date;
        }

        public void Display()
        {
            Console.WriteLine($"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n");
        }

        public string Export()
        {
            return $"{Date}|{Prompt}|{Response}";
        }
    }
}