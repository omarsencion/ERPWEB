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
    
    public partial class ro_NominasPagosCheques
    {
        public ro_NominasPagosCheques()
        {
            this.ro_NominasPagosCheques_det = new HashSet<ro_NominasPagosCheques_det>();
        }
    
        public int IdEmpresa { get; set; }
        public int IdTransaccion { get; set; }
        public int IdNomina_Tipo { get; set; }
        public int IdNomina_TipoLiqui { get; set; }
        public int IdPeriodo { get; set; }
        public string Observacion { get; set; }
        public bool Estado { get; set; }
        public string IdUsuario { get; set; }
        public string IdUsuarioAnu { get; set; }
        public string MotivoAnu { get; set; }
        public string IdUsuarioUltModi { get; set; }
        public Nullable<System.DateTime> FechaAnu { get; set; }
        public System.DateTime FechaTransac { get; set; }
        public Nullable<System.DateTime> FechaUltModi { get; set; }
    
        public virtual ro_Nomina_Tipoliqui ro_Nomina_Tipoliqui { get; set; }
        public virtual ICollection<ro_NominasPagosCheques_det> ro_NominasPagosCheques_det { get; set; }
    }
}