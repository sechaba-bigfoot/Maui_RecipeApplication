using CommunityToolkit.Mvvm.ComponentModel;

namespace Maui_RecipeApplication.PageModels.Shared
{
    public partial class BasePageModel : ObservableObject
    {
        [ObservableProperty] private bool isBusy = false;
    }
}
