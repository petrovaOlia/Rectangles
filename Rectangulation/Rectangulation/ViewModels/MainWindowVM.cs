using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
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
        /// Коллекция полигонов
        /// </summary>
        private ObservableCollection<PolygonVM> _polygons = new ObservableCollection<PolygonVM>();

        /// <summary>
        /// Коллекция прямоугольников
        /// </summary>
        private ObservableCollection<RectangleVM> _rectangles = new ObservableCollection<RectangleVM>();

        /// <summary>
        /// Объединенная коллекция фигур
        /// </summary>
        private CompositeCollection _shapes = new CompositeCollection();

        /// <summary>
        /// Текущий полигон
        /// </summary>
        private PolygonVM _currentPolygon = null;

        public MainWindowVM()
        {
            CollectionContainer polygonContainer = new CollectionContainer();
            polygonContainer.Collection = _polygons;
            _shapes.Add(polygonContainer);

            CollectionContainer rectangleContainer = new CollectionContainer();
            rectangleContainer.Collection = _rectangles;
            _shapes.Add(rectangleContainer);
        }

        /// <summary>
        /// Свойство коллекция фигур
        /// </summary>
        public CompositeCollection Shapes
        {
            get
            {
                return _shapes;
            }
        }

        /// <summary>
        /// Метод добавления квадрата в коллекцию _shapes
        /// </summary>
        /// <param name="x">Координата X левого правого угла прямоугольника</param>
        /// <param name="y">Координата Y левого правого угла прямоугольника</param>
        public void AddRectangle(double x, double y)
        {
            _rectangles.Add(new RectangleVM(x, y));
            OnPropertyChanged();
        }

        /// <summary>
        /// Метод добавления точки в полигон
        /// </summary>
        /// <param name="x">Координата X точки</param>
        /// <param name="y">Координата Y точки</param>
        public void AddPointToPolygon(double x, double y)
        {
            if (_currentPolygon == null)
            {
                _currentPolygon = new PolygonVM(x, y);
                _polygons.Add(_currentPolygon);
            }
            else
                _currentPolygon.AddPoint(x, y);
            OnPropertyChanged();
        }

        /// <summary>
        /// Метод замыкания полигона
        /// </summary>
        public void ClosePolygon()
        {
            if (_currentPolygon != null)
            {
                _currentPolygon.Close();
                _currentPolygon = null;
                OnPropertyChanged();
            }
        }

        // Метод, вызываемый при нажатии кнопки Ректангулировать. Переделать в команду
        public void ReightClick()
        {
            ClosePolygon();
        }
        // Метод, вызываемый при нажатии левой кнопки мыши. Переделать в команду
        public void LeftClick (double x, double y)
        {
            AddPointToPolygon(x, y);
        }

        // <summary>
        /// Удаление содержимого коллекции фигур
        /// </summary>
        public void ClearContent()
        {
            _polygons.Clear();
            _rectangles.Clear();
            OnPropertyChanged();
        }

        private DelegateCommand _AddRectangleCommand;

        public DelegateCommand AddRectangleCommand
        {
            get { return _AddRectangleCommand ?? (_AddRectangleCommand = new DelegateCommand(AddRectangleExecute)); }
        }

        private void AddRectangleExecute()
        {
            var x = 120;
            var y = 120;
            for (var i = 0; i < 5; i++)
            {
                AddRectangle(x += 15, y += 15);
            }
        }

        /// <summary>
        /// Метод, вызываемый при изменении коллекции фигур
        /// </summary>
        public void OnPropertyChanged([CallerMemberName]string prop = "Shapes")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
