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
    
    public partial class VWBAN_003
    {
        public string CodTipoCbteBan { get; set; }
        public int IdEmpresa { get; set; }
        public decimal IdCbteCble { get; set; }
        public int IdTipocbte { get; set; }
        public int IdBanco { get; set; }
        public string ba_descripcion { get; set; }
        public System.DateTime cb_Fecha { get; set; }
        public string cb_Observacion { get; set; }
        public string Estado { get; set; }
        public Nullable<int> IdTipoNota { get; set; }
        public string pe_nombreCompleto { get; set; }
        public string IdCtaCble { get; set; }
        public string pc_Cuenta { get; set; }
        public double dc_Valor { get; set; }
        public double dc_Valor_Debe { get; set; }
        public Nullable<double> dc_Valor_Haber { get; set; }
        public string cb_Cheque { get; set; }
        public string cb_giradoA { get; set; }
    }
}
