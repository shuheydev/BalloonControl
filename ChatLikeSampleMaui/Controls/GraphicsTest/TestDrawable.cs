namespace ChatLikeSampleMaui.Controls.GraphicsTest;

public class TestDrawable : View, IDrawable
{
    public static readonly BindableProperty DrawColorProperty = BindableProperty.Create(
        nameof(DrawColor),
        typeof(Color),
        typeof(TestDrawable),
        defaultValue: Colors.Green);

    public Color DrawColor
    {
        get => (Color)GetValue(DrawColorProperty);
        set => SetValue(DrawColorProperty, value);
    }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.ResetState();
        canvas.FillColor = DrawColor;
        canvas.FillCircle(new Point(50, 50), 50d);
    }
}