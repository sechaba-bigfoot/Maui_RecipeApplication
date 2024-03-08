using Helpers;
using Maui_RecipeApplication.PageModels;

namespace Maui_RecipeApplication.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
        BindingContext = ServiceProviderHelper.GetService<HomePageModel>();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if(BindingContext is HomePageModel)
        {
            await (BindingContext as HomePageModel).Initialise();
        }
    }
}