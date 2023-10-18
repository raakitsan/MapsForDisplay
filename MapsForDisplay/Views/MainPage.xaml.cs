using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MapsForDisplay.ViewModels;
using MapsForDisplay.Views;

namespace MapsForDisplay;

public partial class MainPage : ContentPage
{
   public string Coords = "";
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

      // from MapViewModel.cs and SetPresPosPage.cs
      WeakReferenceMessenger.Default.Register<OpenWindowMessage>(this, HandleOpenWindowMessage);
   }

   private async void HandleOpenWindowMessage(object recipient, OpenWindowMessage message)
   {
      switch (message.Value)
      {
         case true:
            await Navigation.PushAsync(new SetPresPosPage());
            break;
         default:
            await DisplayAlert("Alert", "Secondary window was closed", "OK");
            break;
      }
   }
}

