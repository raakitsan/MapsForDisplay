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
   // when page closes
   protected override void OnDisappearing()
   {
      // to MainPage.xaml.cs
      base.OnDisappearing();
      WeakReferenceMessenger.Default.Send(new OpenWindowMessage(false));
      //WeakReferenceMessenger.Default.Send(new LatLonCoordsMessage("37 53 27.6 N 74 52 19.2 W"));
      
      // below is kind of optional here, as we're not really handling messages on this page. 
      WeakReferenceMessenger.Default.Unregister<OpenWindowMessage>(this);
   }
}