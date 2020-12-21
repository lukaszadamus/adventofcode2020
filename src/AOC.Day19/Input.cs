using System.Collections.Generic;
using System.IO;

namespace AOC.Day19
{
    public class Input
    {
        private readonly bool _readingMessages = false;

        public Dictionary<int, Rule> Rules { get; private set; }
        public List<string> Messages { get; private set; }

        public Input(string path)
        {
            Rules = new Dictionary<int, Rule>();
            Messages = new List<string>();

            foreach (var line in File.ReadAllLines(path))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    _readingMessages = true;
                    continue;
                }

                if (!_readingMessages)
                {
                    ReadRule(line);
                }
                else
                {
                    ReadMEssage(line);
                }
            }
        }

        private void ReadMEssage(string line)
        {
            Messages.Add(line);
        }

        private void ReadRule(string line)
        {
            var idAndDefinitions = line.Split(": ");
            var id = int.Parse(idAndDefinitions[0]);
            var definitions = idAndDefinitions[1].Split(" | ");

            var ids = definitions[0].Split(" ");
            var alternativeIds = definitions.Length > 1 ? definitions[1].Split(" ") : null;

            Rules.Add(id, new Rule(id, ids, alternativeIds));
        }
    }
}
