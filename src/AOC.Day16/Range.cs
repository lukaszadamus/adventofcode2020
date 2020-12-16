namespace AOC.Day16
{
    public record Range
    {
        public int From { get; init; }
        public int To { get; init; }

        public Range(int from, int to)
            => (From, To) = (from, to);

        public Range(string range)
        {
            var p = range.Split("-");
            From = int.Parse(p[0]);
            To = int.Parse(p[1]);
        }        
    }
}
