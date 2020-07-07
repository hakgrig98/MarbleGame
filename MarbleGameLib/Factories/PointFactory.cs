using System;
using System.Collections.Generic;
using System.Text;
using MarbleGameLib.Models;

namespace MarbleGameLib.Factories
{
    public class PointFactory : IPointFactory
    {
        public IPoint Create(IMarble marble, IWall wall)
        {
            return new Point
            {
                Marble = marble,
                Wall = wall
            };
        }
    }
}
