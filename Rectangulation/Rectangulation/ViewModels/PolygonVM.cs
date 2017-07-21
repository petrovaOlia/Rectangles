namespace Rectangulation.ViewModels
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using Rectangulation.Models;

    /// <summary>
    /// Представление модели полигона
    /// </summary>
    class PolygonVM : BaseShapeVM
    {
        /// <summary>
        /// Конструктор полигона
        /// </summary>
        /// <param name="x">Координата X стартовой точки</param>
        /// <param name="y">Координата Y стартовой точки</param>
        public PolygonVM(double x, double y)
        {
            Polygon = new Polygon();
            Polygon.AddPoint(x, y);

            var pathGeom = new PathGeometry();
            var segment = new PolyLineSegment { Points = new PointCollection() };
            var figure = new PathFigure { StartPoint = new Point(x, y) };
            figure.Segments.Add(segment);
            pathGeom.Figures.Add(figure);
            Geometry = pathGeom;
        }

        /// <summary>
        /// Полигон
        /// </summary>
        public Polygon Polygon { get; }

        /// <summary>
        /// Свойство кисть заливки
        /// </summary>
        public override Brush Fill => Brushes.Transparent;

        /// <summary>
        /// Свойство кисть контура
        /// </summary>
        public override Brush Stroke => Brushes.Blue;

        /// <summary>
        /// Свойство толщина линии
        /// </summary>
        public override double StrokeThickness => 2;

        /// <summary>
        /// Метод добавления точки в полигон
        /// </summary>
        /// <param name="x">Координата X точки</param>
        /// <param name="y">Координата Y точки</param>
        public void AddPoint(double x, double y)
        {
            var segment = GetSegment(GetFigure());
            segment.Points.Add(new Point(x, y));
            Polygon.AddPoint(x, y);
        }

        /// <summary>
        /// Метод замыкания полигона
        /// </summary>
        public void Close()
        {
            var figure = GetFigure();
            var segment = GetSegment(figure);
            segment?.Points.Add(figure.StartPoint);
            Polygon.AddPoint(figure.StartPoint.X, figure.StartPoint.Y);
        }

        /// <summary>
        /// Метод получения фигуры
        /// </summary>
        /// <returns>Ссылка на фигуру</returns>
        private PathFigure GetFigure()
        {
            if (Geometry == null)
                return null;
            var pathGeom = (PathGeometry)Geometry;
            if (pathGeom.Figures.Count <= 0)
                return null;
            return (PathFigure)pathGeom.Figures[0];
        }

        /// <summary>
        /// Метод получения сегмента
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <returns>Сегмент</returns>
        private static PolyLineSegment GetSegment(PathFigure figure)
        {
            if (figure.Segments.Count <= 0)
                return null;
            return (PolyLineSegment)figure.Segments[0];
        }

        /// <summary>
        /// Метод, вычисляющий площадь полигона
        /// </summary>
        /// <returns>Площадь</returns>
        public double Square()
        {
            double s = 0;
            for (var i = 0; i < Polygon.Points.Count - 1; i++)
            {
                s += 0.5 * (Polygon.Points[i].X * Polygon.Points[i + 1].Y -
                            Polygon.Points[i].Y * Polygon.Points[i + 1].X);
            }
            return Math.Abs(s);
        } 
    }
}
