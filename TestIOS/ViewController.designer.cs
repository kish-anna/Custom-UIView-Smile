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

namespace TestIOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        TestIOS.EmotionalFaceView BigSmile { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        TestIOS.HappyFaceView HappyFace { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        TestIOS.SadFaceView SadFace { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BigSmile != null) {
                BigSmile.Dispose ();
                BigSmile = null;
            }

            if (HappyFace != null) {
                HappyFace.Dispose ();
                HappyFace = null;
            }

            if (SadFace != null) {
                SadFace.Dispose ();
                SadFace = null;
            }
        }
    }
}