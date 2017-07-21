namespace Rectangulation.ViewModels
{
    using Rectangulation.Models;
    using System.Windows;
    using System.Windows.Media;

    /// <summary>
    /// Представление модели прямоугольника
    /// </summary>
    public class RectangleVM : BaseShapeVM
    {
        /// <summary>
        /// Определяет выделение цветом прямоугольника
        /// </summary>
        private bool _selected;

        /// <summary>
        /// Конструктор RectangleVM
        /// </summary>
        /// <param name="rectangle">Прямоугольник</param>
        public RectangleVM(Rectangle rectangle)
        {
            Rectangle = rectangle;
            Geometry = new RectangleGeometry(new Rect(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height));
        }

        /// <summary>
        /// Прямоугольник
        /// </summary>
        private Rectangle Rectangle { get; }

        /// <summary>
        /// Свойство имя прямоугольника в списке
        /// </summary>
        public string Label => "Прямоугольник " + Rectangle.Id.ToString();

        /// <summary>
        /// Свойство, использующиеся для выбора в списке
        /// </summary>
        public bool Checked { get; set; }

        /// <summary>
        /// Свойство кисть заливки
        /// </summary>
        public override Brush Fill => _selected ? Brushes.Transparent : Brushes.Black;

        /// <summary>
        /// Свойство кисть контура
        /// </summary>
        public override Brush Stroke => _selected ? Brushes.Red : Brushes.Black;

        /// <summary>
        /// Свойство толщина линии
        /// </summary>
        public override double StrokeThickness => 1;

        /// <summary>
        /// Свойство, определяющие выделение цветом прямоугольника
        /// </summary>
        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                OnPropertyChanged("Fill");
                OnPropertyChanged("Stroke");
            }
        }

        /// <summary>
        /// Метод попадания в границы прямоугольника
        /// </summary>
        /// <param name="x">Координата X нажатия левой кнопки мыши</param>
        /// <param name="y">Координата Y нажатия левой кнопки мыши</param>
        /// <returns>Возвращает true, если клик рядом с границей</returns>
        public bool IsHitingToBorder(double x, double y)
        {
            return Rectangle.IsHitingToBorder(x, y);
        }

        /// <summary>
        /// Изменения позиции прямоугольника
        /// </summary>
        /// <param name="x">Координта x</param>
        /// <param name="y">Координта y</param>
        public void Move(double x, double y)
        {
            Rectangle.Y = y;
            Rectangle.X = x;
            Geometry = new RectangleGeometry(new Rect(x, y, Rectangle.Width, Rectangle.Height));
            OnPropertyChanged("Geometry");
        }
    }
}
