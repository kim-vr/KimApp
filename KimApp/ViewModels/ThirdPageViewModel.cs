using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using KimApp.Services;

namespace KimApp.ViewModels
{
    public class ThirdPageViewModel : BindableObject
    {
        private readonly RecipeService _recipeService;
        private string _title;
        private string _ingredients;
        private string _photoUrl;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public string Ingredients
        {
            get => _ingredients;
            set
            {
                _ingredients = value;
                OnPropertyChanged(nameof(Ingredients));
            }
        }

        public string PhotoUrl
        {
            get => _photoUrl;
            set
            {
                _photoUrl = value;
                OnPropertyChanged(nameof(PhotoUrl));
            }
        }

        public ICommand AddRecipeCommand { get; }
        public ICommand PickImageCommand { get; private set; }

        public ThirdPageViewModel(RecipeService recipeService)
        {
            _recipeService = recipeService;
            AddRecipeCommand = new Command(async () => await AddRecipeAsync());
            PickImageCommand = new Command(async () => await PickImageAsync());
        }

        private async Task AddRecipeAsync()
        {
            var recipe = new Recipe
            {
                title = Title,
                ingredients = Ingredients,
                photoUrl = PhotoUrl
            };

            await _recipeService.AddRecipeAsync(recipe);
        }

        private async Task PickImageAsync()
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Please select an image",
                FileTypes = FilePickerFileType.Images,
            });

            if (result != null)
            {
                PhotoUrl = result.FullPath;
            }
        }
    }
}