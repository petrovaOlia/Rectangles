namespace Rectangulation.Commands
{
    using System;
    using System.Windows.Input;
    using Rectangulation.ViewModels;

    /// <summary>
    /// Команда нажатия правой кнопки мыши на канве
    /// </summary>
    internal class RightClickCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var vmodel = (MainWindowVM)parameter;
            if (vmodel.CurrentPolygon != null)
                ClosePolygon(vmodel);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Метод замыкания полигона
        /// </summary>
        /// <param name="vmodel">Экземляр MainWindowVM</param>
        private static void ClosePolygon(MainWindowVM vmodel)
        {
            if (vmodel.CurrentPolygon.Polygon.Points.Count < 3)
            {
                vmodel.Polygons.Remove(vmodel.CurrentPolygon);
                vmodel.CurrentPolygon = null;
                return;
            }
            vmodel.CurrentPolygon.Close();
            vmodel.CurrentPolygon = null;
            vmodel.OnPropertyChanged();
        }
    }
}
