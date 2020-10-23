using System;
using UIKit;
using Smile;
using Foundation;
using System.ComponentModel;
using SkiaSharp.Views.iOS;

namespace Smile_IOS
{
    [Register("EmotionalFaceView"), DesignTimeVisible(true)]
    public class EmotionalFaceView : SKCanvasView 
    {
        [Export("BGColor"), Browsable(true)]
        public UIColor BGColor { get; set; }

        [Export("EyesColor"), Browsable(true)]
        public UIColor EyesColor { get; set; }

        [Export("MouthColor"), Browsable(true)]
        public UIColor MouthColor { get; set; }

        [Export("BorderColor"), Browsable(true)]
        public UIColor BorderColor { get; set; }

        [Export("HappinessState"), Browsable(true)]
        public StateButton HappinessState
        {
            get => _happinessState;
            set
            {
                _happinessState = value;
                SetNeedsDisplay();
            }
        }

        private StateButton _happinessState;

        private FaceView _presenter;

        public EmotionalFaceView(IntPtr handle) : base(handle)
        {
            BGColor = UIColor.Clear;
            EyesColor = UIColor.Clear;
            MouthColor = UIColor.Clear;
            BorderColor = UIColor.Clear;
            HappinessState = StateButton.Happy;
            BackgroundColor = UIColor.Clear;
        }

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            base.OnPaintSurface(e);
            var g = e.Surface.Canvas;

            _presenter = new FaceView(Math.Min(e.Info.Height, e.Info.Width), BGColor.ToSKColor(),
                BorderColor.ToSKColor(), EyesColor.ToSKColor(), MouthColor.ToSKColor());

            _presenter.Draw(g, HappinessState);
        }

    }
}