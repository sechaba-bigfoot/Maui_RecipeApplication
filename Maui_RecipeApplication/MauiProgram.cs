using CommunityToolkit.Maui;
using Maui_RecipeApplication.PageModels;
using Maui_RecipeApplication.Services;
using Maui_RecipeApplication.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Maui_RecipeApplication
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<IRecipeService, RecipeService>();
            builder.Services.AddTransient<HomePageModel>();
            builder.Services.AddTransient<RecipePageModel>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
