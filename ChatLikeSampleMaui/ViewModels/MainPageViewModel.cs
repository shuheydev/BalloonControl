using ChatLikeSampleMaui.Controls;
using ChatLikeSampleMaui.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ChatLikeSampleMaui.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        string _messageSingle = "Hello, World";

        [ObservableProperty]
        Color _balloonColorSingle = Colors.Green;

        [ObservableProperty]
        MouthDirection _mouthDirectionSingle = MouthDirection.Left;

        [ObservableProperty]
        ObservableCollection<Talk> _talks;

        [RelayCommand]
        void ChangeMessage()
        {
            if (MouthDirectionSingle == MouthDirection.Right)
            {
                this.MessageSingle = "こんにちは世界";
                this.BalloonColorSingle = Colors.Green;
                this.MouthDirectionSingle = MouthDirection.Left;
            }
            else if (MouthDirectionSingle == MouthDirection.Left)
            {
                this.MessageSingle = "さようなら日曜日…あああああああああああああああああああ";
                this.BalloonColorSingle = Colors.Orange;
                this.MouthDirectionSingle = MouthDirection.Right;
            }

        }

        [RelayCommand]
        void AddItem()
        {
            this._talks.Add(new Talk { Message = "hello6", MouthDirection = MouthDirection.Right, BalloonColor = Colors.Orange });
        }

        [RelayCommand]
        void ChangeDirection()
        {
            var first = this._talks.First();

            if (first.MouthDirection == MouthDirection.Right)
            {
                first.MouthDirection = MouthDirection.Left;
            }
            else
                first.MouthDirection = MouthDirection.Right;

            first.Message = "Oh";
        }

        public MainPageViewModel()
        {
            this.Talks = new ObservableCollection<Talk>();

            this.Talks.Add(new Talk { Message = "hello1", MouthDirection = MouthDirection.Right, BalloonColor = Colors.Red });
            this.Talks.Add(new Talk { Message = "hello2", MouthDirection = MouthDirection.Right, BalloonColor = Colors.Blue });
            this.Talks.Add(new Talk { Message = "hello3", MouthDirection = MouthDirection.Right, BalloonColor = Colors.Red });
            this.Talks.Add(new Talk { Message = "hello4", MouthDirection = MouthDirection.Right, BalloonColor = Colors.Blue });
            this.Talks.Add(new Talk { Message = "hello5", MouthDirection = MouthDirection.Right, BalloonColor = Colors.Red });
        }
    }
}
