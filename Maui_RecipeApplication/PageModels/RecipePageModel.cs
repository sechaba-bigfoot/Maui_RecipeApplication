using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui_RecipeApplication.Models;
using Maui_RecipeApplication.Objects;
using Maui_RecipeApplication.PageModels.Shared;
using Maui_RecipeApplication.Services.Interfaces;

namespace Maui_RecipeApplication.PageModels
{
    public partial class RecipePageModel : BasePageModel, IQueryAttributable
    {
        private readonly IRecipeService _recipeService;

        [ObservableProperty] private RecipeDetailObject _Recipe;

        public RecipePageModel(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if(query.TryGetValue(nameof(RecipeDetail), out var recipe))
            {
                if(recipe is RecipeDetail)
                {
                    Recipe = RecipeDetailObject.NewRecipeDetail((RecipeDetail) recipe);
                }
            }
        }

        [RelayCommand]
        public async Task NavigateBack()
        {
            try
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
