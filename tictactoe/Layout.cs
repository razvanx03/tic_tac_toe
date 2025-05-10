using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public class Layout : Table
    {
        public override PieceType? CheckWinCon()
        {
            for (int i = 0; i < 3; i++)
            {
                // Check row i
                if (this.TryGetValue(new Coordinate(i, 0), out PieceType firstRowPiece) &&
                    this.TryGetValue(new Coordinate(i, 1), out PieceType secondRowPiece) &&
                    this.TryGetValue(new Coordinate(i, 2), out PieceType thirdRowPiece) &&
                    firstRowPiece == secondRowPiece && secondRowPiece == thirdRowPiece)
                {
                    return firstRowPiece;
                }

                // Check column i
                if (this.TryGetValue(new Coordinate(0, i), out PieceType firstColPiece) &&
                    this.TryGetValue(new Coordinate(1, i), out PieceType secondColPiece) &&
                    this.TryGetValue(new Coordinate(2, i), out PieceType thirdColPiece) &&
                    firstColPiece == secondColPiece && secondColPiece == thirdColPiece)
                {
                    return firstColPiece;
                }
            }

            // Check main diagonal
            if (this.TryGetValue(new Coordinate(0, 0), out PieceType mainDiagPiece) &&
                this.TryGetValue(new Coordinate(1, 1), out PieceType secondMainDiagPiece) &&
                this.TryGetValue(new Coordinate(2, 2), out PieceType thirdMainDiagPiece) &&
                mainDiagPiece == secondMainDiagPiece && secondMainDiagPiece == thirdMainDiagPiece)
            {
                return mainDiagPiece;
            }

            // Check secondary diagonal
            if (this.TryGetValue(new Coordinate(0, 2), out PieceType secDiagPiece) &&
                this.TryGetValue(new Coordinate(1, 1), out PieceType secondSecDiagPiece) &&
                this.TryGetValue(new Coordinate(2, 0), out PieceType thirdSecDiagPiece) &&
                secDiagPiece == secondSecDiagPiece && secondSecDiagPiece == thirdSecDiagPiece)
            {
                return secDiagPiece;
            }

            return null;
        }

        public override bool PlacePiece(Coordinate coordinate, PieceType piece)
        {
            if (coordinate.X > 3 || coordinate.Y > 3 || coordinate.X < 0 || coordinate.Y < 0)
            {
                throw new Exception("Invalid arguments: x = " + coordinate.X + " y = " + coordinate.Y);
            }

            if (!this.ContainsKey(coordinate))
            {
                this[coordinate] = piece;
                return true;
            }
            else return false;
        }
    }
}
