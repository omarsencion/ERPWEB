﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entity_facturacion_electronica : DbContext
    {
        public Entity_facturacion_electronica()
            : base("name=Entity_facturacion_electronica")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tb_facturas_eventos> tb_facturas_eventos { get; set; }
        public virtual DbSet<vwfe_factura> vwfe_factura { get; set; }
        public virtual DbSet<vwfe_factura_detalle> vwfe_factura_detalle { get; set; }
        public virtual DbSet<vwfe_factura_impuestos> vwfe_factura_impuestos { get; set; }
        public virtual DbSet<vwfe_guia_remision> vwfe_guia_remision { get; set; }
        public virtual DbSet<vwfe_guia_remision_detalle> vwfe_guia_remision_detalle { get; set; }
        public virtual DbSet<vwfe_guia_remision_x_factura> vwfe_guia_remision_x_factura { get; set; }
        public virtual DbSet<vwfe_nota_credito> vwfe_nota_credito { get; set; }
        public virtual DbSet<vwfe_nota_credito_detalle> vwfe_nota_credito_detalle { get; set; }
        public virtual DbSet<vwfe_nota_credito_impuestos> vwfe_nota_credito_impuestos { get; set; }
        public virtual DbSet<vwfe_nota_debito> vwfe_nota_debito { get; set; }
        public virtual DbSet<vwfe_nota_debito_detalle> vwfe_nota_debito_detalle { get; set; }
        public virtual DbSet<vwfe_nota_debito_impuestos> vwfe_nota_debito_impuestos { get; set; }
        public virtual DbSet<vwfe_retencion> vwfe_retencion { get; set; }
        public virtual DbSet<vwfe_retencion_detalle> vwfe_retencion_detalle { get; set; }
        public virtual DbSet<vwfe_documentos_peniente_enviar_sri> vwfe_documentos_peniente_enviar_sri { get; set; }
    }
}
