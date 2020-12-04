using System;

namespace AOC.Day04
{
    public static class PasswordUpdater
    {
        public static void Update(string[] tokens, Passport passport)
        {
            if (tokens is null)
            {
                throw new ArgumentNullException(nameof(tokens));
            }

            foreach (var token in tokens)
            {
                Update(token, passport);
            }
        }

        public static void Update(string token, Passport passport)
        {
            if (passport is null)
            {
                throw new ArgumentNullException(nameof(passport));
            }

            var (property, value) = TokenAnalyzer.Parse(token);
            int parsedNumeric;
            switch (property)
            {
                case Tokens.BirthYear:
                    if (int.TryParse(value, out parsedNumeric))
                    {
                        passport.BirthYear = parsedNumeric;
                    }
                    break;

                case Tokens.CountryId:
                    passport.CountryId = value;
                    break;

                case Tokens.ExpirationYear:
                    if (int.TryParse(value, out parsedNumeric))
                    {
                        passport.ExpirationYear = parsedNumeric;
                    }
                    break;

                case Tokens.EyeColor:
                    passport.EyeColor = value;
                    break;

                case Tokens.HairColor:
                    passport.HairColor = value;
                    break;

                case Tokens.Height:
                    var (height, unit) = HeightParser.Parse(value);
                    passport.Height = height;
                    passport.HeightUnit = unit;
                    break;

                case Tokens.IssueYear:
                    if (int.TryParse(value, out parsedNumeric))
                    {
                        passport.IssueYear = parsedNumeric;
                    }
                    break;

                case Tokens.PasswordId:
                    passport.PassportId = value;
                    break;

                default:
                    break;
            }
        }
    }
}
