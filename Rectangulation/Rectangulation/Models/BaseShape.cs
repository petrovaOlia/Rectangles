using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Rectangulation
{
    public class BaseShape
    {
        /// <summary>
        /// Свойство геометрия фигуры
        /// </summary>
        public Geometry Geometry { get; set; }

        /// <summary>
        /// Свойство кисть заливки
        /// </summary>
        public Brush Fill { get; set; }

        /// <summary>
        /// Свойство кисть контура
        /// </summary>
        public Brush Stroke { get; set; }

        /// <summary>
        /// Свойство толщина линии
        /// </summary>
        public double StrokeThickness { get; set; } 
    }
}

