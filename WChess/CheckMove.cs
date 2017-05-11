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

        public bool wPawn(int fromX, int fromY, int toX, int toY)
        {
            if(toY == fromY + 1) {
                if(toX == fromX && f.board[toX, toY] == '.') {
                    return true;
                } else if(f.board[toX, toY] != '.' && (toX == fromX - 1 || toX == fromX + 1)) {
                    return true;
                } else {
                    return false;
                }
            } else if(toY == 3) {
                return true;
            } else {
                return false;
            }
        }

        public bool bPawn(int fromX, int fromY, int toX, int toY) {
            if(toY == fromY - 1) {
                if(toX == fromX && f.board[toX, toY] == '.') {
                    return true;
                } else if(f.board[toX, toY] != '.' && (toX == fromX - 1 || toX == fromX + 1)) {
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

        public bool wRook(int fromX, int fromY, int toX, int toY) {
            int dir, checkX, checkY;
            bool notDone;
            if(fromX != toX && fromY != toY) {
                return false;
            } else if(fromX != toX) {
                dir = fromX - toX;
                checkX = fromX;
                notDone = true;
                if(dir < 0) {
                    while(checkX != toX && notDone) {
                        checkX--;
                        if(f.board[checkX, fromY] != '.') {
                            notDone = false;
                        }
                    }
                    if(checkX == toX) {
                        return true;
                    }else {
                        return false;
                    }
                } else {
                    while(checkX != toX && notDone) {
                        checkX++;
                        if(f.board[checkX, fromY] != '.') {
                            notDone = false;
                        }
                    }
                    if(checkX == toX) {
                        return true;
                    } else {
                        return false;
                    }
                }
            } else {
                return false;
            }
        }

        public bool bRook(int fromX, int fromY, int toX, int toY) {
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
