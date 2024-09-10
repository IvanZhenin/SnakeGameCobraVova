using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace SnakeGame
{
    public class SnakeBody
    {
        private int _numId;
        public SnakeBodyType TypeCell;
        public Position Position;
        public static bool CheckRoadAccident = false;
        public static bool CheckWin = false;
        
        public enum SnakeBodyType
        {
            Head,
            Body
        }

        public SnakeBody(int numId, SnakeBodyType typeCell, Position position)
        {
            _numId = numId;
            TypeCell = typeCell;
            Position = position;
        }

        public static List<SnakeBody> snakeElem = new List<SnakeBody>
        {
            new SnakeBody(0, SnakeBodyType.Head, new Position(2,8)),
            new SnakeBody(1, SnakeBodyType.Body, new Position(2,7)),
            new SnakeBody(2, SnakeBodyType.Body, new Position(2,6)),
        };

        public static void SnakeMove()
        {
            for (int i = snakeElem.Count() - 1; i > 0; i--)
            {
                snakeElem[i].Position = snakeElem[i - 1].Position;
            }

            int posY = snakeElem[0].Position.GetCoordsPosY();
            int posX = snakeElem[0].Position.GetCoordsPosX();
            switch (Direction.directionType)
            {
                case Direction.DirectionType.Left:
                    posX--;
                    if (posX < 0)
                        posX = SnakeGround.GroudSize - 1;
                    break;
                case Direction.DirectionType.Up:
                    posY--;
                    if (posY < 0)
                        posY = SnakeGround.GroudSize - 1;
                    break;
                case Direction.DirectionType.Right:
                    posX++;
                    if (posX > SnakeGround.GroudSize - 1)
                        posX = 0;
                    break;
                case Direction.DirectionType.Down:
                    posY++;
                    if (posY > SnakeGround.GroudSize - 1)
                        posY = 0;
                    break;
            }
            snakeElem[0].Position  = new Position(posY, posX);
            
            for (int i = 1; i < snakeElem.Count(); i++)
            {
                if (snakeElem[0].Position.GetCoordsPosY() == snakeElem[i].Position.GetCoordsPosY()
                    && snakeElem[0].Position.GetCoordsPosX() == snakeElem[i].Position.GetCoordsPosX())
                {
                    CheckRoadAccident = true;
                    break;
                }
            }

            if (SnakeFood.Score >= Math.Pow(SnakeGround.GroudSize,2))
            {
                CheckWin = true;
                return;
            }

            if (snakeElem[0].Position.GetCoordsPosY() == SnakeFood.FoodCoords.GetCoordsPosY() 
                && snakeElem[0].Position.GetCoordsPosX() == SnakeFood.FoodCoords.GetCoordsPosX())
            {
                SnakeFood.Score++;
                SnakeGotFood();
                SnakeFood.CreateFood();
            }
        }

        public static void SnakeGotFood()
        {
            SnakeBody currentLastElem = snakeElem.Last();
            SnakeBody addElem = new SnakeBody(GetNewLastElemId(currentLastElem), SnakeBodyType.Body, GetNewLastElemCoords(currentLastElem));
            snakeElem.Add(addElem);
        }

        private static int GetNewLastElemId(SnakeBody snakeLastElem)
        {
            return snakeLastElem._numId + 1;
        }
        private static Position GetNewLastElemCoords(SnakeBody snakeLastElem)
        {
            int posY = snakeLastElem.Position.GetCoordsPosY();
            int posX = snakeLastElem.Position.GetCoordsPosX();

            switch (Direction.directionType)
            {
                case Direction.DirectionType.Left:
                    posX++;
                    break;
                case Direction.DirectionType.Up:
                    posY++;
                    break;
                case Direction.DirectionType.Right:
                    posX--;
                    break;
                case Direction.DirectionType.Down:
                    posY--;
                    break;
            }

            return new Position(posY, posX);
        }
    }
}