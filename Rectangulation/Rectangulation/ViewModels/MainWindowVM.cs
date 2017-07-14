using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Rectangulation.Commands;
using Rectangulation.ViewModels;

namespace Rectangulation
{
    class MainWindowVM : ViewModel
    {
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
        /// Выделенный прямоугольник
        /// </summary>
        private RectangleVM _selectedRectangle;

        /// <summary>
        /// Свойство выделенного прямоугольника
        /// </summary>
        public RectangleVM SelectedRectangle
        {
            get { return _selectedRectangle; }
            set
            {
                if (_selectedRectangle != null)
                    _selectedRectangle.Selected = false;
                _selectedRectangle = value;
                if (_selectedRectangle != null)
                    _selectedRectangle.Selected = true;
                OnPropertyChanged("SelectedRectangle");
            }
        }

        /// <summary>
        /// Свойство коллекция фигур
        /// </summary>
        public CompositeCollection Shapes { get; private set; }

        /// <summary>
        /// Ширина прямоугольника
        /// </summary>
        public int RectWidth { get; set; }

        /// <summary>
        /// Высота прямоугольника
        /// </summary>
        public int RectHeight { get; set; }

        /// <summary>
        /// Свойство, определяющие возможность рисования полигона
        /// </summary>
        public bool DrawingPoligons { get; set; }

        /// <summary>
        /// Команда нажатия левой кнопки мыши
        /// </summary>
        public LeftClickCommand LeftClickCommand { get; }

        /// <summary>
        /// Команда нажатия правой кнопки мыши
        /// </summary>
        public RightClickCommand RightClickCommand { get; }

        /// <summary>
        /// Комманда нажатия кнопки Ректаннуляция
        /// </summary>
        public RectangulationCommand AddRectangleCommand { get; }

        /// <summary>
        /// Комманда нажатия кнопки Очистить
        /// </summary>
        public ClearCommand ClearCommand { get; }

        /// <summary>
        /// Конструктор MainWindowVM
        /// </summary>
        public MainWindowVM()
        {
            AddRectangleCommand = new RectangulationCommand();
            ClearCommand = new ClearCommand();
            LeftClickCommand = new LeftClickCommand();
            RightClickCommand = new RightClickCommand();

            Shapes = new CompositeCollection();
            Polygons = new ObservableCollection<PolygonVM>();
            Rectangles = new ObservableCollection<RectangleVM>();

            var polygonContainer = new CollectionContainer {Collection = Polygons};
            Shapes.Add(polygonContainer);

            var rectangleContainer = new CollectionContainer {Collection = Rectangles};
            Shapes.Add(rectangleContainer);

            CurrentPolygon = null;
            RectWidth = 20;
            RectHeight = 20;
            SelectedRectangle = null;
            DrawingPoligons = true;
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
    }
}
