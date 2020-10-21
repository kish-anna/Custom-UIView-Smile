using System;
using SkiaSharp;
using Smile;

namespace CustomView
{
    public class FaceView : IEmotionalView
    {
        public FaceView(float size, SKColor fillColor, SKColor strokeColor, StateButton state = StateButton.Happy)
        {
            FillColor = fillColor;
            StrokeColor = strokeColor;
            CurrentState = state;
            Size = size;

        }

        private float _size;
        private StateButton _currentState;

        public float Size
        {
            get => _size;
            set
            {
                _size = value;
                Radius = _size / 2;
                LeftEyeRect = new SKRect();
            }
        }

        public SKRect LeftEyeRect { get; private set; }
        public StateButton CurrentState
        {
            get => _currentState;
            set
            {
                _currentState = value;
                ChangeState?.Invoke();
            }
        }

        public float Radius { get; private set; }
        public event Action ChangeState;
        public SKColor FillColor { get; set; }
        public SKColor StrokeColor { get; set; }
    }
}

