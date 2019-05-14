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
    
    public partial class fa_factura
    {
        public fa_factura()
        {
            this.fa_cuotas_x_doc = new HashSet<fa_cuotas_x_doc>();
            this.fa_factura_det = new HashSet<fa_factura_det>();
            this.fa_factura_x_ct_cbtecble = new HashSet<fa_factura_x_ct_cbtecble>();
            this.fa_factura_x_fa_guia_remision = new HashSet<fa_factura_x_fa_guia_remision>();
            this.fa_factura_x_in_Ing_Egr_Inven = new HashSet<fa_factura_x_in_Ing_Egr_Inven>();
        }
    
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdBodega { get; set; }
        public decimal IdCbteVta { get; set; }
        public string CodCbteVta { get; set; }
        public string vt_tipoDoc { get; set; }
        public string vt_serie1 { get; set; }
        public string vt_serie2 { get; set; }
        public string vt_NumFactura { get; set; }
        public Nullable<System.DateTime> Fecha_Autorizacion { get; set; }
        public string vt_autorizacion { get; set; }
        public decimal IdCliente { get; set; }
        public Nullable<int> IdContacto { get; set; }
        public int IdVendedor { get; set; }
        public int IdNivel { get; set; }
        public string IdCatalogo_FormaPago { get; set; }
        public System.DateTime vt_fecha { get; set; }
        public decimal vt_plazo { get; set; }
        public System.DateTime vt_fech_venc { get; set; }
        public string vt_tipo_venta { get; set; }
        public string vt_Observacion { get; set; }
        public string Estado { get; set; }
        public int IdCaja { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Transaccion { get; set; }
        public string IdUsuarioUltModi { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string MotivoAnulacion { get; set; }
        public Nullable<int> IdPuntoVta { get; set; }
        public Nullable<bool> esta_impresa { get; set; }
        public Nullable<System.DateTime> fecha_primera_cuota { get; set; }
        public Nullable<double> valor_abono { get; set; }
        public bool aprobada_enviar_sri { get; set; }
        public Nullable<bool> Generado { get; set; }
    
        public virtual fa_catalogo fa_catalogo { get; set; }
        public virtual fa_cliente fa_cliente { get; set; }
        public virtual fa_cliente_contactos fa_cliente_contactos { get; set; }
        public virtual ICollection<fa_cuotas_x_doc> fa_cuotas_x_doc { get; set; }
        public virtual ICollection<fa_factura_det> fa_factura_det { get; set; }
        public virtual fa_NivelDescuento fa_NivelDescuento { get; set; }
        public virtual fa_PuntoVta fa_PuntoVta { get; set; }
        public virtual fa_Vendedor fa_Vendedor { get; set; }
        public virtual ICollection<fa_factura_x_ct_cbtecble> fa_factura_x_ct_cbtecble { get; set; }
        public virtual fa_factura_x_cxc_cobro fa_factura_x_cxc_cobro { get; set; }
        public virtual ICollection<fa_factura_x_fa_guia_remision> fa_factura_x_fa_guia_remision { get; set; }
        public virtual ICollection<fa_factura_x_in_Ing_Egr_Inven> fa_factura_x_in_Ing_Egr_Inven { get; set; }
    }
}
