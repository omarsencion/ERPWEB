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
    
    public partial class vwro_SancionesPorMarcaciones_det
    {
        public int IdEmpresa { get; set; }
        public int IdAjuste { get; set; }
        public int Secuencia { get; set; }
        public int IdCalendario { get; set; }
        public decimal IdEmpleado { get; set; }
        public int IdSucursal { get; set; }
        public string IdTipoMarcaciones { get; set; }
        public double Minutos { get; set; }
        public string Observacion { get; set; }
        public string pe_nombreCompleto { get; set; }
        public string pe_apellido { get; set; }
        public string pe_nombre { get; set; }
        public string pe_cedulaRuc { get; set; }
        public string em_codigo { get; set; }
        public System.TimeSpan EsHoraIngreso { get; set; }
        public System.TimeSpan HoraIngreso { get; set; }
        public System.TimeSpan EsHoraSalida { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public System.TimeSpan HoraSalio { get; set; }
    }
}
