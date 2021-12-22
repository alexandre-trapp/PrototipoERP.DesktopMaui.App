using System;

namespace PrototipoERP.DesktopMaui.Models
{
    public class LembreteModel
    {
        public long UsuarioId { get; set; }
        public string Usuario { get; set; }
        public DateTime DataHora { get; set; }
        public string CriadoEm { get; set; }
        public string Texto { get; set; }
    }
}
