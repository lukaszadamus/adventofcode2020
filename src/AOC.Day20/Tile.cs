using System;
using System.Collections.Generic;
using System.Text;

namespace AOC.Day20
{
    public class Tile
    {
        public int Id { get; set; }
        public int[,] Pixels { get; set; }
        public List<int> Edges { get; set; }

        public Tile(Queue<string> lines)
        {
            Id = int.Parse(lines.Dequeue().Split(" ")[1].Replace(":", ""));

            Pixels = new int[10, 10];

            for (var y = 0; y < 10; y++)
            {
                var line = lines.Dequeue();
                for (var x = 0; x < 10; x++)
                {
                    Pixels[x, y] = line[x] == '#' ? 1 : 0;
                }
            }

            Edges = new List<int>
            {
                GetTop(0),
                GetRight(9),
                GetBottom(9),
                GetLeft(0),
                GetTop(0, true),
                GetRight(9, true),
                GetBottom(9, true),
                GetLeft(0, true),
            };
        }

        public override string ToString()
        {
            return $"ID: {Id}";
        }

        private int GetTop(int y, bool reverse = false)
        {
            var edge = new StringBuilder();
            for (var x = 0; x < 10; x++)
            {
                edge.Append(Pixels[x, y]);
            }

            return ToResult(edge, reverse);
        }

        private int GetBottom(int y, bool reverse = false)
        {
            var edge = new StringBuilder();
            for (var x = 9; x >= 0; x--)
            {
                edge.Append(Pixels[x, y]);
            }

            return ToResult(edge, reverse);
        }

        private int GetRight(int x, bool reverse = false)
        {
            var edge = new StringBuilder();
            for (var y = 0; y < 10; y++)
            {
                edge.Append(Pixels[x, y]);
            }

            return ToResult(edge, reverse);
        }

        private int GetLeft(int x, bool reverse = false)
        {
            var edge = new StringBuilder();
            for (var y = 9; y >= 0; y--)
            {
                edge.Append(Pixels[x, y]);
            }

            return ToResult(edge, reverse);
        }

        private int ToResult(StringBuilder sb, bool reverse)
        {
            var literal = sb.ToString();

            if (reverse)
            {
                literal = Reverse(literal);
            }

            return Convert.ToInt32(literal, 2);
        }

        private string Reverse(string input)
        {
            var tmp = input.ToCharArray();
            Array.Reverse(tmp);
            return new string(tmp).PadLeft(10, '0');
        }
    }
}
