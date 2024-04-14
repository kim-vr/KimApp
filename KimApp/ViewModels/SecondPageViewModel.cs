namespace KimApp.ViewModels;

using System.Collections.ObjectModel;
using System.Linq;
using KimApp.Services;


public class SecondPageViewModel : BindableObject
{
    public ObservableCollection<Recipe> Recipes { get; } = new ObservableCollection<Recipe>();
    private readonly RecipeService _recipeService = new RecipeService();

    public SecondPageViewModel()
    {
        LoadRecipes();
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
