using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WChess {
    class CheckMove {

        public int[,] bitboard = new int[8, 8];

        public bool movePiece(int fromX, int fromY, int toX, int toY, char[,] board) {
            char piece = board[fromX, fromY];
            switch(piece) { // kolla vilken pjäs det är som vill röra sig och om det är ett legalt move
                case 'K':
                    if(wKing(fromX, fromY, toX, toY, board)) {
                        return true;
                    } else {
                        return false;
                    }
                case 'Q':
                    if(wQueen(fromX, fromY, toX, toY, board)) {
                        return true;
                    } else {
                        return false;
                    }
                case 'B':
                    if(wBishop(fromX, fromY, toX, toY, board)) {
                        return true;
                    } else {
                        return false;
                    }
                case 'N':
                    if(wKnight(fromX, fromY, toX, toY, board)) {
                        return true;
                    } else {
                        return false;
                    }
                case 'R':
                    if(wRook(fromX, fromY, toX, toY, board)) {
                        return true;
                    } else {
                        return false;
                    }
                case 'P':
                    if(wPawn(fromX, fromY, toX, toY, board)) {
                        return true;
                    } else {
                        return false;
                    }
                case 'k':
                    if(bKing(fromX, fromY, toX, toY, board)) {
                        return true;
                    } else {
                        return false;
                    }
                case 'q':
                    if(bQueen(fromX, fromY, toX, toY, board)) {
                        return true;
                    } else {
                        return false;
                    }
                case 'b':
                    if(bBishop(fromX, fromY, toX, toY, board)) {
                        return true;
                    } else {
                        return false;
                    }
                case 'n':
                    if(bKnight(fromX, fromY, toX, toY, board)) {
                        return true;
                    } else {
                        return false;
                    }
                case 'r':
                    if(bRook(fromX, fromY, toX, toY, board)) {
                        return true;
                    } else {
                        return false;
                    }
                case 'p':
                    if(bPawn(fromX, fromY, toX, toY, board)) {
                        return true;
                    } else {
                        return false;
                    }
            }
            return false;
        }

        public char checkMate(char[,] board) {
            bool noKing = true;
            int xW = 0, yW = 0, xB = 0, yB = 0;
            generateBitBoard(board);
            for(int i = 0; noKing && i < 8; i++) {
                for(int j = 0; noKing && j < 8; j++) {
                    if(board[j, i] == 'K') { // Hitta vitt kungs x och y
                        yW = i;
                        xW = j;
                        noKing = false;
                    }
                }
            }
            noKing = true;
            for(int i = 0; noKing && i < 8; i++) {
                for(int j = 0; noKing && j < 8; j++) {
                    if(board[j, i] == 'k') { // Hitta svart kungs x och y
                        yB = i;
                        xB = j;
                        noKing = false;
                    }
                }
            }

            if(bitboard[xW, yW] != 0) { // Returnar vilken kung som är i schack om ingen är i schack returnar den .
                return 'K';
            } else if(bitboard[xB, yB] != 0) {
                return 'k';
            } else {
                return '.';
            }
        }

        public void promotion(int fromX, int fromY, int toY, char[,] board) {
            if((toY == 0 || toY == 7) && char.ToLower(board[fromX, fromY]) == 'p') { // kolla om det är en bonde som kommit fram till sista raden
                using(var ChoosePiece = new ChoosePiece()) { // Fråga vilken pjäs de vill ha
                    if(ChoosePiece.ShowDialog() == DialogResult.OK) {
                        char SwitchTo = ChoosePiece.toPiece;
                        board[fromX, fromY] = SwitchTo;
                    }
                }
            }
        }

        public void generateBitBoard(char[,] board) { // Gör en bräda som visar hur många pjäser som kan flytta sig till en specifik plats
            for(int i = 0; i < 8; i++) {
                for(int j = 0; j < 8; j++) {
                    bitboard[j, i] = 0;
                }
            }

            for(int i = 0; i < 8; i++) {
                for(int j = 0; j < 8; j++) {
                    if(board[i, j] != '.') {
                        for(int x = 0; x < 8; x++) {
                            for(int y = 0; y < 8; y++) {
                                if(movePiece(i, j, x, y, board)) {
                                    bitboard[x, y]++;
                                }
                            }
                        }
                    }
                }
            }

        }
        /*
        Allt efter här kollar på pjäsernas olika rörelser och svarar med true/false beroende om den pjäsen får röra sig så
        */
        private bool bPawn(int fromX, int fromY, int toX, int toY, char[,] board) {
            if(toY == fromY + 1) {
                if(toX == fromX && board[toX, toY] == '.') {
                    return true;
                } else if(board[toX, toY] != '.' && (toX == fromX - 1 || toX == fromX + 1) && char.IsUpper(board[toX, toY])) {
                    return true;
                } else {
                    return false;
                }
            } else if(toY == 3 && toX == fromX && board[toX, toY] == '.' && board[toX, 2] == '.') {
                return true;
            } else {
                return false;
            }
        
        }

        private bool wPawn(int fromX, int fromY, int toX, int toY, char[,] board) {
            if(toY == fromY - 1) {
                if(toX == fromX && board[toX, toY] == '.') {
                    return true;
                } else if(board[toX, toY] != '.' && (toX == fromX - 1 || toX == fromX + 1) && char.IsLower(board[toX, toY])) {
                    return true;
                } else {
                    return false;
                }
            } else if(toY == 4 && toX == fromX && board[toX, toY] == '.' && board[toX, 5] == '.') {
                return true;
            } else {
                return false;
            }
        }

        private bool bRook(int fromX, int fromY, int toX, int toY, char[,] board) {
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

        private bool wRook(int fromX, int fromY, int toX, int toY, char[,] board) {
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

        private bool wKnight(int fromX, int fromY, int toX, int toY, char[,] board) {
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

        private bool bKnight(int fromX, int fromY, int toX, int toY, char[,] board) {
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

        private bool wBishop(int fromX, int fromY, int toX, int toY, char[,] board) {
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

        private bool bBishop(int fromX, int fromY, int toX, int toY, char[,] board) {
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

        private bool wQueen(int fromX, int fromY, int toX, int toY, char[,] board) {
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

        private bool bQueen(int fromX, int fromY, int toX, int toY, char[,] board) {
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

        private bool wKing(int fromX, int fromY, int toX, int toY, char[,] board) {
            if((toX == fromX + 1 || toX == fromX - 1) && (toY == fromY + 1 || toY == fromY - 1)) {
                if(char.IsLower(board[toX, toY]) || board[toX, toY] == '.') {
                    return true;
                }
            } else if(((toX == fromX + 1 || toX == fromX -1) && toY == fromY) || ((toY == fromY + 1 || toY == fromY - 1) && toX == fromX)) {
                if(char.IsLower(board[toX, toY]) || board[toX, toY] == '.') {
                    return true;
                }
            }
            return false;
        }

        private bool bKing(int fromX, int fromY, int toX, int toY, char[,] board) {
            if((toX == fromX + 1 || toX == fromX - 1) && (toY == fromY + 1 || toY == fromY - 1)) {
                if(char.IsUpper(board[toX, toY]) || board[toX, toY] == '.') {
                    return true;
                }
            } else if(((toX == fromX + 1 || toX == fromX - 1) && toY == fromY) || ((toY == fromY + 1 || toY == fromY - 1) && toX == fromX)) {
                if(char.IsUpper(board[toX, toY]) || board[toX, toY] == '.') {
                    return true;
                }
            }
            return false;
        }

    }
}
