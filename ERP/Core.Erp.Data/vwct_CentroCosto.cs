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
    
    public partial class vwct_CentroCosto
    {
        public int IdEmpresa { get; set; }
        public string IdCentroCosto { get; set; }
        public string IdCentroCostoPadre { get; set; }
        public int IdNivel { get; set; }
        public string cc_Descripcion { get; set; }
        public bool EsMovimiento { get; set; }
        public bool Estado { get; set; }
        public string nv_Descripcion { get; set; }
        public string cc_Descripcion_Padre { get; set; }
    }
}
