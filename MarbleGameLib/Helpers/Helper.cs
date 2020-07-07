using MarbleGameLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarbleGameLib.Helpers
{
    public class Helper : IHelper
    {
        public Position GetPosition(int i, int j, int k, int z)
        {
            if (i == k)
            {
                if (j > z)
                    return Position.W;
                else
                    return Position.E;
            }
            else
            {
                if (i > k)
                    return Position.N;
                else
                    return Position.S;
            }
        }
    }
}
