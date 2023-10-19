using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsForDisplay.ViewModels
{
   [ObservableObject]
   internal partial class SetPresPosViewModel
   {
      [ObservableProperty]
      public static string coord;
   }
}
