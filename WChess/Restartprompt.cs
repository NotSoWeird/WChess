﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WChess {
    public partial class RestartPrompt : Form {
        public bool restart = false;
        public RestartPrompt() {
            InitializeComponent();
        }

        private void btn_No_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
        }

        private void btn_Yes_Click(object sender, EventArgs e) {
            restart = true;
            DialogResult = DialogResult.OK;
        }
    }
}
