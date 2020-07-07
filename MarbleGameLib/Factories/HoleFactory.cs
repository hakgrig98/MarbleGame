using System;
using System.Collections.Generic;
using System.Text;
using MarbleGameLib.Models;

namespace MarbleGameLib.Factories
{
    public class HoleFactory : IHoleFactory
    {
        public IHole Create(int i, int j)
        {
            return new Hole
            {
                I = i,
                J = j
            };
        }
    }
}
