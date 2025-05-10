using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public class tictactoe : Game
    {
        private ToolStripTextBox _toolStripTextBox;
        private PieceType currentPlayer;
        private Board board;
        private Table table;
        private ILogger logger;
        public bool isGameOver = false;

        public tictactoe(ToolStripTextBox toolStripTextBox)
        {
            _toolStripTextBox = toolStripTextBox;
            logger = new Logger();
        }

        public override void Initialise(Board board)
        {
            this.board = board;
            this.board.Initialise();
            this.board.CellClicked += Board_CellClicked;
            this.table = new Layout();
            logger.ClearLog();
        }

        public override void Start()
        {
            currentPlayer = PieceType.X;
            _toolStripTextBox.Text = "Current Player: " + (currentPlayer == PieceType.X ? "X" : "O");
        }

        // fara lambda
        //private void Board_CellClicked(object sender, CellClickedEventArgs e)
        //{
        //    if (!isGameOver)
        //    {
        //        if (table.PlacePiece(new Coordinate(e.X, e.Y), currentPlayer))
        //        {
        //            logger.LogMove(currentPlayer, new Coordinate(e.X, e.Y));

        //            var result = table.CheckWinCon();
        //            if (result != null)
        //            {
        //                _toolStripTextBox.Text = "";
        //                board.UpdateTable(table);
        //                MessageBox.Show($"{result} won!");
        //                logger.SaveLog();
        //                isGameOver = true;
        //                return;
        //            }

        //            currentPlayer = (currentPlayer == PieceType.X ? PieceType.O : PieceType.X);
        //            _toolStripTextBox.Text = "Current Player: " + (currentPlayer == PieceType.X ? "X" : "O");
        //            board.UpdateTable(table);

        //            if (CheckForDraw())
        //            {
        //                logger.SaveLog();
        //                return;
        //            }

        //            if (GameMode.CurrentGame == GameMode.Type.bot)
        //            {
        //                ComputerMove();
        //                CheckForDraw();
        //            }
        //        }
        //    }
        //}

        // cu lambda
        private void Board_CellClicked(object sender, CellClickedEventArgs e)
        {
            if (isGameOver) return;

            Action handleEndGame = () =>
            {
                var result = table.CheckWinCon();
                if (result != null)
                {
                    _toolStripTextBox.Text = "";
                    board.UpdateTable(table);
                    MessageBox.Show($"{result} won!");
                    logger.SaveLog();
                    isGameOver = true;
                    return;
                }

                if (CheckForDraw())
                {
                    logger.SaveLog();
                    isGameOver = true;
                }
            };

            if (table.PlacePiece(new Coordinate(e.X, e.Y), currentPlayer))
            {
                logger.LogMove(currentPlayer, new Coordinate(e.X, e.Y));
                handleEndGame();

                if (!isGameOver)
                {
                    currentPlayer = (currentPlayer == PieceType.X ? PieceType.O : PieceType.X);
                    _toolStripTextBox.Text = "Current Player: " + (currentPlayer == PieceType.X ? "X" : "O");
                    board.UpdateTable(table);

                    if (GameMode.CurrentGame == GameMode.Type.bot)
                    {
                        ComputerMove();

                        if (!isGameOver)
                        {
                            handleEndGame();
                        }
                    }
                }
            }
        }



        private bool CheckForDraw()
        {
            List<Coordinate> emptyCoordinates = GetEmptyCoordinates();
            if (emptyCoordinates.Count == 0)
            {
                var result = table.CheckWinCon();
                if (result == null)
                {
                    MessageBox.Show("It's a draw!");
                    isGameOver = true;
                    return true;
                }
            }

            return false;
        }


        private void ComputerMove()
        {
            if (!ComputerLogic(PieceType.O))
            {
                if (!ComputerLogic(PieceType.X))
                {
                    PlaceRandomSign();
                }
            }

            var result = table.CheckWinCon();
            if (result != null)
            {
                _toolStripTextBox.Text = "";
                board.UpdateTable(table);
                MessageBox.Show($"{result} won!");
                logger.SaveLog();
                isGameOver = true;
                return;
            }

            currentPlayer = PieceType.X;
            _toolStripTextBox.Text = "Current Player: X";
            board.UpdateTable(table);
        }

        private bool ComputerLogic(PieceType sign)
        {
            for (int i = 0; i < 3; i++)
            {
                if (CanWinOrBlock(new Coordinate(i, 0), new Coordinate(i, 1), new Coordinate(i, 2), sign))
                    return true;

                if (CanWinOrBlock(new Coordinate(0, i), new Coordinate(1, i), new Coordinate(2, i), sign))
                    return true;
            }

            if (CanWinOrBlock(new Coordinate(0, 0), new Coordinate(1, 1), new Coordinate(2, 2), sign) ||
                CanWinOrBlock(new Coordinate(0, 2), new Coordinate(1, 1), new Coordinate(2, 0), sign))
            {
                return true;
            }

            return false;
        }

        private bool CanWinOrBlock(Coordinate c1, Coordinate c2, Coordinate c3, PieceType sign)
        {
            int countSign = 0;
            int countEmpty = 0;
            Coordinate emptyCoordinate = null;

            List<Coordinate> coords = new List<Coordinate> { c1, c2, c3 };
            foreach (var coord in coords)
            {
                if (table.ContainsKey(coord))
                {
                    if (table[coord] == sign)
                        countSign++;
                }
                else
                {
                    countEmpty++;
                    emptyCoordinate = coord;
                }
            }

            if (countSign == 2 && countEmpty == 1)
            {
                table.PlacePiece(emptyCoordinate, PieceType.O);
                logger.LogMove(PieceType.O, new Coordinate(emptyCoordinate.X, emptyCoordinate.Y));
                return true;
            }

            return false;
        }

        private void PlaceRandomSign()
        {
            var emptyCoordinates = GetEmptyCoordinates();
            Random rand = new Random();
            var randomCoordinate = emptyCoordinates[rand.Next(emptyCoordinates.Count)];
            table.PlacePiece(randomCoordinate, PieceType.O);
            logger.LogMove(PieceType.O, new Coordinate(randomCoordinate.X, randomCoordinate.Y));
        }

        private List<Coordinate> GetEmptyCoordinates()
        {
            List<Coordinate> emptyCoordinates = new List<Coordinate>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (!table.ContainsKey(new Coordinate(i, j)))
                    {
                        emptyCoordinates.Add(new Coordinate(i, j));
                    }
                }
            }

            return emptyCoordinates;
        }
    }
}
