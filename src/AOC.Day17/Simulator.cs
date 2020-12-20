using System.Collections.Generic;
using System.Linq;

namespace AOC.Day17
{
    public class Simulator
    {
        private readonly EnergySource _energySource;

        public Simulator(EnergySource energySource)
        {
            _energySource = energySource;
        }

        public void PerformCycle3D(int numberOfCycles)
        {
            for (var cycle = 1; cycle <= numberOfCycles; cycle++)
            {
                var changes = new List<(QubeCoords Coords, bool State)>();
                var toCheck = _energySource.Qubes.Where(x => x.Key.Z >= 0 && x.Key.Z <= cycle && x.Key.W == 0);
                foreach (var q in toCheck)
                {
                    changes.AddRange(Check(q.Key, q.Value));
                }

                foreach (var (coords, state) in changes)
                {
                    _energySource.Qubes[coords] = state;
                }
            }
        }

        public void PerformCycle4D(int numberOfCycles)
        {
            for (var cycle = 1; cycle <= numberOfCycles; cycle++)
            {
                var changes = new List<(QubeCoords Coords, bool State)>();
                var toCheck = _energySource.Qubes.Where(x => x.Key.Z >= 0 && x.Key.Z <= cycle && x.Key.W >= 0 && x.Key.W <= cycle);
                foreach (var q in toCheck)
                {
                    changes.AddRange(Check(q.Key, q.Value));
                }

                foreach (var (coords, state) in changes)
                {
                    _energySource.Qubes[coords] = state;
                    if (coords.W > 0)
                    {
                        _energySource.Qubes[coords.ReflectionW()] = state;
                    }
                }
            }
        }

        private List<(QubeCoords Coords, bool State)> Check(QubeCoords Coords, bool State)
        {
            var changes = new List<(QubeCoords Coords, bool State)>();
            var activeCount = _energySource.GetActiveNeighborsCount4D(Coords);

            if (State)
            {
                if (activeCount != 2 && activeCount != 3)
                {
                    changes.Add((Coords, false));

                    if (Coords.Z > 0)
                    {
                        changes.Add((Coords.ReflectionZ(), false));
                    }
                }
            }
            else
            {
                if (activeCount == 3)
                {
                    changes.Add((Coords, true));

                    if (Coords.Z > 0)
                    {
                        changes.Add((Coords.ReflectionZ(), true));
                    }
                }
            }

            return changes;
        }

        public int Active
            => _energySource.Qubes.Where(x => x.Value).Count();
    }
}
