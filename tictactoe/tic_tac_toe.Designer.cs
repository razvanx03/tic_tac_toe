namespace tic_tac_toe
{
    partial class tic_tac_toe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.playwithBotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playcoopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.toolStripTextBox1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playcoopToolStripMenuItem,
            this.playwithBotToolStripMenuItem,
            this.restartMenuItem,
            this.exitMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 23);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // restartMenuItem
            // 
            this.restartMenuItem.Name = "restartMenuItem";
            this.restartMenuItem.Size = new System.Drawing.Size(180, 22);
            this.restartMenuItem.Text = "Restart";
            this.restartMenuItem.Click += new System.EventHandler(this.RestartMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.ReadOnly = true;
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            // 
            // playwithBotToolStripMenuItem
            // 
            this.playwithBotToolStripMenuItem.Name = "playwithBotToolStripMenuItem";
            this.playwithBotToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.playwithBotToolStripMenuItem.Text = "Play (with bot)";
            this.playwithBotToolStripMenuItem.Click += new System.EventHandler(this.playwithBotToolStripMenuItem_Click);
            // 
            // playcoopToolStripMenuItem
            // 
            this.playcoopToolStripMenuItem.Name = "playcoopToolStripMenuItem";
            this.playcoopToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.playcoopToolStripMenuItem.Text = "Play (coop)";
            this.playcoopToolStripMenuItem.Click += new System.EventHandler(this.playcoopToolStripMenuItem_Click);
            // 
            // tic_tac_toe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Name = "tic_tac_toe";
            this.Text = "tic-tac-toe";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartMenuItem; // Updated name
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem; // Updated name
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem playcoopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playwithBotToolStripMenuItem;
    }
}
