namespace ChatLikeSampleMaui.Controls;

public partial class Balloon : ContentView
{
    #region Text�v���p�e�B
    public string Text { get; set; } //�v���p�e�B

    //�v���p�e�B���o�C���h�\�ɂ���L�q
    public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: nameof(Text), //�o�C���h�\�ɂ������v���p�e�B�����w��
            returnType: typeof(string), //�v���p�e�B�̌^���w��
            declaringType: typeof(Balloon), //�v���p�e�B����������N���X���w��
            defaultValue: "",
            defaultBindingMode: BindingMode.TwoWay, //�f�t�H���g�̃o�C���f�B���O�̎��
            propertyChanged: TextPropertyChanged //�v���p�e�B�̒l���ύX���ꂽ�Ƃ��Ɏ��s����郁�\�b�h���w��
        );

    //�v���p�e�B�̒l���ύX���ꂽ�Ƃ��Ɏ��s�����
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