//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ct_parametro
    {
        public int IdEmpresa { get; set; }
        public int IdTipoCbte_SaldoInicial { get; set; }
        public int IdTipoCbte_AsientoCierre_Anual { get; set; }
        public bool P_Se_Muestra_Todas_las_ctas_en_combos { get; set; }
        public int DiasTransaccionesAFuturo { get; set; }
        public Nullable<bool> EsCentroCostoObligatorio { get; set; }
        public Nullable<bool> AnularConFechaDeDocumento { get; set; }
    
        public virtual ct_cbtecble_tipo ct_cbtecble_tipo { get; set; }
        public virtual ct_cbtecble_tipo ct_cbtecble_tipo1 { get; set; }
    }
}
