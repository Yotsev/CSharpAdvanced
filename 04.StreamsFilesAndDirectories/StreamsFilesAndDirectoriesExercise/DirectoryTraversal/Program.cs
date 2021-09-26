using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles(".");

            var filesInfo = new Dictionary<string, Dictionary<string, double>>();

            foreach (var file in files)
            {
                FileInfo info = new FileInfo(file);
                string extension = info.Extension;
                string fileName = info.Name;
                double size = info.Length / 1024.0;

                if (!filesInfo.ContainsKey(extension))
                {
                    filesInfo.Add(extension, new Dictionary<string, double>());
                }

                filesInfo[extension].Add(fileName, size);
            }

            StringBuilder bobTheBuilder = new StringBuilder();

            foreach (var item in filesInfo.OrderByDescending(e => e.Value.Count).ThenBy(e => e.Key))
            {
                bobTheBuilder.AppendLine(item.Key);
                foreach (var file in item.Value.OrderBy(f => f.Value))
                {
                    bobTheBuilder.AppendLine($"--{file.Key} - {file.Value:F2}kb");
                }
            }
            // randomPath - your needed path
            File.WriteAllText("../../../report.txt", bobTheBuilder.ToString());
        }
    }
}
