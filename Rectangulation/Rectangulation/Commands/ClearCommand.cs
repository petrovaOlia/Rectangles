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
            MainWindowVM parameterVM = (MainWindowVM)parameter;
            parameterVM.Rectangles.Clear();
            parameterVM.Polygons.Clear();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
