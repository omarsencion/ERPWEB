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
    
    public partial class Entities_general : DbContext
    {
        public Entities_general()
            : base("name=Entities_general")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tb_sucursal> tb_sucursal { get; set; }
        public virtual DbSet<tb_pais> tb_pais { get; set; }
        public virtual DbSet<tb_CatalogoTipo> tb_CatalogoTipo { get; set; }
        public virtual DbSet<tb_Catalogo> tb_Catalogo { get; set; }
        public virtual DbSet<tb_empresa> tb_empresa { get; set; }
        public virtual DbSet<tb_banco> tb_banco { get; set; }
        public virtual DbSet<tb_transportista> tb_transportista { get; set; }
        public virtual DbSet<tb_sis_Impuesto_Tipo> tb_sis_Impuesto_Tipo { get; set; }
        public virtual DbSet<tb_sis_Impuesto> tb_sis_Impuesto { get; set; }
        public virtual DbSet<tb_sis_Impuesto_x_ctacble> tb_sis_Impuesto_x_ctacble { get; set; }
        public virtual DbSet<tb_bodega> tb_bodega { get; set; }
        public virtual DbSet<tb_mes> tb_mes { get; set; }
        public virtual DbSet<tb_persona> tb_persona { get; set; }
        public virtual DbSet<tb_modulo> tb_modulo { get; set; }
        public virtual DbSet<tb_sis_Documento_Tipo> tb_sis_Documento_Tipo { get; set; }
        public virtual DbSet<tb_sis_Documento_Tipo_Talonario> tb_sis_Documento_Tipo_Talonario { get; set; }
        public virtual DbSet<tb_ciudad> tb_ciudad { get; set; }
        public virtual DbSet<tb_parroquia> tb_parroquia { get; set; }
        public virtual DbSet<vwtb_pais> vwtb_pais { get; set; }
        public virtual DbSet<tb_persona_tipo> tb_persona_tipo { get; set; }
        public virtual DbSet<tb_region> tb_region { get; set; }
        public virtual DbSet<vwtb_ciudad_id> vwtb_ciudad_id { get; set; }
        public virtual DbSet<vwtb_provincia> vwtb_provincia { get; set; }
        public virtual DbSet<vwtb_parroquia> vwtb_parroquia { get; set; }
        public virtual DbSet<tb_provincia> tb_provincia { get; set; }
        public virtual DbSet<tb_sis_reporte_x_seg_usuario> tb_sis_reporte_x_seg_usuario { get; set; }
        public virtual DbSet<tb_sis_reporte> tb_sis_reporte { get; set; }
    }
}
