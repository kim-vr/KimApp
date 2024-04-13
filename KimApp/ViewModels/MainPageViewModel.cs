using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace KimApp.ViewModels
{
    public class MainPageViewModel : BindableObject
    {
        public ObservableCollection<string> Images { get; }

        public MainPageViewModel()
        {
            Images = new ObservableCollection<string>
            {
                "carousel1.jpg",
                "carousel2.jpg",
                "carousel3.jpg",
                "carousel4.jpg",
                "carousel5.jpg"
            };
        }
    }
}