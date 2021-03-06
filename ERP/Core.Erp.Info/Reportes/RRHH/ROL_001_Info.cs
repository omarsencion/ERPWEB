﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.Reportes.RRHH
{
   public class ROL_001_Info
    {
        public Nullable<int> IdEmpresa { get; set; }
        public Nullable<int> IdNominaTipo { get; set; }
        public Nullable<int> IdNominaTipoLiqui { get; set; }
        public string Descripcion { get; set; }
        public string Observacion { get; set; }
        public string Cerrado { get; set; }
        public string de_descripcion { get; set; }
        public decimal IdEmpleado { get; set; }
        public string IdRubro { get; set; }
        public int Orden { get; set; }
        public Nullable<bool> rub_visible_reporte { get; set; }
        public string pe_nombre { get; set; }
        public string pe_nombreCompleto { get; set; }
        public string pe_cedulaRuc { get; set; }
        public string em_codigo { get; set; }
        public Nullable<int> IdDepartamento { get; set; }
        public Nullable<int> IdArea { get; set; }
        public Nullable<int> IdDivision { get; set; }
        public string Area { get; set; }
        public string Division { get; set; }
        public Nullable<System.DateTime> pe_FechaIni { get; set; }
        public Nullable<System.DateTime> pe_FechaFin { get; set; }
        public string pe_estado { get; set; }
        public string Nomina { get; set; }
        public Nullable<int> IdPeriodo { get; set; }
        public string ru_codRolGen { get; set; }
        public string pe_apellido { get; set; }
        public string ru_descripcion { get; set; }
        public string NombreCorto { get; set; }
        public string DescripcionProcesoNomina { get; set; }
        public double Valor { get; set; }
        public string Su_Descripcion { get; set; }
        public Nullable<System.DateTime> em_fechaIngaRol { get; set; }
        public string Periodo { get; set; }
        public string em_ruc { get; set; }
        public Nullable<int> IdSucursal { get; set; }

        public string Empleado { get; set; }
    }
}
