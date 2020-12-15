using System.Collections.Generic;
using AOC.Day14;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AOC.Tests
{
    public class Day14Tests : TestBase
    {
        public Day14Tests(ITestOutputHelper output)
            : base(output)
        {
        }

        [Theory]
        [InlineData("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", 11, 73)]
        [InlineData("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", 101, 101)]
        [InlineData("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", 0, 64)]
        [InlineData("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", 1024, 1024)]
        [InlineData("000000000000000000000000000000000000", 1024, 0)]
        [InlineData("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX1", 33000302, 33000303)]
        [InlineData("XXXXXXXXXXX0000010000111010010010001", 33000302, 554129)]
        [InlineData("11111X110010X0001X1111000X1000111101", 0, 67411624509)]
        public void CanApplyMaskToValue(string mask, ulong input, ulong expected)
        {
            var sut = new ValueMask();
            sut.Set(mask);
            var actual = sut.Apply(input);

            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(2, 4)]
        [InlineData(3, 8)]
        public void CanGeneratePermutations(int length, int expectedCount)
        {
            var actual = Permutations.Generate(length);

            actual.Length.Should().Be(expectedCount);
        }
    }
}
