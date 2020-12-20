using System;
using System.Collections.Generic;
using System.Text;

namespace AOC.Day18
{
    public static class ONP
    {
        public static string[] Convert(string[] tokens, Func<string, int> priority)
        {
            var output = new StringBuilder();
            var stack = new Stack<string>();
            foreach (var t in tokens)
            {
                switch (t)
                {
                    case "(":
                        stack.Push(t);
                        break;

                    case ")":
                        while (stack.Peek() != "(")
                        {
                            Append(stack.Pop());
                        }
                        stack.Pop();
                        break;

                    case "+":
                    case "*":
                        var p = priority(t);
                        while (stack.Count > 0 && priority(stack.Peek()) >= p)
                        {
                            Append(stack.Pop());
                        }
                        stack.Push(t);
                        break;

                    default:
                        Append(t);
                        break;
                }
            }

            while (stack.Count > 0)
            {
                Append(stack.Pop());
            }

            return output.ToString().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            void Append(string t)
            {
                output.Append(t);
                output.Append(' ');
            }
        }

        public static int Priority(string token)
        {
            return token switch
            {
                "+" => 1,
                "*" => 1,
                _ => 0,
            };
        }

        public static int AdvancedMathPriority(string token)
        {
            return token switch
            {
                "+" => 2,
                "*" => 1,
                _ => 0,
            };
        }

        public static long Evaluate(string[] tokens)
        {
            var stack = new Stack<long>();
            foreach (var t in tokens)
            {
                switch (t)
                {
                    case "+":
                    case "*":
                        var a1 = stack.Pop();
                        var a2 = stack.Pop();
                        var r = t switch
                        {
                            "+" => a1 + a2,
                            "*" => a1 * a2,
                            _ => throw new NotImplementedException(),
                        };
                        stack.Push(r);
                        break;

                    default:
                        stack.Push(long.Parse(t));
                        break;
                }
            }
            return stack.Pop();
        }
    }
}
