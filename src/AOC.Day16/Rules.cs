using System.Collections.Generic;

namespace AOC.Day16
{
    public class Rules
    {
        private readonly HashSet<int> _validNumbers;
        public Dictionary<string, HashSet<int>> ValidRanges { get; private set; }

        public Rules()
        {
            _validNumbers = new HashSet<int>();
            ValidRanges = new Dictionary<string, HashSet<int>>();
        }

        public void AddValidRange(string label, Range range)
        {
            if (!ValidRanges.ContainsKey(label))
            {
                ValidRanges.Add(label, new HashSet<int>());
            }            

            for(var i=range.From; i<=range.To; i++)
            {
                if (!_validNumbers.Contains(i))
                {
                    _validNumbers.Add(i);
                }

                ValidRanges[label].Add(i);
            }
        }

        public bool IsValidNumber(int number)
            => _validNumbers.Contains(number);

        public bool IsInRange(string label, int number)
            => ValidRanges[label].Contains(number);

    }
}
