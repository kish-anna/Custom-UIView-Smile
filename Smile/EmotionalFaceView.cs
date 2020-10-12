using System;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using CustomView;

namespace Smile
{
    public class EmotionalFaceView : View
    {
        Color faceColor = new Color(CustomSettings.DefaultFaceColor);
        Color eyesColor = new Color(CustomSettings.DefaultEyesColor);
        Color mouthColor = new Color(CustomSettings.DefaultMouthColor);
        Color borderColor = new Color(CustomSettings.DefaultBorderColor);
        float borderWidth = CustomSettings.DefaultBorderWidth;

        private Path mouthPath = new Path();
        Paint paint = new Paint(PaintFlags.AntiAlias);
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

        protected override void OnDraw(Canvas canvas)
        {            
            base.OnDraw(canvas);            
            drawFaceBackground(canvas);
            drawEyes(canvas);            
            drawMouth(canvas);
        }

        private void drawEyes(Canvas canvas)
        {
            paint.Color = eyesColor;
            paint.SetStyle(Paint.Style.Fill);

            RectF leftEyeRect = new RectF(size * 0.32f, size * 0.23f, size * 0.43f, size * 0.50f);
            canvas.DrawOval(leftEyeRect, paint);

            RectF rightEyeRect = new RectF(size * 0.57f, size * 0.23f, size * 0.68f, size * 0.50f);
            canvas.DrawOval(rightEyeRect, paint);
        }

        private void drawFaceBackground(Canvas canvas)
        {
            paint.Color = faceColor;
            paint.SetStyle(Paint.Style.Fill);

            float radius = size / 2f;
            canvas.DrawCircle(size / 2f, size / 2f, radius, paint);

            paint.Color = borderColor;
            paint.SetStyle(Paint.Style.Stroke);
            paint.StrokeWidth = borderWidth;

            canvas.DrawCircle(size / 2f, size / 2f, radius - borderWidth, paint);
        }


        private void drawMouth(Canvas canvas)
        {
            mouthPath.Reset();

            mouthPath.MoveTo(size * 0.22f, size * 0.7f);

            if (HappinessState == StateButton.Happy)
            {
                mouthPath.QuadTo(size * 0.50f, size * 0.80f, size * 0.78f, size * 0.70f);
                mouthPath.QuadTo(size * 0.50f, size * 0.90f, size * 0.22f, size * 0.70f);
            }
            else
            {
                mouthPath.QuadTo(size * 0.50f, size * 0.50f, size * 0.78f, size * 0.70f);
                mouthPath.QuadTo(size * 0.50f, size * 0.60f, size * 0.22f, size * 0.70f);
            }

            paint.Color = mouthColor;
            paint.SetStyle(Paint.Style.Fill);
            canvas.DrawPath(mouthPath, paint);
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
            size = Math.Min(MeasuredWidth, MeasuredHeight);
            SetMeasuredDimension((int)size, (int)size);
        }        

        private void Initialize(IAttributeSet attrs)
        {
            Attrs = attrs;
            setupAttributes(attrs);            
        }
    }
    

}