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
    
    public partial class vwin_devolucion_inven_det
    {
        public int IdEmpresa { get; set; }
        public decimal IdDev_Inven { get; set; }
        public int secuencia { get; set; }
        public int inv_IdEmpresa { get; set; }
        public int inv_IdSucursal { get; set; }
        public int inv_IdMovi_inven_tipo { get; set; }
        public decimal inv_IdNumMovi { get; set; }
        public int inv_Secuencia { get; set; }
        public double cant_devuelta { get; set; }
        public string pr_descripcion { get; set; }
        public string nom_presentacion { get; set; }
        public double dm_cantidad_sinConversion { get; set; }
        public Nullable<System.DateTime> lote_fecha_vcto { get; set; }
        public string lote_num_lote { get; set; }
        public int IdBodega { get; set; }
        public string NomUnidad { get; set; }
        public double mv_costo_sinConversion { get; set; }
        public string IdUnidadMedida_sinConversion { get; set; }
        public decimal IdProducto { get; set; }
    }
}
