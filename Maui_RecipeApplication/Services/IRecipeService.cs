using Maui_RecipeApplication.Models;
using Maui_RecipeApplication.Services.Interfaces;
using Mobile.Http;

namespace Maui_RecipeApplication.Services
{
    public class RecipeService : IRecipeService
    {
        public async Task<CategoryList> GetRecipeCategoriesAsync()
        {
            return await SharedClient.GetAsync<CategoryList>("categories.php");
        }

        public async Task<RecipeDetailList> GetRecipeDetailsAsync(string id)
        {
            return await SharedClient.GetAsync<RecipeDetailList>($"lookup.php?i={id}");
        }

        public async Task<RecipeList> GetRecipesAsync(string category)
        {
            return await SharedClient.GetAsync<RecipeList>($"filter.php?c={category}");
        }
    }
}
