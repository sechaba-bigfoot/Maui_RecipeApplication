using Maui_RecipeApplication.Pages;

namespace Maui_RecipeApplication
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(RecipePage), typeof(RecipePage));
        }
    }
}
