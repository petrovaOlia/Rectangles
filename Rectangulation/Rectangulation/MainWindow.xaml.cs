using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private void Canvas_MouseLeftDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(mainCanvas);
            (DataContext as MainWindowVM).AddPointToPolygon(p.X, p.Y);
        }

        private void mainCanvas_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(mainCanvas);
            (DataContext as MainWindowVM).ClosePolygon();
        }
        
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainWindowVM).ClearContents();
        }

        private void RectangulationButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
