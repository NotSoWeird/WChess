using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WChess {
    public partial class ChoosePiece : Form {
        Image QueenW = Image.FromFile("QueenW.png");
        Image QueenB = Image.FromFile("QueenB.png");
        Image BishopW = Image.FromFile("BishopW.png");
        Image BishopB = Image.FromFile("BishopB.png");
        Image KnightW = Image.FromFile("KnightW.png");
        Image KnightB = Image.FromFile("KnightB.png");
        Image RookW = Image.FromFile("RookW.png");
        Image RookB = Image.FromFile("RookB.png");

        public char toPiece = ' ';

        bool turn;

        public ChoosePiece(bool Whiteturn) {
            InitializeComponent();
            turn = Whiteturn;
        }

        private void pnl_ShowPieces_Paint(object sender, PaintEventArgs e) { // Rita ut allternativen
            Graphics g = e.Graphics;
            if(turn) {
                g.DrawImage(QueenW, 0, 0, 80, 80);
                g.DrawImage(BishopW, 80, 0, 80, 80);
                g.DrawImage(KnightW, 160, 0, 80, 80);
                g.DrawImage(RookW, 240, 0, 80, 80);
            } else {
                g.DrawImage(QueenB, 0, 0, 80, 80);
                g.DrawImage(BishopB, 80, 0, 80, 80);
                g.DrawImage(KnightB, 160, 0, 80, 80);
                g.DrawImage(RookB, 240, 0, 80, 80);
            }
        }

        private void pnl_ShowPieces_MouseClick(object sender, MouseEventArgs e) { // Kolla vad den har valt och returnera det
            int x = e.X / 80;
            if(turn) {
                if(x == 0) {
                    toPiece = 'Q';
                } else if(x == 1) {
                    toPiece = 'B';
                } else if(x == 2) {
                    toPiece = 'N';
                } else if(x == 3) {
                    toPiece = 'R';
                }
            } else {
                if(x == 0) {
                    toPiece = 'q';
                } else if(x == 1) {
                    toPiece = 'b';
                } else if(x == 2) {
                    toPiece = 'n';
                } else if(x == 3) {
                    toPiece = 'r';
                }
            }
            DialogResult = DialogResult.OK; // Avsluta
        }

    }
}
