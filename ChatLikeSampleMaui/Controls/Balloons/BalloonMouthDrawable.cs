namespace ChatLikeSampleMaui.Controls
{
    internal class BalloonMouthDrawable : View, IDrawable
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
                declaringType: typeof(BalloonMouthDrawable),
                defaultValue: MouthDirection.Right);


        #region MouthColorプロパティ
        public Color MouthColor
        {
            get => (Color)GetValue(MouthColorProperty);
            set => SetValue(MouthColorProperty, value);
        } //プロパティ

        //プロパティをバインド可能にする記述
        public static readonly BindableProperty MouthColorProperty = BindableProperty.Create(
                propertyName: nameof(MouthColor), //バインド可能にしたいプロパティ名を指定
                returnType: typeof(Color), //プロパティの型を指定
                declaringType: typeof(BalloonMouthDrawable), //プロパティが所属するクラスを指定
                defaultValue: Colors.Yellow
            );

        #endregion

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            DrawMouth(canvas);
        }

        private void DrawMouth(ICanvas canvas)
        {
            canvas.SaveState();
            canvas.ResetState();

            var path = new PathF();

            //プラットフォームに応じて
            if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                path.MoveTo(0, 50);
                path.LineTo(100, 50);
                path.LineTo(100, 135);
            }
            else if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                path.MoveTo(0, 50);
                path.LineTo(100, 50);
                path.LineTo(100, 135);
            }
            else if (DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                path.MoveTo(0, 25);
                path.LineTo(50, 25);
                path.LineTo(50, 55);
            }

            path.Close();
            canvas.StrokeColor = MouthColor;
            canvas.FillColor = MouthColor;
            canvas.FillPath(path);
            canvas.DrawPath(path);

            canvas.RestoreState();
        }
    }
}
