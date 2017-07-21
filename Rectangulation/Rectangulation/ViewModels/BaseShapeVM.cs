namespace Rectangulation.ViewModels
{
    using System.Windows.Media;

    /// <summary>
    /// Представление модели базовой фигуры
    /// </summary>
    public abstract class BaseShapeVM : ViewModel
    {
        /// <summary>
        /// Свойство геометрия фигуры
        /// </summary>
        public Geometry Geometry { get; set; }

        /// <summary>
        /// Свойство кисть заливки
        /// </summary>
        public abstract Brush Fill { get;  }

        /// <summary>
        /// Свойство кисть контура
        /// </summary>
        public abstract Brush Stroke { get; }

        /// <summary>
        /// Свойство толщина линии
        /// </summary>
        public abstract double StrokeThickness { get; }
    }

}

