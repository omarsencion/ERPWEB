﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities_cuentas_por_cobrar : DbContext
    {
        public Entities_cuentas_por_cobrar()
            : base("name=Entities_cuentas_por_cobrar")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<cxc_Catalogo> cxc_Catalogo { get; set; }
        public DbSet<cxc_CatalogoTipo> cxc_CatalogoTipo { get; set; }
        public DbSet<cxc_cobro> cxc_cobro { get; set; }
        public DbSet<cxc_cobro_det> cxc_cobro_det { get; set; }
        public DbSet<cxc_cobro_tipo_motivo> cxc_cobro_tipo_motivo { get; set; }
        public DbSet<cxc_cobro_tipo_Param_conta_x_sucursal> cxc_cobro_tipo_Param_conta_x_sucursal { get; set; }
        public DbSet<cxc_cobro_x_ct_cbtecble> cxc_cobro_x_ct_cbtecble { get; set; }
        public DbSet<vwcxc_cobro> vwcxc_cobro { get; set; }
        public DbSet<vwcxc_cobro_det> vwcxc_cobro_det { get; set; }
        public DbSet<vwcxc_cobro_det_retencion> vwcxc_cobro_det_retencion { get; set; }
        public DbSet<vwcxc_cobro_para_retencion> vwcxc_cobro_para_retencion { get; set; }
        public DbSet<vwcxc_cartera_x_cobrar> vwcxc_cartera_x_cobrar { get; set; }
        public DbSet<cxc_liquidacion_comisiones> cxc_liquidacion_comisiones { get; set; }
        public DbSet<cxc_Parametro> cxc_Parametro { get; set; }
        public DbSet<cxc_liquidacion_comisiones_det> cxc_liquidacion_comisiones_det { get; set; }
        public DbSet<vwcxc_liquidacion_comisiones_det> vwcxc_liquidacion_comisiones_det { get; set; }
        public DbSet<vwcxc_liquidacion_comisiones_det_x_comisionar> vwcxc_liquidacion_comisiones_det_x_comisionar { get; set; }
        public DbSet<cxc_cobro_tipo> cxc_cobro_tipo { get; set; }
        public DbSet<cxc_MotivoLiquidacionTarjeta> cxc_MotivoLiquidacionTarjeta { get; set; }
        public DbSet<cxc_MotivoLiquidacionTarjeta_x_tb_sucursal> cxc_MotivoLiquidacionTarjeta_x_tb_sucursal { get; set; }
        public DbSet<vwcxc_MotivoLiquidacionTarjeta_x_tb_sucursal> vwcxc_MotivoLiquidacionTarjeta_x_tb_sucursal { get; set; }
        public DbSet<cxc_LiquidacionTarjeta> cxc_LiquidacionTarjeta { get; set; }
        public DbSet<cxc_LiquidacionTarjeta_x_cxc_cobro> cxc_LiquidacionTarjeta_x_cxc_cobro { get; set; }
        public DbSet<cxc_LiquidacionTarjetaDet> cxc_LiquidacionTarjetaDet { get; set; }
        public DbSet<vwcxc_LiquidacionTarjetaDet> vwcxc_LiquidacionTarjetaDet { get; set; }
    }
}
