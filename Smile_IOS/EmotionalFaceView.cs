using System;
using UIKit;
using Smile;
using Foundation;
using System.ComponentModel;
using SkiaSharp.Views.iOS;
using SkiaSharp;

namespace Smile_IOS
{
    [Register("EmotionalFaceView"), DesignTimeVisible(true)]
    public class EmotionalFaceView : SKCanvasView
    {
        float size = 0;

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
            Initialize();
        }
        public EmotionalFaceView()
        {
            Initialize();
        }
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            _presenter = new FaceView(size, BGColor.ToSKColor(), BorderColor.ToSKColor(),
                EyesColor.ToSKColor(), MouthColor.ToSKColor());
            BackgroundColor = UIColor.Clear;
        }
        void Initialize()
        {
            BGColor = UIColor.Clear;
            EyesColor = UIColor.Clear;
            MouthColor = UIColor.Clear;
            BorderColor = UIColor.Clear;
        }

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            base.OnPaintSurface(e);
            var g = e.Surface.Canvas;

            size = Math.Min(e.Info.Height, e.Info.Width);
            _presenter.Size = size;
            DrawFaceBackground(g);
            DrawEyes(g);
            DrawMouth(g);
        }
        private void DrawFaceBackground(SKCanvas c)
        {

            var paintStroke = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = _presenter.StrokeColor,
                StrokeWidth = 2.0f
            };
            var paintFill = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = _presenter.FillColor
            };

            c.DrawPath(_presenter.FacePath, paintFill);
            c.DrawPath(_presenter.FacePath, paintStroke);
        }
        private void DrawEyes(SKCanvas c)
        {
            var paintFill = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = _presenter.EyesColor
            };

            c.DrawOval(_presenter.LeftEyeRect, paintFill);
            c.DrawOval(_presenter.RightEyeRect, paintFill);
        }

        private void DrawMouth(SKCanvas c)
        {
            var paintFill = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = _presenter.MouthColor
            };

            if(HappinessState == StateButton.Happy)
            {
                c.DrawPath(_presenter.GetHappyMouth(), paintFill);
            }
            else
            {
                c.DrawPath(_presenter.GetSadMouth(), paintFill);
            }
            
        }
    }
}