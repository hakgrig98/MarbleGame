using System;
using System.Collections.Generic;
using System.Text;

namespace MarbleGameLib.Models
{
    public interface IPoint
    {
        IMarble Marble { get; set; }
        IWall Wall { get; set; }
    }
}
