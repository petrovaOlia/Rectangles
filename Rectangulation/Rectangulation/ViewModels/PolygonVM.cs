using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Rectangulation
{
    class PolygonVM : BaseShapeVM
    {
        private Polygon _polygon = new Polygon();

        /// <summary>
        /// Конструктор полигона
        /// </summary>
        /// <param name="x">Координата X стартовой точки</param>
        /// <param name="y">Координата Y стартовой точки</param>
        public PolygonVM(double x, double y)
        {
            _polygon.AddPoint(x, y);

            PathGeometry pathGeom = new PathGeometry();
            PolyLineSegment segment = new PolyLineSegment();
            segment.Points = new PointCollection();
            PathFigure figure = new PathFigure();
            figure.StartPoint = new Point(x, y);
            figure.Segments.Add(segment);
            pathGeom.Figures.Add(figure);
            Fill = Brushes.Transparent;
            Stroke = Brushes.Blue;
            StrokeThickness = 2;
            Geometry = pathGeom;
        }

        /// <summary>
        /// Метод добавления точки в полигон
        /// </summary>
        /// <param name="x">Координата X точки</param>
        /// <param name="y">Координата Y точки</param>
        public void AddPoint(double x, double y)
        {
            _polygon.AddPoint(x, y);
            if (Geometry != null)
            {
                PathGeometry pathGeom = (PathGeometry)Geometry;
                if (pathGeom.Figures.Count > 0)
                {
                    PathFigure figure = (PathFigure)pathGeom.Figures[0];
                    if (figure.Segments.Count > 0)
                    {
                        PolyLineSegment segment = (PolyLineSegment)figure.Segments[0];
                        segment.Points.Add(new Point(x, y));
                    }
                }
            }
        }

        /// <summary>
        /// Метод заиыкания полигона
        /// </summary>
        public void Close()
        {
            if (Geometry != null)
            {
                PathGeometry pathGeom = (PathGeometry)Geometry;
                if (pathGeom.Figures.Count > 0)
                {
                    PathFigure figure = (PathFigure)pathGeom.Figures[0];
                    if (figure.Segments.Count > 0)
                    {
                        PolyLineSegment segment = (PolyLineSegment)figure.Segments[0];
                        segment.Points.Add(figure.StartPoint);
                    }

                }
            }
        }
    }
}
