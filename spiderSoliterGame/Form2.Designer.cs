namespace spiderSoliterGame
{
    partial class Form2
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
            this.theGame = new System.Windows.Forms.ToolStripMenuItem();
            this.newGame = new System.Windows.Forms.ToolStripMenuItem();
            this.Undo = new System.Windows.Forms.ToolStripMenuItem();
            this.اعادةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تعليماتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelUnPlayedCards = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.theGame,
            this.تعليماتToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(1069, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // theGame
            // 
            this.theGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGame,
            this.Undo,
            this.اعادةToolStripMenuItem});
            this.theGame.Name = "theGame";
            this.theGame.Size = new System.Drawing.Size(37, 20);
            this.theGame.Text = "لعبة";
            // 
            // newGame
            // 
            this.newGame.Name = "newGame";
            this.newGame.Size = new System.Drawing.Size(152, 22);
            this.newGame.Text = "لعبة جديدة";
            this.newGame.Click += new System.EventHandler(this.newGame_Click);
            // 
            // Undo
            // 
            this.Undo.Name = "Undo";
            this.Undo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.Undo.Size = new System.Drawing.Size(152, 22);
            this.Undo.Text = "تراجع";
            this.Undo.Click += new System.EventHandler(this.Undo_Click);
            // 
            // اعادةToolStripMenuItem
            // 
            this.اعادةToolStripMenuItem.Name = "اعادةToolStripMenuItem";
            this.اعادةToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.اعادةToolStripMenuItem.Text = "اعادة";
            // 
            // تعليماتToolStripMenuItem
            // 
            this.تعليماتToolStripMenuItem.Name = "تعليماتToolStripMenuItem";
            this.تعليماتToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.تعليماتToolStripMenuItem.Text = "تعليمات";
            // 
            // panelUnPlayedCards
            // 
            this.panelUnPlayedCards.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelUnPlayedCards.AutoSize = true;
            this.panelUnPlayedCards.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUnPlayedCards.Location = new System.Drawing.Point(104, 467);
            this.panelUnPlayedCards.Name = "panelUnPlayedCards";
            this.panelUnPlayedCards.Size = new System.Drawing.Size(95, 100);
            this.panelUnPlayedCards.TabIndex = 4;
            this.panelUnPlayedCards.Click += new System.EventHandler(this.panelUnPlayedCards_Click);
            // 
            // Form2
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(1069, 603);
            this.Controls.Add(this.panelUnPlayedCards);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Shown += new System.EventHandler(this.Form2_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form2_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form2_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.Form2_DragOver);
            this.DragLeave += new System.EventHandler(this.Form2_DragLeave);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem theGame;
        private System.Windows.Forms.ToolStripMenuItem تعليماتToolStripMenuItem;
        private System.Windows.Forms.Panel panelUnPlayedCards;
        private System.Windows.Forms.ToolStripMenuItem newGame;
        private System.Windows.Forms.ToolStripMenuItem Undo;
        private System.Windows.Forms.ToolStripMenuItem اعادةToolStripMenuItem;
    }
}