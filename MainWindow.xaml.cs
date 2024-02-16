using System;
using System.Collections;
using System.Data.Common;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pente_WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BoardLogic boardLogic = new BoardLogic();

        // Win States
        bool whiteWin = false;
        bool blackWin = false;
        FileStream fs = File.Create("gameState.txt");

        int boardSize = 9;


        Image[,] imgary = new Image[0,0];

        public MainWindow()
        {
            InitializeComponent();

            CreateGrid(boardSize);
            AddImagesToGrid();

            boardLogic.gameBoard.newBoard(boardSize);

            setupBoard();
        }


        private void StartOrResetBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{boardLogic.getBoardState().toString()}");
        }


        private void CreateGrid(int rowsandcolumns)
        {
            // Clear Original Grid if Able
            BoardContainer.Children.Clear();

            PenteBoard_Grid = new Grid();
            PenteBoard_Grid.Name = "PenteBoard_Grid";
            PenteBoard_Grid.Width = 500;
            PenteBoard_Grid.Height = 500;
            PenteBoard_Grid.HorizontalAlignment = HorizontalAlignment.Center;
            PenteBoard_Grid.VerticalAlignment = VerticalAlignment.Center;
            PenteBoard_Grid.Background = System.Windows.Media.Brushes.Beige;

            Grid.SetRow(PenteBoard_Grid, 1);


            for (int i = 0; i < rowsandcolumns; i++)
            {
                ColumnDefinition columnDefinition = new ColumnDefinition();
                columnDefinition.Width = new GridLength(1, GridUnitType.Star);
                PenteBoard_Grid.ColumnDefinitions.Add(columnDefinition);

                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.Height = new GridLength(1, GridUnitType.Star);
                PenteBoard_Grid.RowDefinitions.Add(rowDefinition);
            }

            // Add the new Grid to the parent container
            BoardContainer.Children.Add(PenteBoard_Grid);
        }


        private void AddImagesToGrid()
        {
            int rowCount = PenteBoard_Grid.RowDefinitions.Count;
            int columnCount = PenteBoard_Grid.ColumnDefinitions.Count;
            imgary = new Image[rowCount, columnCount];

            for (int row = 0; row < PenteBoard_Grid.RowDefinitions.Count; row++)
            {
                for (int col = 0; col < PenteBoard_Grid.ColumnDefinitions.Count; col++)
                {
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri("Resources/AngryCantera.png", UriKind.Relative));
                    img.Name = "Grid_" + row.ToString("D2") + col.ToString("D2"); // Naming convention based on row and column
                    img.Width = double.NaN; // Auto width
                    img.Height = double.NaN; // Auto height
                    img.MouseLeftButtonDown += imgClick; // Add event handler

                    // Set grid row and column
                    Grid.SetRow(img, row);
                    Grid.SetColumn(img, col);

                    // Add the image to the grid
                    PenteBoard_Grid.Children.Add(img);

                    // Add the image to the array
                    imgary[row, col] = img;
                }
            }
        }


        private void setupBoard()
        {


            int[,] board = boardLogic.getBoardState().GetBoard();

            for (int k = 0; k < board.GetLength(0); k++)
            {
                for (int l = 0; l < board.GetLength(1); l++)
                {
                    switch ((board[k, l]))
                    {
                        case 0:
                            imgary[k, l].Source = new BitmapImage(new Uri("Resources/empty.png", UriKind.Relative));
                            break;
                        case 1:
                            imgary[k, l].Source = new BitmapImage(new Uri("Resources/bctp.png", UriKind.Relative));
                            break;
                        case 2:
                            imgary[k, l].Source = new BitmapImage(new Uri("Resources/whitecircle.png", UriKind.Relative));
                            break;

                    }
                }
            }
            //Console.WriteLine(board);
            //imgary[0,0].Source = new BitmapImage(new Uri("Resources/download.png", UriKind.Relative));
        }


        private void imgClick(object sender, MouseButtonEventArgs e)
        {
            Image imgSender = (Image)sender;
            int row = Grid.GetRow(imgSender);
            int col = Grid.GetColumn(imgSender);

            if (boardLogic.getBoardState().GetBoard()[row, col] == 0)
            {
                boardLogic.placeWhite(row, col);
                setupBoard();

                whiteWin = boardLogic.checkWinWhite(boardLogic.getBoardState().GetBoard(), row, col);

                blackWin = placeRandomBlackPiece();
            }

            if (whiteWin)
            {
                MessageBox.Show("White Wins!");
                boardLogic.clearBoard();
                setupBoard();
            }
            else if (blackWin)
            {
                MessageBox.Show("Black Wins!");
                boardLogic.clearBoard();
                setupBoard();
            }
        }


        private bool placeRandomBlackPiece()
        {
            int randrow = 0;
            int randcol = 0;
            while (true)
            {
                Random rand = new Random();
                randrow = rand.Next(boardSize);
                randcol = rand.Next(boardSize);
                if (boardLogic.getBoardState().GetBoard()[randrow, randcol] == 0)
                {
                    boardLogic.placeBlack(randrow, randcol);
                    setupBoard();
                    break;
                }
            }

            return boardLogic.checkWinBlack(boardLogic.getBoardState().GetBoard(), randrow, randcol);

        }

        private void loadGame_Click(object sender, RoutedEventArgs e)
        {
            List<string> strList = new List<string>();
            using (StreamReader file = new StreamReader("../../../gameState.txt"))
            {
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    Console.WriteLine(ln);
                    strList.Add(ln);
                }
                //C: \Users\Eli\source\repos\Pente_XP\gameState.txt
                file.Close();
                Console.Write(strList.ToArray());
                int boardSize2 = int.Parse(strList.ToArray().GetValue(0).ToString());

                CreateGrid(boardSize2 - 1);
                AddImagesToGrid();
                this.boardSize = boardSize2 - 1;
                boardLogic.gameBoard.newBoard(boardSize2 - 1);

                setupBoard();
                //boardSizeLabel.Content = boardSize2 + ""; // -----------------------------------------------
                //create game
                int[,] board = { };
                List<int[]> boardList = new List<int[]>();
                for (int i = 1; i < boardSize2; i++)
                {
                    int[] boardRow = new int[boardSize2 - 1];
                    for (int j = 0; j < boardSize2 - 1; j++)
                    {

                        boardRow[j] = (int)char.GetNumericValue((strList[i])[j]);
                    }
                    boardList.Add(boardRow);
                }
                for (int i = 0; i < boardList.Count; i++)
                {
                    for (int j = 0; j < boardList.Count; j++)
                    {
                        //int holdint = boardList[i][j];
                        boardLogic.getBoardState().GetBoard()[i, j] = boardList[i][j];
                    }
                }
                //Console.WriteLine(boardLogic.getBoardState().GetBoard());
                setupBoard();
            }

        }


        private void saveGame_Click(object sender, RoutedEventArgs e)
        {
            List<string> strList = new List<string>();
            using (StreamWriter file = new StreamWriter("../../../gameState.txt"))
            {

                int boardSize2 = (int)Math.Sqrt(boardLogic.getBoardState().GetBoard().Length);

                
                file.WriteLine(boardSize2 + 1);
                //C: \Users\Eli\source\repos\Pente_XP\gameState.txt
                //Console.Write(strList.ToArray());
                for (int i = 0; i < boardSize2; i++)
                {
                    string boardString = "";
                    for (int j = 0; j < boardSize2; j++)
                    {

                        boardString += (boardLogic.getBoardState().GetBoard()[i,j]);
                    }
                    file.WriteLine(boardString);
                    
                }
                file.Close();

            }

        }
    }


        
 }
