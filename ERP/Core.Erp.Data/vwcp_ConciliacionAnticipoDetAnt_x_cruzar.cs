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
    
    public partial class vwcp_ConciliacionAnticipoDetAnt_x_cruzar
    {
        public int IdEmpresa { get; set; }
        public decimal IdOrdenPago { get; set; }
        public int IdSucursal { get; set; }
        public decimal IdProveedor { get; set; }
        public string pe_nombreCompleto { get; set; }
        public string Observacion { get; set; }
        public System.DateTime Fecha { get; set; }
        public double ValorOP { get; set; }
        public double MontoAplicado { get; set; }
        public double Saldo { get; set; }
    }
}
