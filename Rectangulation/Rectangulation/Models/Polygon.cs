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
