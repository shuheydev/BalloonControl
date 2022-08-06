using ChatLikeSampleMaui.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatLikeSampleMaui.Models
{
    public partial class Talk : ObservableObject
    {
        private string _userName;
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        private MouthDirection _mouthDirection;
        public MouthDirection MouthDirection
        {
            get => _mouthDirection;
            set => SetProperty(ref _mouthDirection, value);
        }

        private string _message;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        private Color _balloonColor;
        public Color BalloonColor
        {
            get => _balloonColor;
            set => SetProperty(ref _balloonColor, value);
        }
    }
}
