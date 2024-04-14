namespace KimApp.ViewModels;

using KimApp.Services;

public class RecipeDetailViewModel : BindableObject
{
    public Recipe Recipe { get; set; }

    public RecipeDetailViewModel(int recipeId)
    {
        Recipe = RecipeService.Instance.GetRecipeById(recipeId);
    }

    private async void LoadRecipeDetails(int recipeId)
    {
        Recipe = await new RecipeService().GetRecipeByIdAsync(recipeId);
        OnPropertyChanged(nameof(Recipe));
    }
}