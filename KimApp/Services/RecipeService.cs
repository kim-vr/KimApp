using System.Net.Http.Json;
using System.Text.Json;

public class RecipeService
{
    private HttpClient _client;
    private string _apiUrl = "https://api.sampleapis.com/recipes/recipes";

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
}