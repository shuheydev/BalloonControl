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
                propertyChanged: TextPropertyChanged
            );
        private static void TextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
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

        public Color BalloonColor { get; set; }
        public static readonly BindableProperty BalloonColorProperty = BindableProperty.Create(
                propertyName: nameof(BalloonColor),
                returnType: typeof(Color),
                declaringType: typeof(Balloon),
                defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: BalloonColorPropertyChanged
            );
        private static void BalloonColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Balloon)bindable;
            var color = (Color)newValue;
            control.balloonBody.BackgroundColor = color;
            control.balloonMouth.MouthColor = color;
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

        public int CornerRadius { get; set; }
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(
                propertyName: nameof(CornerRadius),
                returnType: typeof(int),
                declaringType: typeof(Balloon),
                defaultValue: 0,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: CornerRadiusPropertyChanged
            );
        private static void CornerRadiusPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Balloon)bindable;
            var cornerRadius = (int)newValue;

            //Range:0~20
            if (cornerRadius < 0)
            {
                cornerRadius = 0;
            }
            if (cornerRadius > 20)
            {
                cornerRadius = 20;
            }

            control.balloonBody.CornerRadius = cornerRadius;
        }

        public new Thickness Padding { get; set; }
        public new static readonly BindableProperty PaddingProperty = BindableProperty.Create(
            propertyName: nameof(Padding),
            returnType: typeof(Thickness),
            declaringType: typeof(Balloon),
            defaultValue: new Thickness(10),
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: PaddingPropertyChanged
            );
        private static void PaddingPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Balloon)bindable;
            var padding = (Thickness)newValue;

            control.balloonBody.Padding = padding;
        }

        public double FontSize { get; set; }
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
                propertyName: nameof(FontSize),
                returnType: typeof(double),
                declaringType: typeof(Balloon),
                defaultValue:(double)10,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: FontSizePropertyChanged
            );
        private static void FontSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Balloon)bindable;
            var fontSize = (double)newValue;    
            control.label.FontSize = fontSize;
        }

        #endregion

        public Balloon()
        {
            InitializeComponent();
        }
    }
}