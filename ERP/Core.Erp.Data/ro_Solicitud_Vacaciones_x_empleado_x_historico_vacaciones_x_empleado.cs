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
    
    public partial class ro_Solicitud_Vacaciones_x_empleado_x_historico_vacaciones_x_empleado
    {
        public int IdEmpresa_sol { get; set; }
        public decimal IdEmpleado_sol { get; set; }
        public int IdSolicitud { get; set; }
        public int IdEmpresa_vaca { get; set; }
        public decimal IdEmpleado_vaca { get; set; }
        public int IdVacacion { get; set; }
        public string Observacion { get; set; }
    
        public virtual ro_historico_vacaciones_x_empleado ro_historico_vacaciones_x_empleado { get; set; }
        public virtual ro_Solicitud_Vacaciones_x_empleado ro_Solicitud_Vacaciones_x_empleado { get; set; }
    }
}