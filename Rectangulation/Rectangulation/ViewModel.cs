using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Rectangulation
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //public ObservableCollection<Polygon> polygons { get; set; }
        private ObservableCollection<BaseShape> _shapes = new ObservableCollection<BaseShape>();
        private Polygon _currentPolygon = null;
        public ObservableCollection<BaseShape> Shapes
        {
            get
            {
                return _shapes;
            }
            set
            {
                _shapes = value;
                OnPropertyChanged();
            }
        }
        public void AddRectangle (double x, double y, int width, int height)
        {
            _shapes.Add(new Rectangle(x, y, width, height));
            OnPropertyChanged();
        }

        public void AddPolygon (double x, double y)
        {
            if (_currentPolygon == null)
            {
                _currentPolygon = new Polygon(x, y);
                _shapes.Add(_currentPolygon);
                
            }
            else
                _currentPolygon.AddPoint(x, y);
            OnPropertyChanged();
        }

        public void FinalizePolygon ()
        {
            if (_currentPolygon != null)
            {
                _currentPolygon.Finalize();
                _currentPolygon = null;
                OnPropertyChanged();
            }
        }

        public void OnPropertyChanged()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Shapes"));
        }
    }
}
