using System.Windows;
using System.Windows.Input;
using Rectangulation.ViewModels;

namespace Rectangulation
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowVM();
        }

        private void mainCanvas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ((MainWindowVM)DataContext).MouseDown(e.GetPosition(MainCanvas));
        }

        private void mainCanvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            ((MainWindowVM)DataContext).MouseMove(e.GetPosition(MainCanvas));
        }

        private void mainCanvas_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ((MainWindowVM)DataContext).MouseUp(e.GetPosition(MainCanvas));
        }
    }
}
