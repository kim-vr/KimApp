namespace KimApp.ViewModels;

using System.Collections.ObjectModel;
using System.Linq;
using KimApp.Services;
using KimApp.Views;


public class SecondPageViewModel : BindableObject
{
    public ObservableCollection<Recipe> Recipes { get; }
    private readonly RecipeService _recipeService = new RecipeService();
    public Command<Recipe> RecipeSelectedCommand { get; } 
    public SecondPageViewModel()
    {
        Recipes = RecipeService.Instance.GetRecipes();
        RecipeSelectedCommand = new Command<Recipe>(NavigateToDetails);
        LoadRecipes();
    }
    
    private async void NavigateToDetails(Recipe selectedRecipe)
    {
        if (selectedRecipe == null)
            return;
        
        await Shell.Current.GoToAsync($"{nameof(RecipeDetailPage)}?recipeId={selectedRecipe.id}");
    }

    private async void LoadRecipes()
    {
        var recipes = await _recipeService.GetRecipesAsync();
        if (recipes != null)
        {
            foreach (var recipe in recipes)
            {
                Recipes.Add(recipe);
            }
        }
    }
    
}
