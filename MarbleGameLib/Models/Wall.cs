using System;
using System.Collections.Generic;
using System.Text;

namespace MarbleGameLib.Models
{
    internal class Wall : IWall
    {
        public int I { get; set; }

        public int J { get; set; }

        public Position Position { get; set; }
    }
}
