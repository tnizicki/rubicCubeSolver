
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RubicCubeSolver.Model.Enums;

namespace RubicCubeSolver.Model
{
    public class Layer
    {
        private readonly LayerColor[,] _content = new LayerColor[3, 3];

        public Layer(LayerColor[,] content)
        {
            _content = content;
        }

        internal static Layer GetFullColorLayer(LayerColor color)
        {
            return new Layer(new LayerColor[,]
            {
                {color, color, color },
                {color, color, color },
                {color, color, color }
            });
        }

        public LayerColor TopLeft
        {
            get { return _content[0, 0]; }
            set { _content[0, 0] = value; }
        }

        public LayerColor TopMid
        {
            get { return _content[0, 1]; }
            set { _content[0, 1] = value; }
        }
        public LayerColor TopRight
        {
            get { return _content[0, 2]; }
            set { _content[0, 2] = value; }
        }

        public LayerColor LeftMid
        {
            get { return _content[1, 0]; }
            set { _content[1, 0] = value; }
        }

        public LayerColor Mid
        {
            get { return _content[1, 1]; }
            set { _content[1, 1] = value; }
        }

        public LayerColor RightMid
        {
            get { return _content[1, 2]; }
            set { _content[1, 2] = value; }
        }

        public LayerColor BottomLeft
        {
            get { return _content[2, 0]; }
            set { _content[2, 0] = value; }
        }

        public LayerColor BottomMid
        {
            get { return _content[2, 1]; }
            set { _content[2, 1] = value; }
        }

        public LayerColor BottomRight
        {
            get { return _content[2, 2]; }
            set { _content[2, 2] = value; }
        }
    }
}
