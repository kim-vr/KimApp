namespace KimApp.ViewModels;

using KimApp.Services;

public class RecipeDetailViewModel : BindableObject
{
    public Recipe Recipe { get; private set; }

    public RecipeDetailViewModel(int recipeId)
    {
        LoadRecipeDetails(recipeId);
    }

    private async void LoadRecipeDetails(int recipeId)
    {
        Recipe = await new RecipeService().GetRecipeByIdAsync(recipeId);
        OnPropertyChanged(nameof(Recipe));
    }
}