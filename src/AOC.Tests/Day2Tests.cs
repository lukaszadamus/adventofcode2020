using AOC.Day02;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AOC.Tests
{
    public class Day2Tests : TestBase
    {
        private readonly Solver _sut;

        public Day2Tests(ITestOutputHelper output)
            : base(output)
        {
            _sut = new Solver();
        }

        [Theory]
        [InlineData(2, "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc")]
        public void CanSolveA(int expected, params string[] input)
        {
            var actual = _sut.RunA(input);
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(1, "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc")]
        public void CanSolveB(int expected, params string[] input)
        {
            var actual = _sut.RunB(input);
            actual.Should().Be(expected);
        }
    }
}
