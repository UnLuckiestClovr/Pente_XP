using System;
using System.Data.Common;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
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


        Image[,] imgary;

        public MainWindow()
        {
            InitializeComponent();

            AddImagesToGrid();

            setupBoard();
        }


        private void StartOrResetBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{boardLogic.getBoardState().toString()}");
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

                placeRandomBlackPiece();

                blackWin = boardLogic.checkWinBlack(boardLogic.getBoardState().GetBoard(), row, col);
            }

            if (whiteWin)
            {
                MessageBox.Show("White Wins!");
                boardLogic.clearBoard();
                setupBoard();
            }
            else if (blackWin)
            {
                MessageBox.Show("White Wins!");
                boardLogic.clearBoard();
                setupBoard();
            }
        }


        private void placeRandomBlackPiece()
        {

            while (true)
            {
                Random rand = new Random();
                int randrow = rand.Next(13);
                int randcol = rand.Next(13);
                if (boardLogic.getBoardState().GetBoard()[randrow, randcol] == 0)
                {
                    boardLogic.placeBlack(randrow, randcol);
                    setupBoard();
                    break;
                }
            }

        }
    };


        
 }
