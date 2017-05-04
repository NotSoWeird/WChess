using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WChess
{
    public partial class Form1 : Form
    {
        char[,] board = new char[8, 8];
        bool[,] highlight = new bool[8, 8];

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
        public Form1()
        {
            InitializeComponent();
            prepareArrays();
            loadBrushes();
            loadImages();
            panel1.Invalidate();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X / 40;
            int y = e.Y / 40;

            if (e.Button == MouseButtons.Left)
            {

            }
        }
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++) {
                    if (i % 2 == 0){
                        if (j % 2 == 0)
                        {
                            g.FillRectangle(brush[0], i * 50, j * 50, 50, 50);
                        }
                        else
                        {
                            g.FillRectangle(brush[1], i * 50, j * 50, 50, 50);
                        }
                    } else {
                        if (j % 2 == 0)
                        {
                            g.FillRectangle(brush[1], i * 50, j * 50, 50, 50);
                        }
                        else
                        {
                            g.FillRectangle(brush[0], i * 50, j * 50, 50, 50);
                        }
                    }
                }           
            }
            for (int i = 0; i < 0; i++)
            {
                for (int j = 0; j < 0; j++)
                {
                    if (board[i, j] != '.')
                    {
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
        }

        private void prepareArrays()
        {
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    highlight[j, i] = false;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board[j, i] = '.';
                }
            }
            for (int i = 0; i < 8; i++)
            {
                board[i, 1] = 'p';
            }
            for(int i = 0; i < 8; i++)
            {
                board[i, 7] = 'P';
            }
            board[0, 0] = 'r';
            board[0, 1] = 'n';
            board[0, 2] = 'b';
            board[0, 3] = 'q';
            board[0, 4] = 'k';
            board[0, 5] = 'b';
            board[0, 6] = 'n';
            board[0, 7] = 'r';

            board[7, 0] = 'R';
            board[7, 1] = 'N';
            board[7, 2] = 'B';
            board[7, 3] = 'Q';
            board[7, 4] = 'K';
            board[7, 5] = 'B';
            board[7, 6] = 'N';
            board[7, 7] = 'R';

        }

        private void loadImages()
        {
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
        }

        private void placePieces()
        {
            
        }

        private void loadBrushes()
        {
            brush[0] = new SolidBrush(Color.AntiqueWhite);
            brush[1] = new SolidBrush(Color.Chocolate);
            brush[2] = new SolidBrush(Color.AliceBlue);
        }
    }
}
