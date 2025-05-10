using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public class Board : Panel
    {
        public event EventHandler<CellClickedEventArgs> CellClicked;
        private int CellSize { get; set; }

        private Table Table;

        public void Initialise()
        {
            DoubleBuffered = true;
            Table = new Layout();
        }

        public void UpdateTable(Table newTable)
        {
            Table = newTable;
            Refresh();
        }

        public void Rescale(int windowWidth, int windowHeight, int menuHeight)
        {
            int width = windowWidth - 16;
            int height = windowHeight - menuHeight - 39;

            CellSize = Math.Min(width, height) / 3;
            SetBounds((width < height) ? 0 : (width - height) / 2, (width < height) ? (height - width) / 2 + menuHeight : menuHeight, CellSize * 3, CellSize * 3);
            Refresh();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            int x = e.Y / CellSize;
            int y = e.X / CellSize;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);


            if (e.Button == MouseButtons.Left)
            {
                int x = e.X / CellSize;
                int y = e.Y / CellSize;

                CellClicked?.Invoke(this, new CellClickedEventArgs(x, y));

                Refresh();
            }
        }

        private void DrawBorder(Graphics g)
        {
            Pen borderPen = Pens.Black;
            for (int i = 1; i <= 2; i++)
            {
                // Draw vertical lines
                g.DrawLine(borderPen, i * CellSize, 0, i * CellSize, 3 * CellSize);

                // Draw horizontal lines
                g.DrawLine(borderPen, 0, i * CellSize, 3 * CellSize, i * CellSize);
            }
        }

        private void DrawPieces(Graphics g)
        {
            if (Table != null)
            {
                foreach (KeyValuePair<Coordinate, PieceType> piece in Table)
                {
                    g.DrawImage(PieceFactory.GetPiece(piece.Value), piece.Key.X * CellSize, piece.Key.Y * CellSize, CellSize, CellSize);
                }
            }
        }

        private void DrawSquares(Graphics g)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    g.FillRectangle(Brushes.DarkGray, j * CellSize, i * CellSize, CellSize, CellSize);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawSquares(e.Graphics);    
            DrawBorder(e.Graphics);
            DrawPieces(e.Graphics);
        }
    }
}
