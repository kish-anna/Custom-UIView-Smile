using System;
using System.Drawing;
using CoreGraphics;
using UIKit;


namespace SmileIOS
{

    public class EmotionalFaceView : UIView
    {

        CGPath path;
        float size = Math.Min((float)UIScreen.MainScreen.Bounds.Height, (float)UIScreen.MainScreen.Bounds.Width);

        


        public UIView drawHeaderView()
        {
            UIView headerView = new UIImageView(new RectangleF(0, 0, (int)UIScreen.MainScreen.Bounds.Width, 100));
            
            headerView.BackgroundColor = UIColor.DarkGray;

            var label = new UILabel(frame: new CGRect(0, 0, 200, 21));
            label.Center = new CGPoint(50, 65);
            label.TextAlignment = UITextAlignment.Center;
            label.TextColor = UIColor.White;
            label.Text = "Smile";
            label.Font = label.Font.WithSize(25);
            headerView.AddSubview(label);

            return headerView;

        }
        public UILabel drawHelloLabel()
        {
            
            var label = new UILabel(frame: new CGRect(0, 0, (int)UIScreen.MainScreen.Bounds.Width, 30));
            label.Center = new CGPoint(UIScreen.MainScreen.Bounds.Width /2f, 150);
            label.TextAlignment = UITextAlignment.Center;
            label.TextColor = UIColor.DarkGray;
            label.Text = "Hello Custom Views";
            label.Font = label.Font.WithSize(15);
             

            return label;

        }





        public EmotionalFaceView()
        {
            path = new CGPath();
            BackgroundColor = UIColor.Gray;
        }
        public override void Draw(CGRect rect)

        {
            base.Draw(rect);
            this.AddSubview(drawHeaderView());
            this.AddSubview(drawHelloLabel());

           using (CGContext g = UIGraphics.GetCurrentContext())
            {
                drawFaceBackground(g);
                drawEyes(g);
                drawHappyFace(g);
                drawSadFace(g);


                // drawMouth(g);

            }

        }

        private void drawFaceBackground(CGContext g)
        {

            nfloat radius = size / 2f;

            g.SetLineWidth(4.0f);
            UIColor.Yellow.SetFill();
            UIColor.Black.SetStroke();

            // create geometry
            var path = new CGPath();
            path.AddArc(Bounds.GetMidX(), Bounds.GetMidY() - 90, size / 2f - 20f, 0, 2.0f * (float)Math.PI, true);

            // add geometry to graphics context and draw 
            g.AddPath(path);
            g.DrawPath(CGPathDrawingMode.FillStroke);

        }

        private void drawHappyFace(CGContext g)
        {

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

        }

        private void drawSadFace(CGContext g)
        {

            nfloat radius = size / 16f;

            g.SetLineWidth(4.0f);
            UIColor.LightGray.SetFill();
            UIColor.Black.SetStroke();

            // create geometry
            var path = new CGPath();
            path.AddArc(360, 150, radius, 0, 2.0f * (float)Math.PI, true);
            Console.WriteLine($"{Bounds.GetMidX()}, {Bounds.GetMidY()}");

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


    }

    
}
