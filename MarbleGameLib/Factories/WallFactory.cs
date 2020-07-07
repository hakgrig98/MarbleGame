using System;
using System.Collections.Generic;
using System.Text;
using MarbleGameLib.Models;

namespace MarbleGameLib.Factories
{
    public class WallFactory : IWallFactory
    {
        public IWall Create(int i, int j, Position position)
        {
            return new Wall
            {
                I = i,
                J = j,
                Position = position
            };
        }
    }
}
