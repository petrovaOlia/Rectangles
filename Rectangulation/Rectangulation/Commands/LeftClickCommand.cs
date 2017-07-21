namespace Rectangulation.Commands
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Input;
    using Rectangulation.ViewModels;

    /// <summary>
    /// Команда нажатия левой кнопки мыши на канвас
    /// </summary>
    internal class LeftClickCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var values = (object[])parameter;
            var canvas = (Canvas)values[0];
            var vmodel = (MainWindowVM)values[1];
            var mousePos = Mouse.GetPosition(canvas);
            if ((vmodel.CurrentPolygon != null) || (!TrySelectRectangle(mousePos.X, mousePos.Y, vmodel)))
                AddPointToPolygon(mousePos.X, mousePos.Y, vmodel);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        //// <summary>
        /// Метод добавления точки в полигон
        /// </summary>
        /// <param name="x">Координата X точки</param>
        /// <param name="y">Координата Y точки</param>
        /// <param name="vmodel">Экземляр MainWindowVM</param>
        private static void AddPointToPolygon(double x, double y, MainWindowVM vmodel)
        {
            if (vmodel.CurrentPolygon == null)
            {
                vmodel.CurrentPolygon = new PolygonVM(x, y);
                vmodel.Polygons.Add(vmodel.CurrentPolygon);
            }
            else
                vmodel.CurrentPolygon.AddPoint(x, y);
            vmodel.OnPropertyChanged();
            vmodel.SelectedRectangleVM = null;
        }

        /// <summary>
        /// Метод выделения прямоугольника
        /// </summary>
        /// <param name="x">Координата X нажатия левой кнопки мыши</param>
        /// <param name="y">Координата Y нажатия левой кнопки мыши</param>
        /// <param name="vmodel">Экземляр MainWindowVM</param>
        private static bool TrySelectRectangle(double x, double y, MainWindowVM vmodel)
        {
            foreach (var rectangle in vmodel.Rectangles)
            {
                if (!rectangle.IsHitingToBorder(x, y)) continue;
                vmodel.SelectedRectangleVM = null;
                vmodel.SelectedRectangleVM = rectangle;
                return true;
            }
            return false;
        }

    }
}
