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
    
    public partial class ct_periodo
    {
        public ct_periodo()
        {
            this.ct_cbtecble = new HashSet<ct_cbtecble>();
        }
    
        public int IdEmpresa { get; set; }
        public int IdPeriodo { get; set; }
        public int IdanioFiscal { get; set; }
        public int pe_mes { get; set; }
        public System.DateTime pe_FechaIni { get; set; }
        public System.DateTime pe_FechaFin { get; set; }
        public string pe_cerrado { get; set; }
        public string pe_estado { get; set; }
    
        public virtual ct_anio_fiscal ct_anio_fiscal { get; set; }
        public virtual ICollection<ct_cbtecble> ct_cbtecble { get; set; }
    }
}
