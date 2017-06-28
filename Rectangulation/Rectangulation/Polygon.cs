using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace Rectangulation
{
    class Polygon : INotifyPropertyChanged
    {
        private ObservableCollection<Point> points = new ObservableCollection<Point>();
        private ObservableCollection<Rectangle> rectangles = new ObservableCollection<Rectangle>();

        
        public ObservableCollection<Point> Points { get; set; }
        public ObservableCollection<Rectangle> Rectangles { get; set; }

        public void Draw ()
        {

        }
        public void Rectangulation () 
        {

        }
        

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
