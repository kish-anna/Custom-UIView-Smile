using System;
using CoreGraphics;
using UIKit;

namespace TestIOS
{
    public partial class SadFaceView : UIControl
    {
        float size = 0;
        private CGPath mouthPath = new CGPath();
        public SadFaceView (IntPtr handle) : base (handle)
        {
            size = Math.Min((float)this.Bounds.Height, (float)this.Bounds.Width);
        }
        public override void Draw(CGRect rect)

        {

            base.Draw(rect);

            using (CGContext g = UIGraphics.GetCurrentContext())
            {

                drawFaceBackground(g);
                drawMouth(g);
            }
        }

        private void drawFaceBackground(CGContext g)
        {
            nfloat radius = (float)Math.Truncate(size / 2f) - 1;

            g.SetLineWidth(2.0f);
            UIColor.LightGray.SetFill();
            UIColor.Black.SetStroke();

            // create geometry
            var path = new CGPath();
            //canvas.DrawCircle(size / 2f, size / 2f, radius, paint);
            path.AddArc(Bounds.GetMidX(), Bounds.GetMidY(), radius, 0, 2.0f * (float)Math.PI, true);

            // add geometry to graphics context and draw 
            g.AddPath(path);
            g.DrawPath(CGPathDrawingMode.FillStroke);
        }

        private void drawMouth(CGContext g)
        {
            var path = new CGPath();

            path.MoveToPoint(size * 0.22f, size * 0.70f);

            path.AddQuadCurveToPoint(size * 0.50f, size * 0.50f, size * 0.78f, size * 0.70f);
            path.AddQuadCurveToPoint(size * 0.50f, size * 0.60f, size * 0.22f, size * 0.70f);

            UIColor.Black.SetFill();
            g.AddPath(path);
            g.DrawPath(CGPathDrawingMode.Fill);

        }
    }
}