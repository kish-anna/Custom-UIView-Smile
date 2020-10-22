using Foundation;
using System;
using UIKit;

namespace Smile_IOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }
       
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            HappyFaceView.UserInteractionEnabled = true;
            UITapGestureRecognizer tapGesture = new UITapGestureRecognizer(Tap);
            tapGesture.NumberOfTapsRequired = 1;
            HappyFaceView.AddGestureRecognizer(tapGesture);
            

            SadFaceView.UserInteractionEnabled = true;
            UITapGestureRecognizer tapGesture1 = new UITapGestureRecognizer(Tap1);
            tapGesture1.NumberOfTapsRequired = 1;
            SadFaceView.AddGestureRecognizer(tapGesture1);
           

            /*  HappyFaceView.TouchUpInside += delegate
              {
                  BigSmile.HappinessState = Smile.StateButton.Happy;
                  Console.WriteLine("happy");

              };
              SadFaceView.TouchUpInside += delegate
              {
                  BigSmile.HappinessState = Smile.StateButton.Sad;
                  Console.WriteLine("sad");

              };*/
        }
        void Tap(UITapGestureRecognizer tap1)
        {

            BigSmile.HappinessState = Smile.StateButton.Happy;
        }
        void Tap1(UITapGestureRecognizer tap1)
        {
            BigSmile.HappinessState = Smile.StateButton.Sad;
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}