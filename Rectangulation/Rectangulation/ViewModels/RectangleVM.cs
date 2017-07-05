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
        private readonly Rectangle _rectangle;

        public static int Width { get; set; } = 30;

        public static int Height { get; set; } = 30;

        public string Label => "Прямоугольник " + _rectangle.Id.ToString();

        public bool Checked { get; set; }

        /// <summary>
        /// Свойство кисть заливки
        /// </summary>
        public override Brush Fill => _rectangle.Fill;

        /// <summary>
        /// Свойство кисть контура
        /// </summary>
        public override Brush Stroke => _rectangle.Fill;

        /// <summary>
        /// Свойство толщина линии
        /// </summary>
        public override double StrokeThickness => 1;

        public RectangleVM(double x, double y)
        {
            _rectangle = new Rectangle(x, y, Width, Height);
            Geometry = new RectangleGeometry(new Rect(x, y, Width, Height));
        }
    }
}
