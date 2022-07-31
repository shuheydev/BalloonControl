namespace ChatLikeSampleMaui.Controls;

public partial class Balloon : ContentView
{
    /// <summary>
    /// �����o���̌��̌���
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


    #region Text�v���p�e�B
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    } //�v���p�e�B

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
        if (newValue is null)
        {
            return;
        }

        var control = (Balloon)bindable;
    }
    #endregion


    #region BalloonColor�v���p�e�B
    public Color BalloonColor
    {
        get => (Color)GetValue(BalloonColorProperty);
        set => SetValue(BalloonColorProperty, value);
    } //�v���p�e�B

    //�v���p�e�B���o�C���h�\�ɂ���L�q
    public static readonly BindableProperty BalloonColorProperty = BindableProperty.Create(
            propertyName: nameof(BalloonColor), //�o�C���h�\�ɂ������v���p�e�B�����w��
            returnType: typeof(Color), //�v���p�e�B�̌^���w��
            declaringType: typeof(Balloon), //�v���p�e�B����������N���X���w��
            defaultValue: Colors.Green,
            defaultBindingMode: BindingMode.TwoWay, //�f�t�H���g�̃o�C���f�B���O�̎��
            propertyChanged: BalloonColorPropertyChanged //�v���p�e�B�̒l���ύX���ꂽ�Ƃ��Ɏ��s����郁�\�b�h���w��
        );

    //�v���p�e�B�̒l���ύX���ꂽ�Ƃ��Ɏ��s�����
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