using Chats.ViewModel;

namespace Chats.Pages.Auth;

public partial class Register : ContentPage
{ 
    public Register(RegisterViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        login.GestureRecognizers.Add(new TapGestureRecognizer
        {
            Command = new Command(async () => await Shell.Current.Navigation.PopAsync())
        });
    }
}