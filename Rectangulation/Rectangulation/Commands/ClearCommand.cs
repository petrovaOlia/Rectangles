using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Rectangulation.Commands
{
    class ClearCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var vmodel = (MainWindowVM)parameter;
            vmodel.DrawingPoligons = true;
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
