namespace AOC.Day12
{
    public record Location
    {
        public long X { get; init; }
        public long Y { get; init; }

        public Location(long x, long y)
            => (X, Y) = (x, y);
    }
}
