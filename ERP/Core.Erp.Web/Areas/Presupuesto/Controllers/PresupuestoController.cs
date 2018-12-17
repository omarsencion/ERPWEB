﻿using Core.Erp.Bus.Contabilidad;
using Core.Erp.Bus.General;
using Core.Erp.Bus.Presupuesto;
using Core.Erp.Info.Contabilidad;
using Core.Erp.Info.Helps;
using Core.Erp.Info.Presupuesto;
using Core.Erp.Web.Helps;
using DevExpress.Web;
using DevExpress.Web.Mvc;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Core.Erp.Info.General.tb_sis_log_error_InfoList;

namespace Core.Erp.Web.Areas.Presupuesto.Controllers
{
    public class PresupuestoController : Controller
    {
        // GET: Presupuesto/Presupuesto
        #region Variables
        pre_Presupuesto_Bus bus_Presupuesto = new pre_Presupuesto_Bus();
        pre_PresupuestoDet_Bus bus_PresupuestoDet = new pre_PresupuestoDet_Bus();
        pre_Grupo_Bus bus_Grupo = new pre_Grupo_Bus();
        tb_sucursal_Bus bus_Sucursal = new tb_sucursal_Bus();
        pre_rubro_Bus bus_Rubro = new pre_rubro_Bus();
        pre_Periodo_Bus bus_Periodo = new pre_Periodo_Bus();
        ct_plancta_Bus bus_PlanCta = new ct_plancta_Bus();
        pre_PresupuestoDet_List Lista_PresupuestoDet = new pre_PresupuestoDet_List();
        List<pre_Presupuesto_Info> lst_Presupuesto = new List<pre_Presupuesto_Info>();
        tb_sis_log_error_List SisLogError = new tb_sis_log_error_List();
        string mensaje = string.Empty;
        #endregion

        #region Index
        public ActionResult Index()
        {
            var info_periodo = bus_Periodo.GetInfo_UltimoPeriodoAbierto(Convert.ToInt32(SessionFixed.IdEmpresa));

            cl_filtros_Info model = new cl_filtros_Info
            {
                IdEmpresa = string.IsNullOrEmpty(SessionFixed.IdEmpresa) ? 0 : Convert.ToInt32(SessionFixed.IdEmpresa),
                IdSucursal = string.IsNullOrEmpty(SessionFixed.IdSucursal) ? 0 : Convert.ToInt32(SessionFixed.IdSucursal),
                IdPeriodo = info_periodo.IdPeriodo
            };

            cargar_filtros(model.IdEmpresa);
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(cl_filtros_Info model)
        {
            model.IdEmpresa = string.IsNullOrEmpty(SessionFixed.IdEmpresa) ? 0 : Convert.ToInt32(SessionFixed.IdEmpresa);

            cargar_filtros(model.IdEmpresa);
            return View(model);
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_Presupuesto(int IdSucursal = 0, decimal IdPeriodo = 0)
        {
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            ViewBag.IdSucursal = IdSucursal == 0 ? 0 : Convert.ToInt32(IdSucursal);
            ViewBag.IdPeriodo = IdPeriodo == 0 ? 0 : Convert.ToInt32(IdPeriodo);

            lst_Presupuesto = bus_Presupuesto.GetList(IdEmpresa, IdSucursal, IdPeriodo, true);
            return PartialView("_GridViewPartial_Presupuesto", lst_Presupuesto);
        }

        #region Metodos
        private void cargar_filtros(int IdEmpresa)
        {
            try
            {
                var lst_Sucursal = bus_Sucursal.get_list(IdEmpresa, false);

                lst_Sucursal.Add(new Info.General.tb_sucursal_Info
                {
                    IdSucursal = 0,
                    Su_Descripcion = "Todos"
                });
                ViewBag.lst_Sucursal = lst_Sucursal;

                var lst_Periodo = bus_Periodo.GetList(IdEmpresa, false, false);

                lst_Periodo.Add(new Info.Presupuesto.pre_Periodo_Info
                {
                    IdPeriodo = 0,
                    DescripcionPeriodo = "Todos"
                });
                ViewBag.lst_Periodo = lst_Periodo;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void cargar_combos(int IdEmpresa)
        {
            try
            {
                var lst_Sucursal = bus_Sucursal.get_list(IdEmpresa, false);
                ViewBag.lst_Sucursal = lst_Sucursal;

                var lst_Periodo = bus_Periodo.GetList(IdEmpresa, false, false);
                ViewBag.lst_Periodo = lst_Periodo;

                var lst_Grupo = bus_Grupo.GetList_x_Usuario(IdEmpresa, SessionFixed.IdUsuario);
                ViewBag.lst_Grupo = lst_Grupo;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
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

            cargar_combos(IdEmpresa);
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
                cargar_combos(model.IdEmpresa);
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

            cargar_combos(IdEmpresa);
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
                cargar_combos(model.IdEmpresa);
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

            cargar_combos(IdEmpresa);
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

                cargar_combos(model.IdEmpresa);
                return View(model);
            };
            return RedirectToAction("Index");
        }
        #endregion

        #region Importacion
        public ActionResult UploadControlUpload()
        {
            UploadControlExtension.GetUploadedFiles("UploadControlFile", UploadControlSettings.UploadValidationSettings, UploadControlSettings.FileUploadComplete);
            return null;
        }
        public ActionResult Importar(int IdEmpresa = 0)
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
                IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual)
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Importar(pre_Presupuesto_Info model)
        {
            try
            {
                var ListaDet = Lista_PresupuestoDet.get_list(model.IdTransaccionSession);
                model.ListaPresupuestoDet = ListaDet;

                if (!bus_Presupuesto.GuardarBD(model))
                {
                    ViewBag.mensaje = "Error al importar el archivo";
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                SisLogError.set_list((ex.InnerException) == null ? ex.Message.ToString() : ex.InnerException.ToString());

                ViewBag.error = ex.Message.ToString();
                return View(model);
            }

            return RedirectToAction("Index");
        }
        //public ActionResult GridViewPartial_PresupuestoDet_importacion()
        //{
        //    SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;
        //    var model = Lista_PresupuestoDet.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
        //    return PartialView("_GridViewPartial_PresupuestoDet", model);
        //}

        public JsonResult ActualizarVariablesSession(int IdEmpresa = 0, decimal IdTransaccionSession = 0)
        {
            string retorno = string.Empty;
            SessionFixed.IdEmpresa = IdEmpresa.ToString();
            SessionFixed.IdTransaccionSession = IdTransaccionSession.ToString();
            SessionFixed.IdTransaccionSessionActual = IdTransaccionSession.ToString();
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Metodos del detalle
        public ActionResult GridViewPartial_PresupuestoDet()
        {
            cargar_combos_detalle();
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
                    pre_rubro_Info info_Rubro = bus_Rubro.GetInfo(IdEmpresa, info_PresupuestoDet.IdRubro);
                    if (info_Rubro != null)
                    {
                        info_PresupuestoDet.Descripcion = info_Rubro.Descripcion;
                    }
                }

            Lista_PresupuestoDet.AddRow(info_PresupuestoDet, Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            var model = Lista_PresupuestoDet.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));

            return PartialView("_GridViewPartial_PresupuestoDet", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] pre_PresupuestoDet_Info info_PresupuestoDet)
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            info_PresupuestoDet.IdEmpresa = IdEmpresa;
            if (info_PresupuestoDet != null)
                if (info_PresupuestoDet.IdRubro != 0)
                {
                    pre_rubro_Info info_Rubro = bus_Rubro.GetInfo(IdEmpresa, info_PresupuestoDet.IdRubro);
                    if (info_Rubro != null)
                    {
                        info_PresupuestoDet.IdRubro = info_Rubro.IdRubro;
                        info_PresupuestoDet.Descripcion = info_Rubro.Descripcion;
                    }                    
                }

            Lista_PresupuestoDet.UpdateRow(info_PresupuestoDet, Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            var model = Lista_PresupuestoDet.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));

            return PartialView("_GridViewPartial_PresupuestoDet", model);
        }

        public ActionResult EditingDelete(int Secuencia)
        {            
            Lista_PresupuestoDet.DeleteRow(Secuencia, Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            var model = Lista_PresupuestoDet.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));

            return PartialView("_GridViewPartial_PresupuestoDet", model);
        }

        private void cargar_combos_detalle()
        {
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);

            var lst_Rubro = bus_Rubro.GetList(IdEmpresa, false);
            ViewBag.lst_Rubro = lst_Rubro;
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


    public class UploadControlSettings
    {
        public static DevExpress.Web.UploadControlValidationSettings UploadValidationSettings = new DevExpress.Web.UploadControlValidationSettings()
        {
            AllowedFileExtensions = new string[] { ".xlsx" },
            MaxFileSize = 40000000
        };
        public static void FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            #region Variables
            pre_rubro_Bus bus_rubro = new pre_rubro_Bus();
            pre_PresupuestoDet_List ListaDet = new pre_PresupuestoDet_List();
            List<pre_PresupuestoDet_Info> Lista_Det = new List<pre_PresupuestoDet_Info>();

            int cont = 0;
            decimal IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual);
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            #endregion


            Stream stream = new MemoryStream(e.UploadedFile.FileBytes);
            if (stream.Length > 0)
            {
                IExcelDataReader reader = null;
                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                #region Presupuesto                
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0) && cont > 0)
                    {
                        var IdRubroDet = Convert.ToInt32(reader.GetValue(0));
                        pre_rubro_Info infoRubro = bus_rubro.GetInfo(IdEmpresa, IdRubroDet);

                        pre_PresupuestoDet_Info info = new pre_PresupuestoDet_Info
                        {
                            IdEmpresa = IdEmpresa,                            
                            IdRubro = IdRubroDet,
                            Descripcion = infoRubro.Descripcion,
                            Monto = Convert.ToDouble(reader.GetValue(1)),

                        };
                        Lista_Det.Add(info);
                    }
                    else
                        cont++;
                }
                ListaDet.set_list(Lista_Det, IdTransaccionSession);
                #endregion
            }
        }
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
            info_det.Monto = info_det.Monto;

            list.Add(info_det);
        }

        public void UpdateRow(pre_PresupuestoDet_Info info_det, decimal IdTransaccionSession)
        {
            pre_PresupuestoDet_Info edited_info = get_list(IdTransaccionSession).Where(m => m.Secuencia == info_det.Secuencia).First();
            edited_info.IdRubro = info_det.IdRubro;
            edited_info.Descripcion = info_det.Descripcion;
            edited_info.Monto = info_det.Monto;
        }

        public void DeleteRow(int Secuencia, decimal IdTransaccionSession)
        {
            List<pre_PresupuestoDet_Info> list = get_list(IdTransaccionSession);
            list.Remove(list.Where(m => m.Secuencia == Secuencia).First());
        }
    }
}