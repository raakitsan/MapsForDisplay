using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MapsForDisplay.ViewModels;
using MapsForDisplay.Views;

namespace MapsForDisplay;

public partial class MainPage : ContentPage
{
   private MapViewModel WindowViewModel
   {
      get;
      set;
   }
   public MainPage()
   {
      InitializeComponent();
      WindowViewModel = new MapViewModel();
      BindingContext = WindowViewModel;

      // SetPresPosPage.cs
      WeakReferenceMessenger.Default.Register<LatLonCoordsMessage>(this, HandleLatLonCoordsMessage);

      // from MapViewModel.cs and SetPresPosPage.cs
      WeakReferenceMessenger.Default.Register<OpenWindowMessage>(this, HandleOpenWindowMessage);

   }
   public string crds = "";
   private void HandleLatLonCoordsMessage(object recipient, LatLonCoordsMessage message)
   {
      crds = message.Value;
   }

   private async void HandleOpenWindowMessage(object recipient, OpenWindowMessage message)
   {
      switch (message.Value)
      {
         case true:
            await Navigation.PushAsync(new SetPresPosPage());
            break;
         default:
            await DisplayAlert("Alert", crds, "OK");
            break;
      }
   }
}

