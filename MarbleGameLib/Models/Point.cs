using System;
using System.Collections.Generic;
using System.Text;

namespace MarbleGameLib.Models
{
    public class Point : IPoint
    {
        public IMarble Marble { get; set; }

        public IWall Wall { get; set; }
    }
}
