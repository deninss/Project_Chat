 
using Chats.ViewModel._personChat;

namespace Chats.Pages.Main.ListChats;

public partial class PersonChats : ContentPage
{
	public PersonChats(PersonChatViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}