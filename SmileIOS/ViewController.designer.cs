// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace SmileIOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIControl BlueButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIControl GreenButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView YellowZone { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BlueButton != null) {
                BlueButton.Dispose ();
                BlueButton = null;
            }

            if (GreenButton != null) {
                GreenButton.Dispose ();
                GreenButton = null;
            }

            if (YellowZone != null) {
                YellowZone.Dispose ();
                YellowZone = null;
            }
        }
    }
}