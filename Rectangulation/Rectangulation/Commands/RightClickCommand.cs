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
            var canvas = (Canvas)values[0] ;
            var vmodel = (MainWindowVM)values[1];
            if ((vmodel.CurrentPolygon != null) && (vmodel.DrawingPoligons))
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
