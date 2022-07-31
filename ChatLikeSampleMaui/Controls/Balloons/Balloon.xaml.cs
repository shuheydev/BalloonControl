namespace ChatLikeSampleMaui.Controls;

public partial class Balloon : ContentView
{
    /// <summary>
    /// 吹き出しの口の向き
    /// </summary>
    public MouthDirection MouthDirection
    {
        get => (MouthDirection)GetValue(MouthDirectionProperty);
        set => SetValue(MouthDirectionProperty, value);
    }
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

        var direction = (MouthDirection)newValue;
        if(direction== MouthDirection.Left)
        {
            control.balloonMouth.RotationY = 0;
        }
        else if(direction== MouthDirection.Right)
        {
            control.balloonMouth.RotationY = 180;
        }
    }


    #region Textプロパティ
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    } //プロパティ

    //プロパティをバインド可能にする記述
    public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: nameof(Text), //バインド可能にしたいプロパティ名を指定
            returnType: typeof(string), //プロパティの型を指定
            declaringType: typeof(Balloon), //プロパティが所属するクラスを指定
            defaultValue: "",
            defaultBindingMode: BindingMode.TwoWay, //デフォルトのバインディングの種類
            propertyChanged: TextPropertyChanged //プロパティの値が変更されたときに実行されるメソッドを指定
        );

    //プロパティの値が変更されたときに実行される
    private static void TextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (newValue is null)
        {
            return;
        }

        var control = (Balloon)bindable;
    }
    #endregion


    #region BalloonColorプロパティ
    public Color BalloonColor
    {
        get => (Color)GetValue(BalloonColorProperty);
        set => SetValue(BalloonColorProperty, value);
    } //プロパティ

    //プロパティをバインド可能にする記述
    public static readonly BindableProperty BalloonColorProperty = BindableProperty.Create(
            propertyName: nameof(BalloonColor), //バインド可能にしたいプロパティ名を指定
            returnType: typeof(Color), //プロパティの型を指定
            declaringType: typeof(Balloon), //プロパティが所属するクラスを指定
            defaultValue: Colors.Green,
            defaultBindingMode: BindingMode.TwoWay, //デフォルトのバインディングの種類
            propertyChanged: BalloonColorPropertyChanged //プロパティの値が変更されたときに実行されるメソッドを指定
        );

    //プロパティの値が変更されたときに実行される
    private static void BalloonColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (Balloon)bindable;
        var color = (Color)newValue;
        control.balloonMouth.BalloonMouthColor = color;
    }
    #endregion

    public Balloon()
    {
        InitializeComponent();
    }
}