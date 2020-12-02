using System;
using System.Linq;

namespace AOC.Day02
{
    public static class PasswordValidator
    {
        public static bool IsValid(Policy policy, string password)
        {
            if (policy is null)
            {
                throw new ArgumentNullException(nameof(policy));
            }

            if (password is null)
            {
                throw new ArgumentNullException(nameof(password));
            }
            var count = password.Count(x => x == policy.Character);

            return policy.Min <= count && count <= policy.Max;
        }

        public static bool IsValid(TobogganPolicy policy, string password)
        {
            if (policy is null)
            {
                throw new ArgumentNullException(nameof(policy));
            }

            if (password is null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            var normalizedPositionA = policy.PositionA - 1;
            var normalizedPositionB = policy.PositionB - 1;

            return password[normalizedPositionA] == policy.Character && password[normalizedPositionB] != policy.Character
                || password[normalizedPositionA] != policy.Character && password[normalizedPositionB] == policy.Character;
        }
    }
}
