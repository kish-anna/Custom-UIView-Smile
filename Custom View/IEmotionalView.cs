using SkiaSharp;

namespace Smile
{
    public interface IEmotionalView
    {
        float Size { get; set; }
        float Radius { get; }

        SKColor FillColor { get; set; }
        SKColor StrokeColor { get; set; }
    }
}
