﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Core.Erp.Bus.Reportes.CuentasPorPagar;
using Core.Erp.Info.Reportes.CuentasPorPagar;
using System.Collections.Generic;
using Core.Erp.Bus.General;

namespace Core.Erp.Web.Reportes.CuentasPorPagar
{
    public partial class CXP_016_Rpt : DevExpress.XtraReports.UI.XtraReport
    {
        public string usuario { get; set; }
        public string empresa { get; set; }
        public int[] IntArray { get; set; }

        public CXP_016_Rpt()
        {
            InitializeComponent();
        }

        private void CXP_016_Rpt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                lbl_fecha.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
                lbl_empresa.Text = empresa;
                lbl_usuario.Text = usuario;
                int IdEmpresa = p_IdEmpresa.Value == null ? 0 : Convert.ToInt32(p_IdEmpresa.Value);
                DateTime fechaIni = p_FechaIni.Value == null ? DateTime.Now : Convert.ToDateTime(p_FechaIni.Value);
                DateTime fechaFin = p_FechaFin.Value == null ? DateTime.Now : Convert.ToDateTime(p_FechaFin.Value);
                string IdUsuario = string.IsNullOrEmpty(p_IdUsuario.Value.ToString()) ? "" : p_IdUsuario.Value.ToString();
                bool MostrarSaldo0 = string.IsNullOrEmpty(p_MostrarSaldo0.Value.ToString()) ? false : Convert.ToBoolean(p_MostrarSaldo0.Value);
                int IdClaseProveedor = string.IsNullOrEmpty(p_IdClaseProveedor.Value.ToString()) ? 0 : Convert.ToInt32(p_IdClaseProveedor.Value);

                CXP_016_Bus bus_rpt = new CXP_016_Bus();
                List<CXP_016_Info> lst_rpt = new List<CXP_016_Info>();

                tb_FiltroReportes_Bus bus_filtro = new tb_FiltroReportes_Bus();
                bus_filtro.GuardarDB(IdEmpresa, IntArray, IdUsuario);

                lst_rpt = bus_rpt.GetList(IdEmpresa, IdUsuario, MostrarSaldo0, fechaIni, fechaFin, IdClaseProveedor);
                this.DataSource = lst_rpt;

                tb_empresa_Bus bus_empresa = new tb_empresa_Bus();
                var emp = bus_empresa.get_info(IdEmpresa);
                if (emp != null && emp.em_logo != null)
                {
                    ImageConverter obj = new ImageConverter();
                    lbl_imagen.Image = (Image)obj.ConvertFrom(emp.em_logo);
                }
            }
            catch (Exception)
            {
                
            }
        }
    }
}
