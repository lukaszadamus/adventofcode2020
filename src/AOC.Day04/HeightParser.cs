namespace AOC.Day04
{
    public static class HeightParser
    {
        public static (int? height, string unit) Parse(string value)
        {
            string unit = value[^2..];
            if (HeightUnitValidator.IsValid(unit))
            {
                if (int.TryParse(value[0..^2], out int height))
                {
                    return (height, unit);
                }
            }
            else
            {
                if (int.TryParse(value[0..], out int height))
                {
                    return (height, null);
                }
            }

            return (null, unit);
        }
    }
}
