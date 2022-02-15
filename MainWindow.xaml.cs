using MazeTest.ViewModel;
using System.Windows;

namespace MazeTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModelMaze();
        }
    }
}
