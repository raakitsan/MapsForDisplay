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
      WeakReferenceMessenger.Default.Register<OpenWindowMessage>(this, HandleOpenWindowMessage);
      BindingContext = WindowViewModel;
      //this.BindingContext = new MapViewModel();
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

