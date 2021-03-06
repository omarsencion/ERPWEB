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
    
    public partial class ro_catalogo
    {
        public ro_catalogo()
        {
            this.ro_cargaFamiliar = new HashSet<ro_cargaFamiliar>();
            this.ro_Parametros = new HashSet<ro_Parametros>();
            this.ro_contrato = new HashSet<ro_contrato>();
            this.ro_contrato1 = new HashSet<ro_contrato>();
            this.ro_prestamo = new HashSet<ro_prestamo>();
            this.ro_rubro_tipo = new HashSet<ro_rubro_tipo>();
        }
    
        public string CodCatalogo { get; set; }
        public int IdCatalogo { get; set; }
        public int IdTipoCatalogo { get; set; }
        public string ca_descripcion { get; set; }
        public string ca_estado { get; set; }
        public int ca_orden { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string nom_pc { get; set; }
        public string ip { get; set; }
        public string MotivoAnulacion { get; set; }
    
        public virtual ICollection<ro_cargaFamiliar> ro_cargaFamiliar { get; set; }
        public virtual ro_catalogoTipo ro_catalogoTipo { get; set; }
        public virtual ICollection<ro_Parametros> ro_Parametros { get; set; }
        public virtual ICollection<ro_contrato> ro_contrato { get; set; }
        public virtual ICollection<ro_contrato> ro_contrato1 { get; set; }
        public virtual ICollection<ro_prestamo> ro_prestamo { get; set; }
        public virtual ICollection<ro_rubro_tipo> ro_rubro_tipo { get; set; }
    }
}
