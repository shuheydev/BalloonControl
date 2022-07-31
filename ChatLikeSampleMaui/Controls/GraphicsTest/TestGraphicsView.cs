namespace ChatLikeSampleMaui.Controls.GraphicsTest;

public class TestGraphicsView : GraphicsView
{
    public static readonly BindableProperty DrawColorProperty = BindableProperty.Create(
    nameof(DrawColor),
    typeof(Color),
    typeof(TestGraphicsView),
    defaultValue: Colors.Green,
    propertyChanged: DrawColorPropertyChanged);

    private static void DrawColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var testDrawView = (TestGraphicsView)bindable;
        var color = (Color)newValue;
        testDrawView._testDrawable.DrawColor = color;
        testDrawView.Invalidate();//再描画。重要
    }

    //上の階層(親コントロール)によって変更される
    public Color DrawColor
    {
        get => (Color)GetValue(DrawColorProperty);
        set => SetValue(DrawColorProperty, value);
    }

    private TestDrawable _testDrawable = new TestDrawable();

    public TestGraphicsView()
    {
        this.Drawable = this._testDrawable;
    }
}
