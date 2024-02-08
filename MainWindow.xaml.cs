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
        }

        private void StartOrResetBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{boardLogic.getBoardState().toString()}");
        }
    }
}