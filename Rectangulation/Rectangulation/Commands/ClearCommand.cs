namespace Rectangulation.Commands
{
    using System;
    using System.Windows.Input;
    using Rectangulation.ViewModels;

    /// <summary>
    /// Команда нажатия кнопки Очистить
    /// </summary>
    internal class ClearCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var vmodel = (MainWindowVM)parameter;
            vmodel.Rectangles.Clear();
            vmodel.Polygons.Clear();
            vmodel.CurrentPolygon = null;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
