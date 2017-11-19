namespace Rectangulation.Commands
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Rectangulation.ViewModels;
    using Rectangulation.Models;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Команда нажатия кнопки Ректангулировать
    /// </summary>
    internal class RectangulationCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        
        public void Execute(object parameter)
        {
            Rectangle.LastId = 1;

            var vmodel = (MainWindowVM)parameter;
            if ((vmodel.Polygons.Count > 0) && (vmodel.CurrentPolygon == null))
            {
                Rectangulation(vmodel.Rectangles, vmodel.Polygons, vmodel.RectWidth, vmodel.RectHeight);
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Метод ректангуляции
        /// </summary>
        /// <param name="rectangles">коллекция прямоугольников</param>
        /// <param name="polygons">коллекция полигонов</param>
        /// <param name="width">ширина прямоугольников</param>
        /// <param name="height">высота прямоугольников</param>
        private static void Rectangulation(ObservableCollection<RectangleVM> rectangles, ObservableCollection<PolygonVM>  polygons, int width, int height)
        {
            if (rectangles.Count == 0)
            {
                foreach (var polygon in polygons)
                {
                    var top = (int)polygon.Geometry.Bounds.Top;
                    var bottom = (int)polygon.Geometry.Bounds.Bottom;
                    List<int> borders = new List<int>();
                    for (int i = top; i <= bottom - height; i += height)
                    {
                        int count = polygon.Polygon.Points.Count;
                        for (int j = 0; j < count - 1; j++)
                        {
                            if ((i <= polygon.Polygon.Points[j + 1].Y) && (i >= polygon.Polygon.Points[j].Y)
                                || (i >= polygon.Polygon.Points[j + 1].Y) && (i <= polygon.Polygon.Points[j].Y))
                                if (i == polygon.Polygon.Points[j].Y)
                                    borders.Add((int)polygon.Polygon.Points[j].X);
                                else if (i == polygon.Polygon.Points[j + 1].Y)
                                    borders.Add((int)polygon.Polygon.Points[j + 1].X);
                                else
                                    borders.Add((int)(
                                        (i - polygon.Polygon.Points[j].Y) *
                                        (polygon.Polygon.Points[j + 1].X - polygon.Polygon.Points[j].X) /
                                        (polygon.Polygon.Points[j + 1].Y - polygon.Polygon.Points[j].Y) + 
                                        polygon.Polygon.Points[j].X));
                        }
                        borders.Sort();
                        int m = 0;
                        while (m < borders.Count - 1) 
                        {
                            int w = 0;
                            if (borders[m] == borders[m + 1])
                            {
                                for (w = 0; w < count - 1; w++)
                                    if ((borders[m] == polygon.Polygon.Points[w].X)
                                        && (i == polygon.Polygon.Points[w].Y))
                                        break;
                                if (w == 0)
                                {
                                    if (!((polygon.Polygon.Points[count - 2].Y < i) &&
                                        (polygon.Polygon.Points[1].Y < i) ||
                                        (polygon.Polygon.Points[count - 2].Y > i) &&
                                        (polygon.Polygon.Points[1].Y > i)))
                                        borders.RemoveAt(w);
                                }
                                else if (!((polygon.Polygon.Points[w - 1].Y < i) &&
                                   (polygon.Polygon.Points[w + 1].Y < i) ||
                                   (polygon.Polygon.Points[w - 1].Y > i) &&
                                   (polygon.Polygon.Points[w + 1].Y > i)))
                                    borders.RemoveAt(w);
                            }
                        m++;
                        }
                        if ((borders.Count == 2) && (borders[0] == borders[1]) || borders.Count == 1)
                        {
                            var rectangle = new Rectangle(borders[0] - width / 2, i, width, height);
                            rectangles.Add(new RectangleVM(rectangle));
                        }
                        else
                            for (int k = 0; k < borders.Count; k += 2)
                                for (int l = borders[k]; l < borders[k + 1] - width/2; l += width)
                                {
                                    var rectangle = new Rectangle(l, i, width, height);
                                    rectangles.Add(new RectangleVM(rectangle));
                                }
                        borders.Clear();
                    }
                }
            }
            else
            {
                var count = rectangles.Count;
                for (var i = 0; i < count; i++)
                    if (!rectangles[i].Checked)
                    {
                        rectangles.RemoveAt(i);
                        i--;
                        count--;
                    }
            }
        }
    }
}
