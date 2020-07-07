using MarbleGameLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarbleGameLib.Factories
{
    public interface IMarbleFactory
    {
        IMarble Create(int i, int j, IHole hole);
    }
}
