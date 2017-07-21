namespace Rectangulation.Models
{

    /// <summary>
    /// Модель прямоугольника
    /// </summary>
    public class Rectangle
    {
        /// <summary>
        /// Конструктор прямоугольника
        /// </summary>
        /// <param name="x">Координата X левого правого угла прямоугольника</param>
        /// <param name="y">Координата Y левого правого угла прямоугольника</param>
        /// <param name="width">Ширина прямоугольника</param>
        /// <param name="height">Высота прямоугольника</param>
        public Rectangle(double x, double y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Id = LastId;
            LastId = LastId + 1;
        }

        /// <summary>
        /// Координата X левого верхнего угла прямоугольника
        /// </summary>
        public double X { get; set; }

        /// <summary>
        ///  Координата Y левого верхнего угла прямоугольника
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Ширина прямоугольника
        /// </summary>
        public double Width { get; private set; }

        /// <summary>
        /// Высота прямоугольника
        /// </summary>
        public double Height { get; private set; }

        /// <summary>
        /// Свойство нумерации прямоугольника
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Свойство последнего номера в списоке прямоугольника
        /// </summary>
        public static int LastId { get; set; } = 1;

        /// <summary>
        /// Метод, определяющий попадание в границы прямоугольника
        /// </summary>
        /// <param name="x">Координата X нажатия левой кнопки мыши</param>
        /// <param name="y">Координата Y нажатия левой кнопки мыши</param>
        /// <returns>Возвращает true, если клик рядом с границей</returns>
        public bool IsHitingToBorder(double x, double y)
        {
            return ((x >= X - 2) &&
                    (y >= Y - 2) &&
                    (x <= X + 2 + Width) &&
                    (y <= Y + 2 + Height))
                   &&
                   ((x <= X + 2) ||
                    (y <= Y + 2) ||
                    (x >= X - 2 + Width) ||
                    (y >= Y - 2 + Height));
        }
    }
}
