using BalloonControl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace chatlikesample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Message> Messages { get; set; } = new ObservableCollection<Message>();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            Messages.Add(new Message { BalloonColor = Color.Bisque, Text = "Hello", TextColor = Color.Red, Direction = MouthDirection.Left, AvatarUrl = "avatar_men_1", SendTime = DateTime.Now.ToShortTimeString() });
            Messages.Add(new Message { BalloonColor = Color.GreenYellow, Text = "Hi", TextColor = Color.Blue, Direction = MouthDirection.Right, AvatarUrl = "avatar_men_2", SendTime = DateTime.Now.ToShortTimeString() });
            Messages.Add(new Message { BalloonColor = Color.GreenYellow, Text = "How are you", TextColor = Color.Blue, Direction = MouthDirection.Right, AvatarUrl = "avatar_men_2", SendTime = DateTime.Now.ToShortTimeString() });
            Messages.Add(new Message { BalloonColor = Color.Bisque, Text = "I'm fine thank you.", TextColor = Color.Red, Direction = MouthDirection.Left, AvatarUrl = "avatar_men_1", SendTime = DateTime.Now.ToShortTimeString() });
            Messages.Add(new Message { BalloonColor = Color.GreenYellow, Text = "bye", TextColor = Color.Blue, Direction = MouthDirection.Right, AvatarUrl = "avatar_men_2", SendTime = DateTime.Now.ToShortTimeString() });
            Messages.Add(new Message { BalloonColor = Color.GreenYellow, Text = @"あkldjふぁsdjふぁをえいjふぁw;おいえfjklsdjfぁksjがをいgじぇおいjslkfjsdklfじゃうぃおえfjわえおいfじぇlfjをあいえjふぉいえjf;ぇfjklsdjfldkfじゃ;lsdkjf;をいえfじゃを;jfldkじゃおぎじぇいおじゃおいえjぇfjksldkjふぁをいえjf", TextColor = Color.Blue, Direction = MouthDirection.Right, AvatarUrl = "avatar_men_1", SendTime = DateTime.Now.ToShortTimeString() });
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Messages.Add(new Message { BalloonColor = Color.LightGray, Text = "Excellent", TextColor = Color.Green, Direction = MouthDirection.Right });
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            foreach (var item in Messages)
            {
                if (item.Direction == MouthDirection.Left)
                {
                    item.Direction = MouthDirection.Right;
                }
                else
                {
                    item.Direction = MouthDirection.Left;
                }
            }
        }
    }

    public class Message : INotifyPropertyChanged
    {
        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }
        public Color TextColor { get; set; }
        public Color BalloonColor { get; set; }
        private MouthDirection _direction;
        public MouthDirection Direction
        {
            get => _direction;
            set
            {
                _direction = value;
                OnPropertyChanged(nameof(Direction));
            }
        }

        public string AvatarUrl { get; set; }
        public string SendTime { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    public class MyDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate LeftTemplate { get; set; }
        public DataTemplate RightTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            Message message = ((Message)item);

            if (message.Direction == MouthDirection.Left)
            {
                return LeftTemplate;
            }
            else
            {
                return RightTemplate;
            }
        }
    }
}
