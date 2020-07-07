using MarbleGameLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarbleGameLib.Factories
{
    public interface IWallFactory
    {
        IWall Create(int i, int j, Position position);
    }
}
