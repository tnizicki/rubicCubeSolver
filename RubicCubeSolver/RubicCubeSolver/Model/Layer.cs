using System.Windows.Media;

namespace RubicCubeSolver.Model
{
    public class Layer
    {
        public Layer()
        {

        }

        private readonly Color[,] _content = new Color[3, 3];

        public Layer(Color[,] content)
        {
            _content = content;
        }

        internal static Layer GetFullColorLayer(Color color)
        {
            return new Layer(new Color[,]
            {
                {color, color, color },
                {color, color, color },
                {color, color, color }
            });
        }

        public Color TopLeft
        {
            get { return _content[0, 0]; }
            set { _content[0, 0] = value; }
        }

        public Color TopMid
        {
            get { return _content[0, 1]; }
            set { _content[0, 1] = value; }
        }
        public Color TopRight
        {
            get { return _content[0, 2]; }
            set { _content[0, 2] = value; }
        }

        public Color LeftMid
        {
            get { return _content[1, 0]; }
            set { _content[1, 0] = value; }
        }

        public Color Mid
        {
            get { return _content[1, 1]; }
            set { _content[1, 1] = value; }
        }

        public Color RightMid
        {
            get { return _content[1, 2]; }
            set { _content[1, 2] = value; }
        }

        public Color BottomLeft
        {
            get { return _content[2, 0]; }
            set { _content[2, 0] = value; }
        }

        public Color BottomMid
        {
            get { return _content[2, 1]; }
            set { _content[2, 1] = value; }
        }

        public Color BottomRight
        {
            get { return _content[2, 2]; }
            set { _content[2, 2] = value; }
        }
    }
}
