using System;

namespace AOC.Day04
{
    public static class Scanner
    {
        public static bool ScanAndUpdate(string line, Passport passport)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                return true;
            }

            if (passport is null)
            {
                throw new ArgumentNullException(nameof(passport));
            }

            var tokens = Tokenizer.GetTokens(line);

            PasswordUpdater.Update(tokens, passport);

            return false;
        }
    }
}
