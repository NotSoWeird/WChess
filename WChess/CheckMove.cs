﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WChess
{
    class CheckMove
    {
        Form1 f = new WChess.Form1();
        public CheckMove()
        {
            
        }

        public bool bPawn(int fromX, int fromY, int toX, int toY, char[,] board)
        {
            if(toY == fromY + 1) {
                if(toX == fromX && board[toX, toY] == '.') {
                    return true;
                } else if(board[toX, toY] != '.') {
                    if(toX == fromX - 1 || toX == fromX + 1) {
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    return false;
                }
            } else if(toY == 3) {
                return true;
            } else {
                return false;
            }
        }

        public bool wPawn(int fromX, int fromY, int toX, int toY, char[,] board) {
            if(toY == fromY - 1) {
                if(toX == fromX && board[toX, toY] == '.') {
                    return true;
                } else if(board[toX, toY] != '.' && (toX == fromX - 1 || toX == fromX + 1)) {
                    return true;
                } else {
                    return false;
                }
            } else if(toY == 4) {
                return true;
            } else {
                return false;
            }
        }

        public bool bRook(int fromX, int fromY, int toX, int toY, char[,] board) {
            int dir, checkX, checkY;
            bool notDone;
            if(fromX != toX && fromY != toY) {
                return false;
            } else if(fromX != toX) {
                dir = fromX - toX;
                checkX = fromX;
                notDone = true;
                if(dir < 0) {
                    while(checkX != toX && checkX <= 1 && notDone) {
                        checkX++;
                        if(board[checkX, fromY] != '.') {
                            notDone = false;
                        }
                    }
                    if(checkX >= toX) {
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    if(checkX > 7) {
                        while(checkX != toX && checkX >= 7 && notDone) {
                            checkX--;
                            if(board[checkX, fromY] != '.') {
                                notDone = false;
                            }
                        }
                    }
                    if(checkX <= toX) {
                        return true;
                    } else {
                        return false;
                    }
                }
            } else if(fromX != toX) {
                dir = fromX - toX;
                checkY = fromY;
                notDone = true;
                if(dir < 0) {
                    while(checkY != toY && checkY <= 1 && notDone) {
                        checkY++;
                        if(board[fromX, checkY] != '.') {
                            notDone = false;
                        }
                    }
                    if(checkY >= toY) {
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    while(checkY != toX && checkY >= 7 && notDone) {
                        checkY--;
                        if(board[fromX, checkY] != '.') {
                            notDone = false;
                        }
                    }
                    if(checkY <= toY) {
                        return true;
                    } else {
                        return false;
                    }
                }
            } else {
                return false;
            }
        }

        public bool wRook(int fromX, int fromY, int toX, int toY, char[,] board) {
            if(fromX != toX && fromY != toY) {
                return false;
            } else if(fromX != toX || fromY != toY) {
                
                return false;
            } else {
                return false;
            }
        }
    }
}
