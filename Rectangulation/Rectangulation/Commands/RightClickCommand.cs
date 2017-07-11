using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Rectangulation.Commands
{
    class RightClickCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var values = (object[])parameter;
            var canvas = values[0] as Canvas;
            var vmodel = values[1] as MainWindowVM;
            if ((vmodel.CurrentPolygon != null) && vmodel.DrawingPoligons)
                ClosePolygon(vmodel);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        
        /// <summary>
        /// Метод замыкания полигона
        /// </summary>
        public void ClosePolygon(MainWindowVM vmodel)
        {
            vmodel.CurrentPolygon.Close();
            vmodel.CurrentPolygon = null;
            vmodel.OnPropertyChanged();
        }
    }
}
