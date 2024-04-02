using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui_RecipeApplication.Models;
using Maui_RecipeApplication.Objects;
using Maui_RecipeApplication.PageModels.Shared;
using Maui_RecipeApplication.Pages;
using Maui_RecipeApplication.Services.Interfaces;
using System.Reflection.Metadata;

namespace Maui_RecipeApplication.PageModels
{
    public partial class HomePageModel : BasePageModel, IInitialise
    {
        private readonly IRecipeService _recipeService;
        private readonly INavigationService _navigationService;

        [ObservableProperty] List<RecipeObject> _Recipes = new List<RecipeObject>();
        [ObservableProperty] List<CategoryObject> _Categories = new List<CategoryObject>();

        [ObservableProperty] CategoryObject _SelectedCategory;
        partial void OnSelectedCategoryChanged(CategoryObject value)
        {
            //UpdateRecipes();
        }

        [ObservableProperty] RecipeObject _SelectedRecipe;
        
        public bool IsInitialized { get; private set; }

        partial void OnSelectedRecipeChanged(RecipeObject value)
        {
            //OpenRecipe();
        }

        public HomePageModel(IRecipeService recipeService, INavigationService navigationService)
        {
            _recipeService = recipeService;
            _navigationService = navigationService;
        }

        [RelayCommand]
        public async Task OpenRecipe(object parameter)
        {
            try
            {
                if (parameter != null && parameter is string recipeId)
                {
                    RecipeDetailList recipeDetails = await _recipeService.GetRecipeDetailsAsync(recipeId);
                    if (recipeDetails.Recipes.Any())
                    {
                        RecipeDetail recipeDetail = recipeDetails.Recipes.First();
                        IDictionary<string, object> paramaters = new Dictionary<string, object>()
                        {
                            { nameof(RecipeDetail), recipeDetail}
                        };

                       await _navigationService.NavigateToAsync(nameof(RecipePage), paramaters);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        [RelayCommand]
        public async void ShowRecipesInCategory(object parameter)
        {
            try
            {
                if(parameter != null && parameter is string category)
                {
                    RecipeList recipeList = new RecipeList();
                    recipeList = await _recipeService.GetRecipesAsync(category);

                    if (recipeList.Recipes.Any())
                    {
                        List<RecipeObject> recipes = new List<RecipeObject>();

                        foreach (Recipe item in recipeList.Recipes)
                        {
                            RecipeObject obj = RecipeObject.NewRecipe(item);
                            recipes.Add(obj);
                        }

                        Recipes = recipes;
                    }
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public async Task Initialise()
        {
            try
            {

                if (IsInitialized) return;

                CategoryList list = await _recipeService.GetRecipeCategoriesAsync();

                if (list?.Categories != null && list.Categories.Any())
                {
                    List<CategoryObject> categories = new List<CategoryObject>();

                    foreach (Category item in list.Categories)
                    {
                        categories.Add(CategoryObject.NewCategory(item));
                    }

                    Categories = categories;
                    SelectedCategory = categories.FirstOrDefault();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                // Handle exception
            }
            finally
            {
                IsInitialized = true;
            }

        }

    }
}
