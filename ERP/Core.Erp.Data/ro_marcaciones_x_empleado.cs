//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ro_marcaciones_x_empleado
    {
        public ro_marcaciones_x_empleado()
        {
            this.ro_SancionesPorMarcaciones_det = new HashSet<ro_SancionesPorMarcaciones_det>();
        }
    
        public int IdEmpresa { get; set; }
        public decimal IdRegistro { get; set; }
        public int IdCalendadrio { get; set; }
        public decimal IdEmpleado { get; set; }
        public string IdTipoMarcaciones { get; set; }
        public Nullable<int> IdNomina { get; set; }
        public Nullable<int> IdSucursal { get; set; }
        public Nullable<System.TimeSpan> es_Hora { get; set; }
        public System.DateTime es_fechaRegistro { get; set; }
        public string Observacion { get; set; }
        public string IdUsuario { get; set; }
        public string Estado { get; set; }
        public System.DateTime Fecha_Transac { get; set; }
        public string Ip { get; set; }
        public string IdUsuarioUltModi { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string nom_pc { get; set; }
        public string Motivo_Anu { get; set; }
    
        public virtual ro_marcaciones_tipo ro_marcaciones_tipo { get; set; }
        public virtual ro_Nomina_Tipo ro_Nomina_Tipo { get; set; }
        public virtual ICollection<ro_SancionesPorMarcaciones_det> ro_SancionesPorMarcaciones_det { get; set; }
        public virtual ro_empleado ro_empleado { get; set; }
    }
}
