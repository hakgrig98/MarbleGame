﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MarbleGameLib.Models
{
    public interface IWall :ICordinate
    {
        Position Position { get; }
    }
}
