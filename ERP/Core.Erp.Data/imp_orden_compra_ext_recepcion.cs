//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class imp_orden_compra_ext_recepcion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public imp_orden_compra_ext_recepcion()
        {
            this.imp_orden_compra_ext_recepcion_det = new HashSet<imp_orden_compra_ext_recepcion_det>();
        }
    
        public int IdEmpresa { get; set; }
        public decimal IdRecepcion { get; set; }
        public System.DateTime or_fecha { get; set; }
        public string or_observacion { get; set; }
        public Nullable<int> IdEmpresa_oc { get; set; }
        public decimal IdOrdenCompraExt { get; set; }
        public int IdEmpresa_inv { get; set; }
        public int IdSucursal_inv { get; set; }
        public int IdBodega { get; set; }
        public int IdMovi_inven_tipo_inv { get; set; }
        public int IdMotivo_Inv { get; set; }
        public decimal IdNumMovi_inv { get; set; }
        public bool estado { get; set; }
        public string IdUsuario_creacion { get; set; }
        public Nullable<System.DateTime> fecha_creacion { get; set; }
        public string IdUsuario_modificacion { get; set; }
        public Nullable<System.DateTime> fecha_modificacion { get; set; }
        public string IdUsuario_anulacion { get; set; }
        public Nullable<System.DateTime> fecha_anulacion { get; set; }
    
        public virtual imp_orden_compra_ext imp_orden_compra_ext { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<imp_orden_compra_ext_recepcion_det> imp_orden_compra_ext_recepcion_det { get; set; }
    }
}
