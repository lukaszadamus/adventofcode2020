using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AOC.Shared
{
    public static class InputHelper
    {
        public static async Task<int[]> LinesAsIntegers(string path)
        {            
            var integers = new List<int>();
            foreach(var line in await Lines(path))
            {
                integers.Add(int.Parse(line));            
            }
            return integers.ToArray();
        }

        public static Task<string[]> Lines(string path)
        {
            return File.ReadAllLinesAsync(path);
        }

        public static Task<string[]> GroupedLines(string path)
        {
            return File.ReadAllLinesAsync(path);
        }

        public static Task<string> Text(string path)
        {
            return File.ReadAllTextAsync(path);
        }

        public async static Task<string[]> ToLines(string input)
        {
            var lines = new List<string>();
            using (var reader = new StringReader(input))
            {
                string line;

                while ((line = await reader.ReadLineAsync()) != null)
                {
                    lines.Add(line);
                }
            }

            return lines.ToArray();
        }

        public async static Task<IEnumerable<string[]>> GroupLines(string input, Func<string, bool> isGropuSeparator) 
            => GroupLines(await ToLines(input), isGropuSeparator);

        public static IEnumerable<string[]> GroupLines(string[] lines, Func<string, bool> isGropuSeparator)
        {            
            var groups = new List<string[]>();
            var group = new List<string>();
            foreach (var line in lines)
            {
                if (isGropuSeparator(line))
                {
                    groups.Add(group.ToArray());
                    group = new List<string>();                    
                }
                else
                {
                    group.Add(line);
                }
            }
            groups.Add(group.ToArray());

            return groups;
        }
    }
}
