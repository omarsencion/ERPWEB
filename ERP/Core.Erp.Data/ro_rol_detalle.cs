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
    
    public partial class ro_rol_detalle
    {
        public int IdEmpresa { get; set; }
        public decimal IdRol { get; set; }
        public decimal IdEmpleado { get; set; }
        public string IdRubro { get; set; }
        public int Orden { get; set; }
        public double Valor { get; set; }
        public Nullable<bool> rub_visible_reporte { get; set; }
        public string Observacion { get; set; }
        public int IdSucursal { get; set; }
    
        public virtual ro_empleado ro_empleado { get; set; }
        public virtual ro_rol ro_rol { get; set; }
        public virtual ro_rubro_tipo ro_rubro_tipo { get; set; }
    }
}
