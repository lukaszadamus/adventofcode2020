namespace AOC.Day11
{
    public record Layout
    {
        public char[,] Seats { get; init; }

        public Layout(char[,] seats)
            => (Seats) = (seats);

        public Layout(string[] lines)
        {
            var width = lines[0].Length + 2;
            var height = lines.Length + 2;
            Seats = new char[height, width];

            for (var row = 0; row < lines.Length; row++)
            {
                for (var column = 0; column < lines[row].Length; column++)
                {
                    Seats[row + 1, column + 1] = lines[row][column];
                }
            }
        }

        public int CountOccupied()
        {
            var count = 0;
            foreach (var s in Seats)
            {
                count += s == '#' ? 1 : 0;
            }
            return count;
        }
    }
}
