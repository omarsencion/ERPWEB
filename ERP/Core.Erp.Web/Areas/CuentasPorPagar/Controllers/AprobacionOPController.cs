﻿using Core.Erp.Bus.CuentasPorPagar;
using Core.Erp.Bus.General;
using Core.Erp.Info.CuentasPorPagar;
using Core.Erp.Info.Helps;
using Core.Erp.Web.Helps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core.Erp.Web.Areas.CuentasPorPagar.Controllers
{
    public class AprobacionOPController : Controller
    {
        // GET: Inventario/AprobarOrdenPago
        cp_orden_pago_Bus bus_orden_pago = new cp_orden_pago_Bus();
        tb_sucursal_Bus bus_sucursal = new tb_sucursal_Bus();
        orden_pago_aprobacion_List List_aprobacion_op = new orden_pago_aprobacion_List();

        public ActionResult Index()
        {
            cl_filtros_Info model = new cl_filtros_Info
            {
                IdEmpresa = string.IsNullOrEmpty(SessionFixed.IdEmpresa) ? 0 : Convert.ToInt32(SessionFixed.IdEmpresa),
                IdSucursal = string.IsNullOrEmpty(SessionFixed.IdSucursal) ? 0 : Convert.ToInt32(SessionFixed.IdSucursal),
                IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual)
            };

            List_aprobacion_op.set_list(new List<cp_orden_pago_Info>(), model.IdTransaccionSession);
            cargar_combos_consulta(model.IdEmpresa);
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(cl_filtros_Info model)
        {
            model.IdEmpresa = string.IsNullOrEmpty(SessionFixed.IdEmpresa) ? 0 : Convert.ToInt32(SessionFixed.IdEmpresa);

            List_aprobacion_op.get_list(model.IdTransaccionSession);
            cargar_combos_consulta(model.IdEmpresa);
            return View(model);
        }

        #region Metodos
        private void cargar_combos_consulta(int IdEmpresa)
        {
            try
            {
                var lst_sucursal = bus_sucursal.get_list(IdEmpresa, false);
                ViewBag.lst_sucursal = lst_sucursal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        public ActionResult GridViewPartial_AprobacionOP(DateTime? fecha_ini, DateTime? fecha_fin, int IdSucursal)
        {
            SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;

            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            ViewBag.fecha_ini = fecha_ini == null ? DateTime.Now.Date.AddMonths(-1) : Convert.ToDateTime(fecha_ini);
            ViewBag.fecha_fin = fecha_fin == null ? DateTime.Now.Date : Convert.ToDateTime(fecha_fin);
            ViewBag.IdSucursal = IdSucursal == 0 ? 0 : Convert.ToInt32(IdSucursal);

            //var Lista = bus_orden_pago.get_list_aprobacion(IdEmpresa, ViewBag.fecha_ini, ViewBag.fecha_fin, IdSucursal);
            //List_aprobacion_op.set_list(Lista, Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));

            //return PartialView("_GridViewPartial_AprobacionOP", List_aprobacion_op.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual)));

            var model = bus_orden_pago.get_list_aprobacion(IdEmpresa, ViewBag.fecha_ini, ViewBag.fecha_fin, IdSucursal);
            return PartialView("_GridViewPartial_AprobacionOP", model);
        }

        public JsonResult aprobar(int IdEmpresa = 0, string Ids = "")
        {
            string[] array = Ids.Split(',');
            List<cp_orden_pago_Info> lst_ordenes_pago_aprobacion = new List<cp_orden_pago_Info>();
            var output = array.GroupBy(q => q).ToList();

            foreach (var item in output)
            {
                cp_orden_pago_Info info = new cp_orden_pago_Info
                {
                    IdEmpresa = IdEmpresa,
                    IdOrdenPago = Convert.ToInt32(item.Key),
                    IdEstadoAprobacion = cl_enumeradores.eEstadoAprobacionOrdenPago.APRO.ToString()
                };

                lst_ordenes_pago_aprobacion.Add(info);
            }

            DateTime fecha_ini = DateTime.Now;
            DateTime fecha_fin = DateTime.Now;

            var resultado_orden = bus_orden_pago.aprobarOP(lst_ordenes_pago_aprobacion);

            return Json(resultado_orden, JsonRequestBehavior.AllowGet);
        }

        public JsonResult rechazar(int IdEmpresa = 0, string Ids = "")
        {
            string[] array = Ids.Split(',');
            List<cp_orden_pago_Info> lst_ordenes_pago_aprobacion = new List<cp_orden_pago_Info>();
            var output = array.GroupBy(q => q).ToList();

            foreach (var item in output)
            {
                cp_orden_pago_Info info = new cp_orden_pago_Info
                {
                    IdEmpresa = IdEmpresa,
                    IdOrdenPago = Convert.ToInt32(item.Key),
                    IdEstadoAprobacion = cl_enumeradores.eEstadoAprobacionOrdenPago.APRO.ToString()
                };

                lst_ordenes_pago_aprobacion.Add(info);
            }

            DateTime fecha_ini = DateTime.Now;
            DateTime fecha_fin = DateTime.Now;

            var resultado_orden = bus_orden_pago.rechazarOP(lst_ordenes_pago_aprobacion);

            return Json(resultado_orden, JsonRequestBehavior.AllowGet);
        }
    }

    public class orden_pago_aprobacion_List
    {
        string variable = "cp_orden_pago_Info";
        public List<cp_orden_pago_Info> get_list(decimal IdTransaccionSession)
        {
            if (HttpContext.Current.Session[variable + IdTransaccionSession.ToString()] == null)
            {
                List<cp_orden_pago_Info> list = new List<cp_orden_pago_Info>();

                HttpContext.Current.Session[variable + IdTransaccionSession.ToString()] = list;
            }
            return (List<cp_orden_pago_Info>)HttpContext.Current.Session[variable + IdTransaccionSession.ToString()];
        }
        public void set_list(List<cp_orden_pago_Info> list, decimal IdTransaccionSession)
        {
            HttpContext.Current.Session[variable + IdTransaccionSession.ToString()] = list;
        }
    }
}