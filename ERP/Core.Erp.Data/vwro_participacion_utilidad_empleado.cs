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
    
    public partial class vwro_participacion_utilidad_empleado
    {
        public int IdEmpresa { get; set; }
        public int IdUtilidad { get; set; }
        public decimal IdEmpleado { get; set; }
        public double DiasTrabajados { get; set; }
        public double CargasFamiliares { get; set; }
        public double ValorIndividual { get; set; }
        public double ValorCargaFamiliar { get; set; }
        public double ValorExedenteIESS { get; set; }
        public double ValorTotal { get; set; }
        public int IdNomina { get; set; }
        public int IdNominaTipo_liq { get; set; }
        public int IdPeriodo { get; set; }
        public string Estado { get; set; }
        public string ca_descripcion { get; set; }
        public string pe_apellido { get; set; }
        public string pe_nombre { get; set; }
        public string pe_cedulaRuc { get; set; }
        public string em_status { get; set; }
        public Nullable<System.DateTime> em_fechaIngaRol { get; set; }
        public Nullable<System.DateTime> em_fecha_ingreso { get; set; }
        public Nullable<System.DateTime> em_fechaSalida { get; set; }
        public double UtilidadDerechoIndividual { get; set; }
        public double UtilidadCargaFamiliar { get; set; }
    }
}
