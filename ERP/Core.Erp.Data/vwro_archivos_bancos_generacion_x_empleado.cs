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
    
    public partial class vwro_archivos_bancos_generacion_x_empleado
    {
        public int IdEmpresa { get; set; }
        public decimal IdArchivo { get; set; }
        public int IdNomina { get; set; }
        public int IdNominaTipo { get; set; }
        public int IdPeriodo { get; set; }
        public double Valor { get; set; }
        public decimal IdEmpleado { get; set; }
        public bool pagacheque { get; set; }
        public string em_tipoCta { get; set; }
        public string em_NumCta { get; set; }
        public string pe_apellido { get; set; }
        public string pe_nombre { get; set; }
        public string pe_nombreCompleto { get; set; }
        public string pe_cedulaRuc { get; set; }
        public string IdTipoDocumento { get; set; }
        public int IdSucursal { get; set; }
        public int Secuencia { get; set; }
    }
}
