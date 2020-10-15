using System;
using UIKit;
using CoreGraphics;

namespace TestIOS
{
    public partial class EmotionalFaceView : UIView
    {
        float size = 0;
        private CGPath mouthPath = new CGPath();


        public EmotionalFaceView (IntPtr handle) : base (handle)
        {
            size = Math.Min((float)this.Bounds.Height, (float)this.Bounds.Width);
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
            nfloat radius = size / 2f;

            g.SetLineWidth(2.0f);
            UIColor.Yellow.SetFill();
            UIColor.Black.SetStroke();

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
            UIColor.Black.SetFill();
            var path = new CGPath();

            //CGRect leftEyeRect = new CGRect(size * 0.32f, size * 0.23f, size * 0.43f, size * 0.50f);
            CGRect leftEyeRect = new CGRect(130, 240, size * 0.1f, size * 0.25f);
            Console.WriteLine($"{size}");

            g.AddPath(path);
            g.AddEllipseInRect(leftEyeRect);
            g.DrawPath(CGPathDrawingMode.FillStroke);

            var path1 = new CGPath();
            //CGRect rightEyeRect = new CGRect(size * 0.57f, size * 0.23f, size * 0.68f, size * 0.50f);
            CGRect rightEyeRect = new CGRect(235, 240, size * 0.1f, size * 0.25f);
            g.AddPath(path1);
            g.AddEllipseInRect(rightEyeRect);
            g.DrawPath(CGPathDrawingMode.FillStroke);
        }

        private void drawMouth(CGContext g)
        {
            //mouthPath.Reset();
            //mouthPath.MoveToPoint(size * 0.22f, size * 0.7f);

            //mouthPath.MoveToPoint(size * 0.22f, size * 1f);

            //if (HappinessState == StateButton.Happy)
            //{
            //    //mouthPath.AddQuadCurveToPoint(size * 0.50f, size * 0.80f, size * 0.78f, size * 0.70f);
            //    //mouthPath.AddQuadCurveToPoint(size * 0.50f, size * 0.90f, size * 0.22f, size * 0.70f);
            //    mouthPath.AddQuadCurveToPoint(size * 0.50f, size * 1.1f, size * 0.78f, size * 1f);
            //    mouthPath.AddQuadCurveToPoint(size * 0.50f, size * 1.2f, size * 0.22f, size * 1f);

            //}
            //else
            //{
            //    mouthPath.AddQuadCurveToPoint(size * 0.50f, size * 0.50f, size * 0.78f, size * 0.70f);
            //    mouthPath.AddQuadCurveToPoint(size * 0.50f, size * 0.60f, size * 0.22f, size * 0.70f);
            //}
            //g.SetLineWidth(2.0f);
            //UIColor.Black.SetFill();
            ////var path = new CGPath();
            //g.AddPath(path);
            //g.AddPath(mouthPath);
            //g.DrawPath(CGPathDrawingMode.FillStroke);

        }
    }
}