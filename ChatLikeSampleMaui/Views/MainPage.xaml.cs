using ChatLikeSampleMaui.ViewModels;

namespace ChatLikeSampleMaui.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            this.BindingContext = vm;
        }
    }
}