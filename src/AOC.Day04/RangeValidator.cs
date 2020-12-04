namespace AOC.Day04
{
    public static class RangeValidator
    {
        public static bool IsValid(int value, int from, int to)
            => value >= from && value <= to;

        public static bool IsValid(int? value, int from, int to)
        {
            if (!value.HasValue)
            {
                return false;
            }

            return IsValid(value.Value, from, to);
        }
    }
}
