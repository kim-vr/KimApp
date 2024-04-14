namespace KimApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.SecondPage), typeof(Views.SecondPage));
            Routing.RegisterRoute(nameof(Views.RecipeDetailPage), typeof(Views.RecipeDetailPage));
        }
    }
}
