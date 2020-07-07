using MarbleGameLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarbleGameLib.Factories
{
    public interface IPointFactory
    {
        IPoint Create(IMarble marble, IWall point);
    }
}
