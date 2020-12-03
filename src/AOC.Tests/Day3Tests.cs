using System.Threading.Tasks;
using AOC.Day03;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AOC.Tests
{
    public class Day3Tests : TestBase
    {        
        public Day3Tests(ITestOutputHelper output)
            : base(output)
        {
            
        }
        
        [Theory]
        [InlineData(3, 1, 3, 1)]
        [InlineData(3, 1, 9, 3)]
        public void CanNormalizeStep(int eX, int eY, int x, int y)
        {
            var (aX, aY) = StepNormalizer.Normalize(x, y);

            aX.Should().Be(eX);
            aY.Should().Be(eY);
        }

        [Fact]        
        public async Task CanSolveA()
        {
            var expected = 7;
            var input = @"..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#";            
            var start = new Point(0, 0);
            var next = new Point(3, 1);
            var sut = new Solver();
            var actual = await sut.RunA(input, start, next);
            actual.Should().Be(expected);
        }

        [Fact]
        public async Task CanSolveB()
        {
            var expected = 336;
            var input = @"..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#";
            var start = new Point(0, 0);
            var next =  new[] { new Point(1, 1), new Point(3, 1), new Point(5, 1), new Point(7, 1), new Point(1, 2) };
            var sut = new Solver();
            var actual = await sut.RunB(input, start, next);
            actual.Should().Be(expected);
        }
    }
}
