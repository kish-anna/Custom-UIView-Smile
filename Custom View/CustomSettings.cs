using System;
using System.Drawing;


namespace CustomView
{
    public static class CustomSettings
    {
        static Color FaceColor = Color.FromArgb(255, 255, 0);
        public static int DefaultFaceColor = FaceColor.ToArgb();

        static Color EyesColor = Color.Black;
        public static int DefaultEyesColor = EyesColor.ToArgb();

        static Color MouthColor = Color.Black;
        public static int DefaultMouthColor = MouthColor.ToArgb();

        static Color BorderColor = Color.Black;
        public static int DefaultBorderColor = BorderColor.ToArgb();

        public static float DefaultBorderWidth = 4.0f;
    }
}
