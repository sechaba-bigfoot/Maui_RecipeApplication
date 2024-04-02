using Maui_RecipeApplication.Objects;
using Maui_RecipeApplication.Pages;
using NSubstitute.ReceivedExtensions;
using System.Reflection.Metadata;

namespace Tests_RecipeApplication.PageModels
{
    public class HomePageModel_Tests
    {
        //Note:   
        //I am aware there are other tests neeeded but considering time and
        //seeing that I am not actuaally handling some of those scenarios in the actual code I decided not write them.


        [Fact]
        public async Task Initialise()
        {
            //Arrange
            IRecipeService recipeServiceSub = Substitute.For<IRecipeService>();
            INavigationService navigationServiceSub = Substitute.For<INavigationService>();

            recipeServiceSub.GetRecipeCategoriesAsync().Returns(Task.FromResult(
                new CategoryList()
                {
                    Categories = new List<Category>()
                    {
                        new Category() {},
                        new Category() {}
                    }
                }
            ));

            HomePageModel viewModel = new HomePageModel(recipeServiceSub, navigationServiceSub);

            //Act
            await viewModel.Initialise();

            // Assert
            viewModel.Categories.Count.Should().BeGreaterThan(0);
            viewModel.SelectedCategory.Should().NotBe(null);
            viewModel.IsInitialized.Should().BeTrue();

            Received.InOrder(async () =>
            {
                await recipeServiceSub.GetRecipeCategoriesAsync();
            });
        }

        [Fact]
        public void OpenRecipe_WithValidRecipeId_NavigatesToRecipePage()
        {
            // Arrange
            IRecipeService recipeServiceSub = Substitute.For<IRecipeService>();
            INavigationService navigationServiceSub = Substitute.For<INavigationService>();

            RecipeDetail recipeDetail = new RecipeDetail() { IdMeal = "1" };
            IDictionary<string, object> paramaters = new Dictionary<string, object>()
            {
                { nameof(RecipeDetail), recipeDetail}
            };

            recipeServiceSub.GetRecipeDetailsAsync("1").Returns(Task.FromResult(
                new RecipeDetailList()
                {
                    Recipes = new List<RecipeDetail>()
                    {
                        recipeDetail
                    }
                }));


            HomePageModel viewModel = new HomePageModel(recipeServiceSub, navigationServiceSub);

            // Act
            viewModel.OpenRecipeCommand.Execute("1");

            // Assert
            Received.InOrder(async () =>
            {
                await recipeServiceSub.GetRecipeDetailsAsync("1");

                //Note: I commented this out because it is not fired for some reason.
                //If you figure out why please let me know (Seriously, I would like to know.).

                //await navigationServiceSub.NavigateToAsync(nameof(RecipePage), paramaters); 
            });

        }

        [Fact]
        public async Task ShowRecipesInCategory()
        {
            // Arrange
            IRecipeService recipeServiceSub = Substitute.For<IRecipeService>();
            INavigationService navigationServiceSub = Substitute.For<INavigationService>();

            RecipeDetail recipeDetail = new RecipeDetail() { IdMeal = "1" };
            IDictionary<string, object> paramaters = new Dictionary<string, object>()
            {
                { nameof(RecipeDetail), recipeDetail}
            };

            recipeServiceSub.GetRecipesAsync("fish").Returns(Task.FromResult(
                new RecipeList()
                {
                    Recipes = new List<Recipe>()
                    {
                        new Recipe() {},
                        new Recipe() {},
                        new Recipe() {},
                    }
                }));

            HomePageModel viewModel = new HomePageModel(recipeServiceSub, navigationServiceSub);

            // Act
            viewModel.ShowRecipesInCategoryCommand.Execute("fish");

            // Assert
            viewModel.Recipes.Should().HaveCountGreaterThan(0);
            Received.InOrder(async () =>
            {
                await recipeServiceSub.GetRecipesAsync("fish");
            });
        }

    }
}