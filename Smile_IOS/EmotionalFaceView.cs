using System;
using UIKit;
using CoreGraphics;
using Smile;
using Foundation;
using System.ComponentModel;
using SkiaSharp.Views.iOS;
using CustomView;
using SkiaSharp;

namespace Smile_IOS
{
    [Register("EmotionalFaceView"), DesignTimeVisible(true)]
    public class EmotionalFaceView : SKCanvasView
    {
        float size = 0;

        [Export("BGColor"), Browsable(true)]
        public UIColor BGColor { get => bgcolor; set => bgcolor = value; }
        private UIColor bgcolor;

        [Export("EyesColor"), Browsable(true)]
        public UIColor EyesColor { get => eyesColor; set => eyesColor = value; }
        private UIColor eyesColor;

        [Export("MouthColor"), Browsable(true)]
        public UIColor MouthColor { get => mouthColor; set => mouthColor = value; }
        private UIColor mouthColor;

        [Export("BorderColor"), Browsable(true)]
        public UIColor BorderColor { get => borderColor; set => borderColor = value; }
        private UIColor borderColor;

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

        void Initialize()
        {
            size = Math.Min((float)this.Bounds.Height, (float)this.Bounds.Width);
            bgcolor = UIColor.Clear;
            eyesColor = UIColor.Clear;
            mouthColor = UIColor.Clear;
            borderColor = UIColor.Clear;
             _presenter = new FaceView(size, bgcolor.ToSKColor(), BorderColor.ToSKColor());
            

        }

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            base.OnPaintSurface(e);
            var g = e.Surface.Canvas;
             DrawFaceBackground(g);
             DrawEyes(g);
             DrawMouth(g);
        }
        private void DrawFaceBackground(SKCanvas c)
        {
            var paintStroke = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                //Color = _presenter.StrokeColor,
                Color = BorderColor.ToSKColor(),
                StrokeWidth = 2.0f
            };
            var paintFill = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                //Color = _presenter.FillColor
                Color = bgcolor.ToSKColor()
            };
            var path = new SKPath();
            //path.AddArc(Bounds.GetMidX(), Bounds.GetMidY(), radius, 0, 2.0f * (float)Math.PI, true);           
            path.AddCircle((float)Bounds.GetMidX()/2, (float)Bounds.GetMidY()/2, (float)_presenter.Radius, SKPathDirection.Clockwise);
            
            
           c.DrawPath(path, paintFill);
           c.DrawPath(path, paintStroke);
        }
        private void DrawEyes(SKCanvas c)
        {         
            var paintFill = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = EyesColor.ToSKColor()
            };
           
            var path = new SKPath();        
            SKRect leftEyeRect = new SKRect(size * 0.32f, size * 0.23f, size * 0.43f, size * 0.50f);
            path.AddOval(leftEyeRect);
            c.DrawOval(leftEyeRect, paintFill);
    
            var path1 = new SKPath();          
            SKRect rightEyeRect = new SKRect(size * 0.57f, size * 0.23f, size * 0.68f, size * 0.50f);
            path1.AddOval(rightEyeRect);
            c.DrawOval(rightEyeRect, paintFill);         
        }

        private void DrawMouth(SKCanvas c)
        {
            var paintFill = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = MouthColor.ToSKColor()
            };

            var path = new SKPath();
            path.MoveTo(size * 0.22f, size * 0.70f);

            if (HappinessState == StateButton.Happy)
            {
                path.QuadTo(size * 0.50f, size * 0.80f, size * 0.78f, size * 0.70f);
                path.QuadTo(size * 0.50f, size * 0.90f, size * 0.22f, size * 0.70f);              
            }
            else
            {
                path.QuadTo(size * 0.50f, size * 0.50f, size * 0.78f, size * 0.70f);
                path.QuadTo(size * 0.50f, size * 0.60f, size * 0.22f, size * 0.70f);       
            }
            c.DrawPath(path, paintFill);         
        }
    }
}