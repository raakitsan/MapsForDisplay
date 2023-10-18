using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MapsForDisplay
{
   public partial class LatLonCoordsMessage : ValueChangedMessage<string>
   {
      public LatLonCoordsMessage(string value) : base(value) { }

   }
}
