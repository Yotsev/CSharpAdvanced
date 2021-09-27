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
            string[] targetWords = File.ReadAllLines("../../../words.txt");
            string[] text = File.ReadAllLines("../../../text.txt");

            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            foreach (var line in text)
            {
                string[] currentLine = line
                    .ToLower()
                    .Split(new string[] { "-", ",", ".", "!", "?", " " }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in currentLine)
                {
                    foreach (var target in targetWords)
                    {
                        if (word == target)
                        {
                            if (!wordsCount.ContainsKey(word))
                            {
                                wordsCount.Add(word, 0);
                            }

                            wordsCount[word]++;
                        }
                    }
                }
            }

            List<string> output = new List<string>();

            foreach (var item in wordsCount.OrderByDescending(w => w.Value))
            {
                output.Add($"{item.Key} - {item.Value}");
            }

            File.WriteAllLines("../../../actualResult.txt", output);
        }
    }
}
