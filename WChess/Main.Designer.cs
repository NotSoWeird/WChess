namespace WChess
{
    partial class Main
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
            this.pnl_Board = new System.Windows.Forms.Panel();
            this.btn_Restart = new System.Windows.Forms.Button();
            this.tbx_Debug = new System.Windows.Forms.TextBox();
            this.lbl_TurnNotif = new System.Windows.Forms.Label();
            this.pnl_Taken = new System.Windows.Forms.Panel();
            this.lbl_Legality = new System.Windows.Forms.Label();
            this.btn_Resign = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnl_Board
            // 
            this.pnl_Board.Location = new System.Drawing.Point(13, 13);
            this.pnl_Board.Name = "pnl_Board";
            this.pnl_Board.Size = new System.Drawing.Size(400, 400);
            this.pnl_Board.TabIndex = 0;
            this.pnl_Board.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_Board_Paint);
            this.pnl_Board.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnl_Board_MouseClick);
            // 
            // btn_Restart
            // 
            this.btn_Restart.Location = new System.Drawing.Point(419, 390);
            this.btn_Restart.Name = "btn_Restart";
            this.btn_Restart.Size = new System.Drawing.Size(82, 23);
            this.btn_Restart.TabIndex = 1;
            this.btn_Restart.Text = "Restart";
            this.btn_Restart.UseVisualStyleBackColor = true;
            this.btn_Restart.Click += new System.EventHandler(this.btn_Restart_Click);
            // 
            // tbx_Debug
            // 
            this.tbx_Debug.Location = new System.Drawing.Point(419, 29);
            this.tbx_Debug.Multiline = true;
            this.tbx_Debug.Name = "tbx_Debug";
            this.tbx_Debug.Size = new System.Drawing.Size(186, 260);
            this.tbx_Debug.TabIndex = 2;
            // 
            // lbl_TurnNotif
            // 
            this.lbl_TurnNotif.AutoSize = true;
            this.lbl_TurnNotif.Location = new System.Drawing.Point(419, 13);
            this.lbl_TurnNotif.Name = "lbl_TurnNotif";
            this.lbl_TurnNotif.Size = new System.Drawing.Size(0, 13);
            this.lbl_TurnNotif.TabIndex = 3;
            // 
            // pnl_Taken
            // 
            this.pnl_Taken.Location = new System.Drawing.Point(419, 295);
            this.pnl_Taken.Name = "pnl_Taken";
            this.pnl_Taken.Size = new System.Drawing.Size(186, 89);
            this.pnl_Taken.TabIndex = 4;
            this.pnl_Taken.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_Taken_Paint);
            // 
            // lbl_Legality
            // 
            this.lbl_Legality.AutoSize = true;
            this.lbl_Legality.Location = new System.Drawing.Point(521, 13);
            this.lbl_Legality.Name = "lbl_Legality";
            this.lbl_Legality.Size = new System.Drawing.Size(0, 13);
            this.lbl_Legality.TabIndex = 5;
            // 
            // btn_Resign
            // 
            this.btn_Resign.Location = new System.Drawing.Point(508, 389);
            this.btn_Resign.Name = "btn_Resign";
            this.btn_Resign.Size = new System.Drawing.Size(75, 23);
            this.btn_Resign.TabIndex = 6;
            this.btn_Resign.Text = "Resign";
            this.btn_Resign.UseVisualStyleBackColor = true;
            this.btn_Resign.Click += new System.EventHandler(this.btn_Resign_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 462);
            this.Controls.Add(this.btn_Resign);
            this.Controls.Add(this.lbl_Legality);
            this.Controls.Add(this.pnl_Taken);
            this.Controls.Add(this.lbl_TurnNotif);
            this.Controls.Add(this.tbx_Debug);
            this.Controls.Add(this.btn_Restart);
            this.Controls.Add(this.pnl_Board);
            this.Name = "Main";
            this.Text = "WChess";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Board;
        private System.Windows.Forms.Button btn_Restart;
        private System.Windows.Forms.TextBox tbx_Debug;
        private System.Windows.Forms.Label lbl_TurnNotif;
        private System.Windows.Forms.Panel pnl_Taken;
        private System.Windows.Forms.Label lbl_Legality;
        private System.Windows.Forms.Button btn_Resign;
    }
}

