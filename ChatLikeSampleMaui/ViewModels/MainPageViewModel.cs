using ChatLikeSampleMaui.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ChatLikeSampleMaui.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        string _message = "Hello, World";

        [ObservableProperty]
        Color _balloonColor = Colors.Green;

        [ObservableProperty]
        MouthDirection _mouthDirection = MouthDirection.Left;

        [ICommand]
        void ChangeMessage()
        {
            if (MouthDirection == MouthDirection.Right)
            {
                this.Message = "こんにちは世界";
                this.BalloonColor = Colors.Green;
                this.MouthDirection = MouthDirection.Left;
            }
            else if (MouthDirection == MouthDirection.Left)
            {
                this.Message = "さようなら日曜日…あああああああああああああああああああ";
                this.BalloonColor = Colors.Orange;
                this.MouthDirection = MouthDirection.Right;
            }

        }
    }
}
