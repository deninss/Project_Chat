using Chats.Pages.Auth;
using Chats.Pages.Main;
using Chats.Pages.Main.ListChats;
using Chats.Services;
using Chats.ViewModel;
using Chats.ViewModel._groupChat; 
using Chats.ViewModel._personChat;
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
            builder.Services.AddTransient<PersonChats>(); 
            builder.Services.AddTransient<PersonChatViewModel>(); 
            builder.Services.AddTransient<GroupChats>(); 
            builder.Services.AddTransient<GroupChatViewModel>(); 
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
