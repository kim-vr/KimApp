using System.Diagnostics;
using System.Timers;
using KimApp.Services;
using TimersTimer = System.Timers.Timer;
using KimApp.ViewModels;

namespace KimApp.Views
{
    [QueryProperty(nameof(RecipeId), "recipeId")]
    public partial class RecipeDetailPage : ContentPage
    {
        private int _recipeId;
        public int RecipeId
        {
            set
            {
                _recipeId = value;
                LoadRecipeDetails(_recipeId);
            }
        }

        public RecipeDetailPage()
        {
            InitializeComponent();
        }
        
        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }

        private  void LoadRecipeDetails(int recipeId)
        {
            var recipe = new RecipeService().GetRecipeById(recipeId);
            this.BindingContext = new RecipeDetailViewModel(recipeId);
        }
    }

}
