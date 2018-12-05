﻿using Core.Erp.Bus.Contabilidad;
using Core.Erp.Bus.Presupuesto;
using Core.Erp.Info.Contabilidad;
using Core.Erp.Info.Presupuesto;
using Core.Erp.Web.Helps;
using DevExpress.Web;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core.Erp.Web.Areas.Presupuesto.Controllers
{
    public class PresupuestoController : Controller
    {
        // GET: Presupuesto/Presupuesto
        #region Variables
        pre_Presupuesto_Bus bus_Presupuesto = new pre_Presupuesto_Bus();
        pre_PresupuestoDet_Bus bus_PresupuestoDet = new pre_PresupuestoDet_Bus();
        pre_Grupo_Bus bus_Grupo = new pre_Grupo_Bus();
        pre_rubro_Bus bus_Rubro = new pre_rubro_Bus();
        ct_plancta_Bus bus_PlanCta = new ct_plancta_Bus();
        pre_PresupuestoDet_List Lista_PresupuestoDet = new pre_PresupuestoDet_List();
        string mensaje = string.Empty;
        #endregion

        #region Index
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_Grupo()
        {
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            List<pre_Presupuesto_Info> model = bus_Presupuesto.GetList(IdEmpresa, true);

            return PartialView("_GridViewPartial_Presupuesto", model);
        }
        #endregion


        #region Acciones
        public ActionResult Nuevo(int IdEmpresa = 0)
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion

            pre_Presupuesto_Info model = new pre_Presupuesto_Info
            {
                IdEmpresa = IdEmpresa,
                IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSession),
                IdUsuarioCreacion = SessionFixed.IdUsuario
            };

            Lista_PresupuestoDet.set_list(new List<pre_PresupuestoDet_Info>(), model.IdTransaccionSession);
            return View(model);
        }
        [HttpPost]
        public ActionResult Nuevo(pre_Presupuesto_Info model)
        {
            model.IdUsuarioCreacion = SessionFixed.IdUsuario;
            model.ListaPresupuestoDet = Lista_PresupuestoDet.get_list(model.IdTransaccionSession);

            if (!Validar(model, ref mensaje))
            {
                ViewBag.mensaje = mensaje;
                SessionFixed.IdTransaccionSessionActual = model.IdTransaccionSession.ToString();
                return View(model);
            }

            if (!bus_Presupuesto.GuardarBD(model))
            {
                SessionFixed.IdTransaccionSessionActual = model.IdTransaccionSession.ToString();
                return View(model);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Modificar(int IdEmpresa = 0, int IdPresupuesto = 0)
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion

            pre_Presupuesto_Info model = bus_Presupuesto.GetInfo(IdEmpresa, IdPresupuesto);

            if (model == null)
                return RedirectToAction("Index");

            model.IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSession);
            model.ListaPresupuestoDet = bus_PresupuestoDet.GetList(model.IdEmpresa, Convert.ToInt32(model.IdPresupuesto));
            Lista_PresupuestoDet.set_list(model.ListaPresupuestoDet, model.IdTransaccionSession);

            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar(pre_Presupuesto_Info model)
        {
            model.ListaPresupuestoDet = Lista_PresupuestoDet.get_list(model.IdTransaccionSession);
            model.IdUsuarioModificacion = Session["IdUsuario"].ToString();

            if (!Validar(model, ref mensaje))
            {
                ViewBag.mensaje = mensaje;
                return View(model);
            }

            if (!bus_Presupuesto.ModificarBD(model))
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Anular(int IdEmpresa = 0, decimal IdPresupuesto = 0)
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion

            pre_Presupuesto_Info model = bus_Presupuesto.GetInfo(IdEmpresa, Convert.ToInt32(IdPresupuesto));
            if (model == null)
                return RedirectToAction("Index");
            model.IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSession);
            model.ListaPresupuestoDet = bus_PresupuestoDet.GetList(model.IdEmpresa, Convert.ToInt32(model.IdPresupuesto));
            Lista_PresupuestoDet.set_list(model.ListaPresupuestoDet, model.IdTransaccionSession);

            return View(model);
        }

        [HttpPost]
        public ActionResult Anular(pre_Presupuesto_Info model)
        {
            model.IdUsuarioAnulacion = SessionFixed.IdUsuario.ToString();
            if (!bus_Presupuesto.AnularBD(model))
            {
                ViewBag.mensaje = "No se ha podido anular el registro";

                model.IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSession);
                model.ListaPresupuestoDet = bus_PresupuestoDet.GetList(model.IdEmpresa, Convert.ToInt32(model.IdGrupo));
                Lista_PresupuestoDet.set_list(model.ListaPresupuestoDet, model.IdTransaccionSession);

                return View(model);
            };
            return RedirectToAction("Index");
        }
        #endregion

        #region Metodos del detalle
        public ActionResult GridViewPartial_GrupoDet()
        {
            SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;
            var model = Lista_PresupuestoDet.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_PresupuestoDet", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] pre_PresupuestoDet_Info info_PresupuestoDet)
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            if (info_PresupuestoDet != null)
                if (info_PresupuestoDet.IdRubro != 0)
                {
                    pre_rubro_Info info_Rubro = bus_Rubro.GetInfo(info_PresupuestoDet.IdEmpresa, info_PresupuestoDet.IdRubro);
                    if (info_Rubro != null)
                    {
                        info_PresupuestoDet.Descripcion = info_Rubro.Descripcion;
                    }
                }
                if (info_PresupuestoDet.IdCtaCble != "")
                {
                    ct_plancta_Info info_PlanCta = bus_PlanCta.get_info(info_PresupuestoDet.IdEmpresa, info_PresupuestoDet.IdCtaCble);
                    if (info_PlanCta != null)
                    {
                        info_PresupuestoDet.pc_Cuenta = info_PlanCta.pc_Cuenta;
                    }
                }

            Lista_PresupuestoDet.AddRow(info_PresupuestoDet, Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            var model = Lista_PresupuestoDet.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));

            return PartialView("_GridViewPartial_GrupoDet", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] pre_PresupuestoDet_Info info_PresupuestoDet)
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            if (info_PresupuestoDet != null)
                if (info_PresupuestoDet.IdRubro != 0)
                {
                    pre_rubro_Info info_Rubro = bus_Rubro.GetInfo(info_PresupuestoDet.IdEmpresa, info_PresupuestoDet.IdRubro);
                    if (info_Rubro != null)
                    {
                        info_PresupuestoDet.Descripcion = info_Rubro.Descripcion;
                    }                    
                }

                if (info_PresupuestoDet.IdCtaCble != "")
                {
                    ct_plancta_Info info_PlanCta = bus_PlanCta.get_info(info_PresupuestoDet.IdEmpresa, info_PresupuestoDet.IdCtaCble);
                    if (info_PlanCta != null)
                    {
                        info_PresupuestoDet.pc_Cuenta = info_PlanCta.pc_Cuenta;
                    }
                }

            Lista_PresupuestoDet.AddRow(info_PresupuestoDet, Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            var model = Lista_PresupuestoDet.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));

            return PartialView("_GridViewPartial_GrupoDet", model);
        }

        public ActionResult EditingDelete(int Secuencia)
        {
            Lista_PresupuestoDet.DeleteRow(Secuencia, Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            var model = Lista_PresupuestoDet.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));

            return PartialView("_GridViewPartial_GrupoDet", model);
        }

        public ActionResult CmbCuentaContable()
        {
            string model = "";
            return PartialView("_CmbCuentaContable", model);
        }

        public List<ct_plancta_Info> get_list_bajo_demanda(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            return bus_PlanCta.get_list_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa), false);
        }

        public ct_plancta_Info get_info_bajo_demanda(ListEditItemRequestedByValueEventArgs args)
        {
            return bus_PlanCta.get_info_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa));
        }

        private bool Validar(pre_Presupuesto_Info i_validar, ref string msg)
        {
            i_validar.ListaPresupuestoDet = Lista_PresupuestoDet.get_list(i_validar.IdTransaccionSession);

            if (i_validar.ListaPresupuestoDet.Count == 0)
            {
                mensaje = "Debe ingresar al menos un rubro";
                return false;
            }
            else
            {
                foreach (var item1 in i_validar.ListaPresupuestoDet)
                {
                    var contador = 0;
                    foreach (var item2 in i_validar.ListaPresupuestoDet)
                    {
                        if (item1.IdRubro == item2.IdRubro)
                        {
                            contador++;
                        }

                        if (contador > 1)
                        {
                            mensaje = "Existen rubros repetidos en el detalle";
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        #endregion        
    }

    public class pre_PresupuestoDet_List
    {
        string Variable = "pre_PresupuestoDet_Info";
        public List<pre_PresupuestoDet_Info> get_list(decimal IdTransaccionSession)
        {

            if (HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] == null)
            {
                List<pre_PresupuestoDet_Info> list = new List<pre_PresupuestoDet_Info>();

                HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
            }
            return (List<pre_PresupuestoDet_Info>)HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()];
        }

        public void set_list(List<pre_PresupuestoDet_Info> list, decimal IdTransaccionSession)
        {
            HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
        }

        public void AddRow(pre_PresupuestoDet_Info info_det, decimal IdTransaccionSession)
        {
            List<pre_PresupuestoDet_Info> list = get_list(IdTransaccionSession);
            info_det.Secuencia = list.Count == 0 ? 1 : list.Max(q => q.Secuencia) + 1;
            info_det.IdRubro = info_det.IdRubro;
            info_det.IdCtaCble = info_det.IdCtaCble;
            info_det.Cantidad = info_det.Cantidad;
            info_det.Monto = info_det.Monto;

            list.Add(info_det);
        }

        public void UpdateRow(pre_PresupuestoDet_Info info_det, decimal IdTransaccionSession)
        {
            pre_PresupuestoDet_Info edited_info = get_list(IdTransaccionSession).Where(m => m.Secuencia == info_det.Secuencia).First();
            edited_info.IdRubro = info_det.IdRubro;
            edited_info.IdCtaCble = info_det.IdCtaCble;
            edited_info.Cantidad = info_det.Cantidad;
            edited_info.Monto = info_det.Monto;
        }

        public void DeleteRow(int Secuencia, decimal IdTransaccionSession)
        {
            List<pre_PresupuestoDet_Info> list = get_list(IdTransaccionSession);
            list.Remove(list.Where(m => m.Secuencia == Secuencia).First());
        }
    }
}