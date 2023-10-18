using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Map = Esri.ArcGISRuntime.Mapping.Map;

namespace MapsForDisplay.ViewModels;

/// <summary>
/// Provides map data to an application
/// </summary>

public partial class MapViewModel : INotifyPropertyChanged
{

   public MapViewModel()
    {
        _map = new Map(SpatialReferences.WebMercator)
        {
            InitialViewpoint = new Viewpoint(new Envelope(-180, -85, 180, 85, SpatialReferences.Wgs84)),
            Basemap = new Basemap(BasemapStyle.ArcGISStreets)
        };
      // from SetPresPosPage.cs
      //WeakReferenceMessenger.Default.Register<LatLonCoordsMessage>(this, HandleLatLonCoordsMessage);
   }
   //private async void HandleLatLonCoordsMessage(object recipient, LatLonCoordsMessage message)
   //{
   //   coords = message.Value;
   //}

   private Map _map;

    /// <summary>
    /// Gets or sets the map
    /// </summary>
    public Map Map
    {
        get => _map;
        set { _map = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Raises the <see cref="PropertyChanged" /> event
    /// </summary>
    /// <param name="propertyName">The name of the property that has changed</param>
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
             PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public event PropertyChangedEventHandler PropertyChanged;

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
