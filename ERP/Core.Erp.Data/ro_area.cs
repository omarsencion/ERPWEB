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
    
    public partial class ro_area
    {
        public ro_area()
        {
            this.ro_area_x_departamento = new HashSet<ro_area_x_departamento>();
            this.ro_Config_Param_contable = new HashSet<ro_Config_Param_contable>();
        }
    
        public int IdEmpresa { get; set; }
        public int IdDivision { get; set; }
        public int IdArea { get; set; }
        public string Descripcion { get; set; }
        public string estado { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string nom_pc { get; set; }
        public string ip { get; set; }
        public string MotiAnula { get; set; }
    
        public virtual ro_Division ro_Division { get; set; }
        public virtual ICollection<ro_area_x_departamento> ro_area_x_departamento { get; set; }
        public virtual ICollection<ro_Config_Param_contable> ro_Config_Param_contable { get; set; }
    }
}
