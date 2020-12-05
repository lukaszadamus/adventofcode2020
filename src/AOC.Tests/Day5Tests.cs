using AOC.Day05;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AOC.Tests
{
    public class Day5Tests : TestBase
    {
        public Day5Tests(ITestOutputHelper output)
            : base(output)
        {
        }

        [Theory]
        [InlineData("BFFFBBFRRR", 70, 7, 567)]
        [InlineData("FFFBBBFRRR", 14, 7, 119)]
        [InlineData("BBFFBBFRLL", 102, 4, 820)]
        public void CanParseBoardingPass(string boardingPass, int expectedRow, int expectedColumn, int expectedSeatId)
        {
            var (row, column, seatId) = BoardingPassParser.Parse(boardingPass);

            row.Should().Be(expectedRow);
            column.Should().Be(expectedColumn);
            seatId.Should().Be(expectedSeatId);
        }
    }
}
