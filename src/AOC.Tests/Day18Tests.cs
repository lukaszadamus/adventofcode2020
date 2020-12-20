using AOC.Day18;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AOC.Tests
{
    public class Day18Tests : TestBase
    {
        public Day18Tests(ITestOutputHelper output)
            : base(output)
        {
        }

        [Theory]
        [InlineData("1 + 2 * 3 + 4 * 5 + 6", 71)]
        [InlineData("1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [InlineData("2 * 3 + (4 * 5)", 26)]
        [InlineData("5 + (8 * 3 + 9 + 3 * 4 * 3)", 437)]
        [InlineData("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 12240)]
        [InlineData("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 13632)]
        public void CanCalculate(string expression, int expected)
        {
            var tokens = Tokenizer.GetTokens(expression);
            var onpTokens = ONP.Convert(tokens, ONP.Priority);
            var actual = ONP.Evaluate(onpTokens);

            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData("1 + 2 * 3 + 4 * 5 + 6", 231)]
        [InlineData("1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [InlineData("2 * 3 + (4 * 5)", 46)]
        [InlineData("5 + (8 * 3 + 9 + 3 * 4 * 3)", 1445)]
        [InlineData("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 669060)]
        [InlineData("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 23340)]
        public void CanCalculateAdvancedMath(string expression, int expected)
        {
            var tokens = Tokenizer.GetTokens(expression);
            var onpTokens = ONP.Convert(tokens, ONP.AdvancedMathPriority);
            var actual = ONP.Evaluate(onpTokens);

            actual.Should().Be(expected);
        }
    }
}
