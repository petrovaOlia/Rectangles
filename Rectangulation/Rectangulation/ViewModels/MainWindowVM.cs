using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Rectangulation
{
    class MainWindowVM : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие изменения коллекции фигур
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Коллекция фигур
        /// </summary>
        private ObservableCollection<BaseShape> _shapes = new ObservableCollection<BaseShape>();

        /// <summary>
        /// Текущий полигон
        /// </summary>
        private Polygon _currentPolygon = null;

        /// <summary>
        /// Свойство коллекция фигур
        /// </summary>
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

        /// <summary>
        /// Метод добавления квадрата в коллекцию _shapes
        /// </summary>
        /// <param name="x">Координата X левого правого угла прямоугольника</param>
        /// <param name="y">Координата Y левого правого угла прямоугольника</param>
        /// <param name="width">Ширина прямоугольника</param>
        /// <param name="height">Высота прямоугольника</param>
        public void AddRectangle (double x, double y, int width, int height)
        {
            _shapes.Add(new Rectangle(x, y, width, height));
            OnPropertyChanged();
        }

        /// <summary>
        /// Метод добавления точки в полигон
        /// </summary>
        /// <param name="x">Координата X точки</param>
        /// <param name="y">Координата Y точки</param>
        public void AddPointToPolygon (double x, double y)
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

        /// <summary>
        /// Метод замыкания полигона
        /// </summary>
        public void ClosePolygon ()
        {
            if (_currentPolygon != null)
            {
                _currentPolygon.Close();
                _currentPolygon = null;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Удаление содержимого коллекции фигур
        /// </summary>
        public void ClearContent()
        {
            _shapes.Clear();
            OnPropertyChanged();
        }

        /// <summary>
        /// Метод, вызываемый при изменении коллекции фигур
        /// </summary>
        public void OnPropertyChanged()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Shapes"));
        }
    }
}
