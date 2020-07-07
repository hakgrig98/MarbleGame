using System;
using System.Collections.Generic;
using System.Text;

namespace MarbleGameLib.Models
{
    public interface IMarble :ICordinate
    {
        IHole Hole { get;}
    }

}
