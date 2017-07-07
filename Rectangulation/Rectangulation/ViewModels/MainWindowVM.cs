using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Rectangulation.Commands;

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
        /// Текущий полигон
        /// </summary>
        private PolygonVM _currentPolygon = null;

        /// <summary>
        /// Конструктор MainWindowVM
        /// </summary>
        public MainWindowVM()
        {
            Shapes = new CompositeCollection();

            CollectionContainer polygonContainer = new CollectionContainer();
            polygonContainer.Collection = _polygons;
            Shapes.Add(polygonContainer);

            CollectionContainer rectangleContainer = new CollectionContainer();
            rectangleContainer.Collection = _rectangles;
            Shapes.Add(rectangleContainer);
        }

        /// <summary>
        /// Свойство коллекция прямоугольников
        /// </summary>
        public ObservableCollection<RectangleVM> Rectangles
        {
            get { return _rectangles; }
            set
            {
                _rectangles = value;
            }
        }

        /// <summary>
        /// Свойство коллекция полигонов
        /// </summary>
        public ObservableCollection<PolygonVM> Polygons
        {
            get { return _polygons; }
            set
            {
                _polygons = value;
            }
        }

        /// <summary>
        /// Свойство коллекция фигур
        /// </summary>
        public CompositeCollection Shapes { get; private set; }

        /// <summary>
        /// Метод добавления квадрата в коллекцию _shapes
        /// </summary>
        /// <param name="x">Координата X левого правого угла прямоугольника</param>
        /// <param name="y">Координата Y левого правого угла прямоугольника</param>
        public void AddRectangle(double x, double y)
        {
            _rectangles.Add(new RectangleVM(x, y));
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

        // Метод, вызываемый  при нажатии правой кнопки мышиь. Переделать в команду
        public void ReightClick()
        {
            ClosePolygon();
        }
        // Метод, вызываемый при нажатии левой кнопки мыши. Переделать в команду
        public void LeftClick (double x, double y)
        {
            AddPointToPolygon(x, y);
        }

       

        private RectangulationCommand _AddRectangleCommand;
        
        public RectangulationCommand AddRectangleCommand
        {
            get { return _AddRectangleCommand ?? (_AddRectangleCommand = new RectangulationCommand()); }
        }

        private ClearCommand _ClearCommand;

        public ClearCommand ClearCommand
        {
            get { return _ClearCommand ?? (_ClearCommand = new ClearCommand()); }
        }

        /// <summary>
        /// Метод, вызываемый при изменении коллекции фигур
        /// </summary>
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
