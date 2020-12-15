using System;

namespace AOC.Day12
{
    public class Ship
    {
        private char _facting;
        private Location _current;
        private Location _waypoint;

        public Ship(char facing, Location waypoint = null)
        {
            _facting = facing;
            _current = new Location(0, 0);
            _waypoint = waypoint;
        }

        public void Move(string instruction)
        {
            var action = instruction[0];
            var value = int.Parse(instruction[1..]);

            _current = action switch
            {
                'F' => MoveInternal(_facting, value, _current),
                'R' => Turn(action, value),
                'L' => Turn(action, value),
                _ => MoveInternal(action, value, _current),
            };
        }

        public void MoveWaypoint(string instruction)
        {
            var action = instruction[0];
            var value = int.Parse(instruction[1..]);

            _waypoint = action switch
            {
                'F' => MoveToWaypoint(value),
                'R' => RotateWaypoint(action, value),
                'L' => RotateWaypoint(action, value),
                _ => MoveInternal(action, value, _waypoint),
            };
        }

        public Location Current => _current;

        private Location MoveToWaypoint(int value)
        {
            _current = _current with { X = _current.X + (_waypoint.X * value), Y = _current.Y + (_waypoint.Y * value) };            
            return _waypoint;
        }

        private Location Turn(char direction, int degrees)
        {
            var left = _facting switch
            {
                'N' => "NWSE",
                'E' => "ENWS",
                'S' => "SENW",
                'W' => "WSEN",
                _ => throw new NotImplementedException(),
            };

            var right = _facting switch
            {
                'N' => "NESW",
                'E' => "ESWN",
                'S' => "SWNE",
                'W' => "WNES",
                _ => throw new NotImplementedException(),
            };

            _facting = (direction == 'L' ? left : right)[degrees / 90 % 4];
            return _current;
        }

        private Location RotateWaypoint(char direction, int degrees)
            => _waypoint.Rotate(direction == 'R' ? 360 - degrees : degrees);

        private Location MoveInternal(char action, int value, Location toMove)
            => action switch
            {
                'N' => toMove with { Y = toMove.Y + value },
                'S' => toMove with { Y = toMove.Y - value },
                'E' => toMove with { X = toMove.X + value },
                'W' => toMove with { X = toMove.X - value },
                _ => toMove,
            };
    }
}
