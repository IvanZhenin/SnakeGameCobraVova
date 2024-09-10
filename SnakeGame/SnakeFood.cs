using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class SnakeFood
    {
        public static int Score = 0;
        public static Position FoodCoords;
        private static bool _checkFreePosForFood = false;
        public static void CreateFood()
        {
            Random random = new Random();
            _checkFreePosForFood = true;
            do
            {
                SnakeFood.FoodCoords = new Position(random.Next(0, SnakeGround.GroudSize), random.Next(0, SnakeGround.GroudSize));
                _checkFreePosForFood = (!SnakeBody.snakeElem.Any(snake => SnakeFood.FoodCoords.GetCoordsPosY() == snake.Position.GetCoordsPosY()
                        && SnakeFood.FoodCoords.GetCoordsPosX() == snake.Position.GetCoordsPosX()));

                if (Score >= Math.Pow(SnakeGround.GroudSize,2))
                {
                    SnakeFood.FoodCoords = new Position(-1, -1);
                    break;
                }
                else if (_checkFreePosForFood == true)
                    break;
                
            } while (true);
            _checkFreePosForFood = false;
        }
    }
}