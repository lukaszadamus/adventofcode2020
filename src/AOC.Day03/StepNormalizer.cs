namespace AOC.Day03
{
    public class StepNormalizer
    {
        public static (int x, int y) Normalize(int x, int y)
        {
            var a = x;
            var b = y;
            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }
            return (x / a, y / b);
        }

        public static (int x, int y) Normalize(Point point) 
            => Normalize(point.X, point.Y);
    }
}
