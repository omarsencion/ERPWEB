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
    
    public partial class ba_parametros
    {
        public int IdEmpresa { get; set; }
        public string CiudadDefaultParaCrearCheques { get; set; }
        public int DiasTransaccionesAFuturo { get; set; }
        public Nullable<int> CantidadChequesAlerta { get; set; }
        public Nullable<bool> PermitirSobreGiro { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> FechaTransac { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> FechaUltMod { get; set; }
    }
}
