using MarbleGameLib.Factories;
using MarbleGameLib.Helpers;
using MarbleGameLib.Models;
using System;
using System.Collections.Generic;

namespace MarbleGameConsole
{
    class Program
    {
        private static readonly IMarbleFactory _marbleFactory;
        private static readonly IHoleFactory _holeFactory;
        private static readonly IWallFactory _wallFactory;
        private static readonly IPointFactory _pointFactory;
        private static readonly IHelper _helper;

        private static IPoint[,] _pointMatrix;
        private static IEnumerable<Position> _position;

        static Program()
        {
            _marbleFactory = new MarbleFactory();
            _holeFactory = new HoleFactory();
            _wallFactory = new WallFactory();
            _pointFactory = new PointFactory();
            _helper = new Helper();
        }
        #region Methods
        private static void ReadInput()
        {
            string line = Console.ReadLine();

            int[] splitarr = Array.ConvertAll(line.Trim().Split(' '), (s) => int.Parse(s));

            _pointMatrix = new IPoint[splitarr[0], splitarr[0]];

            int countOfMarbles = splitarr[1];
            int countOfWalls = splitarr[2];

            for (int i = 0; i < countOfMarbles; i++)
            {
                string marbleLine = Console.ReadLine();
                int[] marlbeCordinates = Array.ConvertAll(marbleLine.Trim().Split(' '), (s) => int.Parse(s));

                string holeLine = Console.ReadLine();
                int[] holeCordinates = Array.ConvertAll(marbleLine.Trim().Split(' '), (s) => int.Parse(s));

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
            for (int i = 0; i < _pointMatrix.Length; i++)
            {
                //_pointMatrix[]
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
        
        static void Main(string[] args)
        {
            ReadInput();
            Process();
            PrintOutput();
        }
    }
}
