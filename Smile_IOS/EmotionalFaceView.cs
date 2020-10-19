using System;
using UIKit;
using CoreGraphics;
using Smile;
using Foundation;
using System.ComponentModel;

namespace Smile_IOS
{
    [Register("EmotionalFaceView"), DesignTimeVisible(true)]
    public class EmotionalFaceView : UIControl
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
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            using (CGContext g = UIGraphics.GetCurrentContext())
            {
                drawFaceBackground(g);
                drawEyes(g);
                drawMouth(g);
            }
        }

        private void drawFaceBackground(CGContext g)
        {
            nfloat radius = (float)Math.Truncate(size / 2f) - 1;

            g.SetLineWidth(2.0f);
            bgcolor.SetFill();
            borderColor.SetStroke();

            // create geometry
            var path = new CGPath();
            //canvas.DrawCircle(size / 2f, size / 2f, radius, paint);
            path.AddArc(Bounds.GetMidX(), Bounds.GetMidY(), radius, 0, 2.0f * (float)Math.PI, true);

            // add geometry to graphics context and draw 
            g.AddPath(path);
            g.DrawPath(CGPathDrawingMode.FillStroke);
        }

        private void drawEyes(CGContext g)
        {
            g.SetLineWidth(4.0f);
            eyesColor.SetFill();
            var path = new CGPath();

            CGRect leftEyeRect = new CGRect(size * 0.32f, size * 0.23f, size * 0.1f, size * 0.25f);

            g.AddPath(path);
            g.AddEllipseInRect(leftEyeRect);
            g.DrawPath(CGPathDrawingMode.FillStroke);

            var path1 = new CGPath();

            CGRect rightEyeRect = new CGRect(size * 0.57f, size * 0.23f, size * 0.1f, size * 0.25f);
            g.AddPath(path1);
            g.AddEllipseInRect(rightEyeRect);
            g.DrawPath(CGPathDrawingMode.FillStroke);
        }

        private void drawMouth(CGContext g)
        {
            var path = new CGPath();
            path.MoveToPoint(size * 0.22f, size * 0.70f);
            if (HappinessState == StateButton.Happy)
            {
                path.AddQuadCurveToPoint(size * 0.50f, size * 0.80f, size * 0.78f, size * 0.70f);
                path.AddQuadCurveToPoint(size * 0.50f, size * 0.90f, size * 0.22f, size * 0.70f);
            }
            else
            {
                path.AddQuadCurveToPoint(size * 0.50f, size * 0.50f, size * 0.78f, size * 0.70f);
                path.AddQuadCurveToPoint(size * 0.50f, size * 0.60f, size * 0.22f, size * 0.70f);
            }

            mouthColor.SetFill();

            g.AddPath(path);
            g.DrawPath(CGPathDrawingMode.Fill);
        }
    }
}