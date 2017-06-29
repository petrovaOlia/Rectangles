using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

namespace Rectangulation
{
    public class Rectangle : BaseShape
    {
        private double _x; // Координата левого правого угла
        private double _y;
        private int _width; 
        private int _height;
        private bool _selected;
        private int _id; // Номер в списке
        static int _lastID = 1; // Последний номер в списоке 

        public Rectangle(double x, double y, int width, int height)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            _id = _lastID++;
            Geometry = new RectangleGeometry(new Rect(x, y, width, height));
            Fill = Brushes.Black;
            Stroke = Brushes.Black;
            StrokeThickness = 2;
        }
        
        public bool Selected 
        {
            get { return _selected; }
            set
            {
                _selected = value;
            }
        }

        public int Id
        {
            get { return _id; }
        }
        
    }
}
