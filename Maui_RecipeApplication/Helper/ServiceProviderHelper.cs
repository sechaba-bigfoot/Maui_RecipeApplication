namespace Helpers;

/// <summary>
/// Allows you to accces services registerd in the MAUI program class. 
/// Thinks of it as an acces point for DI 
/// </summary>
public static class ServiceProviderHelper
{
    public static TService GetService<TService>()
        => Current.GetService<TService>();

    public static IServiceProvider Current =>
#if WINDOWS10_0_17763_0_OR_GREATER
            MauiWinUIApplication.Current.Services;
#elif ANDROID
            MauiApplication.Current.Services;
#elif IOS || MACCATALYST
			MauiUIApplicationDelegate.Current.Services;
#else
			null;
#endif
}