using Chats.Pages.Auth;
using Chats.Services;
using Chats.ViewModel;
using Microsoft.Extensions.Logging;

namespace Chats
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
          
            builder.Services.AddSingleton<IApiService, ApiService>();
            builder.Services.AddTransient<Login>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<Register>();
            builder.Services.AddTransient<RegisterViewModel>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
