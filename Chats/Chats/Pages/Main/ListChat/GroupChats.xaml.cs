 
using Chats.ViewModel._groupChat;

namespace Chats.Pages.Main.ListChats;

public partial class GroupChats : ContentPage
{
	public GroupChats(GroupChatViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}