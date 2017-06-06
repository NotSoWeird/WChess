namespace WChess
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Restart = new System.Windows.Forms.Button();
            this.tbx_Debug = new System.Windows.Forms.TextBox();
            this.lbl_TurnNotif = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 400);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
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
            this.tbx_Debug.Location = new System.Drawing.Point(419, 54);
            this.tbx_Debug.Multiline = true;
            this.tbx_Debug.Name = "tbx_Debug";
            this.tbx_Debug.Size = new System.Drawing.Size(186, 205);
            this.tbx_Debug.TabIndex = 2;
            // 
            // lbl_TurnNotif
            // 
            this.lbl_TurnNotif.AutoSize = true;
            this.lbl_TurnNotif.Location = new System.Drawing.Point(442, 13);
            this.lbl_TurnNotif.Name = "lbl_TurnNotif";
            this.lbl_TurnNotif.Size = new System.Drawing.Size(60, 13);
            this.lbl_TurnNotif.TabIndex = 3;
            this.lbl_TurnNotif.Text = "White Turn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 462);
            this.Controls.Add(this.lbl_TurnNotif);
            this.Controls.Add(this.tbx_Debug);
            this.Controls.Add(this.btn_Restart);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "WChess";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Restart;
        private System.Windows.Forms.TextBox tbx_Debug;
        private System.Windows.Forms.Label lbl_TurnNotif;
    }
}

