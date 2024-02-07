using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pente_WPFApp
{
    internal class BoardLogic
    {
        private Pente_Board gameBoard = new Pente_Board();

        // Returns Board from Backend Logic to Frontend for Viewing Logic
        public Pente_Board getBoardState() { return gameBoard; }

        // Piece Placing Code
        public void placeBlack(int row, int column)
        {
            if(row < 0 || row > 18 || column < 0 || column > 18) { return; }

            int[,] board = gameBoard.GetBoard();

            board[row, column] = 1;

            board = checkCapture_Black(board, row, column);

            gameBoard.SetBoard(board);
        }

        public void placeWhite(int row, int column)
        {
            if (row < 0 || row > 18 || column < 0 || column > 18) { return; }

            int[,] board = gameBoard.GetBoard();

            board[row, column] = 2;

            board = checkCapture_White(board, row, column);

            gameBoard.SetBoard(board);
        }

        // "Capture" Code [ Can Capture exactly 2 Tiles, no less no more ]
        public int[,] checkCapture_Black(int[,] board, int row, int column)
        {

            //Diagonal Down-Right = [row+1, column+1]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = board[(row + i), (column + i)];
                if (currentValue == 0 || currentValue == 1) { break; }

                if (i==3 && currentValue == 1) { 
                    board[(row + 1), (column + 1)] = 0; 
                    board[(row + 2), (column + 2)] = 0; 
                }
            }

            //Down = [row, column+1]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = board[(row), (column + i)];
                if (currentValue == 0 || currentValue == 1) { break; }

                if (i == 3 && currentValue == 1)
                {
                    board[(row), (column + 1)] = 0;
                    board[(row), (column + 2)] = 0;
                }
            }

            //Diagonal Down-Left = [row-1, column+1]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = board[(row - i), (column + i)];
                if (currentValue == 0 || currentValue == 1) { break; }

                if (i == 3 && currentValue == 1)
                {
                    board[(row - 1), (column + 1)] = 0;
                    board[(row - 2), (column + 2)] = 0;
                }
            }

            //Left = [row-1, column]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = board[(row - i), (column)];
                if (currentValue == 0 || currentValue == 1) { break; }

                if (i == 3 && currentValue == 1)
                {
                    board[(row - 1), (column)] = 0;
                    board[(row - 2), (column)] = 0;
                }
            }

            //Diagonal Up-Left = [row-1, column-1]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = board[(row - i), (column - i)];
                if (currentValue == 0 || currentValue == 1) { break; }

                if (i == 3 && currentValue == 1)
                {
                    board[(row - 1), (column - 1)] = 0;
                    board[(row - 2), (column - 2)] = 0;
                }
            }

            //Up = [row, column-1]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = board[(row), (column - i)];
                if (currentValue == 0 || currentValue == 1) { break; }

                if (i == 3 && currentValue == 1)
                {
                    board[(row), (column - 1)] = 0;
                    board[(row), (column - 2)] = 0;
                }
            }

            //Diagonal Up-Right = [row+1, column-1]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = board[(row + i), (column - i)];
                if (currentValue == 0 || currentValue == 1) { break; }

                if (i == 3 && currentValue == 1)
                {
                    board[(row + 1), (column - 1)] = 0;
                    board[(row + 2), (column - 2)] = 0;
                }
            }


            //Right = [row+1, column]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = board[(row + i), (column)];
                if (currentValue == 0 || currentValue == 1) { break; }

                if (i == 3 && currentValue == 1)
                {
                    board[(row + 1), (column)] = 0;
                    board[(row + 2), (column)] = 0;
                }
            }

            return board;
        }


        public int[,] checkCapture_White(int[,] board, int row, int column)
        {

            //Diagonal Down-Right = [row+1, column+1]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = board[(row + i), (column + i)];
                if (currentValue == 0 || currentValue == 2) { break; }

                if (i == 3 && currentValue == 2)
                {
                    board[(row + 1), (column + 1)] = 0;
                    board[(row + 2), (column + 2)] = 0;
                }
            }

            //Down = [row, column+1]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = board[(row), (column + i)];
                if (currentValue == 0 || currentValue == 2) { break; }

                if (i == 3 && currentValue == 2)
                {
                    board[(row), (column + 1)] = 0;
                    board[(row), (column + 2)] = 0;
                }
            }

            //Diagonal Down-Left = [row-1, column+1]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = board[(row - i), (column + i)];
                if (currentValue == 0 || currentValue == 2) { break; }

                if (i == 3 && currentValue == 2)
                {
                    board[(row - 1), (column + 1)] = 0;
                    board[(row - 2), (column + 2)] = 0;
                }
            }

            //Left = [row-1, column]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = board[(row - i), (column)];
                if (currentValue == 0 || currentValue == 2) { break; }

                if (i == 3 && currentValue == 2)
                {
                    board[(row - 1), (column)] = 0;
                    board[(row - 2), (column)] = 0;
                }
            }

            //Diagonal Up-Left = [row-1, column-1]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = board[(row - i), (column - i)];
                if (currentValue == 0 || currentValue == 2) { break; }

                if (i == 3 && currentValue == 2)
                {
                    board[(row - 1), (column - 1)] = 0;
                    board[(row - 2), (column - 2)] = 0;
                }
            }

            //Up = [row, column-1]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = board[(row), (column - i)];
                if (currentValue == 0 || currentValue == 2) { break; }

                if (i == 3 && currentValue == 2)
                {
                    board[(row), (column - 1)] = 0;
                    board[(row), (column - 2)] = 0;
                }
            }

            //Diagonal Up-Right = [row+1, column-1]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = board[(row + i), (column - i)];
                if (currentValue == 0 || currentValue == 2) { break; }

                if (i == 3 && currentValue == 2)
                {
                    board[(row + 1), (column - 1)] = 0;
                    board[(row + 2), (column - 2)] = 0;
                }
            }


            //Right = [row+1, column]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = board[(row + i), (column)];
                if (currentValue == 0 || currentValue == 2) { break; }

                if (i == 3 && currentValue == 2)
                {
                    board[(row + 1), (column)] = 0;
                    board[(row + 2), (column)] = 0;
                }
            }

            return board;
        }


        // Reset / Clear Board
        public void clearBoard()
        {
            gameBoard = new Pente_Board();
        }

        

    }

    class Pente_Board // Stores Board State
    {
        // 0 = Blank
        // 1 = Black
        // 2 = White

        private int[,] board = { // 13x13 board for our Pente Board Game
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //0
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //1
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //2
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //3
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //4
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //5
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //6
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //7
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //8
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //9
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //10
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //11
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //12
          //  0| 1| 2| 3| 4| 5| 6| 7| 8| 9|10|11|12
        };

        public int[,] GetBoard() { return board; }

        public void SetBoard(int[,] newBoard) { board = newBoard; }


        // Print then Return Board as String for Testing Purposes
        public string toString()
        {
            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < board.GetLength(0); row++)
            {
                Console.WriteLine($"Row {row} -->  ");

                for (int col = 0; col < board.GetLength(1); col++)
                {

                    Console.Write($"{board[row,col]}");

                    sb.Append($"{board[row, col]}");
                    
                }

                sb.Append("\n");
            }

            return sb.ToString();
        }
    }
}
