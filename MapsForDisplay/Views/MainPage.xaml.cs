using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CoordinateSharp;
using Esri.ArcGISRuntime.Geometry;
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

      // from MapViewModel.cs and SetPresPosPage.cs
      WeakReferenceMessenger.Default.Register<OpenWindowMessage>(this, HandleOpenWindowMessage);

      // from SetPresPosPage.xaml.cs
      WeakReferenceMessenger.Default.Register<LatLonCoordsMessage>(this, HandleLatLonCoordsMessage);
   }

   private async void HandleLatLonCoordsMessage(object recipient, LatLonCoordsMessage message)
   {
      try
      {
      string theCrds = message.Value;
      Coordinate c = Coordinate.Parse(theCrds);

      MapPoint NewCoords = new MapPoint(
         c.WebMercator.Easting, c.WebMercator.Northing, SpatialReferences.WebMercator);

      // Set Viewpoint so that it is centered on the London coordinates defined above
      await mapView.SetViewpointCenterAsync(NewCoords);

      // Set the Viewpoint scale to match the specified scale
      await mapView.SetViewpointScaleAsync(10000000);
      }
      catch(Exception ex) { }
   }

   private async void HandleOpenWindowMessage(object recipient, OpenWindowMessage message)
   {
      switch (message.Value)
      {
         case true:
            await Navigation.PushAsync(new SetPresPosPage());
            break;
         default:
            await DisplayAlert("Alert", "Lat Lon should be in upper left corner now", "OK");
            break;
      }
   }
}

