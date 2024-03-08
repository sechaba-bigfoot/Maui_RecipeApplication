
using Maui_RecipeApplication.Models;

namespace Maui_RecipeApplication.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<CategoryList> GetRecipeCategoriesAsync();
        Task<RecipeDetailList> GetRecipeDetailsAsync(string id);
        Task<RecipeList> GetRecipesAsync(string category);
    }
}
