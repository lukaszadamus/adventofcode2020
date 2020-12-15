using System;

namespace AOC.Day12
{
    public static class Transform
    {
        public static Location Rotate(this Location location, int degrees, Location around = null)
        {
            around = around is null ? new Location(0, 0) : around;

            var r = degrees * Math.PI / 180;

            var cos = Math.Cos(r);
            var sin = Math.Sin(r);

            var x = (int)Math.Round((cos * (location.X - around.X) - sin * (location.Y - around.Y) + around.X));
            var y = (int)Math.Round((sin * (location.X - around.X) + cos * (location.Y - around.Y) + around.Y));

            return new Location(x, y);
        }
    }
}
