namespace AOC.Day04
{
    public class Passport
    {
        public int? BirthYear { get; set; }
        public int? IssueYear { get; set; }
        public int? ExpirationYear { get; set; }
        public int? Height { get; set; }
        public string HeightUnit { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string PassportId { get; set; }
        public string CountryId { get; set; }

        public override string ToString()
        {
            return $"{Tokens.BirthYear}:{BirthYear} {Tokens.IssueYear}:{IssueYear} {Tokens.ExpirationYear}:{ExpirationYear} {Tokens.Height}:{Height} {Tokens.HairColor}:{HairColor} {Tokens.EyeColor}:{EyeColor} {Tokens.PasswordId}:{PassportId} {Tokens.CountryId}:{CountryId}";
        }
    }
}
