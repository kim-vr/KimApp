﻿using Microsoft.Maui.Controls;
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
    }
}