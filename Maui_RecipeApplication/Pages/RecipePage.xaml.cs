using Helpers;
using Maui_RecipeApplication.PageModels;

namespace Maui_RecipeApplication.Pages;

public partial class RecipePage : ContentPage
{
	public RecipePage()
	{
		InitializeComponent();
        BindingContext = ServiceProviderHelper.GetService<RecipePageModel>();
    }
}