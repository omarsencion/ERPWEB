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
    
    public partial class vwro_archivos_bancos_generacion
    {
        public int IdEmpresa { get; set; }
        public decimal IdArchivo { get; set; }
        public int IdNomina { get; set; }
        public int IdNominaTipo { get; set; }
        public int IdPeriodo { get; set; }
        public int IdCuentaBancaria { get; set; }
        public int IdProceso { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionProcesoNomina { get; set; }
        public System.DateTime pe_FechaIni { get; set; }
        public System.DateTime pe_FechaFin { get; set; }
        public string NombreProceso { get; set; }
        public string estado { get; set; }
        public string IdProceso_bancario_tipo { get; set; }
        public Nullable<int> IdSucursal { get; set; }
        public string Su_Descripcion { get; set; }
    }
}
