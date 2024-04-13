using Microsoft.Maui.Controls;
using System;

namespace KimApp
{
    public partial class GifPage : ContentPage
    {
        public GifPage()
        {
            InitializeComponent();
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await Task.Delay(100);
            gifAn.IsAnimationPlaying = false;
            await Task.Delay(100);
            gifAn.IsAnimationPlaying = true;
        }
    }
}