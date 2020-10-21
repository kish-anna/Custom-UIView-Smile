using System;
using SkiaSharp;
using Smile;

namespace CustomView
{
    public interface IEmotionalView
    {
        float Size { get; set; }
        float Radius { get; }

        event Action ChangeState;

        StateButton CurrentState { get; set; }

        SKColor FillColor { get; set; }
        SKColor StrokeColor { get; set; }
    }
}
