using CommunityToolkit.Mvvm.ComponentModel;
using Maui_RecipeApplication.Models;
using Maui_RecipeApplication.Objects;
using Maui_RecipeApplication.PageModels.Shared;
using Maui_RecipeApplication.Pages;
using Maui_RecipeApplication.Services.Interfaces;

namespace Maui_RecipeApplication.PageModels
{
    public partial class HomePageModel : BasePageModel, IInitialise
    {
        private readonly IRecipeService _recipeService;

        [ObservableProperty] List<RecipeObject> _Recipes = new List<RecipeObject>();
        [ObservableProperty] List<CategoryObject> _Categories = new List<CategoryObject>();

        [ObservableProperty] CategoryObject _SelectedCategory;
        partial void OnSelectedCategoryChanged(CategoryObject value)
        {
            UpdateRecipes();
        }

        [ObservableProperty] RecipeObject _SelectedRecipe;
        partial void OnSelectedRecipeChanged(RecipeObject value)
        {
            OpenRecipe();
        }

        
        public HomePageModel(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        private async void OpenRecipe()
        {
            try
            {
                RecipeDetailList recipeDetails = await _recipeService.GetRecipeDetailsAsync(SelectedRecipe.Id);
                if (recipeDetails.Recipes.Any())
                {
                    RecipeDetail recipeDetail = recipeDetails.Recipes.First();
                    IDictionary<string, object> query = new Dictionary<string, object>()
                    {
                        { nameof(RecipeDetail), recipeDetail}
                    };

                    await AppShell.Current.GoToAsync(nameof(RecipePage), query);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public async void UpdateRecipes()
        {
            RecipeList recipeList = new RecipeList();

            try
            {
                string category = SelectedCategory.Name;
                recipeList = await _recipeService.GetRecipesAsync(category);

                if (recipeList.Recipes.Any())
                {
                    List<RecipeObject> recipes = new List<RecipeObject>();

                    foreach (Recipe item in recipeList.Recipes)
                    {
                        RecipeObject obj = await RecipeObject.NewRecipe(item);
                        recipes.Add(obj);
                    }

                    Recipes = recipes;
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public async Task Initialise()
        {
            CategoryList list = new CategoryList();

            try
            {
                list = await _recipeService.GetRecipeCategoriesAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            if(list.Categories.Any()) 
            {
                List<CategoryObject> categories = new List<CategoryObject>();
                
                foreach (Category item in list.Categories) 
                {
                    categories.Add(CategoryObject.NewCategory(item));
                }

                Categories = categories;
                SelectedCategory = categories[0];
            }

        }

    }
}
