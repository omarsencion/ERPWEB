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
    
    public partial class ro_contrato
    {
        public int IdEmpresa { get; set; }
        public decimal IdEmpleado { get; set; }
        public decimal IdContrato { get; set; }
        public Nullable<int> IdNomina { get; set; }
        public string IdContrato_Tipo { get; set; }
        public string NumDocumento { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaFin { get; set; }
        public Nullable<double> Sueldo { get; set; }
        public string Estado { get; set; }
        public string IdUsuario { get; set; }
        public string Observacion { get; set; }
        public string MotiAnula { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> FechaHoraAnul { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public string EstadoContrato { get; set; }
    
        public virtual ro_Nomina_Tipo ro_Nomina_Tipo { get; set; }
        public virtual ro_empleado ro_empleado { get; set; }
    }
}
