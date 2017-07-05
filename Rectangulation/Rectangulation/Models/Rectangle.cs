using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

namespace Rectangulation
{
    public class Rectangle
    {
        /// <summary>
        /// Координата X левого правого угла прямоугольника
        /// </summary>
        private double _x;

        /// <summary>
        ///  Координата Y левого правого угла прямоугольника
        /// </summary>
        private double _y;

        /// <summary>
        /// Ширина прямоугольника
        /// </summary>
        private int _width;

        /// <summary>
        /// Высота прямоугольника
        /// </summary>
        private int _height;

        /// <summary>
        /// Номер в списке прямоугольника
        /// </summary>
        private int _id;

        /// <summary>
        /// Последний номер в списоке прямоугольника
        /// </summary>
        static int _lastID = 1;

        /// <summary>
        /// Конструктор прямоугольника
        /// </summary>
        /// <param name="x">Координата X левого правого угла прямоугольника</param>
        /// <param name="y">Координата Y левого правого угла прямоугольника</param>
        /// <param name="width">Ширина прямоугольника</param>
        /// <param name="height">Высота прямоугольника</param>
        public Rectangle(double x, double y, int width, int height)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            _id = _lastID++;
        }

        /// <summary>
        /// Свойство нумерации прямоугольника
        /// </summary>
        public int Id
        {
            get { return _id; }
        }
    }
}
