﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.Contabilidad
{
    public class DinardapData_Info
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdBodega { get; set; }
        public decimal IdCliente { get; set; }
        public string Codigo { get; set; }
        public decimal IdCbteVta { get; set; }
        public string CodCbteVta { get; set; }
        public string vt_tipoDoc { get; set; }
        public string vt_serie1 { get; set; }
        public string vt_serie2 { get; set; }
        public string vt_NumFactura { get; set; }
        public string Su_Descripcion { get; set; }
        public string pe_nombreCompleto { get; set; }
        public string pe_cedulaRuc { get; set; }
        public Nullable<double> Valor_Original { get; set; }
        public double Total_Pagado { get; set; }
        public Nullable<double> Valor_x_Vencer { get; set; }
        public Nullable<double> x_Vencer_1_30_Dias { get; set; }
        public Nullable<double> x_Vencer_31_90_Dias { get; set; }
        public Nullable<double> x_Vencer_91_180_Dias { get; set; }
        public Nullable<double> x_Vencer_181_360_Dias { get; set; }
        public Nullable<double> x_Vencer_Mayor_a_360Dias { get; set; }
        public Nullable<double> Valor_Vencido { get; set; }
        public Nullable<double> Vencido_1_30_Dias { get; set; }
        public Nullable<double> Vencido_31_90_Dias { get; set; }
        public Nullable<double> Vencido_91_180_Dias { get; set; }
        public Nullable<double> Vencido_181_360_Dias { get; set; }
        public Nullable<double> Vencido_Mayor_a_360Dias { get; set; }
        public Nullable<System.DateTime> vt_fech_venc { get; set; }
        public System.DateTime vt_fecha { get; set; }
        public int Idtipo_cliente { get; set; }
        public Nullable<int> Dias_Vencidos { get; set; }
        public Nullable<decimal> Total { get; set; }
        public string pe_telefonoOfic { get; set; }
        public string Cod_Provincia { get; set; }
        public string Cod_Ciudad { get; set; }
        public string cod_parroquia { get; set; }
        public string pe_Naturaleza { get; set; }
        public string pe_sexo { get; set; }
        public string IdTipoDocumento { get; set; }
        public string IdEstadoCivil { get; set; }
        public Nullable<decimal> Plazo { get; set; }
        public string cod_entidad_dinardap { get; set; }
        public Nullable<int> cr_fechaCobro { get; set; }
        public Nullable<int> Valor_cobrado { get; set; }
    }
}
