﻿using Foundation;
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

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}