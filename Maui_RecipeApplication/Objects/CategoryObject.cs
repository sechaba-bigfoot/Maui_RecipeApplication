using CommunityToolkit.Mvvm.ComponentModel;
using Maui_RecipeApplication.Models;

namespace Maui_RecipeApplication.Objects
{
    public partial class CategoryObject : ObservableObject
    {

        [ObservableProperty] private string _Id;
        [ObservableProperty] private string _Name;
        [ObservableProperty] private string _Image;
        [ObservableProperty] private string _Description;

        private CategoryObject()
        {
            
        }

        public static CategoryObject NewCategory(Category category)
        {
            return new CategoryObject 
            {
                Id = category.Id,
                Name = category.Name,
                Image = category.Image,
                Description = category.Description,
            };
        }
    }
}
