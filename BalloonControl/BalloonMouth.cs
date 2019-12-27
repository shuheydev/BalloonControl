using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.ComponentModel;
using Xamarin.Forms;

namespace BalloonControl
{
    [DesignTimeVisible(true)]
    internal class BalloonMouth : SKCanvasView
    {
        #region Properties

        /// <summary>
        /// 吹き出しの口の向き
        /// </summary>
        public MouthDirection MouthDirection { get; set; }
        public static readonly BindableProperty MouthDirectionProperty = BindableProperty.Create(
                propertyName: "MouthDirection",
                returnType: typeof(MouthDirection),
                declaringType: typeof(Balloon),
                defaultValue: MouthDirection.Right,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: MouthDirectionPropertyChanged
            );
        private static void MouthDirectionPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Balloon)bindable;
            control.MouthDirection = (MouthDirection)newValue;
        }

        /// <summary>
        /// 吹き出しの口の色
        /// </summary>
        public Color MouthColor { get; set; }

        #endregion

        /// <summary>
        /// 吹き出しの口の描画
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            SKPath path = new SKPath();
            //吹き出しの口の向きに応じて
            switch (this.MouthDirection)
            {
                case MouthDirection.Left:
                    {
                        #region From Left

                        switch (Device.RuntimePlatform)
                        {
                            case Device.iOS:
                                path.MoveTo(0, 50);
                                path.LineTo(100, 50);
                                path.LineTo(100, 135);
                                path.Close();
                                break;
                            case Device.Android:
                                path.MoveTo(0, 50);
                                path.LineTo(100, 50);
                                path.LineTo(100, 135);
                                path.Close();
                                break;
                            case Device.UWP:
                                path.MoveTo(0, 25);
                                path.LineTo(50, 25);
                                path.LineTo(50,55);
                                path.Close();
                                break;
                        }

                        #endregion

                        break;
                    }
                case MouthDirection.Right:
                    {
                        #region From Right

                        switch (Device.RuntimePlatform)
                        {
                            case Device.iOS:
                                path.MoveTo(info.Width, 50);
                                path.LineTo(info.Width-100, 50);
                                path.LineTo(info.Width-100, 135);
                                path.Close();
                                break;
                            case Device.Android:
                                path.MoveTo(info.Width, 50);
                                path.LineTo(info.Width - 100, 50);
                                path.LineTo(info.Width - 100, 135);
                                path.Close();
                                break;
                            case Device.UWP:
                                path.MoveTo(info.Width, 25);
                                path.LineTo(info.Width-50, 25);
                                path.LineTo(info.Width-50, 55);
                                path.Close();
                                break;
                        }

                        #endregion

                        break;
                    }
            }

            //色
            SKPaint fillPaint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = SKColor.Parse(this.MouthColor.ToHex())
            };

            //ここで描画
            canvas.DrawPath(path, fillPaint);
        }
    }
}
