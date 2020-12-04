namespace AOC.Day04
{
    public static class Tokenizer
    {
        public static string[] GetTokens(string line, char splitBy = ' ')
        {
            return line.Split(splitBy);
        }
    }
}
