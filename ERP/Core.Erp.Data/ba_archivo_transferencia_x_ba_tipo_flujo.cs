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
    
    public partial class ba_archivo_transferencia_x_ba_tipo_flujo
    {
        public int IdEmpresa { get; set; }
        public decimal IdArchivo { get; set; }
        public int Secuencia { get; set; }
        public decimal IdTipoFlujo { get; set; }
        public double Porcentaje { get; set; }
        public double Valor { get; set; }
    
        public virtual ba_TipoFlujo ba_TipoFlujo { get; set; }
        public virtual ba_Archivo_Transferencia ba_Archivo_Transferencia { get; set; }
    }
}
