//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class fa_TipoNota
    {
        public fa_TipoNota()
        {
            this.fa_notaCreDeb = new HashSet<fa_notaCreDeb>();
        }
    
        public int IdEmpresa { get; set; }
        public int IdTipoNota { get; set; }
        public string CodTipoNota { get; set; }
        public string Tipo { get; set; }
        public string No_Descripcion { get; set; }
        public Nullable<bool> GeneraMoviInven { get; set; }
        public string IdCtaCble { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string Estado { get; set; }
        public string MotiAnula { get; set; }
    
        public virtual ICollection<fa_notaCreDeb> fa_notaCreDeb { get; set; }
    }
}
