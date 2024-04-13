namespace KimApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        public async void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GifPage());
        }
    }

}
