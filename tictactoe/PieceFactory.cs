using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe
{
    public static class PieceFactory
    {
        private static Bitmap PieceImages = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("tic_tac_toe.Resources.tictactoe.png"));
        public static Image GetPiece(PieceType piece)
        {
            int convertedPiece = (int)piece;

            return PieceImages.Clone(new Rectangle(PieceImages.Width / 2 * convertedPiece, 0, PieceImages.Width / 2, PieceImages.Height), PieceImages.PixelFormat);
        }
    }
}
