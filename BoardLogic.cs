using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Pente_WPFApp
{
    // Board needs to be in a changeable setup between 9x9 and 39x39 ; MUST BE ODD
    // Sets first Pin in center point
    // Save / Load Functions
    // File Persistence through JSON, YAML, or XML


    internal class BoardLogic
    {
        int whiteCaptures = 0;
        int blackCaptures = 0;
        int winner = 0; // 1 for player win 2 for ai win
        private Pente_Board gameBoard = new Pente_Board();

        // Returns Board from Backend Logic to Frontend for Viewing Logic
        public Pente_Board getBoardState() { return gameBoard; }

        // Piece Placing Code
        public void placeBlack(int row, int column)
        {
            if (winner < 1)
            {
                if (row < 0 || row > 12 || column < 0 || column > 12) { return; }

                int[,] board = gameBoard.GetBoard();

                board[row, column] = 1;

                board = checkCapture_Black(board, row, column);

                gameBoard.SetBoard(board);
                if (whiteCaptures >= 5)
                {
                    winner = 2;
                }
            }
        }

        public void placeWhite(int row, int column)
        {
            if (winner < 1) {
                if (row < 0 || row > 18 || column < 0 || column > 18) { return; }

                int[,] board = gameBoard.GetBoard();

                board[row, column] = 2;

                board = checkCapture_White(board, row, column);

                gameBoard.SetBoard(board);
                if (whiteCaptures >= 5)
                {
                    winner = 1;
                }
            }
        }

        // "Capture" Code [ Can Capture exactly 2 Tiles, no less no more ]
        public int[,] checkCapture_Black(int[,] board, int row, int column)
        {

            //Diagonal Down-Right = [row+, column+]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = 0;
                if (row + i < 13 && column + i < 13)
                {
                    currentValue = board[(row + i), (column + i)];
                }
                
                if (currentValue == 0 || (currentValue == 1 && i < 3)) { break; }

                if (i==3 && currentValue == 1) { 
                    board[(row + 1), (column + 1)] = 0; 
                    board[(row + 2), (column + 2)] = 0;
                    blackCaptures++;
                }
            }

            //Down = [row, column+]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = 0;
                if (row + i < 13 && column + i < 13)
                {
                    currentValue = board[(row + i), (column + i)];
                }
                if (currentValue == 0 || (currentValue == 1 && i < 3)) { break; }

                if (i == 3 && currentValue == 1)
                {
                    board[(row), (column + 1)] = 0;
                    board[(row), (column + 2)] = 0;
                    blackCaptures++;
                }
            }

            //Diagonal Down-Left = [row-, column+]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = 0;
                if (row + i < 13 && column + i < 13)
                {
                    currentValue = board[(row + i), (column + i)];
                }
                if (currentValue == 0 || (currentValue == 1 && i < 3)) { break; }

                if (i == 3 && currentValue == 1)
                {
                    board[(row - 1), (column + 1)] = 0;
                    board[(row - 2), (column + 2)] = 0;
                    blackCaptures++;
                }
            }

            //Left = [row-, column]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = 0;
                if (row + i < 13 && column + i < 13)
                {
                    currentValue = board[(row + i), (column + i)];
                }
                if (currentValue == 0 || (currentValue == 1 && i < 3)) { break; }

                if (i == 3 && currentValue == 1)
                {
                    board[(row - 1), (column)] = 0;
                    board[(row - 2), (column)] = 0;
                    blackCaptures++;
                }
            }

            //Diagonal Up-Left = [row-, column-]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = 0;
                if (row + i < 13 && column + i < 13)
                {
                    currentValue = board[(row + i), (column + i)];
                }
                if (currentValue == 0 || (currentValue == 1 && i < 3)) { break; }

                if (i == 3 && currentValue == 1)
                {
                    board[(row - 1), (column - 1)] = 0;
                    board[(row - 2), (column - 2)] = 0;
                    blackCaptures++;
                }
            }

            //Up = [row, column-]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = 0;
                if (row + i < 13 && column + i < 13)
                {
                    currentValue = board[(row + i), (column + i)];
                }
                if (currentValue == 0 || (currentValue == 1 && i < 3)) { break; }

                if (i == 3 && currentValue == 1)
                {
                    board[(row), (column - 1)] = 0;
                    board[(row), (column - 2)] = 0;
                    blackCaptures++;
                }
            }

            //Diagonal Up-Right = [row+, column-]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = 0;
                if (row + i < 13 && column + i < 13)
                {
                    currentValue = board[(row + i), (column + i)];
                }
                if (currentValue == 0 || (currentValue == 1 && i < 3)) { break; }

                if (i == 3 && currentValue == 1)
                {
                    board[(row + 1), (column - 1)] = 0;
                    board[(row + 2), (column - 2)] = 0;
                    blackCaptures++;
                }
            }


            //Right = [row+, column]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = 0;
                if (row + i < 13 && column + i < 13)
                {
                    currentValue = board[(row + i), (column + i)];
                }
                if (currentValue == 0 || (currentValue == 1 && i < 3)) { break; }

                if (i == 3 && currentValue == 1)
                {
                    board[(row + 1), (column)] = 0;
                    board[(row + 2), (column)] = 0;
                    blackCaptures++;
                }
            }

            return board;
        }


        public int[,] checkCapture_White(int[,] board, int row, int column)
        {

            //Diagonal Down-Right = [row+, column+]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = 0;
                if (row + i < 13 && column + i < 13)
                {
                    currentValue = board[(row + i), (column + i)];
                }
                if (currentValue == 0 || (currentValue == 2 && i < 3)) { break; }

                if (i == 3 && currentValue == 2)
                {
                    board[(row + 1), (column + 1)] = 0;
                    board[(row + 2), (column + 2)] = 0;
                    whiteCaptures++;
                }
            }

            //Down = [row, column+]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = 0;
                if (row < 13 && column + i < 13)
                {
                    currentValue = board[(row), (column + i)];
                }
                if (currentValue == 0 || (currentValue == 2 && i < 3)) { break; }

                if (i == 3 && currentValue == 2)
                {
                    board[(row), (column + 1)] = 0;
                    board[(row), (column + 2)] = 0;
                    whiteCaptures++;
                }
            }

            //Diagonal Down-Left = [row-, column+]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = 0;
                if (row - i >= 0 && column + i < 13)
                {
                    currentValue = board[(row - i), (column + i)];
                }
                if (currentValue == 0 || (currentValue == 2 && i < 3)) { break; }

                if (i == 3 && currentValue == 2)
                {
                    board[(row - 1), (column + 1)] = 0;
                    board[(row - 2), (column + 2)] = 0;
                    whiteCaptures++;
                }
            }

            //Left = [row-, column]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = 0;
                if (row - i >= 0 && column < 13)
                {
                    currentValue = board[(row - i), (column)];
                }
                if (currentValue == 0 || (currentValue == 2 && i < 3)) { break; }

                if (i == 3 && currentValue == 2)
                {
                    board[(row - 1), (column)] = 0;
                    board[(row - 2), (column)] = 0;
                    whiteCaptures++;
                }
            }

            //Diagonal Up-Left = [row-, column-]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = 0;
                if (row - i >= 13 && column - i >= 0)
                {
                    currentValue = board[(row - i), (column - i)];
                }
                if (currentValue == 0 || (currentValue == 2 && i < 3)) { break; }

                if (i == 3 && currentValue == 2)
                {
                    board[(row - 1), (column - 1)] = 0;
                    board[(row - 2), (column - 2)] = 0;
                    whiteCaptures++;
                }
            }

            //Up = [row, column-]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = 0;
                if (row < 13 && column -i >= 0)
                {
                    currentValue = board[(row), (column - i)];
                }
                if (currentValue == 0 || (currentValue == 2 && i < 3)) { break; }

                if (i == 3 && currentValue == 2)
                {
                    board[(row), (column - 1)] = 0;
                    board[(row), (column - 2)] = 0;
                    whiteCaptures++;
                }
            }

            //Diagonal Up-Right = [row+, column-]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = 0;
                if (row + i < 13 && column - i >= 0)
                {
                    currentValue = board[(row + i), (column - i)];
                }
                if (currentValue == 0 || (currentValue == 2 && i < 3)) { break; }

                if (i == 3 && currentValue == 2)
                {
                    board[(row + 1), (column - 1)] = 0;
                    board[(row + 2), (column - 2)] = 0;
                    whiteCaptures++;
                }
            }


            //Right = [row+     , column]
            for (int i = 1; i < 4; i++)
            {
                int currentValue = 0;
                if (row + i < 13 && column < 13)
                {
                    currentValue = board[(row + i), (column)];
                }
                if (currentValue == 0 || (currentValue == 2 && i < 3)) { break; }

                if (i == 3 && currentValue == 2)
                {
                    board[(row + 1), (column)] = 0;
                    board[(row + 2), (column)] = 0;
                    whiteCaptures++;
                }
            }

            return board;
        }

        public bool checkWinWhite(int[,] board, int row, int column)
        {
            if (whiteCaptures >= 5)
            {
                return true;
            }

            //Diagonal Down-Right = [row+, column+]
            for (int i = 1; i < 5; i++)
            {
                int currentValue = 0;
                if (row + i < 13 && column + i < 13)
                {
                    currentValue = board[(row + i), (column + i)];
                }
                if (currentValue == 0 || currentValue == 1) { break; }

                if (i == 4 && currentValue == 2)
                {
                    return true;
                }
            }

            //Down = [row, column+]
            for (int i = 1; i < 5; i++)
            {
                int currentValue = 0;
                if (row < 13 && column + i < 13)
                {
                    currentValue = board[(row), (column + i)];
                }
                if (currentValue == 0 || currentValue == 1) { break; }

                if (i == 4 && currentValue == 2)
                {
                    return true;
                }
            }

            //Diagonal Down-Left = [row-, column+]
            for (int i = 1; i < 5; i++)
            {
                int currentValue = 0;
                if (row - i >= 0 && column + i < 13)
                {
                    currentValue = board[(row - i), (column + i)];
                }
                if (currentValue == 0 || currentValue == 1) { break; }

                if (i == 4 && currentValue == 2)
                {
                    return true;
                }
            }

            //Left = [row-, column]
            for (int i = 1; i < 5; i++)
            {
                int currentValue = 0;
                if (row - i >= 0 && column < 13)
                {
                    currentValue = board[(row - i), (column)];
                }
                if (currentValue == 0 || currentValue == 1) { break; }

                if (i == 4 && currentValue == 2)
                {
                    return true;
                }
            }

            //Diagonal Up-Left = [row-, column-]
            for (int i = 1; i < 5; i++)
            {
                int currentValue = 0;
                if (row - i > 0 && column - i >= 0)
                {
                    currentValue = board[(row - i), (column - i)];
                }
                if (currentValue == 0 || currentValue == 1) { break; }

                if (i == 4 && currentValue == 2)
                {
                    return true;
                }
            }

            //Up = [row, column-]
            for (int i = 1; i < 5; i++)
            {
                int currentValue = 0;
                if (row < 13 && column - i >= 0)
                {
                    currentValue = board[(row), (column - i)];
                }
                if (currentValue == 0 || currentValue == 1) { break; }

                if (i == 4 && currentValue == 2)
                {
                    return true;
                }
            }

            //Diagonal Up-Right = [row+, column-]
            for (int i = 1; i < 5; i++)
            {
                int currentValue = 0;
                if (row + i < 13 && column - i >= 0)
                {
                    currentValue = board[(row + i), (column - i)];
                }
                if (currentValue == 0 || currentValue == 1) { break; }

                if (i == 4 && currentValue == 2)
                {
                    return true;
                }
            }


            //Right = [row+     , column]
            for (int i = 1; i < 5; i++)
            {
                int currentValue = 0;
                if (row + i < 13 && column < 13)
                {
                    currentValue = board[(row + i), (column)];
                }
                if (currentValue == 0 || currentValue == 1) { break; }

                if (i == 4 && currentValue == 2)
                {
                    return true;
                }
            }

            return false;
        }

        public bool checkWinBlack(int[,] board, int row, int column)
        {
            if (blackCaptures >= 5)
            {
                return true;
            }

            //Diagonal Down-Right = [row+, column+]
            for (int i = 1; i < 5; i++)
            {
                int currentValue = 0;
                if (row + i < 13 && column + i < 13)
                {
                    currentValue = board[(row + i), (column + i)];
                }
                if (currentValue == 0 || currentValue == 2) { break; }

                if (i == 4 && currentValue == 1)
                {
                    return true;
                }
            }

            //Down = [row, column+]
            for (int i = 1; i < 5; i++)
            {
                int currentValue = 0;
                if (row < 13 && column + i < 13)
                {
                    currentValue = board[(row), (column + i)];
                }
                if (currentValue == 0 || currentValue == 2) { break; }

                if (i == 4 && currentValue == 1)
                {
                    return true;
                }
            }

            //Diagonal Down-Left = [row-, column+]
            for (int i = 1; i < 5; i++)
            {
                int currentValue = 0;
                if (row - i >= 0 && column + i < 13)
                {
                    currentValue = board[(row - i), (column + i)];
                }
                if (currentValue == 0 || currentValue == 2) { break; }

                if (i == 4 && currentValue == 1)
                {
                    return true;
                }
            }

            //Left = [row-, column]
            for (int i = 1; i < 5; i++)
            {
                int currentValue = 0;
                if (row - i >= 0 && column < 13)
                {
                    currentValue = board[(row - i), (column)];
                }
                if (currentValue == 0 || currentValue == 2) { break; }

                if (i == 4 && currentValue == 1)
                {
                    return true;
                }
            }

            //Diagonal Up-Left = [row-, column-]
            for (int i = 1; i < 5; i++)
            {
                int currentValue = 0;
                if (row - i >= 13 && column - i >= 0)
                {
                    currentValue = board[(row - i), (column - i)];
                }
                if (currentValue == 0 || currentValue == 2) { break; }

                if (i == 4 && currentValue == 1)
                {
                    return true;
                }
            }

            //Up = [row, column-]
            for (int i = 1; i < 5; i++)
            {
                int currentValue = 0;
                if (row < 13 && column - i >= 0)
                {
                    currentValue = board[(row), (column - i)];
                }
                if (currentValue == 0 || currentValue == 2) { break; }

                if (i == 4 && currentValue == 1)
                {
                    return true;
                }
            }

            //Diagonal Up-Right = [row+, column-]
            for (int i = 1; i < 5; i++)
            {
                int currentValue = 0;
                if (row + i < 13 && column - i >= 0)
                {
                    currentValue = board[(row + i), (column - i)];
                }
                if (currentValue == 0 || currentValue == 2) { break; }

                if (i == 4 && currentValue == 1)
                {
                    return true;
                }
            }


            //Right = [row+     , column]
            for (int i = 1; i < 5; i++)
            {
                int currentValue = 0;
                if (row + i < 13 && column < 13)
                {
                    currentValue = board[(row + i), (column)];
                }
                if (currentValue == 0 || currentValue == 2) { break; }

                if (i == 4 && currentValue == 1)
                {
                    return true;
                }
            }

            return false;
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
       

        public void SetBoard(int[,] newBoard) { 

            foreach (int i in board) {
                switch (i)
                {
                    case 0:
                        

                        break;
                }
            }
            
        
        }


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
