using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Rectangulation
{
    class RectangulationCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        
        public void Execute(object parameter)
        {
            MainWindowVM parameterVM = (MainWindowVM) parameter;
            ObservableCollection<RectangleVM> rectangles = parameterVM.Rectangles;
            if (rectangles.Count == 0)
            {
                var x = 100;
                var y = 100;
                for (var i = 0; i < 5; i++)
                {
                    var rectangle = new Rectangle(x += 25, y += 25, parameterVM.RectWidth, parameterVM.RectHeight);
                    rectangles.Add(new RectangleVM(rectangle));
                }
            }
            else
            {
                int count = rectangles.Count;
                for (int i = 0; i < count; i++)
                    if (!rectangles[i].Checked)
                    {
                        rectangles.RemoveAt(i);
                        i--;
                        count--;
                    }
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
