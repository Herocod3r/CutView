using System;
using NControl.Abstractions;
using NGraphics;
using Xamarin.Forms;

namespace Plugin
{
    public class CutView : ContentView
    {
        public CutView()
        {
            GetView();
        }



        private void GetView()
        {
            if (!IsReverse)
            {
                Content = new NControlView()
                {
                    BackgroundColor = FillBgColor,
                    DrawingFunction = (canvas, rect) =>
                    {
                        canvas.FillPath(new PathOp[] {
            new MoveTo (NGraphics.Point.Zero),
                            new LineTo (rect.Width, 0),
                            new LineTo ( rect.Width - GetInset(rect.Width), rect.Height),
            new LineTo (0, rect.Height),
            new ClosePath ()
                        }, new NGraphics.Color(FillColor.R, FillColor.G, FillColor.B));
                    }
                };
            }
            else
            {
                Content = new NControlView()
                {
                    BackgroundColor = FillBgColor,
                    DrawingFunction = (canvas, rect) =>
                    {
                        canvas.FillPath(new PathOp[] {
                            new MoveTo (new NGraphics.Point(GetInset(rect.Width),0)),
                            new LineTo (rect.Width, 0),
                            new LineTo ( rect.Width, rect.Height),
            new LineTo (0, rect.Height),
            new ClosePath ()
                        }, new NGraphics.Color(FillColor.R, FillColor.G, FillColor.B));
                    }
                };
            }


        }



        private double GetInset(double width)
        {
            return (Inset / 100) * width;
        }




        public static readonly BindableProperty FillColorProperty = BindableProperty.Create(
            "FillColor", typeof(Xamarin.Forms.Color), typeof(CutView), Xamarin.Forms.Color.Blue, propertyChanged: OnFillColorChanged);

        static void OnFillColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var obj = ((CutView)bindable);
            obj.GetView();
        }

        public Xamarin.Forms.Color FillColor
        {
            get { return (Xamarin.Forms.Color)GetValue(FillColorProperty); }
            set { SetValue(FillColorProperty, value); }
        }



        public static readonly BindableProperty FillBgColorProperty = BindableProperty.Create(
            "FillBgColor", typeof(Xamarin.Forms.Color), typeof(CutView), Xamarin.Forms.Color.Transparent, propertyChanged: OnFillBgColorChanged);

        static void OnFillBgColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var obj = ((CutView)bindable);
            obj.GetView();
        }

        public Xamarin.Forms.Color FillBgColor
        {
            get { return (Xamarin.Forms.Color)GetValue(FillBgColorProperty); }
            set { SetValue(FillBgColorProperty, value); }
        }




        public static readonly BindableProperty IsReverseProperty = BindableProperty.Create(
            "IsReverse", typeof(bool), typeof(CutView), false, propertyChanged: OnIsReverseChanged);

        static void OnIsReverseChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var obj = ((CutView)bindable);
            obj.GetView();
        }

        public bool IsReverse
        {
            get { return (bool)GetValue(IsReverseProperty); }
            set { SetValue(IsReverseProperty, value); }
        }




        public static readonly BindableProperty InsetProperty = BindableProperty.Create(
            "IsReverse", typeof(double), typeof(CutView), 1.5d, propertyChanged: InsetChanged);

        static void InsetChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var obj = ((CutView)bindable);
            obj.GetView();
        }

        public double Inset
        {
            get { return (double)GetValue(InsetProperty); }
            set { SetValue(InsetProperty, value); }
        }




    }
}
