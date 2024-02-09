using System;
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

        public MainWindow()
        {
            InitializeComponent();
            setupBoard();
        }

        private void StartOrResetBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{boardLogic.getBoardState().toString()}");
        }
        private void setupBoard()
        {
            Image[,] imgary = {{ Grid_0000, Grid_0001, Grid_0002, Grid_0003, Grid_0004, Grid_0005, Grid_0006, Grid_0007, Grid_0008, Grid_0009, Grid_0010, Grid_0011, Grid_0012 },
                { Grid_0100,Grid_0101,Grid_0102, Grid_0103, Grid_0104, Grid_0105, Grid_0106, Grid_0107, Grid_0108, Grid_0109, Grid_0110, Grid_0111, Grid_0112},
                { Grid_0200,Grid_0201,Grid_0202, Grid_0203, Grid_0204, Grid_0205, Grid_0206, Grid_0207, Grid_0208, Grid_0209, Grid_0210, Grid_0211, Grid_0212},
                { Grid_0300,Grid_0301,Grid_0302, Grid_0303, Grid_0304, Grid_0305, Grid_0306, Grid_0307, Grid_0308, Grid_0309, Grid_0310, Grid_0311, Grid_0312},
                { Grid_0400,Grid_0401,Grid_0402, Grid_0403, Grid_0404, Grid_0405, Grid_0406, Grid_0407, Grid_0408, Grid_0409, Grid_0410, Grid_0411, Grid_0412},
                { Grid_0500,Grid_0501,Grid_0502, Grid_0503, Grid_0504, Grid_0505, Grid_0506, Grid_0507, Grid_0508, Grid_0509, Grid_0510, Grid_0511, Grid_0512},
                { Grid_0600,Grid_0601,Grid_0602, Grid_0603, Grid_0604, Grid_0605, Grid_0606, Grid_0607, Grid_0608, Grid_0609, Grid_0610, Grid_0611, Grid_0612},
                { Grid_0700,Grid_0701,Grid_0702, Grid_0703, Grid_0704, Grid_0705, Grid_0706, Grid_0707, Grid_0708, Grid_0709, Grid_0710, Grid_0711, Grid_0712},
                { Grid_0800,Grid_0801,Grid_0802, Grid_0803, Grid_0804, Grid_0805, Grid_0806, Grid_0807, Grid_0808, Grid_0809, Grid_0810, Grid_0811, Grid_0812},
                { Grid_0900,Grid_0901,Grid_0902, Grid_0903, Grid_0904, Grid_0905, Grid_0906, Grid_0907, Grid_0908, Grid_0909, Grid_0910, Grid_0911, Grid_0912},
                { Grid_1000,Grid_1001,Grid_1002, Grid_1003, Grid_1004, Grid_1005, Grid_1006, Grid_1007, Grid_1008, Grid_1009, Grid_1010, Grid_1011, Grid_1012},
                { Grid_1100,Grid_1101,Grid_1102, Grid_1103, Grid_1104, Grid_1105, Grid_1106, Grid_1107, Grid_1108, Grid_1109, Grid_1110, Grid_1111, Grid_1112},
                { Grid_1200,Grid_1201,Grid_1202, Grid_1203, Grid_1204, Grid_1205, Grid_1206, Grid_1207, Grid_1208, Grid_1209, Grid_1210, Grid_1211, Grid_1212},
            };
                        Pente_Board pb = boardLogic.getBoardState();
            int[,] board = pb.GetBoard();
            for (int k = 0; k < board.GetLength(0); k++)
                for (int l = 0; l < board.GetLength(1); l++)
                {
                    switch((board[k, l]))
                    {
                        case 0:
                            imgary[k,l].Source = new BitmapImage(new Uri("Resources/empty.png", UriKind.Relative));
                            break;
                        case 1:
                            imgary[k,l].Source = new BitmapImage(new Uri("Resources/whitecircle.png", UriKind.Relative));
                            break;
                        case 2:
                            imgary[k,l].Source = new BitmapImage(new Uri("Resources/bctp.png", UriKind.Relative));
                            break;

                    }
                }
            //imgary[0,0].Source = new BitmapImage(new Uri("Resources/download.png", UriKind.Relative));
        }

        private void imgClick(object sender, MouseButtonEventArgs e)
        {
            Image imgSender = (Image)sender;
            int row = Grid.GetRow(imgSender);
            int col = Grid.GetColumn(imgSender);

            boardLogic.placeBlack(row, col);
            setupBoard();
        }
    };


        
 }
