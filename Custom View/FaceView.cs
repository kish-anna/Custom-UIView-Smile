using SkiaSharp;

namespace Smile
{
    public class FaceView : IEmotionalView
    {
        public FaceView(float size, SKColor fillColor, SKColor strokeColor, SKColor eyesColor, SKColor mouthColor)
        {
            FillColor = fillColor;
            StrokeColor = strokeColor;
            EyesColor = eyesColor;
            MouthColor = mouthColor;
            Size = size;
        }

        private float _size;
        public float Size
        {
            get => _size;
            set
            {
                _size = value;
                Radius = _size / 2;
                LeftEyeRect = new SKRect(_size * 0.32f, _size * 0.23f, _size * 0.43f, _size * 0.50f);
                RightEyeRect = new SKRect(_size * 0.57f, _size * 0.23f, _size * 0.68f, _size * 0.50f);
                FacePath = GetFacePath();
                //Mouth = GetMouth(_size, _happinessState);

            }
        }

        public SKRect LeftEyeRect { get; private set; }
        public SKRect RightEyeRect { get; private set; }
        public SKPath FacePath { get; private set; }

        public float Radius { get; private set; }
        public SKColor FillColor { get; set; }
        public SKColor StrokeColor { get; set; }
        public SKColor EyesColor { get; set; }
        public SKColor MouthColor { get; set; }

        public SKPath GetFacePath()
        {
            var path = new SKPath();
            path.AddCircle(Radius, Radius, Radius, SKPathDirection.Clockwise);

            return path;
        }

        public SKPath GetHappyMouth()
        {
            var path = new SKPath();
            path.MoveTo(_size * 0.22f, _size * 0.70f);

            path.QuadTo(_size * 0.50f, _size * 0.80f, _size * 0.78f, _size * 0.70f);
            path.QuadTo(_size * 0.50f, _size * 0.90f, _size * 0.22f, _size * 0.70f);

            return path;
        }

        public SKPath GetSadMouth()
        {
            var path = new SKPath();
            path.MoveTo(_size * 0.22f, _size * 0.70f);

            path.QuadTo(_size * 0.50f, _size * 0.50f, _size * 0.78f, _size * 0.70f);
            path.QuadTo(_size * 0.50f, _size * 0.60f, _size * 0.22f, _size * 0.70f);

            return path;
        }
    }
}

