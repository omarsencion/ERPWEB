//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data.Reportes.Base
{
    using System;
    using System.Collections.Generic;
    
    public partial class VWFAC_005
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdBodega { get; set; }
        public decimal IdCbteVta { get; set; }
        public string vt_tipoDoc { get; set; }
        public decimal IdCliente { get; set; }
        public string NomCliente { get; set; }
        public System.DateTime vt_fecha { get; set; }
        public double VRetenIVA { get; set; }
        public double VRetenFTE { get; set; }
        public Nullable<double> ValorACobrar { get; set; }
        public double VCobrado { get; set; }
        public Nullable<double> Saldo { get; set; }
        public string TipoDocumento { get; set; }
        public Nullable<bool> EsExportacion { get; set; }
        public string Su_Descripcion { get; set; }
        public string Su_CodigoEstablecimiento { get; set; }
        public decimal SubtotalIVASinDscto { get; set; }
        public decimal SubtotalSinIVASinDscto { get; set; }
        public decimal SubtotalSinDscto { get; set; }
        public decimal Descuento { get; set; }
        public decimal SubtotalIVAConDscto { get; set; }
        public decimal SubtotalSinIVAConDscto { get; set; }
        public decimal SubtotalConDscto { get; set; }
        public decimal ValorIVA { get; set; }
        public decimal Total { get; set; }
    }
}
