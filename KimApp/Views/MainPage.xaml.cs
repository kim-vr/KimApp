using System.Timers;
using TimersTimer = System.Timers.Timer;
using KimApp.ViewModels;

namespace KimApp
{
    public partial class MainPage : ContentPage
    {
        private TimersTimer _carouselTimer;

        public MainPage()
        {
            InitializeComponent();
            StartCarouselTimer();
            BindingContext = new MainPageViewModel();
        }

        private void StartCarouselTimer()
        {
            _carouselTimer = new TimersTimer(3000);
            _carouselTimer.Elapsed += OnTimedEvent;
            _carouselTimer.AutoReset = true;
            _carouselTimer.Enabled = true;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (carouselView.ItemsSource != null)
                {
                    var itemsCount = carouselView.ItemsSource.Cast<object>().Count();
                    if (itemsCount > 0)
                    {
                        var newIndex = (carouselView.Position + 1) % itemsCount; //Faire défiler en boucle
                        carouselView.Position = newIndex; 
                    }
                }
            });
        }

        public async void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GifPage());
        }

        protected override void OnDisappearing()
        {
            _carouselTimer?.Stop(); 
            _carouselTimer?.Dispose();
            base.OnDisappearing();
        }
    }
}