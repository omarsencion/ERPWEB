﻿using Core.Erp.Bus.Banco;
using Core.Erp.Bus.Caja;
using Core.Erp.Bus.CuentasPorCobrar;
using Core.Erp.Bus.General;
using Core.Erp.Info.CuentasPorCobrar;
using Core.Erp.Info.General;
using Core.Erp.Info.Helps;
using Core.Erp.Web.Helps;
using DevExpress.Web;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core.Erp.Web.Areas.CuentasPorCobrar.Controllers
{
    public class CobranzaController : Controller
    {
        tb_sucursal_Bus bus_sucursal = new tb_sucursal_Bus();
        cxc_cobro_Bus bus_cobro = new cxc_cobro_Bus();
        caj_Caja_Bus bus_caja = new caj_Caja_Bus();
        caj_parametro_Bus bus_param_caja = new caj_parametro_Bus();
        cxc_cobro_tipo_Bus bus_cobro_tipo = new cxc_cobro_tipo_Bus();
        tb_persona_Bus bus_persona = new tb_persona_Bus();
        tb_banco_Bus bus_banco = new tb_banco_Bus();
        ba_Banco_Cuenta_Bus bus_banco_cuenta = new ba_Banco_Cuenta_Bus();
        cxc_cobro_det_Bus bus_det = new cxc_cobro_det_Bus();
        cxc_cobro_det_List list_det = new cxc_cobro_det_List();

        #region Metodos ComboBox bajo demanda
        public ActionResult CmbCliente_Cobranza()
        {
            cxc_cobro_Info model = new cxc_cobro_Info();
            return PartialView("_CmbCliente_Cobranza", model);
        }
        public List<tb_persona_Info> get_list_bajo_demanda(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            return bus_persona.get_list_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa), cl_enumeradores.eTipoPersona.CLIENTE.ToString());
        }
        public tb_persona_Info get_info_bajo_demanda(ListEditItemRequestedByValueEventArgs args)
        {
            return bus_persona.get_info_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa), cl_enumeradores.eTipoPersona.CLIENTE.ToString());
        }
        #endregion

        public ActionResult Index()
        {
            cl_filtros_Info model = new cl_filtros_Info
            {
                IdSucursal = Convert.ToInt32(SessionFixed.IdSucursal)
            };
            cargar_combos_consulta();
            return View(model);
        }
        private void cargar_combos_consulta()
        {
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var lst_sucursal = bus_sucursal.get_list(IdEmpresa, false);
            ViewBag.lst_sucursal = lst_sucursal;
        }

        private void cargar_combos()
        {
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var lst_sucursal = bus_sucursal.get_list(IdEmpresa, false);
            ViewBag.lst_sucursal = lst_sucursal;

            var lst_caja = bus_caja.get_list(IdEmpresa, false);
            ViewBag.lst_caja = lst_caja;

            var lst_cobro_tipo = bus_cobro_tipo.get_list(false);
            ViewBag.lst_cobro_tipo = lst_cobro_tipo;

            var lst_banco = bus_banco.get_list(false);
            ViewBag.lst_banco = lst_banco;

            var lst_banco_cuenta = bus_banco_cuenta.get_list(IdEmpresa, false);
            ViewBag.lst_banco_cuenta = lst_banco_cuenta;
        }
        [HttpPost]
        public ActionResult Index(cl_filtros_Info model)
        {
            cargar_combos_consulta();
            return View(model);
        }

        public ActionResult Nuevo()
        {
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            int IdSucursal = Convert.ToInt32(SessionFixed.IdSucursal);
            var param_caja = bus_param_caja.get_info(IdEmpresa);
            cxc_cobro_Info model = new cxc_cobro_Info
            {
                IdEmpresa = IdEmpresa,
                IdSucursal = IdSucursal,
                cr_fecha = DateTime.Now.Date,
                IdCobro_tipo = "EFEC",
                IdCaja = 1
            };
            cargar_combos();
            return View(model);
        }

        public ActionResult Modificar()
        {
            cargar_combos();
            return View();
        }

        public ActionResult Anular()
        {
            cargar_combos();
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_cobranza(DateTime? Fecha_ini, DateTime? Fecha_fin, int IdSucursal = 0)
        {
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            ViewBag.Fecha_ini = Fecha_ini == null ? DateTime.Now.Date.AddMonths(-1) : Convert.ToDateTime(Fecha_ini);
            ViewBag.Fecha_fin = Fecha_fin == null ? DateTime.Now.Date : Convert.ToDateTime(Fecha_fin);
            ViewBag.IdSucursal = IdSucursal;
            var model = bus_cobro.get_list(IdEmpresa,IdSucursal, ViewBag.Fecha_ini, ViewBag.Fecha_fin);
            return PartialView("_GridViewPartial_cobranza", model);
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_cobranza_det()
        {
            var model = list_det.get_list();
            return PartialView("_GridViewPartial_cobranza_det", model);
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_cobranza_facturas_x_cruzar()
        {
            Session["IdSucursalCobranza"] = (Request.Params["IdSucursalCobranza"] != null ? Convert.ToInt32(Request.Params["IdSucursalCobranza"]) : 0);
            Session["IdClienteCobranza"] = Request.Params["IdClienteCobranza"] != null ? Convert.ToDecimal(Request.Params["IdClienteCobranza"]) : 0;
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            int IdSucursal = Convert.ToInt32(Session["IdSucursalCobranza"]);
            decimal IdCliente = Convert.ToDecimal(Session["IdClienteCobranza"]);
            var model = bus_det.get_list_cartera(IdEmpresa, IdSucursal, IdCliente);
            return PartialView("_GridViewPartial_cobranza_facturas_x_cruzar", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult EditingAddNewFactura(string IDs = "")
        {
            if (IDs != "")
            {
                int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
                var lst_x_cruzar = bus_det.get_list_cartera(IdEmpresa, Convert.ToInt32(Session["IdSucursalCobranza"]), Convert.ToDecimal(Session["IdClienteCobranza"]));
                string[] array = IDs.Split(',');
                foreach (var item in array)
                {
                    var info_det = lst_x_cruzar.Where(q => q.secuencia == item).FirstOrDefault();
                    if (info_det != null)
                        list_det.AddRow(info_det);
                }
            }
            var model = list_det.get_list();
            return PartialView("_GridViewPartial_cobranza_det", model);
        }
    }

    public class cxc_cobro_det_List
    {
        public List<cxc_cobro_det_Info> get_list()
        {
            if (HttpContext.Current.Session["cxc_cobro_det_Info"] == null)
            {
                List<cxc_cobro_det_Info> list = new List<cxc_cobro_det_Info>();

                HttpContext.Current.Session["cxc_cobro_det_Info"] = list;
            }
            return (List<cxc_cobro_det_Info>)HttpContext.Current.Session["cxc_cobro_det_Info"];
        }

        public void set_list(List<cxc_cobro_det_Info> list)
        {
            HttpContext.Current.Session["cxc_cobro_det_Info"] = list;
        }

        public void AddRow(cxc_cobro_det_Info info_det)
        {
            List<cxc_cobro_det_Info> list = get_list();            
            list.Add(info_det);
        }

        public void UpdateRow(cxc_cobro_det_Info info_det)
        {
            cxc_cobro_det_Info edited_info = get_list().Where(m => m.secuencia == info_det.secuencia).First();
        }

        public void DeleteRow(string secuencia)
        {
            List<cxc_cobro_det_Info> list = get_list();
            list.Remove(list.Where(m => m.secuencia == secuencia).First());
        }
    }
}