using MarbleGameLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarbleGameLib.Factories
{
    public interface IHoleFactory
    {
        IHole Create(int i, int j);
    }
}
