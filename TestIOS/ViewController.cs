using System;
using UIKit;

namespace TestIOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            HappyFace.TouchUpInside += delegate
            {
                Console.WriteLine("happy");
                
            };
            SadFace.TouchUpInside += delegate
            {
                Console.WriteLine("happy");

            };

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}