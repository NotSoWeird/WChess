namespace WChess {
    partial class ChoosePiece {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lbl_Header = new System.Windows.Forms.Label();
            this.pnl_ShowPieces = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lbl_Header
            // 
            this.lbl_Header.AutoSize = true;
            this.lbl_Header.Location = new System.Drawing.Point(56, 9);
            this.lbl_Header.Name = "lbl_Header";
            this.lbl_Header.Size = new System.Drawing.Size(218, 13);
            this.lbl_Header.TabIndex = 0;
            this.lbl_Header.Text = "Choose piece you want the pawn promote to";
            // 
            // pnl_ShowPieces
            // 
            this.pnl_ShowPieces.Location = new System.Drawing.Point(12, 25);
            this.pnl_ShowPieces.Name = "pnl_ShowPieces";
            this.pnl_ShowPieces.Size = new System.Drawing.Size(320, 80);
            this.pnl_ShowPieces.TabIndex = 1;
            this.pnl_ShowPieces.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_ShowPieces_Paint);
            this.pnl_ShowPieces.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnl_ShowPieces_MouseClick);
            // 
            // ChoosePiece
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 117);
            this.Controls.Add(this.pnl_ShowPieces);
            this.Controls.Add(this.lbl_Header);
            this.Name = "ChoosePiece";
            this.Text = "ChoosePiece";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Header;
        private System.Windows.Forms.Panel pnl_ShowPieces;
    }
}