﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe
{
    public interface ILogger
    {
        void LogMove(PieceType player, Coordinate coordinate);
        void SaveLog();
        void ClearLog();
    }
}
