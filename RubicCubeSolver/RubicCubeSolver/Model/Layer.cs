using Microsoft.Practices.Prism.Commands;
using RubicCubeSolver.Model.Enum;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media;
using System;
using Utils;
using Microsoft.Practices.Prism.Mvvm;

namespace RubicCubeSolver.Model
{
    public class Layer : BindableBase
    {
        private Color _topLeft;
        private Color _topMid;
        private Color _topRight;
        private Color _midLeft;
        private Color _mid;
        private Color _midRight;
        private Color _bottomLeft;
        private Color _bottomMid;
        private Color _bottomRight;

        private LinkedList<Color> _colorsOrder = new LinkedList<Color>(); //{ Colors.White, Colors.Yellow, Colors.Orange, Colors.Red, Colors.Green, Colors.Blue };

        public ICommand ChangeColorCommand { get; set; }

        public Layer()
        {
            TopLeft = Colors.Orange;
            TopMid = Colors.Orange;
            TopRight = Colors.Orange;
            MidLeft = Colors.Orange;
            Mid = Colors.Orange;
            MidRight = Colors.Orange;
            BottomLeft = Colors.Orange;
            BottomMid = Colors.Orange;
            BottomRight = Colors.Orange;

            ChangeColorCommand = new DelegateCommand<string>(ChangeColor);

            _colorsOrder.AddLast(Colors.White);
            _colorsOrder.AddLast(Colors.Yellow);
            _colorsOrder.AddLast(Colors.Orange);
            _colorsOrder.AddLast(Colors.Red);
            _colorsOrder.AddLast(Colors.Green);
            _colorsOrder.AddLast(Colors.Blue);
        }

        private void ChangeColor(string parameter)
        {
            var property = GetType().GetProperty(parameter);
            var nextNode = _colorsOrder.Find((Color)property.GetValue(this)).Next;
            var nextVal = nextNode != null ? nextNode.Value : _colorsOrder.First.Value;
            property.SetValue(this, nextVal);
        }

        public Layer(Dictionary<LayerPosition, Color> content)
            : this()
        {
            foreach (var item in content)
            {
                GetType().GetProperty(item.Key.ToString()).SetValue(this, item.Value);
            }
        }

        internal static Layer GetFullColorLayer(Color color)
        {
            return new Layer(new Dictionary<LayerPosition, Color>
            {
                {LayerPosition.BottomLeft, color },
                {LayerPosition.BottomMid, color },
                {LayerPosition.BottomRight, color },
                {LayerPosition.MidLeft, color },
                {LayerPosition.Mid, color },
                {LayerPosition.MidRight, color },
                {LayerPosition.TopLeft, color },
                {LayerPosition.TopMid, color },
                {LayerPosition.TopRight, color }
            });
        }

        public Color TopLeft
        {
            get { return _topLeft; }
            set { SetProperty(ref _topLeft, value); }
        }

        public Color TopMid
        {
            get { return _topMid; }
            set { SetProperty(ref _topMid, value); }
        }
        public Color TopRight
        {
            get { return _topRight; }
            set { SetProperty(ref _topRight, value); }
        }

        public Color MidLeft
        {
            get { return _midLeft; }
            set { SetProperty(ref _midLeft, value); }
        }

        public Color Mid
        {
            get { return _mid; }
            set { SetProperty(ref _mid, value); }
        }

        public Color MidRight
        {
            get { return _midRight; }
            set { SetProperty(ref _midRight, value); }
        }

        public Color BottomLeft
        {
            get { return _bottomLeft; }
            set { SetProperty(ref _bottomLeft, value); }
        }

        public Color BottomMid
        {
            get { return _bottomMid; }
            set { SetProperty(ref _bottomMid, value); }
        }

        public Color BottomRight
        {
            get { return _bottomRight; }
            set { SetProperty(ref _bottomRight, value); }
        }
    }
}
