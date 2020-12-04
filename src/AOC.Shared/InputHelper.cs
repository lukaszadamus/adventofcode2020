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
    }
}
