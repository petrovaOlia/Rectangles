using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace Rectangulation
{
    public class Polygon 
    {
        List<Point> _points = new List<Point>();

        /// <summary>
        /// Свойство кисть заливки
        /// </summary>
        public Brush Fill { get; set; }

        /// <summary>
        /// Свойство кисть контура
        /// </summary>
        public Brush Stroke { get; set; }

        /// <summary>
        /// Свойство толщина линии
        /// </summary>
        public double StrokeThickness { get; set; }

        public Polygon()
        {
            Fill = Brushes.Transparent;
            Stroke = Brushes.Blue;
            StrokeThickness = 2;
        }

        ///// <summary>
        ///// Метод добавления точки в полигон
        ///// </summary>
        ///// <param name="x">Координата X точки</param>
        ///// <param name="y">Координата Y точки</param>
        public void AddPoint(double x, double y)
        {
            _points.Add(new Point(x, y));
        }
    }
}
