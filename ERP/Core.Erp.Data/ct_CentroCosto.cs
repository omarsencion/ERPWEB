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
    
    public partial class ct_CentroCosto
    {
        public ct_CentroCosto()
        {
            this.ct_CentroCosto1 = new HashSet<ct_CentroCosto>();
            this.ct_cbtecble_det = new HashSet<ct_cbtecble_det>();
            this.ct_cbtecble_Plantilla_det = new HashSet<ct_cbtecble_Plantilla_det>();
        }
    
        public int IdEmpresa { get; set; }
        public string IdCentroCosto { get; set; }
        public string IdCentroCostoPadre { get; set; }
        public int IdNivel { get; set; }
        public string cc_Descripcion { get; set; }
        public bool EsMovimiento { get; set; }
        public bool Estado { get; set; }
        public string IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string IdUsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string IdUsuarioAnulacion { get; set; }
        public Nullable<System.DateTime> FechaAnulacion { get; set; }
        public string MotivoAnulacion { get; set; }
    
        public virtual ICollection<ct_CentroCosto> ct_CentroCosto1 { get; set; }
        public virtual ct_CentroCosto ct_CentroCosto2 { get; set; }
        public virtual ct_CentroCostoNivel ct_CentroCostoNivel { get; set; }
        public virtual ICollection<ct_cbtecble_det> ct_cbtecble_det { get; set; }
        public virtual ICollection<ct_cbtecble_Plantilla_det> ct_cbtecble_Plantilla_det { get; set; }
    }
}
