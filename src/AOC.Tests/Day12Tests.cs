using AOC.Day12;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AOC.Tests
{
    public class Day12Tests : TestBase
    {
        public Day12Tests(ITestOutputHelper output)
            : base(output)
        {
        }

        [Theory]
        [InlineData(0, 0, 2, 0, 90, 0, 2)]
        [InlineData(0, 0, 10, -1, 90, 1, 10)]
        [InlineData(3, -2, 7, -4, 90, 5, 2)]
        public void CanRotate(int x0, int y0, int x1, int y1, int degrees, int ex, int ey)
        {
            var center = new Location(x0, y0);
            var location = new Location(x1, y1);
            var actual = location.Rotate(degrees, center);

            actual.X.Should().Be(ex);
            actual.Y.Should().Be(ey);
        }
    }
}
