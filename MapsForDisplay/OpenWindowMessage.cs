using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MapsForDisplay
{
   public class OpenWindowMessage : ValueChangedMessage<bool>
   {
      public OpenWindowMessage(bool value) : base(value) { }
   }
}
