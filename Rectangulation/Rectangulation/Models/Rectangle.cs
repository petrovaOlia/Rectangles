using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

namespace Rectangulation
{
    public class Rectangle
    {
        public Rect Rect;

        /// <summary>
        /// Координата X левого правого угла прямоугольника
        /// </summary>
        public double X
        {
            get { return Rect.X; }
            set { Rect.X = value; }
        }

        /// <summary>
        ///  Координата Y левого правого угла прямоугольника
        /// </summary>
        public double Y
        {
            get { return Rect.Y; }
            set { Rect.Y = value; }
        }

        /// <summary>
        /// Ширина прямоугольника
        /// </summary>
        public double Width
        {
            get { return Rect.Width; }
            set { Rect.Width = value; }
        }

        /// <summary>
        /// Высота прямоугольника
        /// </summary>
        public double Height
        {
            get { return Rect.Height; }
            set { Rect.Height = value; }
        }

        /// <summary>
        /// Свойство кисть заливки и контура
        /// </summary>
        public Brush Fill { get; set; }

        /// <summary>
        /// Свойство нумерации прямоугольника
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Свойство последнего номера в списоке прямоугольника
        /// </summary>
        public static int LastId { get; set; } = 1;

        /// <summary>
        /// Конструктор прямоугольника
        /// </summary>
        /// <param name="x">Координата X левого правого угла прямоугольника</param>
        /// <param name="y">Координата Y левого правого угла прямоугольника</param>
        /// <param name="width">Ширина прямоугольника</param>
        /// <param name="height">Высота прямоугольника</param>
        public Rectangle(double x, double y, int width, int height)
        {
            Rect = new Rect(x, y, width, height);
            Fill = Brushes.Black;
            Id = LastId;
            LastId = LastId + 1;
        }
        
        
    }
}
