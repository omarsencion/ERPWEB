﻿using Core.Erp.Bus.Contabilidad;
using Core.Erp.Bus.CuentasPorPagar;
using Core.Erp.Bus.SeguridadAcceso;
using Core.Erp.Info.Contabilidad;
using Core.Erp.Info.CuentasPorPagar;
using Core.Erp.Info.SeguridadAcceso;
using Core.Erp.Web.Helps;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace Core.Erp.Web.Areas.CuentasPorPagar.Controllers
{
    [SessionTimeout]
    public class TipoOrdenPagoController : Controller
    {
        #region Variables
        cp_orden_pago_tipo_x_empresa_Bus bus_tipo_op = new cp_orden_pago_tipo_x_empresa_Bus();
        ct_plancta_Bus bus_pla_cuenta = new ct_plancta_Bus();
        ct_cbtecble_tipo_Bus bus_tipo_comprobante = new ct_cbtecble_tipo_Bus();
        cp_orden_pago_estado_aprob_Bus bus_estado_op = new cp_orden_pago_estado_aprob_Bus();
        string mensaje = string.Empty;
        string MensajeSuccess = "La transacción se ha realizado con éxito";
        seg_Menu_x_Empresa_x_Usuario_Bus bus_permisos = new seg_Menu_x_Empresa_x_Usuario_Bus();
        cp_orden_pago_tipo_List Lista_OrdenPagoTipo = new cp_orden_pago_tipo_List();
        cp_orden_pago_tipo_Bus bus_top = new cp_orden_pago_tipo_Bus();
        #endregion

        #region Metodos ComboBox bajo demanda
        ct_plancta_Bus bus_plancta = new ct_plancta_Bus();
        public ActionResult CmbCuenta_Tipo()
        {
            cp_orden_pago_tipo_x_empresa_Info model = new cp_orden_pago_tipo_x_empresa_Info();
            return PartialView("_CmbCuenta_Tipo", model);
        }
        public ActionResult CmbCuenta_credito_Tipo()
        {
            cp_orden_pago_tipo_x_empresa_Info model = new cp_orden_pago_tipo_x_empresa_Info();
            return PartialView("_CmbCuenta_credito_tipo", model);
        }

        public List<ct_plancta_Info> get_list_bajo_demanda(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            return bus_plancta.get_list_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa), false);
        }
        public ct_plancta_Info get_info_bajo_demanda(ListEditItemRequestedByValueEventArgs args)
        {
            return bus_plancta.get_info_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa));
        }
        #endregion

        #region Index
        public ActionResult Index()
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion
            #region Permisos
            seg_Menu_x_Empresa_x_Usuario_Info info = bus_permisos.get_list_menu_accion(Convert.ToInt32(SessionFixed.IdEmpresa), SessionFixed.IdUsuario, "CuentasPorPagar", "TipoOrdenPago", "Index");
            ViewBag.Nuevo = info.Nuevo;
            #endregion

            cp_orden_pago_tipo_Info model = new cp_orden_pago_tipo_Info
            {
                IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSession)
            };

            var lst = bus_top.get_list();
            Lista_OrdenPagoTipo.set_list(lst, model.IdTransaccionSession);

            return View(model);
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_tipo_orden_pago(bool Nuevo=false)
        {
            ViewBag.Nuevo = Nuevo;
            SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;
            var model = Lista_OrdenPagoTipo.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_tipo_orden_pago", model);
        }
        private void cargar_combos(int IdEmpresa)
        {
            ViewBag.lst_tipo_comprobante = bus_tipo_comprobante.get_list(IdEmpresa, false);
            ViewBag.lst_cuenta_contable = bus_pla_cuenta.get_list(IdEmpresa, false, true);
            ViewBag.lst_estado = bus_estado_op.get_list();
        }


        #endregion

        #region Acciones
        public ActionResult Nuevo(int IdEmpresa = 0 )
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion
            #region Permisos
            seg_Menu_x_Empresa_x_Usuario_Info info = bus_permisos.get_list_menu_accion(Convert.ToInt32(SessionFixed.IdEmpresa), SessionFixed.IdUsuario, "CuentasPorPagar", "TipoOrdenPago", "Index");
            if (!info.Nuevo)
                return RedirectToAction("Index");
            #endregion

            cp_orden_pago_tipo_x_empresa_Info model = new cp_orden_pago_tipo_x_empresa_Info
            {
                IdEmpresa = IdEmpresa
            };
            cargar_combos(IdEmpresa);
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(cp_orden_pago_tipo_x_empresa_Info model)
        {
            model.IdEmpresa = model.IdEmpresa;
            if (bus_tipo_op.si_existe(model))
            {
                cargar_combos(model.IdEmpresa);
                ViewBag.mensaje = "El código ya se encuentra registrado";
                return View(model);
            }

            if (!bus_tipo_op.guardarDB(model))
            {
                cargar_combos(model.IdEmpresa);

                return View(model);
            }
            return RedirectToAction("Consultar", new { IdEmpresa = model.IdEmpresa, IdTipo_op = model.IdTipo_op, Exito = true });
        }

        public ActionResult Consultar(int IdEmpresa = 0, string IdTipo_op = "", bool Exito=false)
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion

            cargar_combos(IdEmpresa);
            cp_orden_pago_tipo_x_empresa_Info model = bus_tipo_op.get_info(IdEmpresa, IdTipo_op);
            if (model == null)
            {
                return RedirectToAction("Index");
            }

            #region Permisos
            seg_Menu_x_Empresa_x_Usuario_Info info = bus_permisos.get_list_menu_accion(Convert.ToInt32(SessionFixed.IdEmpresa), SessionFixed.IdUsuario, "CuentasPorPagar", "TipoOrdenPago", "Index");
            if (model.Estado == "I")
            {
                info.Modificar = false;
                info.Anular = false;
            }
            model.Nuevo = (info.Nuevo==true ? 1 : 0);
            model.Modificar = (info.Modificar == true ? 1 : 0);
            model.Anular = (info.Anular == true ? 1 : 0);
            #endregion

            if (Exito)
                ViewBag.MensajeSuccess = MensajeSuccess;

            return View(model);
        }

        public ActionResult Modificar(int IdEmpresa = 0, string IdTipo_op = "")
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion
            #region Permisos
            seg_Menu_x_Empresa_x_Usuario_Info info = bus_permisos.get_list_menu_accion(Convert.ToInt32(SessionFixed.IdEmpresa), SessionFixed.IdUsuario, "CuentasPorPagar", "TipoOrdenPago", "Index");
            if (!info.Modificar)
                return RedirectToAction("Index");
            #endregion

            cargar_combos(IdEmpresa);
            cp_orden_pago_tipo_x_empresa_Info model = bus_tipo_op.get_info(IdEmpresa, IdTipo_op);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar(cp_orden_pago_tipo_x_empresa_Info model)
        {
            if (!bus_tipo_op.modificarDB(model))
            {
                cargar_combos(model.IdEmpresa);
                return View(model);
            }
            return RedirectToAction("Consultar", new { IdEmpresa = model.IdEmpresa, IdTipo_op = model.IdTipo_op, Exito = true });
        }

        public ActionResult Anular(int IdEmpresa = 0 , string IdTipo_op = "")
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion
            #region Permisos
            seg_Menu_x_Empresa_x_Usuario_Info info = bus_permisos.get_list_menu_accion(Convert.ToInt32(SessionFixed.IdEmpresa), SessionFixed.IdUsuario, "CuentasPorPagar", "TipoOrdenPago", "Index");
            if (!info.Anular)
                return RedirectToAction("Index");
            #endregion

            cargar_combos(IdEmpresa);
            cp_orden_pago_tipo_x_empresa_Info model = bus_tipo_op.get_info(IdEmpresa, IdTipo_op);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Anular(cp_orden_pago_tipo_x_empresa_Info model)
        {
            if (!bus_tipo_op.anularDB(model))
            {
                cargar_combos(model.IdEmpresa);

                return View(model);
            }
            return RedirectToAction("Index");
        }

        #endregion
        
    }

    public class cp_orden_pago_tipo_List
    {
        string Variable = "cp_orden_pago_tipo_Info";
        public List<cp_orden_pago_tipo_Info> get_list(decimal IdTransaccionSession)
        {
            if (HttpContext.Current.Session[Variable + IdTransaccionSession] == null)
            {
                List<cp_orden_pago_tipo_Info> list = new List<cp_orden_pago_tipo_Info>();

                HttpContext.Current.Session[Variable + IdTransaccionSession] = list;
            }
            return (List<cp_orden_pago_tipo_Info>)HttpContext.Current.Session[Variable + IdTransaccionSession];
        }

        public void set_list(List<cp_orden_pago_tipo_Info> list, decimal IdTransaccionSession)
        {
            HttpContext.Current.Session[Variable + IdTransaccionSession] = list;
        }
    }
}