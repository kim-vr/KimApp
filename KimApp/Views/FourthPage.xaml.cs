using Microsoft.Maui.Controls;
using KimApp.ViewModels;

namespace KimApp.Views
{
    public partial class FourthPage : ContentPage
    {
        public FourthPage()
        {
            InitializeComponent();
            BindingContext = new FourthPageViewModel(); 
        }
    }
}