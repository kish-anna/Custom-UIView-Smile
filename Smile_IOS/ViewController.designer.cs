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

namespace Smile_IOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        Smile_IOS.EmotionalFaceView BigSmile { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        Smile_IOS.EmotionalFaceView HappyFaceView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        Smile_IOS.EmotionalFaceView SadFaceView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BigSmile != null) {
                BigSmile.Dispose ();
                BigSmile = null;
            }

            if (HappyFaceView != null) {
                HappyFaceView.Dispose ();
                HappyFaceView = null;
            }

            if (SadFaceView != null) {
                SadFaceView.Dispose ();
                SadFaceView = null;
            }
        }
    }
}