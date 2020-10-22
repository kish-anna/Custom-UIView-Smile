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

            //HappyFaceView.UserInteractionEnabled = true;
            //UITapGestureRecognizer tapGesture = new UITapGestureRecognizer(Tap);
            //tapGesture.NumberOfTapsRequired = 1;
            //HappyFaceView.AddGestureRecognizer(tapGesture);
            //SadFaceView.UserInteractionEnabled = true;
            //UITapGestureRecognizer tapGesture1 = new UITapGestureRecognizer(Tap1);
            //tapGesture1.NumberOfTapsRequired = 1;
            //SadFaceView.AddGestureRecognizer(tapGesture1);

            HappyFaceView.UserInteractionEnabled = true;
            HappyFaceView.AddGestureRecognizer(GetNewGesture(HappyTapHandle));

            SadFaceView.UserInteractionEnabled = true;
            SadFaceView.AddGestureRecognizer(GetNewGesture(SadTapHandle));
        }

        void HappyTapHandle(UITapGestureRecognizer tap)
        {
            BigSmile.HappinessState = Smile.StateButton.Happy;
        }
        void SadTapHandle(UITapGestureRecognizer tap)
        {
            BigSmile.HappinessState = Smile.StateButton.Sad;
        }
        UITapGestureRecognizer GetNewGesture(Action<UITapGestureRecognizer> action)
        {
            UITapGestureRecognizer g = new UITapGestureRecognizer(action);
            g.NumberOfTapsRequired = 1;

            return g;
        }

        //void Tap(UITapGestureRecognizer tap1)
        //{
        //    BigSmile.HappinessState = Smile.StateButton.Happy;
        //}
        //void Tap1(UITapGestureRecognizer tap1)
        //{
        //    BigSmile.HappinessState = Smile.StateButton.Sad;
        //}

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}