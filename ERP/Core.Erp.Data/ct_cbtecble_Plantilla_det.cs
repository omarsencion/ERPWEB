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
    
    public partial class ct_cbtecble_Plantilla_det
    {
        public int IdEmpresa { get; set; }
        public decimal IdPlantilla { get; set; }
        public int secuencia { get; set; }
        public string IdCtaCble { get; set; }
        public double dc_Valor { get; set; }
        public string dc_Observacion { get; set; }
        public Nullable<int> IdPunto_cargo_grupo { get; set; }
        public Nullable<int> IdPunto_cargo { get; set; }
        public string IdCentroCosto { get; set; }
    
        public virtual ct_cbtecble_Plantilla ct_cbtecble_Plantilla { get; set; }
        public virtual ct_CentroCosto ct_CentroCosto { get; set; }
        public virtual ct_punto_cargo ct_punto_cargo { get; set; }
        public virtual ct_punto_cargo_grupo ct_punto_cargo_grupo { get; set; }
        public virtual ct_plancta ct_plancta { get; set; }
    }
}
