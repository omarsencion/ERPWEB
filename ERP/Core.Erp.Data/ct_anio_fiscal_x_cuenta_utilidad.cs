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
    
    public partial class ct_anio_fiscal_x_cuenta_utilidad
    {
        public int IdEmpresa { get; set; }
        public int IdanioFiscal { get; set; }
        public string IdCtaCble { get; set; }
        public string observacion { get; set; }
        public Nullable<int> IdEmpresa_cbte_cierre { get; set; }
        public Nullable<int> IdTipoCbte_cbte_cierre { get; set; }
        public Nullable<decimal> IdCbteCble_cbte_cierre { get; set; }
    
        public virtual ct_anio_fiscal ct_anio_fiscal { get; set; }
        public virtual ct_plancta ct_plancta { get; set; }
        public virtual ct_cbtecble ct_cbtecble { get; set; }
    }
}
