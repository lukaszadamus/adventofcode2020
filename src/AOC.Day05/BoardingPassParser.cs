using System;

namespace AOC.Day05
{
    public static class BoardingPassParser
    {
        public static (int row, int column, int seatId) Parse(string boardingPass)
        {
            var row = AsInt(boardingPass[..7]);
            var column = AsInt(boardingPass[^3..]);
            var seatId = row * 8 + column;
            return (row, column, seatId);
        }

        private static int AsInt(string input)
            => Convert.ToInt32(ToBinaryLiteral(input), 2);

        private static string ToBinaryLiteral(string input)
            => input.Replace("F", "0").Replace("B", "1").Replace("L", "0").Replace("R", "1").PadLeft(8, '0');
    }
}
