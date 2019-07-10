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
    
    public partial class cp_proveedor
    {
        public cp_proveedor()
        {
            this.cp_SolicitudPago = new HashSet<cp_SolicitudPago>();
            this.cp_orden_giro = new HashSet<cp_orden_giro>();
            this.cp_nota_DebCre = new HashSet<cp_nota_DebCre>();
        }
    
        public int IdEmpresa { get; set; }
        public decimal IdProveedor { get; set; }
        public decimal IdPersona { get; set; }
        public string pr_codigo { get; set; }
        public string pr_contribuyenteEspecial { get; set; }
        public int pr_plazo { get; set; }
        public string pr_estado { get; set; }
        public string IdCiudad { get; set; }
        public string IdCtaCble_CXP { get; set; }
        public string IdCtaCble_Gasto { get; set; }
        public int IdClaseProveedor { get; set; }
        public string MotivoAnulacion { get; set; }
        public string IdTipoCta_acreditacion_cat { get; set; }
        public string num_cta_acreditacion { get; set; }
        public Nullable<int> IdBanco_acreditacion { get; set; }
        public bool es_empresa_relacionada { get; set; }
        public string pr_telefonos { get; set; }
        public string pr_celular { get; set; }
        public string pr_direccion { get; set; }
        public string pr_correo { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
    
        public virtual cp_proveedor_clase cp_proveedor_clase { get; set; }
        public virtual ICollection<cp_SolicitudPago> cp_SolicitudPago { get; set; }
        public virtual ICollection<cp_orden_giro> cp_orden_giro { get; set; }
        public virtual ICollection<cp_nota_DebCre> cp_nota_DebCre { get; set; }
    }
}
