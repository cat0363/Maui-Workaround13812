#if ANDROID
using Maui_Workaround13812.Platforms.Android;
#endif
#if IOS
using Maui_Workaround13812.Platforms.iOS;
#endif

using Microsoft.Extensions.Logging;

namespace Maui_Workaround13812;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .ConfigureMauiHandlers(handlers => {
#if ANDROID
                handlers.AddHandler<CustomViewCell, CustomViewCellHandler>();
#endif
#if IOS
				handlers.AddHandler<CustomViewCell, CustomViewCellHandler>();
#endif
            })
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
