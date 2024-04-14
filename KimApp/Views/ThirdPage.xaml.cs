using Microsoft.Maui.Controls;
using KimApp.ViewModels;
using KimApp.Services;

namespace KimApp.Views
{
    public partial class ThirdPage : ContentPage
    {
        public ThirdPage()
        {
            InitializeComponent();
            BindingContext = new ThirdPageViewModel(RecipeService.Instance);
        }
    }
}