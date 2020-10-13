using Foundation;
using UIKit;

namespace SmileIOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {

        
        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // create a new window instance based on the screen size
            Window = new UIWindow(UIScreen.MainScreen.Bounds);


            var controller = new UIViewController();
            


            controller.View = new EmotionalFaceView();


            controller.View.BackgroundColor = UIColor.LightGray;
            controller.Title = "Smile";
            

            //var navController = new UINavigationController(controller);

            Window.RootViewController = controller;

            // make the window visible
            Window.MakeKeyAndVisible();


            //var vc = new UIViewController();
            //vc.View = new UIView();
            //vc.View.Frame = new CGRect(0, 0, UIScreen.MainScreen.Bounds.Size.Width, UIScreen.MainScreen.Bounds.Size.Height + 20.0);
            //vc.View.BackgroundColor = UIColor.Cyan;

            //var header = new UIView();
            //header.Frame = new CGRect(0, 0, UIScreen.MainScreen.Bounds.Size.Width, 100);
            //header.BackgroundColor = UIColor.Green;

            //vc.View.AddSubview(header);





            return true;
        }
    }
}

