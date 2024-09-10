using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public struct Position
    {
        private int _posX;
        private int _posY;

        public Position(int posY, int posX)
        {
            _posY = posY;
            _posX = posX;
        }

        public int GetCoordsPosY()
        {
            return _posY;
        }
        public int GetCoordsPosX() 
        {
            return _posX;
        }
    }
}