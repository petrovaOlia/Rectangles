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
            Rectangle.LastId = 1;

            MainWindowVM vmodel = (MainWindowVM) parameter;
            ObservableCollection<RectangleVM> rectangles = vmodel.Rectangles;
            if (vmodel.Polygons.Count > 0)
            {
                vmodel.DrawingPoligons = false;
                Rectangulation(vmodel.Rectangles, vmodel.RectWidth, vmodel.RectHeight);
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Метод ректангуляции
        /// </summary>
        /// <param name="rectangles">коллекция прямоугольников</param>
        /// <param name="width">ширина прямоугольников</param>
        /// <param name="height">высота прямоугольников</param>
        private void Rectangulation(ObservableCollection<RectangleVM> rectangles, int width, int height)
        {
            if (rectangles.Count == 0)
            {
                var x = 100;
                var y = 100;
                for (var i = 0; i < 5; i++)
                {
                    var rectangle = new Rectangle(x += 25, y += 25, width, height);
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
    }
}
