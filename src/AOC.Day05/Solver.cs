using System.Collections.Generic;
using System.Linq;
using AOC.Shared;
using Serilog;

namespace AOC.Day05
{
    public class Solver
    {
        private readonly ILogger _logger = Log.ForContext<Solver>();

        public int RunA(string[] lines)
        {
            using var _ = new DiagnosticHelper("Day05.A");
            var maxSeatId = int.MinValue;

            foreach (var line in lines)
            {
                var (row, column, seatId) = BoardingPassParser.Parse(line);

                maxSeatId = seatId > maxSeatId ? seatId : maxSeatId;
            }

            _logger.Information("Max SeatID: {maxSeatId}", maxSeatId);

            return maxSeatId;
        }

        public int RunB(string[] lines)
        {
            using var _ = new DiagnosticHelper("Day05.B");
            var seats = new List<Seat>();

            foreach (var line in lines)
            {
                var (row, column, seatId) = BoardingPassParser.Parse(line);

                seats.Add(new Seat(row, column, seatId, line));
            }

            seats.Sort((x, y) => x.SeatId.CompareTo(y.SeatId));

            for (var seatId = 0; seatId < 1024; seatId++)
            {
                var seat = seats.FirstOrDefault(x => x.SeatId == seatId);

                if (seat is null)
                {
                    var leftSeatId = seatId - 1;
                    var rightSeatId = seatId + 1;

                    var leftSeat = seats.FirstOrDefault(x => x.SeatId == leftSeatId);

                    if (leftSeat is null)
                    {
                        continue;
                    }

                    var rightSeat = seats.FirstOrDefault(x => x.SeatId == rightSeatId);

                    if (rightSeat is null)
                    {
                        continue;
                    }

                    _logger.Information("Your seat ID: {seatId}", seatId);

                    return seatId;
                }
            }

            return -1;
        }
    }
}
