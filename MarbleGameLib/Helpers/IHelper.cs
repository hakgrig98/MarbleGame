using MarbleGameLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarbleGameLib.Helpers
{
    public interface IHelper
    {
        Position GetPosition(int i, int j, int k, int z);
        object DeepClone(object objSource);
    }
}
