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
        public Geometry Geometry { get; set; } // геометрия фигуры
        public Brush Fill { get; set; } // кисть заливки
        public Brush Stroke { get; set; } // кисть контура
        public double StrokeThickness { get; set; } // толщина линии
    }
}

