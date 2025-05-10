using System;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class tic_tac_toe : Form
    {
        private Board board { get; set; }

        public tic_tac_toe()
        {
            InitializeComponent();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            board?.Rescale(Width, Height, menuToolStripMenuItem.Height);
        }
        private void playcoopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GameMode.CurrentGame == GameMode.Type.player)
            {
                return;
            } 
            else if (board != null)
            {
                RestartMenuItem_Click(sender, e);
                GameMode.CurrentGame = GameMode.Type.player;
                return;
            }

            GameMode.CurrentGame = GameMode.Type.player;

            board = new Board();
            Controls.Add(board);
            OnResize(e);

            Game tictactoe = new tictactoe(toolStripTextBox1);
            tictactoe.Initialise(board);
            tictactoe.Start();
        }
        private void playwithBotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GameMode.CurrentGame == GameMode.Type.bot)
            {
                return;
            }
            else if (board != null)
            {
                RestartMenuItem_Click(sender, e);
                GameMode.CurrentGame = GameMode.Type.bot;
                return;
            }

            GameMode.CurrentGame = GameMode.Type.bot;

            board = new Board();
            Controls.Add(board);
            OnResize(e);

            Game tictactoe = new tictactoe(toolStripTextBox1);
            tictactoe.Initialise(board);
            tictactoe.Start();
        }

        private void RestartMenuItem_Click(object sender, EventArgs e)
        {
            if (board != null)
            {
                toolStripTextBox1.Text = "";
                Controls.Remove(board);
                board.Dispose();
                board = new Board();
                Controls.Add(board);
                OnResize(e);

                Game tictactoe = new tictactoe(toolStripTextBox1);
                tictactoe.Initialise(board);
                tictactoe.Start();
            }
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
