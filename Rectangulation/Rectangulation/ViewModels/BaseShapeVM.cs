using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Rectangulation.ViewModels;

namespace Rectangulation
{
   
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

