//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class vwba_Conciliacion
    {
        public int IdEmpresa { get; set; }
        public decimal IdConciliacion { get; set; }
        public int IdBanco { get; set; }
        public int IdPeriodo { get; set; }
        public System.DateTime co_Fecha { get; set; }
        public double co_SaldoContable_MesAnt { get; set; }
        public double co_totalIng { get; set; }
        public double co_totalEgr { get; set; }
        public double co_SaldoContable_MesAct { get; set; }
        public string Estado { get; set; }
        public string co_Observacion { get; set; }
        public string ba_descripcion { get; set; }
        public string IdCtaCble { get; set; }
        public string Periodo { get; set; }
        public double co_SaldoBanco_anterior { get; set; }
        public string IdEstado_Concil_Cat { get; set; }
        public double co_SaldoBanco_EstCta { get; set; }
    }
}
