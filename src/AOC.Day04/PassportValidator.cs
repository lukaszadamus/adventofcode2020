using Serilog;

namespace AOC.Day04
{
    public static class PassportValidator
    {
        private static readonly ILogger _logger = Log.ForContext("loggerName", "PassportValidator");

        public static bool IsValid(Passport passport)
        {
            if (passport is null)
            {
                _logger.Verbose("Passport is null");
                return false;
            }

            if (passport.BirthYear is null)
            {
                _logger.Verbose("Missing BirthYear");
                return false;
            }

            if (passport.ExpirationYear is null)
            {
                _logger.Verbose("Missing ExpirationYear");
                return false;
            }

            if (passport.EyeColor is null)
            {
                _logger.Verbose("Missing EyeColor");
                return false;
            }

            if (passport.HairColor is null)
            {
                _logger.Verbose("Missing HairColor");
                return false;
            }

            if (passport.Height is null)
            {
                _logger.Verbose("Missing Height");
                return false;
            }

            if (passport.IssueYear is null)
            {
                _logger.Verbose("Missing IssueYear");
                return false;
            }

            if (passport.PassportId is null)
            {
                _logger.Verbose("Missing PassportId");
                return false;
            }

            return true;
        }

        public static bool IsValidEnhanced(Passport passport)
        {
            if (!IsValid(passport))
            {
                return false;
            }

            if (!RangeValidator.IsValid(passport.BirthYear, 1920, 2002))
            {
                _logger.Verbose("BirthYear not in range, value:{value} range:{from}-{to}", passport.BirthYear, 1920, 2002);
                return false;
            }

            if (!RangeValidator.IsValid(passport.IssueYear, 2010, 2020))
            {
                _logger.Verbose("IssueYear not in range, value:{value} range:{from}-{to}", passport.IssueYear, 2010, 2020);
                return false;
            }

            if (!RangeValidator.IsValid(passport.ExpirationYear, 2020, 2030))
            {
                _logger.Verbose("ExpirationYear not in range, value:{value} range:{from}-{to}", passport.ExpirationYear, 2020, 2030);
                return false;
            }

            var isHeighValid = passport.HeightUnit switch
            {
                HeightUnits.Cm => RangeValidator.IsValid(passport.Height, 150, 193),
                HeightUnits.In => RangeValidator.IsValid(passport.Height, 59, 76),
                _ => false,
            };

            if (!isHeighValid)
            {
                _logger.Verbose("Height invalid, value:{value} unit:{unit}", passport.Height, passport.HeightUnit);
                return false;
            }

            if (!HairColorValidator.IsValid(passport.HairColor))
            {
                _logger.Verbose("HairColor invalid, value:{value}", passport.HairColor);
                return false;
            }

            if (!EyeColorValidator.IsValid(passport.EyeColor))
            {
                _logger.Verbose("EyeColor invalid, value:{value}", passport.EyeColor);
                return false;
            }

            if (!PassportIdValidator.IsValid(passport.PassportId))
            {
                _logger.Verbose("PassportId invalid, value:{value}", passport.PassportId);
                return false;
            }

            return true;
        }
    }
}
