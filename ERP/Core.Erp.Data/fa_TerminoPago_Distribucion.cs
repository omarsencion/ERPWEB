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
    
    public partial class fa_TerminoPago_Distribucion
    {
        public string IdTerminoPago { get; set; }
        public int Secuencia { get; set; }
        public int Num_Dias_Vcto { get; set; }
        public double Por_distribucion { get; set; }
    
        public virtual fa_TerminoPago fa_TerminoPago { get; set; }
    }
}
