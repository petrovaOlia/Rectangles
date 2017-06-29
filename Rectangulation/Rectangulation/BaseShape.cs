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
        private Geometry _geometry; // геометрия фигуры
        private Brush _fill; // кисть заливки
        private Brush _stroke; // кисть контура
        private double _strokeThickness; // толщина линии

        public Geometry Geometry
        {
            get
            {
                return _geometry;
            }
            set
            {
                _geometry = value;
            }
        }
        public Brush Fill
        {
            get
            {
                return _fill;
            }
            set
            {
                _fill = value;
            }
        }

        public Brush Stroke
        {
            get
            {
                return _stroke;
            }
            set
            {
                _stroke = value;
            }
        }
        public double StrokeThickness
        {
            get
            {
                return _strokeThickness;
            }
            set
            {
                _strokeThickness = value;
            }
        }
    }
}

