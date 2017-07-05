﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Rectangulation
{
   
    public abstract class BaseShapeVM
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

