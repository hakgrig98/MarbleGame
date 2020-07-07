using MarbleGameLib.Factories;
using MarbleGameLib.Helpers;
using MarbleGameLib.Models;
using System;
using System.Collections.Generic;

namespace MarbleGameConsole
{
    class Program
    {
        #region Fields
        private static readonly IMarbleFactory _marbleFactory;
        private static readonly IHoleFactory _holeFactory;
        private static readonly IWallFactory _wallFactory;
        private static readonly IPointFactory _pointFactory;
        private static readonly IHelper _helper;
        private static int _squareCount;

        private static IPoint[,] _pointMatrix;
        private static List<Position> _position;

        #endregion

        #region Ctor
        static Program()
        {
            _marbleFactory = new MarbleFactory();
            _holeFactory = new HoleFactory();
            _wallFactory = new WallFactory();
            _pointFactory = new PointFactory();
            _helper = new Helper();
        }
        #endregion
        #region Methods
        private static void ReadInput()
        {
            string line = Console.ReadLine();

            int[] splitarr = Array.ConvertAll(line.Trim().Split(' '), (s) => int.Parse(s));

            _squareCount = splitarr[0];
            _pointMatrix = new IPoint[splitarr[0], splitarr[0]];

            int countOfMarbles = splitarr[1];
            int countOfWalls = splitarr[2];

            for (int i = 0; i < countOfMarbles; i++)
            {
                string marbleLine = Console.ReadLine();
                int[] marlbeCordinates = Array.ConvertAll(marbleLine.Trim().Split(' '), (s) => int.Parse(s));

                string holeLine = Console.ReadLine();
                int[] holeCordinates = Array.ConvertAll(holeLine.Trim().Split(' '), (s) => int.Parse(s));

                _pointMatrix[marlbeCordinates[0], marlbeCordinates[1]] = _pointFactory.Create(_marbleFactory.Create(marlbeCordinates[0], marlbeCordinates[1], _holeFactory.Create(holeCordinates[0], holeCordinates[1])), null);
            }

            for (int i = 0; i < countOfWalls; i++)
            {
                string wallLine = Console.ReadLine();
                int[] wallCordinates = Array.ConvertAll(wallLine.Trim().Split(' '), (s) => int.Parse(s));

                _pointMatrix[wallCordinates[0], wallCordinates[1]] = _pointFactory.Create(null, _wallFactory.Create(wallCordinates[0], wallCordinates[1], _helper.GetPosition(wallCordinates[0], wallCordinates[1], wallCordinates[2], wallCordinates[3])));

            }
        }

        private static void Process()
        {
            _position = new List<Position>();

            for (int i = 0; i < _squareCount; i++)
            {
                for (int j = 0; j < _squareCount; j++)
                {
                    if (_pointMatrix[i, j] != null)
                    {
                        var currentMarbleMatrix = _pointMatrix[i, j];

                        if (currentMarbleMatrix.Marble != null)
                        {
                            var currentMarble = currentMarbleMatrix.Marble;
                            var currentMarbleHole = currentMarble.Hole;
                            if (currentMarble.I == currentMarbleHole.I)
                            {
                                if (IsWall(i, j, currentMarbleHole.I, currentMarbleHole.J))
                                {
                                    if (currentMarble.J > currentMarbleHole.J)
                                    {
                                        _position.Add(Position.E);
                                        MoveMatrix(Position.E);
                                    }
                                    else
                                    {
                                        _position.Add(Position.W);
                                        MoveMatrix(Position.W);
                                    }

                                    _pointMatrix[i, j] = null;
                                }
                            }
                            else if (currentMarble.J == currentMarbleHole.J)
                            {
                                if (IsWall(i, j, currentMarbleHole.I, currentMarbleHole.J))
                                {
                                    if (currentMarble.I > currentMarbleHole.I)
                                    {
                                        _position.Add(Position.N);
                                        MoveMatrix(Position.N);
                                    }
                                    else
                                    {
                                        _position.Add(Position.S);
                                        MoveMatrix(Position.S);
                                    }

                                    _pointMatrix[i, j] = null;

                                }
                            }
                            else
                                continue;
                        }
                    }
                }
            }
        }

        private static void PrintOutput()
        {
            foreach (var position in _position)
            {
                Console.Write(position.ToString());
            }
        }
        #endregion
        #region Helpers
        private static bool IsWall(int i, int j, int k, int z)
        {
            Position position = Position.E;//Optional
            if (i == k)
            {
                if (j > z)
                    position = Position.W;
                else
                    position = Position.E;
            }
            else
            {
                if (i > k)
                    position = Position.N;
                else
                    position = Position.S;
            }

            for (int l = 1; l < _squareCount; l++)
            {
                switch (position)
                {
                    case Position.E:
                        if (j + l >= _squareCount)
                            break;

                        if (_pointMatrix[i, j + l] != null && _pointMatrix[i, j + l].Wall != null)
                            return false;
                        break;
                    case Position.N:
                        if (i - l < 0)
                            break;

                        if (_pointMatrix[i - l, j] != null && _pointMatrix[i - l, j].Wall != null)
                            return false;
                        break;
                    case Position.S:
                        if (i + l >= _squareCount)
                            break;

                        if (_pointMatrix[i + l, j] != null && _pointMatrix[i + l, j].Wall != null)
                            return false;
                        break;
                    case Position.W:
                        if (j - l < 0)
                            break;

                        if (_pointMatrix[i, j - l] != null && _pointMatrix[i, j - l].Wall != null)
                            return false;
                        break;
                    default:
                        break;
                }
            }
            return true;
        }

        private static void MoveMatrix(Position position)
        {
            for (int i = 0; i < _squareCount; i++)
            {
                for (int j = 0; j < _squareCount; j++)
                {
                    if (_pointMatrix[i, j] != null)
                    {
                        var currentMarbleMatrix = _pointMatrix[i, j];

                        if (currentMarbleMatrix != null && currentMarbleMatrix.Marble != null)
                        {


                            switch (position)
                            {
                                case Position.E:
                                    {
                                        bool isWall = IsWall(i, j, i, _squareCount - 1);
                                        if (isWall)
                                        {
                                            for (int k = j; k < _squareCount; k++)
                                            {
                                                if (_pointMatrix[i, k] != null && _pointMatrix[i, k].Wall != null)
                                                {
                                                    _pointMatrix[i, k] = _pointMatrix[i, j];
                                                    _pointMatrix[i, j] = null;
                                                }
                                                else
                                                {
                                                    _pointMatrix[i, _squareCount-1] = _pointMatrix[i, j];
                                                    _pointMatrix[i, j] = null;
                                                }
                                                    
                                            }
                                        }
                                    }
                                    break;
                                case Position.N:
                                    break;
                                case Position.S:
                                    {
                                        bool isWall = IsWall(i, j, _squareCount-1, j);
                                        if (isWall)
                                        {
                                            for (int k = j; k < _squareCount; k++)
                                            {
                                                if (_pointMatrix[i, j] != null && _pointMatrix[i, j].Wall != null)
                                                {
                                                    _pointMatrix[_squareCount-1, j] = _pointMatrix[i, j];
                                                    _pointMatrix[i, j] = null;
                                                }
                                                else
                                                {
                                                    _pointMatrix[_squareCount-1, j] = _pointMatrix[i, j];
                                                    _pointMatrix[i, j] = null;
                                                }

                                            }
                                        }
                                    }
                                    break;
                                case Position.W:
                                    {
                                        bool isWall = IsWall(i, _squareCount - 1, i, j);
                                        if (isWall)
                                        {
                                            for (int k = j; k < _squareCount; k++)
                                            {
                                                if (_pointMatrix[i, j-k] != null && _pointMatrix[i, j-k].Wall != null)
                                                {
                                                    _pointMatrix[i, j-k] = _pointMatrix[i, j];
                                                    _pointMatrix[i, j] = null;
                                                }
                                                else
                                                {
                                                    _pointMatrix[i, j-_squareCount - 1] = _pointMatrix[i, j];
                                                    _pointMatrix[i, j] = null;
                                                }

                                            }
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }


                    }
                }
            }
        }
        #endregion
        static void Main(string[] args)
        {
            ReadInput();
            Process();
            PrintOutput();
        }
    }
}
