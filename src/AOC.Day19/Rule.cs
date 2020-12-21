using System;
using System.Collections.Generic;

namespace AOC.Day19
{
    public class Rule
    {
        public int Id { get; set; }
        public List<int> RuleIds { get; set; }
        public List<int> AlternativeRuleIds { get; set; }
        public string Literal { get; private set; }

        public Rule(int id, string[] ids, string[] alternativeIds)
        {
            Id = id;
            if (ids is not null)
            {
                RuleIds = new List<int>();
                foreach (var i in ids)
                {
                    if (int.TryParse(i, out var parsed))
                    {
                        RuleIds.Add(parsed);
                    }
                    else
                    {
                        RuleIds = null;
                        AlternativeRuleIds = null;
                        Literal = i.Replace("\"", "");
                    }
                }
            }
            if (alternativeIds is not null)
            {
                AlternativeRuleIds = new List<int>();
                foreach (var i in alternativeIds)
                {
                    AlternativeRuleIds.Add(int.Parse(i));
                }
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return IsEqual((Rule)obj);
        }

        private bool IsEqual(Rule rule)
            => Id == rule.Id;
    }
}
