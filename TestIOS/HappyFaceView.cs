using CoreGraphics;
using Foundation;
using System;
using System.Drawing;
using UIKit;

namespace TestIOS
{
    public partial class HappyFaceView : UIControl
    {
        CGPath path;
        float size = Math.Min((float)UIScreen.MainScreen.Bounds.Height, (float)UIScreen.MainScreen.Bounds.Width);
        private CGPath mouthPath = new CGPath();
        public HappyFaceView (IntPtr handle) : base (handle)
        {
        }
        public override void Draw(CGRect rect)

        {

            base.Draw(rect);

            using (CGContext g = UIGraphics.GetCurrentContext())
            {
                
                drawHappyFace(g);
                
            }
        }
        private UIView drawHappyFace(CGContext g)
        {

            UIView happyFace = new UIImageView(new RectangleF(50, 150, size / 16f, size / 16f));
            happyFace.BackgroundColor = UIColor.Red;
            nfloat radius = size / 16f;

            g.SetLineWidth(4.0f);
            UIColor.Red.SetFill();
            UIColor.White.SetStroke();

            // create geometry
            var path = new CGPath();
            path.AddArc(50, 150, radius, 0, 2.0f * (float)Math.PI, true);
            Console.WriteLine($"{Bounds.GetMidX()}, {Bounds.GetMidY()}");

            // add geometry to graphics context and draw 
            g.AddPath(path);
            g.DrawPath(CGPathDrawingMode.FillStroke);



            return happyFace;
        }
    }

}