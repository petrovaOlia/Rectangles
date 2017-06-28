using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Rectangulation
{
    class Rectangle : INotifyPropertyChanged
    {
        private Point coord; // Координата левого правого угла
        private int width; 
        private int height;
        private bool selected;
        private int id; // Номер в списке
        static int lastID = 1; // Последний номер в списоке 

        public Rectangle(Point coord)
        {
            id = lastID++;
        }
        public Point Coord
        {
            get { return coord; }
            set
            {
                coord = value;
                OnPropertyChanged("Coord");
            }
        }
        public int Height
        {
            get { return height; }
            set
            {
                height = value;
                OnPropertyChanged("Height");
            }
        }
        public int Width
        {
            get { return width; }
            set
            {
                width = value;
                OnPropertyChanged("Width");
            }
        }
        public bool Selected 
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged("Selected");
            }
        }

        public int Id
        {
            get { return id; }
        }

        public void Draw()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
