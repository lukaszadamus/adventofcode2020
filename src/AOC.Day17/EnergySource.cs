using System.Collections.Generic;

namespace AOC.Day17
{
    public class EnergySource
    {
        public Dictionary<QubeCoords, bool> Qubes { get; private set; }

        public EnergySource(string[] lines, int numberOfCycles)
        {
            Qubes = new Dictionary<QubeCoords, bool>();
            var minW = -numberOfCycles;
            var maxW = numberOfCycles;
            var minZ = -numberOfCycles;
            var maxZ = numberOfCycles;
            var minY = -numberOfCycles;
            var maxY = numberOfCycles + lines.Length;
            var minX = -numberOfCycles;
            var maxX = numberOfCycles + lines[0].Length;

            for (var w = minW; w <= maxW; w++)
            {
                for (var z = minZ; z <= maxZ; z++)
                {
                    for (var y = minY; y <= maxY; y++)
                    {
                        for (var x = minX; x <= maxX; x++)
                        {
                            Qubes.Add(new QubeCoords(x, y, z, w), false);
                        }
                    }
                }
            }

            for (var y = 0; y < lines.Length; y++)
            {
                for (var x = 0; x < lines[y].Length; x++)
                {
                    Qubes[new QubeCoords(x, y, 0, 0)] = lines[y][x] == '#';
                }
            }
        }

        public int GetActiveNeighborsCount3D(QubeCoords qube, int w = 0)
        {
            var count = 0;

            for (var z = -1; z <= 1; z++)
            {
                for (var y = -1; y <= 1; y++)
                {
                    for (var x = -1; x <= 1; x++)
                    {
                        var q = new QubeCoords(qube.X + x, qube.Y + y, qube.Z + z, qube.W + w);
                        if (!q.Equals(qube) && Qubes.ContainsKey(q))
                        {
                            count += Qubes[q] ? 1 : 0;
                        }
                    }
                }
            }
            
            return count;
        }

        public int GetActiveNeighborsCount4D(QubeCoords qube)
        {
            var count = 0;

            for (var w = -1; w <= 1; w++)
            {
                count += GetActiveNeighborsCount3D(qube, w);
            }
            return count;
        }
    }
}
