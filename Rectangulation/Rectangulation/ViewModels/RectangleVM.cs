using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Rectangulation
{
    public class RectangleVM : BaseShapeVM
    {
        /// <summary>
        /// Прямоугольник
        /// </summary>
        private readonly Rectangle _rectangle;

        /// <summary>
        /// Ширина прямоугольника
        /// </summary>
        public static int Width { get; set; } = 20;

        /// <summary>
        /// Высота прямоугольника
        /// </summary>
        public static int Height { get; set; } = 20;

        /// <summary>
        /// Имя прямоугольника в списке
        /// </summary>
        public string Label
        {
            get { return "Прямоугольник " + _rectangle.Id.ToString(); }
        }

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

        /// <summary>
        /// Конструктор RectangleVM
        /// </summary>
        /// <param name="x">Координата X левого правого угла прямоугольника</param>
        /// <param name="y">Координата Y левого правого угла прямоугольника</param>
        public RectangleVM(double x, double y)
        {
            _rectangle = new Rectangle(x, y, Width, Height);
            Geometry = new RectangleGeometry(new Rect(x, y, Width, Height));
        }
    }
}
