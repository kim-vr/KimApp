namespace KimApp.Services;

using System.Text.Json;

public class RecipeService
{
    private static RecipeService _instance;
    public static RecipeService Instance => _instance ??= new RecipeService();
    private HttpClient _client;
    private string _apiUrl = "https://api.sampleapis.com/recipes/recipes";
    private List<Recipe> _recipes = new List<Recipe>(); 

    public RecipeService()
    {
        _client = new HttpClient(); 
    }

    public async Task<List<Recipe>> GetRecipesAsync()
    {
        var response = await _client.GetAsync("https://api.sampleapis.com/recipes/recipes");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Recipe>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public async Task<Recipe> GetRecipeByIdAsync(int id)
    {
        string url = $"{_apiUrl}/{id}";
        HttpResponseMessage response = await _client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Recipe>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public Task AddRecipeAsync(Recipe recipe)
    {
        _recipes.Insert(0, recipe);  
        return Task.CompletedTask;
    }
}