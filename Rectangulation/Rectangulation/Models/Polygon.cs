using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace Rectangulation
{
    public class Polygon : BaseShape
    {
        //private ObservableCollection<Point> _points = new ObservableCollection<Point>();
        //private ObservableCollection<Rectangle> _rectangles = new ObservableCollection<Rectangle>();


        //public ObservableCollection<Point> Points { get; set; }
        //public ObservableCollection<Rectangle> Rectangles { get; set; }

        public Polygon (double x, double y)
        {
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

        public void AddPoint (double x, double y)
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
                        segment.Points.Add(new Point(x, y));
                    }

                }
            }
        }

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
