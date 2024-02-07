using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pente_WPFApp
{
    internal class BoardLogic
    {
        Pente_Board gameBoard = new Pente_Board();

        // Piece Placing Code
        public void placeBlack(int row, int column)
        {
            if(row < 0 || row > 18 || column < 0 || column > 18) { return; }

            int[,] board = gameBoard.GetBoard();

            board[row, column] = 1;

            gameBoard.SetBoard(board);
        }

        public void placeWhite(int row, int column)
        {
            if (row < 0 || row > 18 || column < 0 || column > 18) { return; }

            int[,] board = gameBoard.GetBoard();

            board[row, column] = 2;

            gameBoard.SetBoard(board);
        }

        // "Capture" Code
        public void checkCapture_Black(int[,] board, int row, int column)
        {
            /*
             Up = [row, column-1]
             Up-Right = [row+1, column-1]
             Right = [row+1, column]
             */

            //Diagonal Down-Right = [row+1, column+1]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = board[(row + i), (column + i)];
                if (currentValue == 0) { break; }

                if (i==3 && currentValue == 1) { 
                    board[(row + 1), (column + 1)] = 0; 
                    board[(row + 2), (column + 2)] = 0; 
                }
            }

            //Down = [row, column+1]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = board[(row), (column + i)];
                if (currentValue == 0) { break; }

                if (i == 3 && currentValue == 1)
                {
                    board[(row + 1), (column + 1)] = 0;
                    board[(row + 2), (column + 2)] = 0;
                }
            }

            //Diagonal Down-Left = [row-1, column+1]

            //Left = [row-1, column]

            //Diagonal Up-Left = [row-1, column-1]

            //Up

            //Diagonal Up-Right

            //Right
        }


    }

    class Pente_Board // Stores Board State
    {
        // 0 = Blank
        // 1 = Black
        // 2 = White

        private int[,] board = { // 19x19 board for our Pente Board Game
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //0
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //1
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //2
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //3
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //4
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //5
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //6
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //7
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //8
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //9
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //10
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //11
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //12
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //13
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //14
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //15
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //16
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //17
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } //18
          //  0| 1| 2| 3| 4| 5| 6| 7| 8| 9|10|11|12|13|14|15|16|17|18
        };

        public int[,] GetBoard() { return board; }

        public void SetBoard(int[,] newBoard) { board = newBoard; }
    }
}
