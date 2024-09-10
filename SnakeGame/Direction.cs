using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Direction
    {
        public static DirectionType directionType = DirectionType.Right;
        public enum DirectionType 
        {
            Left,
            Up,
            Right,
            Down
        }
    }
}