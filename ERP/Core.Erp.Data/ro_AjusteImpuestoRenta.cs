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
    
    public partial class ro_AjusteImpuestoRenta
    {
        public ro_AjusteImpuestoRenta()
        {
            this.ro_AjusteImpuestoRentaDet = new HashSet<ro_AjusteImpuestoRentaDet>();
            this.ro_AjusteImpuestoRentaDetOI = new HashSet<ro_AjusteImpuestoRentaDetOI>();
        }
    
        public int IdEmpresa { get; set; }
        public decimal IdAjuste { get; set; }
        public int IdAnio { get; set; }
        public System.DateTime Fecha { get; set; }
        public System.DateTime FechaCorte { get; set; }
        public Nullable<int> IdSucursal { get; set; }
        public string Observacion { get; set; }
        public bool Estado { get; set; }
        public string IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string IdUsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string IdUsuarioAnulacion { get; set; }
        public Nullable<System.DateTime> FechaAnulacion { get; set; }
        public string MotivoAnulacion { get; set; }
    
        public virtual ICollection<ro_AjusteImpuestoRentaDet> ro_AjusteImpuestoRentaDet { get; set; }
        public virtual ICollection<ro_AjusteImpuestoRentaDetOI> ro_AjusteImpuestoRentaDetOI { get; set; }
    }
}
