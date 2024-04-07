using Chats.Pages.Auth;

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
