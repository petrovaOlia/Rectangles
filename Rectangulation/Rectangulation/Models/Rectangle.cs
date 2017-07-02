using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

namespace Rectangulation
{
    public class Rectangle : BaseShape
    {
        /// <summary>
        /// Координата X левого правого угла
        /// </summary>
        private double _x; 
        /// <summary>
        ///  Координата Y левого правого угла
        /// </summary>
        private double _y;
        private int _width; 
        private int _height;
        private bool _selected;
        /// <summary>
        /// Номер в списке
        /// </summary>
        private int _id;
        /// <summary>
        /// Последний номер в списоке
        /// </summary>
        static int _lastID = 1;

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
            get
            {
                return _selected;
            }

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
