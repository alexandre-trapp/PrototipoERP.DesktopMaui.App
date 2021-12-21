using PrototipoERP.DesktopMaui.Models;
using System.Collections.ObjectModel;

namespace PrototipoERP.DesktopMaui
{
    public static class AppState
    {
        public static ObservableCollection<LembreteModel> Lembretes { get; set; } = new();
    }
}
