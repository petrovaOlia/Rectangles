using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Rectangulation
{
    class RectangulationCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        
        public void Execute(object parameter)
        {
            Rectangle.LastId = 1;

            var vmodel = (MainWindowVM)parameter;
            var rectangles = vmodel.Rectangles;
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
        /// <param name="width">ширина прямоугольников</param>
        /// <param name="height">высота прямоугольников</param>
        private void Rectangulation(ObservableCollection<RectangleVM> rectangles, ObservableCollection<PolygonVM>  polygons, int width, int height)
        {
            if (rectangles.Count == 0)
            {
                var rand = new Random();
                foreach (var polygon in polygons)
                {
                    var countRect = (int) (polygon.Square() / (width * height));
                    for (var i = 0; i < countRect + 1; i++)
                    {
                        var rectangle =
                            new Rectangle(
                                rand.Next((int) polygon.Geometry.Bounds.Left, (int) polygon.Geometry.Bounds.Right - width),
                                rand.Next((int) polygon.Geometry.Bounds.Top, (int) polygon.Geometry.Bounds.Bottom - height),
                                width, height);
                        rectangles.Add(new RectangleVM(rectangle));
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
