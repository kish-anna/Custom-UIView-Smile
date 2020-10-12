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
            controller.Title = "Hello Custom Views";

            var navController = new UINavigationController(controller);

            Window.RootViewController = navController;

            // make the window visible
            Window.MakeKeyAndVisible();
            

            
            return true;
        }
    }
}

