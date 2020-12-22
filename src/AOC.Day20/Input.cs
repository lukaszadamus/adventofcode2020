using System.Collections.Generic;
using System.IO;

namespace AOC.Day20
{
    public class Input
    {
        public List<Tile> Tiles { get; set; } = new List<Tile>();

        public Input(string path)
        {
            var lines = File.ReadAllLines(path);
            var q = new Queue<string>();
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    Tiles.Add(new Tile(q));
                }
                else
                {
                    q.Enqueue(line);
                }
            }
            if (q.Count > 0)
            {
                Tiles.Add(new Tile(q));
            }
        }
    }
}
