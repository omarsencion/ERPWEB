//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class vwin_Ing_Egr_Inven_distribucion_det
    {
        public long IdRow { get; set; }
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdMovi_inven_tipo { get; set; }
        public decimal IdNumMovi { get; set; }
        public Nullable<decimal> IdProducto_padre { get; set; }
        public decimal IdProducto { get; set; }
        public string pr_descripcion { get; set; }
        public string IdUnidadMedida { get; set; }
        public double dm_cantidad { get; set; }
        public double mv_costo { get; set; }
        public Nullable<System.DateTime> lote_fecha_vcto { get; set; }
        public string lote_num_lote { get; set; }
        public Nullable<System.DateTime> lote_fecha_fab { get; set; }
    }
}
