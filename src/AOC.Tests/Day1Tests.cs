using AOC.Day01;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AOC.Tests
{
    public class Day1Tests : TestBase
    {
        private readonly Solver _sut;
        public Day1Tests(ITestOutputHelper output) 
            : base(output)
        {
            _sut = new Solver();
        }    

        [Theory]
        [InlineData(514579, 1721, 979, 366, 299, 675, 1456)]                
        public void CanSolveA(int expected, params int[] input)
        {
            var actual = _sut.RunA(input);
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(241861950, 1721, 979, 366, 299, 675, 1456)]                
        public void CanSolveB(int expected, params int[] input)
        {
            var actual = _sut.RunB(input);
            actual.Should().Be(expected);
        }
    }
}
