using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatLikeSampleMaui.Controls
{
    internal class BalloonMouthGraphicsView : GraphicsView
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
                declaringType: typeof(BalloonMouthGraphicsView),
                defaultValue: MouthDirection.Right,
                propertyChanged: MouthDirectionPropertyChanged
            );
        private static void MouthDirectionPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (BalloonMouthGraphicsView)bindable;

            var direction = (MouthDirection)newValue;
            control.BalloonMouthDrawable.MouthDirection = direction;
            control.Invalidate();
        }


        #region BalloonMouthColorプロパティ
        public Color BalloonMouthColor
        {
            get => (Color)GetValue(BalloonMouthColorProperty);
            set => SetValue(BalloonMouthColorProperty, value);
        } //プロパティ

        //プロパティをバインド可能にする記述
        public static readonly BindableProperty BalloonMouthColorProperty = BindableProperty.Create(
                propertyName: nameof(BalloonMouthColor), //バインド可能にしたいプロパティ名を指定
                returnType: typeof(Color), //プロパティの型を指定
                declaringType: typeof(BalloonMouthGraphicsView), //プロパティが所属するクラスを指定
                defaultValue: Colors.Blue,
                defaultBindingMode: BindingMode.TwoWay, //デフォルトのバインディングの種類
                propertyChanged: BalloonMouthColorPropertyChanged //プロパティの値が変更されたときに実行されるメソッドを指定
            );

        //プロパティの値が変更されたときに実行される
        private static void BalloonMouthColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (BalloonMouthGraphicsView)bindable;
            var color = (Color)newValue;
            control.BalloonMouthDrawable.MouthColor = color;
            //control.Invalidate();
        }
        #endregion

        public BalloonMouthGraphicsView() => Drawable = BalloonMouthDrawable;

        private BalloonMouthDrawable BalloonMouthDrawable = new BalloonMouthDrawable();
    }
}
