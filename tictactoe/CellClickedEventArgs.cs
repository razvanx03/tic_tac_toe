﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe
{
    public class CellClickedEventArgs : EventArgs
    {
        public int X { get; }
        public int Y { get; }

        public CellClickedEventArgs(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
