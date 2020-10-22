using System;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using CustomView;
using SkiaSharp;
using SkiaSharp.Views.Android;

namespace Smile
{
    public class EmotionalFaceView : SKCanvasView
    {
        Color faceColor = new Color(CustomSettings.DefaultFaceColor);
        Color eyesColor = new Color(CustomSettings.DefaultEyesColor);
        Color mouthColor = new Color(CustomSettings.DefaultMouthColor);
        Color borderColor = new Color(CustomSettings.DefaultBorderColor);
        float borderWidth = CustomSettings.DefaultBorderWidth;

        float size = 0;

        public static IAttributeSet Attrs;

        private StateButton _happinessState;

        public StateButton HappinessState
        {
            get => _happinessState;
            set
            {
                _happinessState = value;
                Invalidate();
            }
        }       

        public EmotionalFaceView(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            Initialize(attrs);

        }       

        private void setupAttributes(IAttributeSet attrs)
        {
            int[] attrsArray = Resource.Styleable.EmotionalFaceView;

            var typedArray = Context.Theme.ObtainStyledAttributes(attrs, attrsArray, 0, 0);

            HappinessState = (StateButton)typedArray.GetInt(Resource.Styleable.EmotionalFaceView_state, (int)StateButton.Happy);
            faceColor = typedArray.GetColor(Resource.Styleable.EmotionalFaceView_faceColor, CustomSettings.DefaultFaceColor);
            eyesColor = typedArray.GetColor(Resource.Styleable.EmotionalFaceView_eyesColor, CustomSettings.DefaultEyesColor);
            mouthColor = typedArray.GetColor(Resource.Styleable.EmotionalFaceView_mouthColor, CustomSettings.DefaultMouthColor);
            borderColor = typedArray.GetColor(Resource.Styleable.EmotionalFaceView_borderColor, CustomSettings.DefaultBorderColor);
            borderWidth = typedArray.GetDimension(Resource.Styleable.EmotionalFaceView_borderWidth, CustomSettings.DefaultBorderWidth);

            typedArray.Recycle();
        }

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            base.OnPaintSurface(e);

            var canvas = e.Surface.Canvas;
            size = Math.Min(e.Info.Width, e.Info.Height);

            drawFaceBackground(canvas);
            drawEyes(canvas);
            drawMouth(canvas);
        }

        private void drawFaceBackground(SKCanvas c)
        {
            var paintStroke = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = borderColor.ToSKColor(),
                StrokeWidth = 2.0f
            };
            var paintFill = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = faceColor.ToSKColor(),
            };

            var radius = size / 2;

            var path = new SKPath();
            path.AddCircle(radius, radius, radius, SKPathDirection.Clockwise);
            c.DrawPath(path, paintFill);
            c.DrawPath(path, paintStroke);
        }

        private void drawEyes(SKCanvas c)
        {

            var paintFill = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = eyesColor.ToSKColor()
            };

            var path = new SKPath();
            SKRect leftEyeRect = new SKRect(size * 0.32f, size * 0.23f, size * 0.43f, size * 0.50f);
            path.AddOval(leftEyeRect);
            c.DrawOval(leftEyeRect, paintFill);

            var path1 = new SKPath();
            SKRect rightEyeRect = new SKRect(size * 0.57f, size * 0.23f, size * 0.68f, size * 0.50f);
            path1.AddOval(rightEyeRect);
            c.DrawOval(rightEyeRect, paintFill);
        }

        private void drawMouth(SKCanvas c)
        {

            var paintFill = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = mouthColor.ToSKColor()
            };

            var path = new SKPath();
            path.MoveTo(size * 0.22f, size * 0.70f);

            if (HappinessState == StateButton.Happy)
            {
                path.QuadTo(size * 0.50f, size * 0.80f, size * 0.78f, size * 0.70f);
                path.QuadTo(size * 0.50f, size * 0.90f, size * 0.22f, size * 0.70f);
            }
            else
            {
                path.QuadTo(size * 0.50f, size * 0.50f, size * 0.78f, size * 0.70f);
                path.QuadTo(size * 0.50f, size * 0.60f, size * 0.22f, size * 0.70f);
            }
            c.DrawPath(path, paintFill);
        }

        //protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        //{
        //    base.OnMeasure(widthMeasureSpec, heightMeasureSpec);

        //    size = Math.Min(MeasuredWidth, MeasuredHeight);
        //    SetMeasuredDimension((int)size, (int)size);
        //}        

        private void Initialize(IAttributeSet attrs)
        {
            Attrs = attrs;
            setupAttributes(attrs);            
        }
    }
    

}