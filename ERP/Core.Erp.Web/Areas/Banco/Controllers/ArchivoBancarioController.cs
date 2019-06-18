﻿using Core.Erp.Web.Helps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Erp.Bus.Banco;
using Core.Erp.Info.Banco;
using Core.Erp.Bus.General;
using Core.Erp.Info.Helps;
using Core.Erp.Bus.Contabilidad;
using DevExpress.Web.Mvc;
using Core.Erp.Info.CuentasPorPagar;

namespace Core.Erp.Web.Areas.Banco.Controllers
{
    public class ArchivoBancarioController : Controller
    {

        string rutafile = System.IO.Path.GetTempPath();

        #region Variables
        ba_Archivo_Transferencia_Bus bus_archivo = new ba_Archivo_Transferencia_Bus();
        ba_Archivo_Transferencia_Det_Bus bus_archivo_det = new ba_Archivo_Transferencia_Det_Bus();
        ba_Archivo_Transferencia_Det_List List_det = new ba_Archivo_Transferencia_Det_List();
        ba_Archivo_Transferencia_Det_List_op Lst_det_op = new ba_Archivo_Transferencia_Det_List_op();

        ba_Archivo_Flujo_List List_flujo = new ba_Archivo_Flujo_List();
        ba_archivo_transferencia_x_ba_tipo_flujo_Bus bus_archivo_flujo = new ba_archivo_transferencia_x_ba_tipo_flujo_Bus();
        ba_TipoFlujo_PlantillaDet_Bus bus_TipoFlujo_PlantillaDet = new ba_TipoFlujo_PlantillaDet_Bus();

        tb_banco_procesos_bancarios_x_empresa_Bus bus_procesos_bancarios = new tb_banco_procesos_bancarios_x_empresa_Bus();
        ba_Banco_Cuenta_Bus bus_cuentas_bancarias = new ba_Banco_Cuenta_Bus();
        tb_sucursal_Bus bus_sucursal = new tb_sucursal_Bus();
        string mensaje = string.Empty;
        ct_periodo_Bus bus_periodo = new ct_periodo_Bus();
        string MensajeSuccess = "La transacción se ha realizado con éxito";
        #endregion
        #region Index
        public ActionResult Index()
        {
            return View();
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial_archivo_bancario()
        {
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var model = bus_archivo.GetList(IdEmpresa, true);
            return PartialView("_GridViewPartial_archivo_bancario", model);
        }
        #endregion
        #region Metodos
        private bool validar(ba_Archivo_Transferencia_Info i_validar, ref string msg)
        {
            if (!bus_periodo.ValidarFechaTransaccion(i_validar.IdEmpresa, i_validar.Fecha, cl_enumeradores.eModulo.BANCO, i_validar.IdSucursal, ref msg))
            {
                return false;
            }

            var pro = bus_procesos_bancarios.get_info(i_validar.IdEmpresa, i_validar.IdProceso_bancario);
            i_validar.Cod_Empresa = pro.Codigo_Empresa;

            if (i_validar.SecuencialInicial == 0)
            {
                i_validar.SecuencialInicial = bus_archivo_det.GetIdSecuencial(i_validar.IdEmpresa, i_validar.IdBanco, i_validar.IdProceso_bancario);
            }

            var lst_prov = i_validar.Lst_det.GroupBy(q => new { q.IdTipoPersona, q.IdEntidad, q.IdPersona }).ToList();
            foreach (var item in lst_prov)
            {
                i_validar.Lst_det.Where(q=> q.IdTipoPersona == item.Key.IdTipoPersona && q.IdEntidad == item.Key.IdEntidad && q.IdPersona == item.Key.IdPersona).ToList().ForEach(q => { q.Secuencial_reg_x_proceso = i_validar.SecuencialInicial; });
                i_validar.SecuencialInicial++;
            }

            return true;
        }
        private void cargar_combos()
        {
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            
            var lst_cuenta_bancarias = bus_cuentas_bancarias.get_list(IdEmpresa, Convert.ToInt32(SessionFixed.IdSucursal), false);
            ViewBag.lst_cuenta_bancarias = lst_cuenta_bancarias;

            var lst_proceso = bus_procesos_bancarios.get_list(IdEmpresa, false);
            ViewBag.lst_proceso = lst_proceso;

            var lst_sucursal = bus_sucursal.GetList(IdEmpresa, SessionFixed.IdUsuario, false);
            ViewBag.lst_sucursal = lst_sucursal;
            
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
            ba_Archivo_Transferencia_Info model = new ba_Archivo_Transferencia_Info
            {
                IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa),
                Fecha = DateTime.Now,
                IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual),
                Lst_det = new List<ba_Archivo_Transferencia_Det_Info>(), 
                Lst_Flujo = new List<ba_archivo_transferencia_x_ba_tipo_flujo_Info>()               
            };
            List_det.set_list(model.Lst_det, model.IdTransaccionSession);
            List_flujo.set_list(model.Lst_Flujo, model.IdTransaccionSession);
            cargar_combos();
            return View(model);
        }
        [HttpPost]
        public ActionResult Nuevo(ba_Archivo_Transferencia_Info model)
        {
            model.IdUsuario = SessionFixed.IdUsuario;
            model.Lst_det = List_det.get_list(model.IdTransaccionSession);
            model.Lst_Flujo = List_flujo.get_list(model.IdTransaccionSession);
            if (!validar(model, ref mensaje))
            {
                ViewBag.mensaje = mensaje;
                cargar_combos();
                return View(model);
            }
            if (!bus_archivo.GuardarDB(model))
            {
                cargar_combos();
                return View(model);
            }
            return RedirectToAction("Modificar", new { IdEmpresa = model.IdEmpresa, IdArchivo = model.IdArchivo, Exito = true });
        }
        public ActionResult Modificar(int IdEmpresa = 0, decimal IdArchivo = 0, bool Exito = false)
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion
            ba_Archivo_Transferencia_Info model = bus_archivo.GetInfo(IdEmpresa, IdArchivo);
            if (model == null)
                return RedirectToAction("Index");
            model.IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual);
            model.Lst_det = bus_archivo_det.GetList(model.IdEmpresa, model.IdArchivo);
            List_det.set_list(model.Lst_det, model.IdTransaccionSession);

            model.Lst_Flujo = bus_archivo_flujo.GetList(model.IdEmpresa, model.IdArchivo);
            List_flujo.set_list(model.Lst_Flujo, model.IdTransaccionSession);
            cargar_combos();

            if (Exito)
                ViewBag.MensajeSuccess = MensajeSuccess;
            return View(model);
        }
        [HttpPost]
        public ActionResult Modificar(ba_Archivo_Transferencia_Info model)
        {
            model.IdUsuarioUltMod = SessionFixed.IdUsuario;
            model.Lst_det = List_det.get_list(model.IdTransaccionSession);
            model.Lst_Flujo = List_flujo.get_list(model.IdTransaccionSession);

            if (!bus_archivo.ModificarDB(model))
            {
                cargar_combos();
                return View(model);
            }

            return RedirectToAction("Modificar", new { IdEmpresa = model.IdEmpresa, IdArchivo = model.IdArchivo, Exito = true });
        }

        public ActionResult Anular(int IdEmpresa = 0, decimal IdArchivo = 0)
        {
            ba_Archivo_Transferencia_Info model = bus_archivo.GetInfo(IdEmpresa, IdArchivo);
            if (model == null)
                return RedirectToAction("Index");
            #region Validacion Periodo CXC
            ViewBag.MostrarBoton = true;
            if (!bus_periodo.ValidarFechaTransaccion(IdEmpresa, model.Fecha, cl_enumeradores.eModulo.BANCO, model.IdSucursal, ref mensaje))
            {
                ViewBag.mensaje = mensaje;
                ViewBag.MostrarBoton = false;
            }
            #endregion
            cargar_combos();
            return View(model);
        }
        [HttpPost]
        public ActionResult Anular(ba_Archivo_Transferencia_Info model)
        {
            model.IdUsuarioUltAnu = SessionFixed.IdUsuario;
            if (!bus_archivo.AnularDB(model))
            {
                cargar_combos();
                return View(model);
            }
            return RedirectToAction("Index");
        }
        #endregion
        #region Detalle Archivo
        [ValidateInput(false)]
        public ActionResult GridViewPartial_archivo_bancario_det()
        {
            SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var model = List_det.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_archivo_bancario_det", model);
        }
        public ActionResult GridViewPartial_archivo_bancario_det_op()
        {
            SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var model = Lst_det_op.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_archivo_bancario_det_op", model);
        }

        [HttpPost, ValidateInput(false)]
        public JsonResult EditingAddNew(string IDs = "", decimal IdTransaccionSession = 0, int IdEmpresa = 0)
        {
            if (IDs != "")
            {
                var Lst_det = Lst_det_op.get_list(IdTransaccionSession);
                string[] array = IDs.Split(',');
                foreach (var item in array)
                {
                    var info_det = Lst_det.Where(q => q.IdOrdenPago == Convert.ToInt32(item)).FirstOrDefault();
                    if (info_det != null)
                    {
                        List_det.AddRow(info_det, IdTransaccionSession);
                    }
                }
            }
            var model = List_det.get_list(IdTransaccionSession);
            return Json("", JsonRequestBehavior.AllowGet);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] ba_Archivo_Transferencia_Det_Info info_det)
        {

            if (ModelState.IsValid)
                List_det.UpdateRow(info_det, Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            var model = List_det.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_archivo_bancario_det", model);
        }
        public ActionResult EditingDelete(decimal IdOrdenPago)
        {
            List_det.DeleteRow(IdOrdenPago, Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            var model = List_det.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_archivo_bancario_det", model);
        }
        #endregion
        #region Json
        public JsonResult GetListPorCruzar(int IdEmpresa = 0, decimal IdTransaccionSession = 0, int IdSucursal = 0)
        {
            var lst = bus_archivo_det.get_list_con_saldo(IdEmpresa, 0, "PROVEE", 0, "APRO", SessionFixed.IdUsuario, IdSucursal, false);
            Lst_det_op.set_list(lst, IdTransaccionSession);
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region Archivo

        public FileResult get_archivo(int IdEmpresa = 0, int IdArchivo = 0)
        {
            byte[] archivo;
            ba_Archivo_Transferencia_Bus bus_tipo_file = new ba_Archivo_Transferencia_Bus();

            var info_archivo = bus_archivo.GetInfo(IdEmpresa, IdArchivo);
            info_archivo.Lst_det = bus_archivo_det.GetList(IdEmpresa, IdArchivo);

            archivo = GetArchivo(info_archivo, info_archivo.Nom_Archivo);
            return File(archivo, "application/xml", info_archivo.Nom_Archivo + ".txt");
        }

        private byte[] GetMulticash(ba_Archivo_Transferencia_Info info, string NombreArchivo)
        {
            try
            {
                System.IO.File.Delete(rutafile + NombreArchivo + ".txt");                
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(rutafile + NombreArchivo + ".txt", true))
                {
                    foreach (var item in info.Lst_det.Where(v => v.Valor > 0))
                    {
                        string linea = "";
                        double valor = Convert.ToDouble(item.Valor);
                        double valorEntero = Math.Floor(valor);
                        double valorDecimal = Convert.ToDouble((valor - valorEntero).ToString("N2")) * 100;

                        linea += "PA\t";
                        linea += string.IsNullOrEmpty(item.num_cta_acreditacion) ? "" : item.num_cta_acreditacion.PadLeft(10, '0') + "\t";
                        linea += item.Secuencial_reg_x_proceso.ToString().PadLeft(7, ' ') + "\t";
                        linea += "\t";//COMPROBANTE DE PAGO
                        linea += (string.IsNullOrEmpty(item.num_cta_acreditacion) ? item.pe_cedulaRuc.Trim() : item.num_cta_acreditacion.Trim()) + "\t";
                        linea += "USD\t";
                        linea += (valorEntero.ToString() + valorDecimal.ToString().PadLeft(2, '0')).PadLeft(13, '0') + "\t";
                        linea += (string.IsNullOrEmpty(item.num_cta_acreditacion) ? "EFE" : "CTA") + "\t";
                        linea += (string.IsNullOrEmpty(item.num_cta_acreditacion) ? "0017" : item.CodigoLegalBanco.ToString().PadLeft(4, '0')) + "\t";
                        linea += (string.IsNullOrEmpty(item.num_cta_acreditacion) || string.IsNullOrEmpty(item.IdTipoCta_acreditacion_cat) ? "" : (item.IdTipoCta_acreditacion_cat.Trim() == "COR" ? "CTE" : item.IdTipoCta_acreditacion_cat)) + "\t";
                        linea += string.IsNullOrEmpty(item.num_cta_acreditacion) ? "" : item.num_cta_acreditacion.PadLeft(10, '0') + "\t";
                        linea += (item.IdTipoDocumento == "CED" ? "C" : (item.IdTipoDocumento == "RUC" ? "R" : "P")) + "\t";
                        linea += item.pe_cedulaRuc.Trim() + "\t";
                        linea += (string.IsNullOrEmpty(item.Nom_Beneficiario) ? "" : (item.Nom_Beneficiario.Length > 40 ? item.Nom_Beneficiario.Substring(0, 40) : item.Nom_Beneficiario.Trim())) + "\t";
                        linea += "\t";//(string.IsNullOrEmpty(item.pr_direccion) ? "" : (item.pr_direccion.Length > 40 ? item.pr_direccion.Substring(0, 40) : item.pr_direccion.Trim())) + "\t";
                        linea += "\t";//Ciudad
                        linea += "\t";//Telefono
                        linea += "\t";//Localidad
                        linea += (string.IsNullOrEmpty(item.Referencia) ? "" : (item.Referencia.Length > 200 ? item.Referencia.Substring(0,200) : item.Referencia.Trim())) + "\t";
                        linea += "\t";//Ref adicional

                        file.WriteLine(linea);
                    }
                }
                byte[] filebyte = System.IO.File.ReadAllBytes(rutafile + NombreArchivo + ".txt");
                return filebyte;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public byte[] GetArchivo(ba_Archivo_Transferencia_Info info, string nombre_file)
        {
            try
            {
                return GetMulticash(info, nombre_file);

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
    public class ba_Archivo_Transferencia_Det_List
    {
        string Variable = "ba_Archivo_Transferencia_Det_Info";
        public List<ba_Archivo_Transferencia_Det_Info> get_list(decimal IdTransaccionSession)
        {

            if (HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] == null)
            {
                List<ba_Archivo_Transferencia_Det_Info> list = new List<ba_Archivo_Transferencia_Det_Info>();

                HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
            }
            return (List<ba_Archivo_Transferencia_Det_Info>)HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()];
        }

        public void set_list(List<ba_Archivo_Transferencia_Det_Info> list, decimal IdTransaccionSession)
        {
            HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
        }

        public void AddRow(ba_Archivo_Transferencia_Det_Info info_det, decimal IdTransaccionSession)
        {
            List<ba_Archivo_Transferencia_Det_Info> list = get_list(IdTransaccionSession);
            info_det.Secuencia = list.Count == 0 ? 1 : list.Max(q => q.Secuencia) + 1;
            if (list.Where(q => q.IdOrdenPago == info_det.IdOrdenPago).Count() == 0)
                list.Add(info_det);
        }

        public void UpdateRow(ba_Archivo_Transferencia_Det_Info info_det, decimal IdTransaccionSession)
        {
            ba_Archivo_Transferencia_Det_Info edited_info = get_list(IdTransaccionSession).Where(m => m.IdOrdenPago == info_det.IdOrdenPago).First();
            if (edited_info != null)
            {
                edited_info.Valor = info_det.Valor;
            }
        }

        public void DeleteRow(decimal IdOrdenPago, decimal IdTransaccionSession)
        {
            List<ba_Archivo_Transferencia_Det_Info> list = get_list(IdTransaccionSession);
            list.Remove(list.Where(m => m.IdOrdenPago == IdOrdenPago).First());
        }
    }

    public class ba_Archivo_Transferencia_Det_List_op
    {
        string Variable = "ba_Archivo_Transferencia_Det_Info_op";
        public List<ba_Archivo_Transferencia_Det_Info> get_list(decimal IdTransaccionSession)
        {

            if (HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] == null)
            {
                List<ba_Archivo_Transferencia_Det_Info> list = new List<ba_Archivo_Transferencia_Det_Info>();

                HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
            }
            return (List<ba_Archivo_Transferencia_Det_Info>)HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()];
        }

        public void set_list(List<ba_Archivo_Transferencia_Det_Info> list, decimal IdTransaccionSession)
        {
            HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
        }
    }

    public class ba_Archivo_Flujo_List
    {
        string Variable = "ba_archivo_transferencia_x_ba_tipo_flujo_Info";
        public List<ba_archivo_transferencia_x_ba_tipo_flujo_Info> get_list(decimal IdTransaccionSession)
        {

            if (HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] == null)
            {
                List<ba_archivo_transferencia_x_ba_tipo_flujo_Info> list = new List<ba_archivo_transferencia_x_ba_tipo_flujo_Info>();

                HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
            }
            return (List<ba_archivo_transferencia_x_ba_tipo_flujo_Info>)HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()];
        }

        public void set_list(List<ba_archivo_transferencia_x_ba_tipo_flujo_Info> list, decimal IdTransaccionSession)
        {
            HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
        }

        public void AddRow(ba_archivo_transferencia_x_ba_tipo_flujo_Info info_det, decimal IdTransaccionSession)
        {
            List<ba_archivo_transferencia_x_ba_tipo_flujo_Info> list = get_list(IdTransaccionSession);
            info_det.Secuencia = list.Count == 0 ? 1 : list.Max(q => q.Secuencia) + 1;
            
        }

        public void UpdateRow(ba_archivo_transferencia_x_ba_tipo_flujo_Info info_det, decimal IdTransaccionSession)
        {
            ba_archivo_transferencia_x_ba_tipo_flujo_Info edited_info = get_list(IdTransaccionSession).Where(m => m.Secuencia == info_det.Secuencia).First();
            edited_info.IdTipoFlujo = info_det.IdTipoFlujo;
            edited_info.IdArchivo = info_det.IdArchivo;
            edited_info.Porcentaje = info_det.Porcentaje;
            edited_info.Valor = info_det.Valor;
            edited_info.Secuencia = info_det.Secuencia;
        }

        public void DeleteRow(int Secuencia, decimal IdTransaccionSession)
        {
            List<ba_archivo_transferencia_x_ba_tipo_flujo_Info> list = get_list(IdTransaccionSession);
            list.Remove(list.Where(m => m.Secuencia == Secuencia).First());
        }
    }

}