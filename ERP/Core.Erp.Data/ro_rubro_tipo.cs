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
    
    public partial class ro_rubro_tipo
    {
        public ro_rubro_tipo()
        {
            this.ro_Acta_Finiquito_Detalle = new HashSet<ro_Acta_Finiquito_Detalle>();
            this.ro_Config_Param_contable = new HashSet<ro_Config_Param_contable>();
            this.ro_empleado_novedad_det = new HashSet<ro_empleado_novedad_det>();
            this.ro_empleado_x_ro_rubro = new HashSet<ro_empleado_x_ro_rubro>();
            this.ro_empleado_x_rubro_acumulado = new HashSet<ro_empleado_x_rubro_acumulado>();
            this.ro_EmpleadoNovedadCargaMasiva = new HashSet<ro_EmpleadoNovedadCargaMasiva>();
            this.ro_prestamo = new HashSet<ro_prestamo>();
            this.ro_rol_detalle = new HashSet<ro_rol_detalle>();
            this.ro_rubros_calculados = new HashSet<ro_rubros_calculados>();
            this.ro_rubros_calculados1 = new HashSet<ro_rubros_calculados>();
            this.ro_rubros_calculados2 = new HashSet<ro_rubros_calculados>();
            this.ro_rubros_calculados3 = new HashSet<ro_rubros_calculados>();
            this.ro_rubros_calculados4 = new HashSet<ro_rubros_calculados>();
            this.ro_rubros_calculados5 = new HashSet<ro_rubros_calculados>();
            this.ro_rubros_calculados6 = new HashSet<ro_rubros_calculados>();
            this.ro_rubros_calculados7 = new HashSet<ro_rubros_calculados>();
            this.ro_rubros_calculados8 = new HashSet<ro_rubros_calculados>();
            this.ro_rubros_calculados9 = new HashSet<ro_rubros_calculados>();
            this.ro_rubros_calculados10 = new HashSet<ro_rubros_calculados>();
            this.ro_rubros_calculados11 = new HashSet<ro_rubros_calculados>();
            this.ro_rubros_calculados12 = new HashSet<ro_rubros_calculados>();
            this.ro_rubros_calculados13 = new HashSet<ro_rubros_calculados>();
            this.ro_rubros_calculados14 = new HashSet<ro_rubros_calculados>();
            this.ro_HorasProfesores_det = new HashSet<ro_HorasProfesores_det>();
        }
    
        public int IdEmpresa { get; set; }
        public string IdRubro { get; set; }
        public string rub_codigo { get; set; }
        public string ru_codRolGen { get; set; }
        public string ru_descripcion { get; set; }
        public string NombreCorto { get; set; }
        public string ru_tipo { get; set; }
        public string ru_estado { get; set; }
        public int ru_orden { get; set; }
        public bool rub_concep { get; set; }
        public string rub_ctacon { get; set; }
        public Nullable<int> rub_grupo { get; set; }
        public bool rub_provision { get; set; }
        public bool rub_nocontab { get; set; }
        public bool rub_aplica_IESS { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public bool rub_acumula { get; set; }
        public bool rub_acumula_descuento { get; set; }
    
        public virtual ICollection<ro_Acta_Finiquito_Detalle> ro_Acta_Finiquito_Detalle { get; set; }
        public virtual ICollection<ro_Config_Param_contable> ro_Config_Param_contable { get; set; }
        public virtual ICollection<ro_empleado_novedad_det> ro_empleado_novedad_det { get; set; }
        public virtual ICollection<ro_empleado_x_ro_rubro> ro_empleado_x_ro_rubro { get; set; }
        public virtual ICollection<ro_empleado_x_rubro_acumulado> ro_empleado_x_rubro_acumulado { get; set; }
        public virtual ICollection<ro_EmpleadoNovedadCargaMasiva> ro_EmpleadoNovedadCargaMasiva { get; set; }
        public virtual ICollection<ro_prestamo> ro_prestamo { get; set; }
        public virtual ICollection<ro_rol_detalle> ro_rol_detalle { get; set; }
        public virtual ICollection<ro_rubros_calculados> ro_rubros_calculados { get; set; }
        public virtual ICollection<ro_rubros_calculados> ro_rubros_calculados1 { get; set; }
        public virtual ICollection<ro_rubros_calculados> ro_rubros_calculados2 { get; set; }
        public virtual ICollection<ro_rubros_calculados> ro_rubros_calculados3 { get; set; }
        public virtual ICollection<ro_rubros_calculados> ro_rubros_calculados4 { get; set; }
        public virtual ICollection<ro_rubros_calculados> ro_rubros_calculados5 { get; set; }
        public virtual ICollection<ro_rubros_calculados> ro_rubros_calculados6 { get; set; }
        public virtual ICollection<ro_rubros_calculados> ro_rubros_calculados7 { get; set; }
        public virtual ICollection<ro_rubros_calculados> ro_rubros_calculados8 { get; set; }
        public virtual ICollection<ro_rubros_calculados> ro_rubros_calculados9 { get; set; }
        public virtual ICollection<ro_rubros_calculados> ro_rubros_calculados10 { get; set; }
        public virtual ICollection<ro_rubros_calculados> ro_rubros_calculados11 { get; set; }
        public virtual ICollection<ro_rubros_calculados> ro_rubros_calculados12 { get; set; }
        public virtual ICollection<ro_rubros_calculados> ro_rubros_calculados13 { get; set; }
        public virtual ICollection<ro_rubros_calculados> ro_rubros_calculados14 { get; set; }
        public virtual ICollection<ro_HorasProfesores_det> ro_HorasProfesores_det { get; set; }
    }
}
