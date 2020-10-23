using System;
using Android.Content;
using Android.Graphics;
using Android.Util;
using SkiaSharp.Views.Android;

namespace Smile
{
    public class EmotionalFaceView : SKCanvasView
    {
        Color faceColor;
        Color eyesColor;
        Color mouthColor;
        Color borderColor;

        private StateButton _happinessState;

        private FaceView _presenter;

        public StateButton HappinessState
        {
            get => _happinessState;
            set
            {
                _happinessState = value;
                Invalidate();  
            }
        }

        public EmotionalFaceView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            setupAttributes(attrs);
            SetBackgroundColor(Color.Transparent);
        }

        private void setupAttributes(IAttributeSet attrs)
        {
            int[] attrsArray = Resource.Styleable.EmotionalFaceView;

            var typedArray = Context.Theme.ObtainStyledAttributes(attrs, attrsArray, 0, 0);

            _happinessState = (StateButton)typedArray.GetInt(Resource.Styleable.EmotionalFaceView_state, (int)StateButton.Happy);
            faceColor = typedArray.GetColor(Resource.Styleable.EmotionalFaceView_faceColor, Color.Transparent);
            eyesColor = typedArray.GetColor(Resource.Styleable.EmotionalFaceView_eyesColor, Color.Transparent);
            mouthColor = typedArray.GetColor(Resource.Styleable.EmotionalFaceView_mouthColor, Color.Transparent);
            borderColor = typedArray.GetColor(Resource.Styleable.EmotionalFaceView_borderColor, Color.Transparent);

            typedArray.Recycle();
        }

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            base.OnPaintSurface(e);

            var canvas = e.Surface.Canvas;
            _presenter = new FaceView(Math.Min(e.Info.Width, e.Info.Height), faceColor.ToSKColor(),
                borderColor.ToSKColor(), eyesColor.ToSKColor(), mouthColor.ToSKColor());

            _presenter.Draw(canvas, HappinessState);
        }
    
    }
}