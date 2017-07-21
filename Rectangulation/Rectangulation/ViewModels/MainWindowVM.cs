namespace Rectangulation.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Data;
    using Rectangulation.Commands;

    /// <summary>
    /// Представление главного окна
    /// </summary>
    class MainWindowVM : ViewModel
    {
        /// <summary>
        /// Выделенный прямоугольник
        /// </summary>
        private RectangleVM _selectedRectangleVM;

        /// <summary>
        /// Конструктор MainWindowVM
        /// </summary>
        public MainWindowVM()
        {
            RectangulationCommand = new RectangulationCommand();
            ClearCommand = new ClearCommand();
            LeftClickCommand = new LeftClickCommand();
            RightClickCommand = new RightClickCommand();

            Shapes = new CompositeCollection();
            Polygons = new ObservableCollection<PolygonVM>();
            Rectangles = new ObservableCollection<RectangleVM>();

            var polygonContainer = new CollectionContainer { Collection = Polygons };
            Shapes.Add(polygonContainer);

            var rectangleContainer = new CollectionContainer { Collection = Rectangles };
            Shapes.Add(rectangleContainer);

            CurrentPolygon = null;
            RectWidth = 20;
            RectHeight = 20;
            SelectedRectangleVM = null;
        }

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
        /// Свойство выделенного прямоугольника
        /// </summary>
        public RectangleVM SelectedRectangleVM
        {
            get { return _selectedRectangleVM; }
            set
            {
                if (_selectedRectangleVM != null)
                    _selectedRectangleVM.Selected = false;
                _selectedRectangleVM = value;
                if (_selectedRectangleVM != null)
                    _selectedRectangleVM.Selected = true;
                OnPropertyChanged("SelectedRectangleVM");
            }
        }

        /// <summary>
        /// Свойство коллекции фигур
        /// </summary>
        public CompositeCollection Shapes { get; private set; }

        /// <summary>
        /// Свойство ширины прямоугольника
        /// </summary>
        public int RectWidth { get; set; }

        /// <summary>
        /// Свойство высоты прямоугольника
        /// </summary>
        public int RectHeight { get; set; }

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
        public RectangulationCommand RectangulationCommand { get; }

        /// <summary>
        /// Комманда нажатия кнопки Очистить
        /// </summary>
        public ClearCommand ClearCommand { get; }

        /// <summary>
        /// Свойство, определяющие перемещение прямоугольника
        /// </summary>
        private bool MovingRectangle { get; set; } = false;

        /// <summary>
        /// Разница между позицией нажатия мыши и позицией прямоугольника
        /// </summary>
        private Point MouseDownPos { get; set; }

        /// <summary>
        /// Метод нажатия мыши
        /// </summary>
        /// <param name="mousePos">Позиция мыши</param>
        public void MouseDown(Point mousePos)
        {
            foreach (var rectangle in Rectangles)
            {
                if (!rectangle.IsHitingToBorder(mousePos.X, mousePos.Y)) continue;
                MouseDownPos = new Point(rectangle.Geometry.Bounds.X - mousePos.X,
                    rectangle.Geometry.Bounds.Y - mousePos.Y);
                SelectedRectangleVM = rectangle;
                MovingRectangle = true;
                return;
            }
        }
        /// <summary>
        /// Метод перемещения мыши
        /// </summary>
        /// <param name="mousePos">Позиция мыши</param>
        public void MouseMove(Point mousePos)
        {
            if ((SelectedRectangleVM != null) && (MovingRectangle))
            {
                SelectedRectangleVM.Move(mousePos.X + MouseDownPos.X, mousePos.Y + MouseDownPos.Y);
            }
        }

        /// <summary>
        /// Метод отпускания мыши
        /// </summary>
        /// <param name="mousePos">Позиция мыши</param>
        public void MouseUp(Point mousePos)
        {
            if (!MovingRectangle) return;
            MovingRectangle = false;
            SelectedRectangleVM?.Move(mousePos.X + MouseDownPos.X, mousePos.Y + MouseDownPos.Y);
        }
    }
}
