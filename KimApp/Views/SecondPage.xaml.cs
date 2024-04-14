using System.Timers;
using TimersTimer = System.Timers.Timer;
using KimApp.ViewModels;

namespace KimApp
{
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
            BindingContext = new SecondPageViewModel();
        }
    }
}