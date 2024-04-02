using Maui_RecipeApplication.Services.Interfaces;

namespace Maui_RecipeApplication.Services
{
    public class NavigationService : INavigationService
    {
        public async Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null)
        {
            ShellNavigationState shellNavigation = new ShellNavigationState(route);
            if (routeParameters != null)
            {
                await Shell.Current.GoToAsync(route, routeParameters);
            }
            else
            {
                await Shell.Current.GoToAsync(route);
            }
        }
    }
}
