using System;
using System.Linq;
using System.Threading.Tasks;

namespace AOC.Day11
{
    public static class Model
    {
        public static (Layout layout, int changes) RoundA(Layout layout)
        {
            return RoundInternal(layout, 4, OccupiedNeighborhood);
        }

        public static (Layout layout, int changes) RoundB(Layout layout)
        {
            return RoundInternal(layout, 5, OccupiedInSight);
        }

        public static (Layout layout, int changes) RoundInternal(Layout layout, int emptyIf, Func<Layout, int, int, int> occupiedCount)
        {
            var changes = 0;
            var nextSeats = new char[layout.Seats.GetLength(0), layout.Seats.GetLength(1)];

            for (var row = 0; row < layout.Seats.GetLength(0); row++)
            {
                for (var column = 0; column < layout.Seats.GetLength(1); column++)
                {
                    if (layout.Seats[row, column] != '#' && layout.Seats[row, column] != 'L')
                    {
                        continue;
                    }

                    var occupied = occupiedCount(layout, row, column);

                    if (layout.Seats[row, column] == 'L' && occupied == 0)
                    {
                        nextSeats[row, column] = '#';
                        changes++;
                    }
                    else if (layout.Seats[row, column] == '#' && occupied >= emptyIf)
                    {
                        nextSeats[row, column] = 'L';
                        changes++;
                    }
                    else
                    {
                        nextSeats[row, column] = layout.Seats[row, column];
                    }
                }
            }
            return (layout with { Seats = nextSeats }, changes);
        }

        public static int OccupiedNeighborhood(Layout layout, int row, int column)
        {
            var neighborhood = new char[,]
            {
                { layout.Seats[row-1, column-1], layout.Seats[row-1, column], layout.Seats[row-1, column+1] },
                { layout.Seats[row, column-1], char.MinValue, layout.Seats[row, column+1] },
                { layout.Seats[row+1, column-1], layout.Seats[row+1, column], layout.Seats[row+1, column+1] },
            };

            var count = 0;
            foreach (var s in neighborhood)
            {
                count += s == '#' ? 1 : 0;
            }
            return count;
        }

        public static int OccupiedInSight(Layout layout, int row, int column)
        {
            var tasks = new Task<int>[]
            {
                Task.Run(() => OccupiedInSightCount(layout, row, column, 0,1)),
                Task.Run(() => OccupiedInSightCount(layout, row, column, 1,1)),
                Task.Run(() => OccupiedInSightCount(layout, row, column, 1,0)),
                Task.Run(() => OccupiedInSightCount(layout, row, column, 1,-1)),
                Task.Run(() => OccupiedInSightCount(layout, row, column, 0,-1)),
                Task.Run(() => OccupiedInSightCount(layout, row, column, -1,-1)),
                Task.Run(() => OccupiedInSightCount(layout, row, column, -1,0)),
                Task.Run(() => OccupiedInSightCount(layout, row, column, -1,1)),
            };

            Task.WaitAll(tasks);

            return tasks.Sum(x => x.Result);
        }

        private static int OccupiedInSightCount(Layout layout, int row, int column, int rowStep, int columnStep)
        {
            var count = 0;
            if (rowStep != 0 && columnStep != 0)
            {
                var ri = row + rowStep;
                var ci = column + columnStep;
                do
                {
                    if (ri < 1 || ci < 1 || ri >= layout.Seats.GetLength(0) || ci >= layout.Seats.GetLength(1))
                    {
                        break;
                    }

                    count += GetCount(layout.Seats[ri, ci]);
                    if (Break(layout.Seats[ri, ci]))
                    {
                        return count;
                    }

                    ri += rowStep;
                    ci += columnStep;
                }
                while (true);
            }
            else if (rowStep == 0)
            {
                for (var c = column + columnStep; c < layout.Seats.GetLength(1) && c > 0; c += columnStep)
                {
                    count += GetCount(layout.Seats[row, c]);
                    if (Break(layout.Seats[row, c]))
                    {
                        return count;
                    }
                }
            }
            else if (columnStep == 0)
            {
                for (var r = row + rowStep; r < layout.Seats.GetLength(0) && r > 0; r += rowStep)
                {
                    count += GetCount(layout.Seats[r, column]);
                    if (Break(layout.Seats[r, column]))
                    {
                        return count;
                    }
                }
            }

            return count;

            static int GetCount(char element)
                => element == '#' ? 1 : 0;

            static bool Break(char element)
                => element == '#' || element == 'L';
        }
    }
}
