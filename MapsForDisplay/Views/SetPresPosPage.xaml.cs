using CommunityToolkit.Mvvm.Messaging;
using MapsForDisplay.ViewModels;

namespace MapsForDisplay.Views;

public partial class SetPresPosPage : ContentPage
{
	SetPresPosViewModel vm = new SetPresPosViewModel();
	public SetPresPosPage()
	{
		BindingContext = vm;
		InitializeComponent();
	}
   protected override void OnDisappearing()
   {
      base.OnDisappearing();
      WeakReferenceMessenger.Default.Send(new OpenWindowMessage(false));

      // below is kind of optional here, as we're not really handling messages on this page. 
      WeakReferenceMessenger.Default.Unregister<OpenWindowMessage>(this);
   }
}