using System;
using CoreGraphics;
using UIKit;


namespace SmileIOS
{
    public class EmotionalFaceView : UIView
    {
       
        CGPath path;
        float size = 0;
        public EmotionalFaceView()
        {
            path = new CGPath();
            BackgroundColor = UIColor.Gray;
        }
        public override void Draw(CGRect rect)

        {
            base.Draw(rect);

            //get graphics context
            using (var g = UIGraphics.GetCurrentContext())

            {
                nfloat radius = size / 2f;
                //faceColor.SetColor();
                //SetStyle(Paint.Style.Fill);
                //path.AddArc(rect.X, rect.Y, radius, 0, 0.0f * 2 * (float)Math.PI, true);
                //g.AddPath(path);
                //g.DrawPath(CGPathDrawingMode.Stroke);

                // borderColor.SetStroke();
                //paint.SetStyle(Paint.Style.Stroke);
                //paint.StrokeWidth = borderWidth;

                // canvas.DrawCircle(size / 2f, size / 2f, radius - borderWidth, paint);

                // set up drawing attributes
                g.SetLineWidth(4.0f);
                UIColor.Yellow.SetFill();
                UIColor.Black.SetStroke();

                // create geometry
                var path = new CGPath();
                path.AddArc(Bounds.GetMidX(), Bounds.GetMidY(), 200f, 0, 2.0f * (float)Math.PI, true);

                // add geometry to graphics context and draw 
                g.AddPath(path);
                g.DrawPath(CGPathDrawingMode.FillStroke);
            }


        }
        
    }
}
