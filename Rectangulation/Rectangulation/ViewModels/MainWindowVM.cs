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
        public ObservableCollection<PolygonVM> Polygons { get; }

        /// <summary>
        /// Коллекция прямоугольников
        /// </summary>
        public ObservableCollection<RectangleVM> Rectangles { get; }

        /// <summary>
        /// Текущий полигон
        /// </summary>
        public PolygonVM CurrentPolygon { get; set; }

        /// <summary>
        /// Свойство коллекция фигур
        /// </summary>
        public CompositeCollection Shapes { get; private set; }

        /// <summary>
        /// Команда добавления полигона
        /// </summary>
        public AddPolygonCommand AddPolygonCommand { get; }

        /// <summary>
        /// Комманда добавления квадрата в коллекцию _shapes
        /// </summary>
        public RectangulationCommand AddRectangleCommand { get; }

        /// <summary>
        /// Комманда очистки области отображения
        /// </summary>
        public ClearCommand ClearCommand { get; }

        /// <summary>
        /// Ширина прямоугольника
        /// </summary>
        public int RectWidth { get; set; }

        /// <summary>
        /// Высота прямоугольника
        /// </summary>
        public int RectHeight { get; set; }

        /// <summary>
        /// Конструктор MainWindowVM
        /// </summary>
        public MainWindowVM()
        {
            AddRectangleCommand = new RectangulationCommand();
            ClearCommand = new ClearCommand();

            Shapes = new CompositeCollection();
            Polygons = new ObservableCollection<PolygonVM>();
            Rectangles = new ObservableCollection<RectangleVM>();

            CollectionContainer polygonContainer = new CollectionContainer();
            polygonContainer.Collection = Polygons;
            Shapes.Add(polygonContainer);

            CollectionContainer rectangleContainer = new CollectionContainer();
            rectangleContainer.Collection = Rectangles;
            Shapes.Add(rectangleContainer);

            CurrentPolygon = null;
            RectWidth = 20;
            RectHeight = 20;
        }

        /// <summary>
        /// Метод добавления точки в полигон
        /// </summary>
        /// <param name="x">Координата X точки</param>
        /// <param name="y">Координата Y точки</param>
        public void AddPointToPolygon(double x, double y)
        {
            if (CurrentPolygon == null)
            {
                CurrentPolygon = new PolygonVM(x, y);
                Polygons.Add(CurrentPolygon);
            }
            else
                CurrentPolygon.AddPoint(x, y);
            OnPropertyChanged();
        }

        /// <summary>
        /// Метод замыкания полигона
        /// </summary>
        public void ClosePolygon()
        {
            if (CurrentPolygon != null)
            {
                CurrentPolygon.Close();
                CurrentPolygon = null;
                OnPropertyChanged();
            }
        }

        // Метод, вызываемый  при нажатии правой кнопки мышиь. Переделать в команду
        public void ReightClick()
        {
            ClosePolygon();
        }

        // Метод, вызываемый при нажатии левой кнопки мыши. Переделать в команду
        public void LeftClick(double x, double y)
        {
            AddPointToPolygon(x, y);
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
