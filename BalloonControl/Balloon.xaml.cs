using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BalloonControl
{
    [DesignTimeVisible(true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Balloon : ContentView
    {
        #region Properties
        public string Text { get; set; }
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
                propertyName: nameof(Text),
                returnType: typeof(string),
                declaringType: typeof(Balloon),
                defaultValue: "",
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: TitlePropertyChanged
            );
        private static void TitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Balloon)bindable;
            control.label.Text = newValue.ToString();
        }

        public MouthDirection MouthDirection { get; set; }
        public static readonly BindableProperty MouthDirectionProperty = BindableProperty.Create(
                propertyName: nameof(MouthDirection),
                returnType: typeof(MouthDirection),
                declaringType: typeof(Balloon),
                defaultValue: MouthDirection.Right,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: MouthDirectionPropertyChanged
            );
        private static void MouthDirectionPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Balloon)bindable;
            control.balloonMouth.MouthDirection = (MouthDirection)newValue;
            control.balloonMouth.InvalidateSurface();//再描画
        }

        public Color ForegroundColor { get; set; }
        public static readonly BindableProperty ForegroundColorProperty = BindableProperty.Create(
                propertyName: nameof(ForegroundColor),
                returnType: typeof(Color),
                declaringType: typeof(Balloon),
                defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: ForegroundColorPropertyChanged
            );
        private static void ForegroundColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Balloon)bindable;
            var color = (Color)newValue;
            control.boxView.BackgroundColor = color;
            control.balloonMouth.ForegroundColor = color;
            control.balloonMouth.InvalidateSurface();//再描画
        }

        public Color TextColor { get; set; }
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
                propertyName: nameof(TextColor),
                returnType: typeof(Color),
                declaringType: typeof(Balloon),
                defaultValue: Color.Default,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: TextColorPropertyChanged
            );
        private static void TextColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Balloon)bindable;
            var color = (Color)newValue;
            control.label.TextColor = color;
        }

        //public double FontSize { get; set; }
        //public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
        //        propertyName: nameof(FontSize),
        //        returnType: typeof(double),
        //        declaringType: typeof(Balloon),
        //        defaultBindingMode: BindingMode.TwoWay,
        //        propertyChanged: FontSizePropertyChanged
        //    );
        //private static void FontSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        //{
        //    var control = (Balloon)bindable;
        //    var fontSize = (double)newValue;
        //    control.label.FontSize = fontSize;
        //}


        #endregion

        public Balloon()
        {
            InitializeComponent();
        }
    }
}