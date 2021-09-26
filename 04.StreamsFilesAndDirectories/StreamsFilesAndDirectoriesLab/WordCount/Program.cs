using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader reader = new StreamReader("words.txt");
            string[] targetwords = reader
                .ReadToEnd().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .ToArray();

            using StreamReader textReader = new StreamReader("text.txt");
            string[] text = textReader.ReadToEnd()
                .Split(new string[] { ".", ",", "!", "?", "-"," ",Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .ToArray();

            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            foreach (var word in text)
            {
                foreach (var targetWord in targetwords)
                {
                    if (word == targetWord)
                    {
                        if (!wordsCount.ContainsKey(word))
                        {
                            wordsCount.Add(word, 0);
                        }
                        wordsCount[word]++;
                    }
                }
            }

            using StreamWriter writer = new StreamWriter("Output.txt");

            foreach (var word in wordsCount.OrderByDescending(w=>w.Value))
            {
                writer.WriteLine($"{word.Key} - {word.Value}");
            }
        }
    }
}
