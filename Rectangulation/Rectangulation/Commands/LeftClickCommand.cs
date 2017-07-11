using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Rectangulation.Commands
{
    class LeftClickCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var values = (object[])parameter;
            var canvas = values[0] as Canvas;
            var vmodel = values[1] as MainWindowVM;
            Point mousePos = Mouse.GetPosition(canvas);
            if (vmodel.DrawingPoligons)
                AddPointToPolygon(mousePos.X, mousePos.Y, vmodel);
            else
            {
                vmodel.SelectedRectangle = null;
                SelectRectangle(mousePos.X, mousePos.Y, vmodel);
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Метод добавления точки в полигон
        /// </summary>
        /// <param name="x">Координата X точки</param>
        /// <param name="y">Координата Y точки</param>
        private void AddPointToPolygon(double x, double y, MainWindowVM vmodel)
        {
            if (vmodel.CurrentPolygon == null)
            {
                vmodel.CurrentPolygon = new PolygonVM(x, y);
                vmodel.Polygons.Add(vmodel.CurrentPolygon);
            }
            else
                vmodel.CurrentPolygon.AddPoint(x, y);
            vmodel.OnPropertyChanged();
        }

        /// <summary>
        /// Метод выделения прямоугольника
        /// </summary>
        /// <param name="x">Координата X нажатия левой кнопки мыши</param>
        /// <param name="y">Координата Y нажатия левой кнопки мыши</param>
        /// <param name="vmodel">Экземляр MainWindowVM</param>
        private void SelectRectangle(double x, double y, MainWindowVM vmodel)
        {
            foreach (var rectangle in vmodel.Rectangles)
            {
                if ((x >= rectangle.Geometry.Bounds.X) &&
                    (y >= rectangle.Geometry.Bounds.Y) &&
                    (x <= rectangle.Geometry.Bounds.X + rectangle.Geometry.Bounds.Width) &&
                    (y <= rectangle.Geometry.Bounds.Y + rectangle.Geometry.Bounds.Height))
                {
                    vmodel.SelectedRectangle = rectangle;
                    break;
                }
            }
        }

    }
}
