namespace ChatLikeSampleMaui.Controls;

public partial class Balloon : ContentView
{
    #region Textプロパティ
    public string Text { get; set; } //プロパティ

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
        if(newValue is null)
        {
            return;
        }

        var control = (Balloon)bindable;
        control.label.Text = newValue.ToString();
    }
    #endregion


    private Color _balloonColor;
    public Color BalloonColor
    {
        get => _balloonColor;
        set
        {
            _balloonColor = value;
            this.balloonBody.BackgroundColor = _balloonColor;
        }
    }

    public Balloon()
    {
        InitializeComponent();
    }
}