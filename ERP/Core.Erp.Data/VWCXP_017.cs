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
    
    public partial class VWCXP_017
    {
        public int IdEmpresa { get; set; }
        public decimal IdOrdenPago { get; set; }
        public string IdTipo_op { get; set; }
        public string IdTipo_Persona { get; set; }
        public decimal IdPersona { get; set; }
        public decimal IdEntidad { get; set; }
        public System.DateTime Fecha { get; set; }
        public string IdEstadoAprobacion { get; set; }
        public string IdFormaPago { get; set; }
        public string Estado { get; set; }
        public string pe_nombreCompleto { get; set; }
        public Nullable<double> Total_OP { get; set; }
        public double Total_cancelado { get; set; }
        public Nullable<double> Saldo { get; set; }
        public string Observacion { get; set; }
        public Nullable<int> IdTipoFlujo { get; set; }
        public string nom_tipoFlujo { get; set; }
        public string EstadoCancelacion { get; set; }
        public string Descripcion { get; set; }
        public int IdSucursal { get; set; }
        public string Su_Descripcion { get; set; }
    }
}