//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class in_devolucion_inven
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public in_devolucion_inven()
        {
            this.in_devolucion_inven_det = new HashSet<in_devolucion_inven_det>();
        }
    
        public int IdEmpresa { get; set; }
        public decimal IdDev_Inven { get; set; }
        public string cod_Dev_Inven { get; set; }
        public System.DateTime Fecha { get; set; }
        public int IdEmpresa_inv { get; set; }
        public int IdSucursal_inv { get; set; }
        public int IdMovi_inven_tipo_inv { get; set; }
        public decimal IdNumMovi_inv { get; set; }
        public int dev_IdEmpresa { get; set; }
        public int dev_IdSucursal { get; set; }
        public int dev_IdMovi_inven_tipo { get; set; }
        public decimal dev_IdNumMovi { get; set; }
        public string dev_signo { get; set; }
        public string observacion { get; set; }
        public bool Estado { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public string IdUsuarioUltModi { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdusuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string MotivoAnulacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<in_devolucion_inven_det> in_devolucion_inven_det { get; set; }
        public virtual in_Ing_Egr_Inven in_Ing_Egr_Inven { get; set; }
        public virtual in_Ing_Egr_Inven in_Ing_Egr_Inven1 { get; set; }
    }
}
