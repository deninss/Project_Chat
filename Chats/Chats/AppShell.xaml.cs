using Chats.Pages.Auth;
using Chats.Pages.Main;

namespace Chats
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Login), typeof(Login));
            Routing.RegisterRoute(nameof(Register), typeof(Register)); 
        }
    }
}
