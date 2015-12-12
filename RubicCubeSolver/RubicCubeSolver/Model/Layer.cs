using Microsoft.Practices.Prism.Commands;
using RubicCubeSolver.Model.Enum;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media;
using System;

namespace RubicCubeSolver.Model
{
    public class Layer
    {
        public ICommand ChangeColorCommand { get; set; }

        public Layer()
        {
            _content = new Dictionary<LayerPosition, Color>()
            {
                {LayerPosition.BottomLeft, Colors.Orange },
                {LayerPosition.BottomMid,  Colors.Orange },
                {LayerPosition.BottomRight,  Colors.Orange },
                {LayerPosition.MidLeft,  Colors.Orange },
                {LayerPosition.Mid,  Colors.Orange },
                {LayerPosition.MidRight,  Colors.Orange },
                {LayerPosition.TopLeft,  Colors.Orange },
                {LayerPosition.TopMid,  Colors.Orange },
                {LayerPosition.TopRight,  Colors.Orange }
            };

            ChangeColorCommand = new DelegateCommand<string>(ChangeColor);
        }

        private void ChangeColor(object obj)
        {
            throw new NotImplementedException();
        }

        private readonly Dictionary<LayerPosition, Color> _content;

        public Layer(Dictionary<LayerPosition, Color> content)
            : this()
        {
            _content = content;
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
            get { return _content[LayerPosition.TopLeft]; }
            set { _content[LayerPosition.TopLeft] = value; }
        }

        public Color TopMid
        {
            get { return _content[LayerPosition.TopMid]; }
            set { _content[LayerPosition.TopMid] = value; }
        }
        public Color TopRight
        {
            get { return _content[LayerPosition.TopRight]; }
            set { _content[LayerPosition.TopRight] = value; }
        }

        public Color MidLeft
        {
            get { return _content[LayerPosition.MidLeft]; }
            set { _content[LayerPosition.MidLeft] = value; }
        }

        public Color Mid
        {
            get { return _content[LayerPosition.Mid]; }
            set { _content[LayerPosition.Mid] = value; }
        }

        public Color MidRight
        {
            get { return _content[LayerPosition.MidRight]; }
            set { _content[LayerPosition.MidRight] = value; }
        }

        public Color BottomLeft
        {
            get { return _content[LayerPosition.BottomLeft]; }
            set { _content[LayerPosition.BottomLeft] = value; }
        }

        public Color BottomMid
        {
            get { return _content[LayerPosition.BottomMid]; }
            set { _content[LayerPosition.BottomMid] = value; }
        }

        public Color BottomRight
        {
            get { return _content[LayerPosition.BottomRight]; }
            set { _content[LayerPosition.BottomRight] = value; }
        }
    }
}
