namespace Rectangulation.Models
{
    using System.Collections.Generic;
    using System.Windows;

    /// <summary>
    /// Модель полигона
    /// </summary>
    public class Polygon 
    {
        /// <summary>
        /// Конструктор полигона
        /// </summary>
        public Polygon()
        {
            Points = new List<Point>();
        }

        /// <summary>
        /// Лист точек полигона
        /// </summary>
        public List<Point> Points { get; }

        ///// <summary>
        ///// Метод добавления точки в полигон
        ///// </summary>
        ///// <param name="x">Координата X точки</param>
        ///// <param name="y">Координата Y точки</param>
        public void AddPoint(double x, double y)
        {
            Points.Add(new Point((int)x, (int)y));
        }

        //Комментарий
    }
}
