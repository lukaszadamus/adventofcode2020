using System.Collections.Generic;
using System.Linq;

namespace AOC.Day16
{
    public class Input
    {
        public Rules Rules { get; private set; }
        public int[] Ticket { get; private set; }
        public List<int[]> NearbyTickets { get; private set; }
        public List<int>[] ValidPivot { get; private set; }

        private Mode _mode = Mode.Rules;

        public Input(string[] lines)
        {
            Rules = new Rules();
            NearbyTickets = new List<int[]>();

            foreach (var l in lines)
            {
                if (!string.IsNullOrWhiteSpace(l))
                {
                    if (SwitchMode(l))
                    {
                        continue;
                    }

                    switch (_mode)
                    {
                        case Mode.Rules:
                            AddRule(l);
                            break;

                        case Mode.Ticket:
                            AddTicket(l);
                            break;

                        case Mode.NerbyTickets:
                            AddNearbyTicket(l);
                            break;

                        default:
                            break;
                    }
                }
            }

            var validTickets = NearbyTickets
                .Where(x => x.All(x => Rules.IsValidNumber(x)))
                .ToList();


            ValidPivot = new List<int>[Ticket.Length];
            for(var i=0; i<Ticket.Length; i++)
            {
                ValidPivot[i] = new List<int>();
            }

            foreach(var ticket in validTickets)
            {                
                for(var i=0; i<ticket.Length; i++)
                {
                    ValidPivot[i].Add(ticket[i]);
                }
            }
        }

        private void AddRule(string line)
        {
            var p = line.Split(": ");
            var ranges = p[1].Split(" or ");

            foreach (var r in ranges)
            {
                Rules.AddValidRange(p[0], new Range(r));
            }
        }

        private void AddTicket(string line) 
            => Ticket = line.Split(",").Select(x => int.Parse(x)).ToArray();


        private void AddNearbyTicket(string line) 
            => NearbyTickets.Add(line.Split(",").Select(x => int.Parse(x)).ToArray());

        private bool SwitchMode(string line)
        {
            switch (line)
            {
                case "your ticket:":
                    _mode = Mode.Ticket;
                    return true;

                case "nearby tickets:":
                    _mode = Mode.NerbyTickets;
                    return true;

                default:
                    return false;
            }
        }

        private enum Mode
        {
            Rules,
            Ticket,
            NerbyTickets,
        }
    }
}
