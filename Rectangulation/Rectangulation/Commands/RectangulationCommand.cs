using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Rectangulation
{
    class RectangulationCommand : ICommand
    {
        private readonly ObservableCollection<RectangleVM> _rectCollection;
        private readonly Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        public RectangulationCommand( ObservableCollection<RectangleVM> rectCollection, Func<bool> canExecute = null)
        {
            if (rectCollection == null)
                throw new ArgumentNullException("rectCollection");
            _canExecute = canExecute;
            _rectCollection = rectCollection;
        }

        public void Execute(object parameter)
        {
            var x = 120;
            var y = 120;
            for (var i = 0; i < 5; i++)
            {
                _rectCollection.Add(new RectangleVM(x += 15, y += 15));
            }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}
