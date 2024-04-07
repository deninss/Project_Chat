using Chats.ViewModel;
using System.Windows.Input;

namespace Chats.Pages.Auth;
    
public partial class Login : ContentPage
{
    public Login(LoginViewModel viewModel)
	{   
		InitializeComponent();
        BindingContext = viewModel;
        reg.GestureRecognizers.Add(new TapGestureRecognizer
        {
            Command = new Command(async () => await Shell.Current.GoToAsync(nameof(Register)))
        });
    } 
}