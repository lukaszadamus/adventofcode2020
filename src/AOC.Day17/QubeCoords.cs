using System;

namespace AOC.Day17
{
    public class QubeCoords
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }
        public int W { get; private set; }

        public QubeCoords(int x, int y, int z, int w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z, W);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return IsEqual((QubeCoords)obj);
        }

        public override string ToString() 
            => $"x={X}; y={Y}; z={Z}; w={W}";

        private bool IsEqual(QubeCoords qube) 
            => X == qube.X && Y == qube.Y && Z == qube.Z && W == qube.W;

        public QubeCoords ReflectionZ()
            => new QubeCoords(X, Y, 0 - Z, W);

        public QubeCoords ReflectionW()
            => new QubeCoords(X, Y, Z, 0-W);
    }
}
