using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Serilog;

namespace AOC.Day03
{
    public class Map
    {
        private readonly ILogger _logger = Log.ForContext<Map>();

        public char[,] LoadedMap { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public async Task Load(string input)
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

            Load(lines.ToArray());
        }

        public void Load(string[] lines)
        {
            Width = lines[0].Length;
            Height = lines.Length;

            LoadedMap = new char[Width, Height];

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    LoadedMap[j, i] = lines[i][j];
                }
            }

            foreach (var line in lines)
            {
                _logger.Verbose(line);
            }
        }

        public Square GetSquare(Point point)
            => new Square(point, LoadedMap[point.X, point.Y]);
    }
}
