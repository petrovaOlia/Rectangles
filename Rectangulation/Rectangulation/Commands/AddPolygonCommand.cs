using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Rectangulation.Commands
{
    class AddPolygonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
