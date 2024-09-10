using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static SnakeGame.SnakeBody;

namespace SnakeGame
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int[,] _gameBoard = new int[SnakeGround.GroudSize, SnakeGround.GroudSize];
        private bool _isGameStarted = false;
        private bool _isDirectionChangedInTick = false;
        private bool _isPausePosition = false;
        private Key _lastKeyPressed = Key.None;
        public MainWindow()
        {
            InitializeComponent();
            gameBoard.Rows = SnakeGround.GroudSize;
            gameBoard.Columns = SnakeGround.GroudSize;
            SnakeFood.CreateFood();
            DrawGameBoard();
            gameBoard.Focus();
        }
       
        private void DrawGameBoard()
        {
            if (SnakeBody.CheckRoadAccident)
            {
                MessageBox.Show("ИГРА ЗАКОНЧЕНА!");
                return;
            }
            else if (SnakeBody.CheckWin)
            {
                MessageBox.Show("КОБРА ВОВА НАКОРМЛЕН!");
                return;
            }

            gameBoard.Children.Clear();
            textScore.Text = $"Очки: {SnakeFood.Score}";
            for (int r = 0; r < _gameBoard.GetLength(0); r++)
            {
                for (int c = 0; c < _gameBoard.GetLength(1); c++)
                {
                    Border cell = new Border
                    {
                        Background = Brushes.LightBlue,
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(1),
                        Width = 30,
                        Height = 30
                    };

                    if (SnakeFood.FoodCoords.GetCoordsPosY() == r && SnakeFood.FoodCoords.GetCoordsPosX() == c)
                        cell.Background = Brushes.LightCoral;

                    foreach (SnakeBody snake in SnakeBody.snakeElem)
                    {
                        if (snake.Position.GetCoordsPosY() == r && snake.Position.GetCoordsPosX() == c)
                        {
                            cell.Background = Brushes.LightGreen;
                            if (snake.TypeCell == SnakeBody.SnakeBodyType.Head)
                                cell.Background = Brushes.Green;
                            break;
                        }
                    }

                    gameBoard.Children.Add(cell);
                }
            }
        }

        private async void GameStart()
        {
            if (_isGameStarted)
            {
                while (!SnakeBody.CheckRoadAccident && _isGameStarted && !SnakeBody.CheckWin)
                {
                    SnakeBody.SnakeMove();
                    DrawGameBoard();
                    await Task.Delay(120);
                    _isDirectionChangedInTick = false;

                    if (_isPausePosition)
                        break;
                }
            }
        }

        private void GameBoardKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.W && e.Key != Key.S && e.Key != Key.A && e.Key != Key.D && e.Key != Key.A)
                return;

            if (!_isGameStarted)
            {
                _isGameStarted = true;
                GameStart();
            }

            _lastKeyPressed = e.Key;

            if (!_isDirectionChangedInTick)
            {
                if (_lastKeyPressed == Key.W && Direction.directionType != Direction.DirectionType.Down)
                {
                    Direction.directionType = Direction.DirectionType.Up;
                    _isDirectionChangedInTick = true;
                }
                else if (_lastKeyPressed == Key.S && Direction.directionType != Direction.DirectionType.Up)
                {
                    Direction.directionType = Direction.DirectionType.Down;
                    _isDirectionChangedInTick = true;
                }
                else if (_lastKeyPressed == Key.A && Direction.directionType != Direction.DirectionType.Right)
                {
                    Direction.directionType = Direction.DirectionType.Left;
                    _isDirectionChangedInTick = true;
                }
                else if (_lastKeyPressed == Key.D && Direction.directionType != Direction.DirectionType.Left)
                {
                    Direction.directionType = Direction.DirectionType.Right;
                    _isDirectionChangedInTick = true;
                }
            }
        }

        private void ButtonGoNewGameClick(object sender, RoutedEventArgs e)
        {
            _isGameStarted = false;
            snakeElem = new List<SnakeBody>
            {
                new SnakeBody(0, SnakeBodyType.Head, new Position(2,8)),
                new SnakeBody(1, SnakeBodyType.Body, new Position(2,7)),
                new SnakeBody(2, SnakeBodyType.Body, new Position(2,6)),
            };
            Direction.directionType = Direction.DirectionType.Right;
            SnakeFood.Score = 0;
            gameBoard.Focus();
            SnakeBody.CheckRoadAccident = false;
            SnakeBody.CheckWin = false;
            SnakeFood.CreateFood();
            DrawGameBoard();
        }

        private void ButtonPauseClick(object sender, RoutedEventArgs e)
        {
            if (buttonPause.Content.ToString() == "Пауза 1000-7" && !SnakeBody.CheckRoadAccident)
            {
                buttonPause.Content = "Играть 1000-7";
                _isPausePosition = true;
            }
            else if (buttonPause.Content.ToString() == "Играть 1000-7" && !SnakeBody.CheckRoadAccident)
            {
                buttonPause.Content = "Пауза 1000-7";
                gameBoard.Focus();
                _isPausePosition = false;
                GameStart();
            }
        }
    }
}