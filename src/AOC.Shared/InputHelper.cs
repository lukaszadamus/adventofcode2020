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
    }
}
