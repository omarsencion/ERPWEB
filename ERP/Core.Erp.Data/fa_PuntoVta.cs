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
    
    public partial class fa_PuntoVta
    {
        public fa_PuntoVta()
        {
            this.fa_notaCreDeb = new HashSet<fa_notaCreDeb>();
            this.fa_factura = new HashSet<fa_factura>();
            this.fa_guia_remision = new HashSet<fa_guia_remision>();
        }
    
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdPuntoVta { get; set; }
        public string cod_PuntoVta { get; set; }
        public string nom_PuntoVta { get; set; }
        public bool estado { get; set; }
        public int IdBodega { get; set; }
        public int IdCaja { get; set; }
        public string IPImpresora { get; set; }
        public Nullable<int> NumCopias { get; set; }
        public bool CobroAutomatico { get; set; }
        public string codDocumentoTipo { get; set; }
        public bool EsElectronico { get; set; }
        public string IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string IdUsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string IdUsuarioAnulacion { get; set; }
        public Nullable<System.DateTime> FechaAnulacion { get; set; }
        public string MotivoAnulacion { get; set; }
    
        public virtual ICollection<fa_notaCreDeb> fa_notaCreDeb { get; set; }
        public virtual ICollection<fa_factura> fa_factura { get; set; }
        public virtual ICollection<fa_guia_remision> fa_guia_remision { get; set; }
    }
}
