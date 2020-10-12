using System;
using UIKit;

namespace SmileIOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }
        EmotionalFaceView view;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            view = new EmotionalFaceView();
            View = view;


          /*  Console.WriteLine("Tosi Bosi");

            GreenButton.TouchUpInside += delegate
            {
                Console.WriteLine("GreenButton: Clicked!");
                YellowZone.BackgroundColor = UIColor.Green;
              
            };

            BlueButton.TouchUpInside += delegate
            {
                Console.WriteLine("BlueButton: Clicked!");
                YellowZone.BackgroundColor = UIColor.Blue;
            }; */
        }



        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}