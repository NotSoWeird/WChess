namespace WChess {
    partial class RestartPrompt {
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
            this.btn_No = new System.Windows.Forms.Button();
            this.btn_Yes = new System.Windows.Forms.Button();
            this.lbl_Prompt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_No
            // 
            this.btn_No.Location = new System.Drawing.Point(99, 31);
            this.btn_No.Name = "btn_No";
            this.btn_No.Size = new System.Drawing.Size(75, 23);
            this.btn_No.TabIndex = 0;
            this.btn_No.Text = "No";
            this.btn_No.UseVisualStyleBackColor = true;
            this.btn_No.Click += new System.EventHandler(this.btn_No_Click);
            // 
            // btn_Yes
            // 
            this.btn_Yes.Location = new System.Drawing.Point(12, 31);
            this.btn_Yes.Name = "btn_Yes";
            this.btn_Yes.Size = new System.Drawing.Size(75, 23);
            this.btn_Yes.TabIndex = 1;
            this.btn_Yes.Text = "Yes";
            this.btn_Yes.UseVisualStyleBackColor = true;
            this.btn_Yes.Click += new System.EventHandler(this.btn_Yes_Click);
            // 
            // lbl_Prompt
            // 
            this.lbl_Prompt.AutoSize = true;
            this.lbl_Prompt.Location = new System.Drawing.Point(12, 9);
            this.lbl_Prompt.Name = "lbl_Prompt";
            this.lbl_Prompt.Size = new System.Drawing.Size(144, 13);
            this.lbl_Prompt.TabIndex = 2;
            this.lbl_Prompt.Text = "Do you really want to restart?";
            // 
            // RestartPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(186, 66);
            this.Controls.Add(this.lbl_Prompt);
            this.Controls.Add(this.btn_Yes);
            this.Controls.Add(this.btn_No);
            this.Name = "RestartPrompt";
            this.Text = "Are you sure?";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_No;
        private System.Windows.Forms.Button btn_Yes;
        private System.Windows.Forms.Label lbl_Prompt;
    }
}