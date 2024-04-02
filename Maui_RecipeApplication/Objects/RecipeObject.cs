using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helpers;
using Maui_RecipeApplication.Models;
using Maui_RecipeApplication.Services.Interfaces;

namespace Maui_RecipeApplication.Objects
{
    public partial class RecipeObject : ObservableObject
    {

        [ObservableProperty] private string _Id;
        [ObservableProperty] private string _Name;
        [ObservableProperty] private UriImageSource _Image;
        //[ObservableProperty] private string _Image;
        
       


        private RecipeObject()
        {
            
        }

        public static RecipeObject NewRecipe(Recipe recipe)
        {
            RecipeObject obj = new RecipeObject
            {
                Id = recipe.Id ?? "",
                Name = recipe.Name ?? "Error",
                Image = new UriImageSource 
                { 
                    Uri = new Uri(recipe.Image ?? "https://media.istockphoto.com/id/1147544807/vector/thumbnail-image-vector-graphic.jpg?s=612x612&w=0&k=20&c=rnCKVbdxqkjlcs3xH87-9gocETqpspHFXu5dIGB4wuM="),
                    CachingEnabled = true,
                    CacheValidity = TimeSpan.FromDays(7),
                }
            };
            return obj;
        }

    }

    public partial class RecipeDetailObject : ObservableObject
    {
        [ObservableProperty] public string _Id;
        [ObservableProperty] public string _Name;
        [ObservableProperty] public object _StrDrinkAlternate;
        [ObservableProperty] public string _Category;
        [ObservableProperty] public string _StrArea;
        [ObservableProperty] public string _Instructions;
        [ObservableProperty] public string _StrMealThumb;
        [ObservableProperty] public string _StrTags;
        [ObservableProperty] public string _StrYoutube;
        [ObservableProperty] public string _StrIngredient1;
        [ObservableProperty] public string _StrIngredient2;
        [ObservableProperty] public string _StrIngredient3;
        [ObservableProperty] public string _StrIngredient4;
        [ObservableProperty] public string _StrIngredient5;
        [ObservableProperty] public string _StrIngredient6;
        [ObservableProperty] public string _StrIngredient7;
        [ObservableProperty] public string _StrIngredient8;
        [ObservableProperty] public string _StrIngredient9;
        [ObservableProperty] public string _StrIngredient10;
        [ObservableProperty] public string _StrIngredient11;
        [ObservableProperty] public string _StrIngredient12;
        [ObservableProperty] public string _StrIngredient13;
        [ObservableProperty] public string _StrIngredient14;
        [ObservableProperty] public string _StrIngredient15;
        [ObservableProperty] public object _StrIngredient16;
        [ObservableProperty] public object _StrIngredient17;
        [ObservableProperty] public object _StrIngredient18;
        [ObservableProperty] public object _StrIngredient19;
        [ObservableProperty] public object _StrIngredient20;
        [ObservableProperty] public string _StrMeasure1;
        [ObservableProperty] public string _StrMeasure2;
        [ObservableProperty] public string _StrMeasure3;
        [ObservableProperty] public string _StrMeasure4;
        [ObservableProperty] public string _StrMeasure5;
        [ObservableProperty] public string _StrMeasure6;
        [ObservableProperty] public string _StrMeasure7;
        [ObservableProperty] public string _StrMeasure8;
        [ObservableProperty] public string _StrMeasure9;
        [ObservableProperty] public string _StrMeasure10;
        [ObservableProperty] public string _StrMeasure11;
        [ObservableProperty] public string _StrMeasure12;
        [ObservableProperty] public string _StrMeasure13;
        [ObservableProperty] public string _StrMeasure14;
        [ObservableProperty] public string _StrMeasure15;
        [ObservableProperty] public object _StrMeasure16;
        [ObservableProperty] public object _StrMeasure17;
        [ObservableProperty] public object _StrMeasure18;
        [ObservableProperty] public object _StrMeasure19;
        [ObservableProperty] public object _StrMeasure20;
        [ObservableProperty] public object _StrSource;
        [ObservableProperty] public object _StrImageSource;
        [ObservableProperty] public object _StrCreativeCommonsConfirmed;
        [ObservableProperty] public object _DateModified;

        private RecipeDetailObject(RecipeDetail recipe)
        {
           
        }
        
        public static RecipeDetailObject NewRecipeDetail (RecipeDetail recipe)
        {
            return new RecipeDetailObject(recipe) 
            {
                Id = recipe.IdMeal,
                Name = recipe.StrMeal,
                StrDrinkAlternate = recipe.StrDrinkAlternate,
                Category = recipe.StrCategory,
                StrArea = recipe.StrArea,
                Instructions = recipe.StrInstructions,
                StrMealThumb = recipe.StrMealThumb,
                StrTags = recipe.StrTags,
                StrYoutube = recipe.StrYoutube,
                StrIngredient1 = recipe.StrIngredient1,
                StrIngredient2 = recipe.StrIngredient2,
                StrIngredient3 = recipe.StrIngredient3,
                StrIngredient4 = recipe.StrIngredient4,
                StrIngredient5 = recipe.StrIngredient5,
                StrIngredient6 = recipe.StrIngredient6,
                StrIngredient7 = recipe.StrIngredient7,
                StrIngredient8 = recipe.StrIngredient8,
                StrIngredient9 = recipe.StrIngredient9,
                StrIngredient10 = recipe.StrIngredient10,
                StrIngredient11 = recipe.StrIngredient11,
                StrIngredient12 = recipe.StrIngredient12,
                StrIngredient13 = recipe.StrIngredient13,
                StrIngredient14 = recipe.StrIngredient14,
                StrIngredient15 = recipe.StrIngredient15,
                StrIngredient16 = recipe.StrIngredient16,
                StrIngredient17 = recipe.StrIngredient17,
                StrIngredient18 = recipe.StrIngredient18,
                StrIngredient19 = recipe.StrIngredient19,
                StrIngredient20 = recipe.StrIngredient20,
                StrMeasure1 = recipe.StrMeasure1,
                StrMeasure2 = recipe.StrMeasure2,
                StrMeasure3 = recipe.StrMeasure3,
                StrMeasure4 = recipe.StrMeasure4,
                StrMeasure5 = recipe.StrMeasure5,
                StrMeasure6 = recipe.StrMeasure6,
                StrMeasure7 = recipe.StrMeasure7,
                StrMeasure8 = recipe.StrMeasure8,
                StrMeasure9 = recipe.StrMeasure9,
                StrMeasure10 = recipe.StrMeasure10,
                StrMeasure11 = recipe.StrMeasure11,
                StrMeasure12 = recipe.StrMeasure12,
                StrMeasure13 = recipe.StrMeasure13,
                StrMeasure14 = recipe.StrMeasure14,
                StrMeasure15 = recipe.StrMeasure15,
                StrMeasure16 = recipe.StrMeasure16,
                StrMeasure17 = recipe.StrMeasure17,
                StrMeasure18 = recipe.StrMeasure18,
                StrMeasure19 = recipe.StrMeasure19,
                StrMeasure20 = recipe.StrMeasure20,
                StrSource = recipe.StrSource,
                StrImageSource = recipe.StrImageSource,
                StrCreativeCommonsConfirmed = recipe.StrCreativeCommonsConfirmed,
                DateModified = recipe.DateModified,
            };
        }

    }
}
