using System;
using System.Collections.Generic;
using System.Text;

namespace MarbleGameLib.Models
{
    internal class Marble :IMarble
    {
        public int I { get; set; }
        public int J { get; set; }
        public IHole Hole { get; set; }
    }
}
