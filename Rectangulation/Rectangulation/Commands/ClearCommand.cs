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
            var parameterVM = (MainWindowVM)parameter;
            parameterVM.DrawingPoligons = true;
            parameterVM.Rectangles.Clear();
            parameterVM.Polygons.Clear();
            parameterVM.CurrentPolygon = null;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
