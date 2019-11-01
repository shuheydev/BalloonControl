using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChatLikeSmaple
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public List<Message> Messages { get; set; }

        public MainPage()
        {
            InitializeComponent();

            Messages = new List<Message>();

            Messages.Add(new Message { Text = "はろー", TextColor = Color.Red, BackgroundColor = Color.Bisque });
        }
    }


    public class Message
    {
        public string Text { get; set; }
        public Color TextColor { get; set; }
        public Color BackgroundColor { get; set; }
    }
}
