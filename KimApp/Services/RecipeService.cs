using System.Net.Http.Json;
using System.Text.Json;

namespace KimApp.Services;

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
    
    public async Task<Recipe> GetRecipeByIdAsync(int id)
    {
        Recipe recipe = null;
        string url = $"https://api.sampleapis.com/recipes/recipes/{id}";
        try
        {
            HttpResponseMessage response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode(); 
            string responseBody = await response.Content.ReadAsStringAsync();
            recipe = JsonSerializer.Deserialize<Recipe>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
        return recipe;
    }
}