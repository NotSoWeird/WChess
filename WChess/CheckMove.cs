using System;
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
            } else if(toY == 3 && board[toX, toY] == '.' && board[toX, 2] == '.') {
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
            } else if(toY == 4 && board[toX, toY] == '.' && board[toX, 5] == '.') {
                return true;
            } else {
                return false;
            }
        }

        public bool bRook(int fromX, int fromY, int toX, int toY, char[,] board) {
            int checkX, checkY;
            if(fromX != toX && fromY != toY) {
                return false;
            } else if(fromX != toX) {
                if((toX - fromX) > 0) {
                    checkX = fromX + 1;
                    while(checkX < toX && board[checkX, toY] == '.') {
                        checkX++;
                    }
                    if(checkX == toX && (char.IsUpper(board[toX, toY]) || board[toX, toY] == '.')) {
                        return true;
                    }
                } else {
                    checkX = fromX - 1;
                    while(checkX > toX && board[checkX, toY] == '.') {
                        checkX--;
                    }
                    if(checkX == toX && (char.IsUpper(board[toX, toY]) || board[toX, toY] == '.')) {
                        return true;
                    }
                }
                return false;
            } else if(fromY != toY) {
                if((toY - fromY) > 0) {
                    checkY = fromY + 1;
                    while(checkY < toY && board[toX, checkY] == '.') {
                        checkY++;
                    }
                    if(checkY == toY && (char.IsUpper(board[toX, toY]) || board[toX, toY] == '.')) {
                        return true;
                    }
                } else {
                    checkY = fromY - 1;
                    while(checkY > toY && board[toX, checkY] == '.') {
                        checkY--;
                    }
                    if(checkY == toY && (char.IsUpper(board[toX, toY]) || board[toX, toY] == '.')) {
                        return true;
                    }
                }
                return false;
            } else {
                return false;
            }
        }

        public bool wRook(int fromX, int fromY, int toX, int toY, char[,] board) {
            int checkX, checkY;
            if(fromX != toX && fromY != toY) {
                return false;
            } else if(fromX != toX) {
                if((toX - fromX) > 0) {
                    checkX = fromX + 1;
                    while(checkX < toX && board[checkX, toY] == '.') {
                        checkX++;
                    }
                    if(checkX == toX && (char.IsLower(board[toX, toY]) || board[toX, toY] == '.')) {
                        return true;
                    }
                } else {
                    checkX = fromX - 1;
                    while(checkX > toX && board[checkX, toY] == '.') {
                        checkX--;
                    }
                    if(checkX == toX && (char.IsLower(board[toX, toY]) || board[toX, toY] == '.')) {
                        return true;
                    }
                }
                return false;
            } else if(fromY != toY) {
                if((toY - fromY) > 0) {
                    checkY = fromY + 1;
                    while(checkY < toY && board[toX, checkY] == '.') {
                        checkY++;
                    }
                    if(checkY == toY && (char.IsLower(board[toX, toY]) || board[toX, toY] == '.')) {
                        return true;
                    }
                } else {
                    checkY = fromY - 1;
                    while(checkY > toY && board[toX, checkY] == '.') {
                        checkY--;
                    }
                    if(checkY == toY && (char.IsLower(board[toX, toY]) || board[toX, toY] == '.')) {
                        return true;
                    }
                }
                return false;
            } else {
                return false;
            }
        }

        public bool wKnight(int fromX, int fromY, int toX, int toY, char[,] board) {
            if((toX == fromX + 2 && (toY == fromY + 1 || toY == fromY - 1)) || (toX == fromX - 2 && (toY == fromY + 1 || toY == fromY - 1))) {
                if(board[toX, toY] == '.' || char.IsLower(board[toX, toY])) {
                    return true;
                } else {
                    return false;
                }  
            } else if((toY == fromY + 2 && (toX == fromX + 1 || toX == fromX - 1)) || (toY == fromY - 2 && (toX == fromX + 1 || toX == fromX - 1))) {
                if(board[toX, toY] == '.' || char.IsLower(board[toX, toY])) {
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }

        public bool bKnight(int fromX, int fromY, int toX, int toY, char[,] board) {
            if((toX == fromX + 2 && (toY == fromY + 1 || toY == fromY - 1)) || (toX == fromX - 2 && (toY == fromY + 1 || toY == fromY - 1))) {
                if(board[toX, toY] == '.' || char.IsUpper(board[toX, toY])) {
                    return true;
                } else {
                    return false;
                }
            } else if((toY == fromY + 2 && (toX == fromX + 1 || toX == fromX - 1)) || (toY == fromY - 2 && (toX == fromX + 1 || toX == fromX - 1))) {
                if(board[toX, toY] == '.' || char.IsUpper(board[toX, toY])) {
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }

        public bool wBishop(int fromX, int fromY, int toX, int toY, char[,] board) {
            if(fromX != toX && fromY != toY) {
                int checkX, checkY;
                if((toX - fromX) > 0) {
                    if((toY - fromY) > 0) {
                        checkX = fromX + 1;
                        checkY = fromY + 1;
                        while(checkX < toX && checkY < toY && board[checkX, checkY] == '.') {
                            checkX++;
                            checkY++;
                        }
                        if(checkX == toX && checkY == toY && (char.IsLower(board[toX, toY]) || board[toX, toY] == '.')) {
                            return true;
                        }
                    } else {
                        checkX = fromX + 1;
                        checkY = fromY - 1;
                        while(checkX < toX && checkY > toY && board[checkX, checkY] == '.') {
                            checkX++;
                            checkY--;
                        }
                        if(checkX == toX && checkY == toY && (char.IsLower(board[toX, toY]) || board[toX, toY] == '.')) {
                            return true;
                        }
                    }
                } else {
                    if((toY - fromY) > 0) {
                        checkX = fromX - 1;
                        checkY = fromY + 1;
                        while(checkX > toX && checkY < toY && board[checkX, checkY] == '.') {
                            checkX--;
                            checkY++;
                        }
                        if(checkX == toX && checkY == toY && (char.IsLower(board[toX, toY]) || board[toX, toY] == '.')) {
                            return true;
                        }
                    } else {
                        checkX = fromX - 1;
                        checkY = fromY - 1;
                        while(checkX > toX && checkY > toY && board[checkX, checkY] == '.') {
                            checkX--;
                            checkY--;
                        }
                        if(checkX == toX && checkY == toY && (char.IsLower(board[toX, toY]) || board[toX, toY] == '.')) {
                            return true;
                        }
                    }
                }
                return false;
            } else {
                return false;
            }
        }

        public bool bBishop(int fromX, int fromY, int toX, int toY, char[,] board) {
            if(fromX != toX && fromY != toY) {
                int checkX, checkY;
                if((toX - fromX) > 0) {
                    if((toY - fromY) > 0) {
                        checkX = fromX + 1;
                        checkY = fromY + 1;
                        while(checkX < toX && checkY < toY && board[checkX, checkY] == '.') {
                            checkX++;
                            checkY++;
                        }
                        if(checkX == toX && checkY == toY && (char.IsUpper(board[toX, toY]) || board[toX, toY] == '.')) {
                            return true;
                        }
                    } else {
                        checkX = fromX + 1;
                        checkY = fromY - 1;
                        while(checkX < toX && checkY > toY && board[checkX, checkY] == '.') {
                            checkX++;
                            checkY--;
                        }
                        if(checkX == toX && checkY == toY && (char.IsUpper(board[toX, toY]) || board[toX, toY] == '.')) {
                            return true;
                        }
                    }
                } else {
                    if((toY - fromY) > 0) {
                        checkX = fromX - 1;
                        checkY = fromY + 1;
                        while(checkX > toX && checkY < toY && board[checkX, checkY] == '.') {
                            checkX--;
                            checkY++;
                        }
                        if(checkX == toX && checkY == toY && (char.IsUpper(board[toX, toY]) || board[toX, toY] == '.')) {
                            return true;
                        }
                    } else {
                        checkX = fromX - 1;
                        checkY = fromY - 1;
                        while(checkX > toX && checkY > toY && board[checkX, checkY] == '.') {
                            checkX--;
                            checkY--;
                        }
                        if(checkX == toX && checkY == toY && (char.IsUpper(board[toX, toY]) || board[toX, toY] == '.')) {
                            return true;
                        }
                    }
                }
                return false;
            } else {
                return false;
            }
        }

        public bool wQueen(int fromX, int fromY, int toX, int toY, char[,] board) {
            int checkX, checkY;
            if(fromX != toX && fromY != toY) {
                if((toX - fromX) > 0) {
                    if((toY - fromY) > 0) {
                        checkX = fromX + 1;
                        checkY = fromY + 1;
                        while(checkX < toX && checkY < toY && board[checkX, checkY] == '.') {
                            checkX++;
                            checkY++;
                        }
                        if(checkX == toX && checkY == toY && (char.IsUpper(board[toX, toY]) || board[toX, toY] == '.')) {
                            return true;
                        }
                    } else {
                        checkX = fromX + 1;
                        checkY = fromY - 1;
                        while(checkX < toX && checkY > toY && board[checkX, checkY] == '.') {
                            checkX++;
                            checkY--;
                        }
                        if(checkX == toX && checkY == toY && (char.IsUpper(board[toX, toY]) || board[toX, toY] == '.')) {
                            return true;
                        }
                    }
                } else {
                    if((toY - fromY) > 0) {
                        checkX = fromX - 1;
                        checkY = fromY + 1;
                        while(checkX > toX && checkY < toY && board[checkX, checkY] == '.') {
                            checkX--;
                            checkY++;
                        }
                        if(checkX == toX && checkY == toY && (char.IsUpper(board[toX, toY]) || board[toX, toY] == '.')) {
                            return true;
                        }
                    } else {
                        checkX = fromX - 1;
                        checkY = fromY - 1;
                        while(checkX > toX && checkY > toY && board[checkX, checkY] == '.') {
                            checkX--;
                            checkY--;
                        }
                        if(checkX == toX && checkY == toY && (char.IsUpper(board[toX, toY]) || board[toX, toY] == '.')) {
                            return true;
                        }
                    }
                }
            } else if(fromX != toX) {
                if((toX - fromX) > 0) {
                    checkX = fromX + 1;
                    while(checkX < toX && board[checkX, toY] == '.') {
                        checkX++;
                    }
                    if(checkX == toX && (char.IsLower(board[toX, toY]) || board[toX, toY] == '.')) {
                        return true;
                    }
                } else {
                    checkX = fromX - 1;
                    while(checkX > toX && board[checkX, toY] == '.') {
                        checkX--;
                    }
                    if(checkX == toX && (char.IsLower(board[toX, toY]) || board[toX, toY] == '.')) {
                        return true;
                    }
                }
                return false;
            } else if(fromY != toY) {
                if((toY - fromY) > 0) {
                    checkY = fromY + 1;
                    while(checkY < toY && board[toX, checkY] == '.') {
                        checkY++;
                    }
                    if(checkY == toY && (char.IsLower(board[toX, toY]) || board[toX, toY] == '.')) {
                        return true;
                    }
                } else {
                    checkY = fromY - 1;
                    while(checkY > toY && board[toX, checkY] == '.') {
                        checkY--;
                    }
                    if(checkY == toY && (char.IsLower(board[toX, toY]) || board[toX, toY] == '.')) {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }

        public bool bQueen(int fromX, int fromY, int toX, int toY, char[,] board) {
            int checkX, checkY;
            if(fromX != toX && fromY != toY) {
                if((toX - fromX) > 0) {
                    if((toY - fromY) > 0) {
                        checkX = fromX + 1;
                        checkY = fromY + 1;
                        while(checkX < toX && checkY < toY && board[checkX, checkY] == '.') {
                            checkX++;
                            checkY++;
                        }
                        if(checkX == toX && checkY == toY && (char.IsUpper(board[toX, toY]) || board[toX, toY] == '.')) {
                            return true;
                        }
                    } else {
                        checkX = fromX + 1;
                        checkY = fromY - 1;
                        while(checkX < toX && checkY > toY && board[checkX, checkY] == '.') {
                            checkX++;
                            checkY--;
                        }
                        if(checkX == toX && checkY == toY && (char.IsUpper(board[toX, toY]) || board[toX, toY] == '.')) {
                            return true;
                        }
                    }
                } else {
                    if((toY - fromY) > 0) {
                        checkX = fromX - 1;
                        checkY = fromY + 1;
                        while(checkX > toX && checkY < toY && board[checkX, checkY] == '.') {
                            checkX--;
                            checkY++;
                        }
                        if(checkX == toX && checkY == toY && (char.IsUpper(board[toX, toY]) || board[toX, toY] == '.')) {
                            return true;
                        }
                    } else {
                        checkX = fromX - 1;
                        checkY = fromY - 1;
                        while(checkX > toX && checkY > toY && board[checkX, checkY] == '.') {
                            checkX--;
                            checkY--;
                        }
                        if(checkX == toX && checkY == toY && (char.IsUpper(board[toX, toY]) || board[toX, toY] == '.')) {
                            return true;
                        }
                    }
                }
            } else if(fromX != toX) {
                if((toX - fromX) > 0) {
                    checkX = fromX + 1;
                    while(checkX < toX && board[checkX, toY] == '.') {
                        checkX++;
                    }
                    if(checkX == toX && (char.IsUpper(board[toX, toY]) || board[toX, toY] == '.')) {
                        return true;
                    }
                } else {
                    checkX = fromX - 1;
                    while(checkX > toX && board[checkX, toY] == '.') {
                        checkX--;
                    }
                    if(checkX == toX && (char.IsUpper(board[toX, toY]) || board[toX, toY] == '.')) {
                        return true;
                    }
                }
                return false;
            } else if(fromY != toY) {
                if((toY - fromY) > 0) {
                    checkY = fromY + 1;
                    while(checkY < toY && board[toX, checkY] == '.') {
                        checkY++;
                    }
                    if(checkY == toY && (char.IsUpper(board[toX, toY]) || board[toX, toY] == '.')) {
                        return true;
                    }
                } else {
                    checkY = fromY - 1;
                    while(checkY > toY && board[toX, checkY] == '.') {
                        checkY--;
                    }
                    if(checkY == toY && (char.IsUpper(board[toX, toY]) || board[toX, toY] == '.')) {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }

        public bool wKing(int fromX, int fromY, int toX, int toY, char[,] board) {
            if((toX == fromX + 1 || toX == fromX - 1) && (toY == fromY + 1 || toY == fromY - 1)) {
                return true;
            }else if() {
                return true;
            }
            return false;
        }

        public bool bKing(int fromX, int fromY, int toX, int toY, char[,] board) {
            return false;
        }
    }
}
