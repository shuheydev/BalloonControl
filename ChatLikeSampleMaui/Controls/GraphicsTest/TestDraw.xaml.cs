namespace ChatLikeSampleMaui.Controls.GraphicsTest;

public partial class TestDraw : ContentView
{
    public static readonly BindableProperty DrawColorProperty = BindableProperty.Create(
        nameof(DrawColor),
        typeof(Color),
        typeof(TestDraw),
        defaultValue: Colors.Green,
        propertyChanged: DrawColorPropertyChanged);

    private static void DrawColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var testDrawView = (TestDraw)bindable;
        var color= (Color)newValue;
        testDrawView.TestDrawGraphics.DrawColor = color;//‰º‚ÌŠK‘w‚ÌGraphicsView‚ÌDrawColor‚ðXV
    }

    public Color DrawColor
    {
        get => (Color)GetValue(DrawColorProperty);
        set => SetValue(DrawColorProperty, value);
    }


    //public TestGraphicsView TestGraphicsView = new TestGraphicsView();

    public TestDraw()
    {
        InitializeComponent();
    }
}