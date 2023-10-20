using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Map = Esri.ArcGISRuntime.Mapping.Map;
using CoordinateSharp;

namespace MapsForDisplay.ViewModels;

/// <summary>
/// Provides map data to an application
/// </summary>
[ObservableObject]
public partial class MapViewModel
{
   [ObservableProperty]
   private string crds = "should have changed to Lat Lon";
   public MapViewModel()
    {
        _map = new Map(SpatialReferences.WebMercator)
        {
            InitialViewpoint = new Viewpoint(new Envelope(-180, -85, 180, 85, SpatialReferences.Wgs84)),
            Basemap = new Basemap(BasemapStyle.ArcGISStreets)
        };

      // from SetPresPosPage.xaml.cs
      WeakReferenceMessenger.Default.Register<LatLonCoordsMessage>(this, HandleLatLonCoordsMessage);
   }
   private async void HandleLatLonCoordsMessage(object recipient, LatLonCoordsMessage message)
   {
      string theCrds = message.Value;
      Coordinate c = Coordinate.Parse(theCrds);
      Crds = $"{c.WebMercator.Easting} and {c.WebMercator.Northing}";
   }

   private Map _map;

   /// <summary>
   /// Gets or sets the map
   /// </summary>
   public Map Map
    {
        get => _map;
        set { _map = value; }
    }

   // button on MainPage.xaml clicked
   public Command OpenWindowCommand
   {
      get
      {
         // to MainPage.xaml.cs
         return new Command(() => {
            WeakReferenceMessenger.Default.Send(new OpenWindowMessage(true));
         });
      }
   }
}
