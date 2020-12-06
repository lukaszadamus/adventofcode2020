using System.Threading.Tasks;
using AOC.Day06;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AOC.Tests
{
    public class Day6Tests : TestBase
    {        
        public Day6Tests(ITestOutputHelper output)
            : base(output)
        {
            
        }
        

        [Fact]        
        public async Task CanSolveA()
        {
            var expected = 11;
            var input = @"abc

a
b
c

ab
ac

a
a
a
a

b";            
            var sut = new Solver();
            var actual = await sut.RunA(input);
            actual.Should().Be(expected);
        }

        [Fact]
        public async Task CanSolveB()
        {
            var expected = 6;
            var input = @"abc

a
b
c

ab
ac

a
a
a
a

b";
            var sut = new Solver();
            var actual = await sut.RunB(input);
            actual.Should().Be(expected);
        }
    }
}
