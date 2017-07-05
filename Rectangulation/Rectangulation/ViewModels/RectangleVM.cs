using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Rectangulation
{
    public class RectangleVM : BaseShapeVM
    {
        private Rectangle _rectangle;

        public static int Width { get; set; } = 30;

        public static int Height { get; set; } = 30;

        public String Label
        {
            get
            {
                return "Прямоугольник " + _rectangle.Id.ToString();
            }
        }

        public bool Checked { get; set; }

        public RectangleVM(double x, double y)
        {
            _rectangle = new Rectangle(x, y, Width, Height);
            Geometry = new RectangleGeometry(new Rect(x, y, Width, Height));
            Fill = Brushes.Black;
            Stroke = Brushes.Black;
            StrokeThickness = 2;
        }
    }
}
