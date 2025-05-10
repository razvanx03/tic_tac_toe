using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public abstract class Table : Dictionary<Coordinate, PieceType>
    {
        public abstract PieceType? CheckWinCon();

        public abstract bool PlacePiece(Coordinate coordinate, PieceType piece);
    }
}
