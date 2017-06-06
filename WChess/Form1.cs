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
    public partial class Form1 : Form {
        char[,] board = new char[8, 8];
        char[,] oldboard = new char[8, 8];
        bool[,] highlight = new bool[8, 8];
        List<char> takenW = new List<char>();
        List<char> takenB = new List<char>();
        int highlightfirstx = 0;
        int highlightfirsty = 0;
        public bool Whiteturn;

        CheckMove checkMove = new CheckMove();
        SolidBrush[] brush = new SolidBrush[3];
        Image KingW = Image.FromFile("KingW.png");
        Image KingB = Image.FromFile("KingB.png");
        Image QueenW = Image.FromFile("QueenW.png");
        Image QueenB = Image.FromFile("QueenB.png");
        Image BishopW = Image.FromFile("BishopW.png");
        Image BishopB = Image.FromFile("BishopB.png");
        Image KnightW = Image.FromFile("KnightW.png");
        Image KnightB = Image.FromFile("KnightB.png");
        Image RookW = Image.FromFile("RookW.png");
        Image RookB = Image.FromFile("RookB.png");
        Image PawnW = Image.FromFile("PawnW.png");
        Image PawnB = Image.FromFile("PawnB.png");



        public Form1() {
            InitializeComponent();
            prepareArrays();
            loadBrushes();
            pnl_Board.Invalidate();
        }

        private void pnl_Board_MouseClick(object sender, MouseEventArgs e) {
            int x = e.X / 50;
            int y = e.Y / 50;
            int highlightCount = 0;

            if(e.Button == MouseButtons.Left) {
                highlight[x, y] = !highlight[x, y];
            }

            for(int i = 0; i < 8; i++) {
                for(int j = 0; j < 8; j++) {
                    if(highlight[i, j]) {
                        highlightCount++;
                    }
                }
            }

            lbl_Legality.Text = "";

            if(highlightCount == 1 ) {
                highlightfirstx = x;
                highlightfirsty = y;
            } else if(highlightCount == 2) {
                if (checkMove.movePiece(highlightfirstx, highlightfirsty, x, y, board) && ((char.IsUpper(board[highlightfirstx, highlightfirsty]) && Whiteturn) || (char.IsLower(board[highlightfirstx, highlightfirsty]) && !Whiteturn))){
                    for(int i = 0; i < 8; i++) {
                        for(int j = 0; j < 8; j++) {
                            oldboard[i, j] = board[i, j];
                        }
                    }
                    promotion(highlightfirstx, highlightfirsty, y);
                    if(board[x, y] != '.') {
                        if(char.IsUpper(board[x, y])) {
                            takenW.Add(board[x, y]);
                        } else {
                            takenB.Add(board[x, y]);
                        }
                    }
                    char piece = board[highlightfirstx, highlightfirsty];
                    board[highlightfirstx, highlightfirsty] = '.';
                    board[x, y] = piece;
                    Whiteturn = !Whiteturn;
                    if((!Whiteturn && checkMove.checkMate(board) == 'K') || (Whiteturn && checkMove.checkMate(board) == 'k')) {
                        Whiteturn = !Whiteturn;
                        for(int i = 0; i < 8; i++) {
                            for(int j = 0; j < 8; j++) {
                                board[i, j] = oldboard[i, j];
                            }
                        }
                        lbl_Legality.Text = "In Check";
                    }
                    if(Whiteturn) {
                        lbl_TurnNotif.Text = "White Turn";
                    } else {
                        lbl_TurnNotif.Text = "Black Turn";
                    }
                } else {
                    lbl_Legality.Text = "Illegal move";
                }
                highlight[x, y] = false;
                highlight[highlightfirstx, highlightfirsty] = false;
            }
            pnl_Board.Invalidate();
        }
        
        private void pnl_Board_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    if (i % 2 == 0){
                        if (j % 2 == 0) {
                            g.FillRectangle(brush[0], i * 50, j * 50, 50, 50);
                        } else {
                            g.FillRectangle(brush[1], i * 50, j * 50, 50, 50);
                        }
                    } else {
                        if (j % 2 == 0){
                            g.FillRectangle(brush[1], i * 50, j * 50, 50, 50);
                        } else { 
                            g.FillRectangle(brush[0], i * 50, j * 50, 50, 50);
                        }
                    }
                    if(highlight[i, j]) {
                        g.FillRectangle(brush[2], i * 50, j * 50, 50, 50);
                    }
                }           
            }
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    if (board[i, j] != '.') {
                        switch (board[i, j])
                        {
                            case 'K':
                                g.DrawImage(KingW, i * 50, j * 50, 50, 50);
                                break;
                            case 'Q':
                                g.DrawImage(QueenW, i * 50, j * 50, 50, 50);
                                break;
                            case 'B':
                                g.DrawImage(BishopW, i * 50, j * 50, 50, 50);
                                break;
                            case 'N':
                                g.DrawImage(KnightW, i * 50, j * 50, 50, 50);
                                break;
                            case 'R':
                                g.DrawImage(RookW, i * 50, j * 50, 50, 50);
                                break;
                            case 'P':
                                g.DrawImage(PawnW, i * 50, j * 50, 50, 50);
                                break;
                            case 'k':
                                g.DrawImage(KingB, i * 50, j * 50, 50, 50);
                                break;
                            case 'q':
                                g.DrawImage(QueenB, i * 50, j * 50, 50, 50);
                                break;
                            case 'b':
                                g.DrawImage(BishopB, i * 50, j * 50, 50, 50);
                                break;
                            case 'n':
                                g.DrawImage(KnightB, i * 50, j * 50, 50, 50);
                                break;
                            case 'r':
                                g.DrawImage(RookB, i * 50, j * 50, 50, 50);
                                break;
                            case 'p':
                                g.DrawImage(PawnB, i * 50, j * 50, 50, 50);
                                break;
                        }
                    }
                }
            }

            pnl_Taken.Invalidate();
            checkMove.generateBitBoard(board);

            tbx_Debug.Text = "";
            string row = "";
            for(int i = 0; i < 8; i++) {
                for(int j = 0; j < 8; j++) {
                   //row += board[j, i];
                }
                for(int j = 0; j < 8; j++) {
                    row += checkMove.bitboard[j, i];
                    row += " ";
                }
                tbx_Debug.AppendText(row);
                tbx_Debug.AppendText("\r\n");
                row = "";
            }
            if(checkMove.checkMate(board) == 'K') {
                tbx_Debug.AppendText("White in check");
            } else if(checkMove.checkMate(board) == 'k') {
                tbx_Debug.AppendText("Black in check");
            } else {
                tbx_Debug.AppendText("No Check");
            }
            
        }

        private void pnl_Taken_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            for(int i = 0; i < takenW.Count; i++) {
                switch(takenW[i]) {
                    case 'K':
                        g.DrawImage(KingW, i * 15, 3, 40, 40);
                        break;
                    case 'Q':
                        g.DrawImage(QueenW, i * 15, 3, 40, 40);
                        break;
                    case 'B':
                        g.DrawImage(BishopW, i * 15, 3, 40, 40);
                        break;
                    case 'N':
                        g.DrawImage(KnightW, i * 15, 3, 40, 40);
                        break;
                    case 'R':
                        g.DrawImage(RookW, i * 15, 3, 40, 40);
                        break;
                    case 'P':
                        g.DrawImage(PawnW, i * 15, 3, 40, 40);
                        break;
                }
            }

            for(int i = 0; i < takenB.Count; i++) {
                switch(takenB[i]) {
                    case 'k':
                        g.DrawImage(KingB, i * 15, 50, 40, 40);
                        break;
                    case 'q':
                        g.DrawImage(QueenB, i * 15, 50, 40, 40);
                        break;
                    case 'b':
                        g.DrawImage(BishopB, i * 15, 50, 40, 40);
                        break;
                    case 'n':
                        g.DrawImage(KnightB, i * 15, 50, 40, 40);
                        break;
                    case 'r':
                        g.DrawImage(RookB, i * 15, 50, 40, 40);
                        break;
                    case 'p':
                        g.DrawImage(PawnB, i * 15, 50, 40, 40);
                        break;
                }
            }
        }

        private void prepareArrays() {
            for(int i = 0; i < 8; i++) {
                for(int j = 0; j < 8; j++) {
                    highlight[j, i] = false;
                }
            }
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    board[j, i] = '.';
                }
            }
            for (int i = 0; i < 8; i++) {
                board[i, 1] = 'p';
            }
            for(int i = 0; i < 8; i++) {
                board[i, 6] = 'P';
            }

            board[0, 0] = 'r';
            board[1, 0] = 'n';
            board[2, 0] = 'b';
            board[3, 0] = 'q';
            board[4, 0] = 'k';
            board[5, 0] = 'b';
            board[6, 0] = 'n';
            board[7, 0] = 'r';

            board[0, 7] = 'R';
            board[1, 7] = 'N';
            board[2, 7] = 'B';
            board[3, 7] = 'Q';
            board[4, 7] = 'K';
            board[5, 7] = 'B';
            board[6, 7] = 'N';
            board[7, 7] = 'R'; 
            
            Whiteturn = true;
            lbl_TurnNotif.Text = "White Turn";
            checkMove.generateBitBoard(board);
        }
        
        private void promotion(int fromX, int fromY, int toY) {
            if((toY == 0 || toY == 7) && char.ToLower(board[fromX, fromY]) == 'p') {
                using(var ChoosePiece = new ChoosePiece()) {
                    if(ChoosePiece.ShowDialog() == DialogResult.OK) {
                        char SwitchTo = ChoosePiece.toPiece;
                        board[fromX, fromY] = SwitchTo;
                    }
                }
            }
        }
        

        private void loadBrushes() {
            brush[0] = new SolidBrush(Color.AntiqueWhite);
            brush[1] = new SolidBrush(Color.Chocolate);
            brush[2] = new SolidBrush(Color.AliceBlue);
        }

        private void btn_Restart_Click(object sender, EventArgs e) {
            using(var RestartPrompt = new RestartPrompt()) {
                if(RestartPrompt.ShowDialog() == DialogResult.Yes) {
                    prepareArrays();
                    pnl_Board.Invalidate();
                }
            }
            //'\u0001'
        }

    }
}
