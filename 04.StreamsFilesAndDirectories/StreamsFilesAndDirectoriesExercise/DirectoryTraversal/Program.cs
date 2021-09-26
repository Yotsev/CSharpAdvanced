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

            var filesInfo = new Dictionary<string, Dictionary<string, long>>();

            foreach (var file in files)
            {
                FileInfo info = new FileInfo(file);
                string extension = info.Extension;
                string fileName = info.Name;
                long size = info.Length/1024;

                if (!filesInfo.ContainsKey(extension))
                {
                    filesInfo.Add(extension, new Dictionary<string, long>());
                }

                filesInfo[extension].Add(fileName, size);
            }

            StringBuilder bobTheBuilder = new StringBuilder();

            foreach (var item in filesInfo.OrderByDescending(e => e.Value.Count).ThenBy(e => e.Key))
            {
                bobTheBuilder.AppendLine(item.Key);
                foreach (var file in item.Value.OrderBy(f=>f.Value))
                {
                    bobTheBuilder.AppendLine($"--{file.Key} - {file.Value}kb");
                }
            }
            // randomPath - your needed path
            File.WriteAllText("randomPath", bobTheBuilder.ToString());
        }
    }
}
