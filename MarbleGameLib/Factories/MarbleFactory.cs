using System;
using System.Collections.Generic;
using System.Text;
using MarbleGameLib.Models;

namespace MarbleGameLib.Factories
{
    public class MarbleFactory : IMarbleFactory
    {
        public IMarble Create(int i, int j, IHole hole)
        {
            return new Marble
            {
                I = i,
                J = j,
                Hole = hole
            };
        }
    }
}
