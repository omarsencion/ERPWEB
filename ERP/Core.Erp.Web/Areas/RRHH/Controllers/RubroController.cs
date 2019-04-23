﻿using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Erp.Info.RRHH;
using Core.Erp.Bus.RRHH;
using Core.Erp.Info.Contabilidad;
using Core.Erp.Bus.Contabilidad;
using Core.Erp.Web.Helps;

namespace Core.Erp.Web.Areas.RRHH.Controllers
{
    public class RubroController : Controller
    {
        List<ro_catalogo_Info> lst_tipo_rubro = new List<ro_catalogo_Info>();
        List<ro_catalogo_Info> lst_tipo_campo = new List<ro_catalogo_Info>();
        List<ro_catalogo_Info> lst_grupo = new List<ro_catalogo_Info>();
        ro_catalogo_Bus bus_catalogo = new ro_catalogo_Bus();
        ro_rubro_tipo_Bus bus_rubro = new ro_rubro_tipo_Bus();
        List<ct_plancta_Info> lst_plancuenta = new List<ct_plancta_Info>();
        List<ro_catalogo_Info> lst_grupo_rep_gene = new List<ro_catalogo_Info>();

        Bus.Contabilidad.ct_plancta_Bus bus_plancuenta = new Bus.Contabilidad.ct_plancta_Bus();
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_rubro()
        {
            try
            {
                List<ro_rubro_tipo_Info> model = bus_rubro.get_list(GetIdEmpresa(), true);
                return PartialView("_GridViewPartial_rubro", model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Nuevo(ro_rubro_tipo_Info info)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    info.IdEmpresa = GetIdEmpresa();
                    if (!bus_rubro.guardarDB(info))
                    {
                        cargar_combo();
                        return View(info);
                    }
                    else
                        return RedirectToAction("Index");
                }
                else
                    return View(info);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Nuevo()
        {
            try
            {
                ro_rubro_tipo_Info info = new ro_rubro_tipo_Info
                {
                    rub_GrupoResumen = "",
                    rub_grupo = ""
                };
                cargar_combo();
                return View(info);

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Modificar(ro_rubro_tipo_Info info)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!bus_rubro.modificarDB(info))
                    {
                        cargar_combo();
                        return View(info);
                    }
                    else
                        return RedirectToAction("Index");
                }
                else
                    return View(info);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Modificar(string IdRubro )
        {
            try
            {
                ro_rubro_tipo_Info model = bus_rubro.get_info(GetIdEmpresa(), IdRubro);
                if (model == null)
                    return RedirectToAction("Index");
                model.rub_grupo = model.rub_grupo == null ? "" : model.rub_grupo;
                model.rub_GrupoResumen = model.rub_GrupoResumen == null ? "" : model.rub_GrupoResumen;
                cargar_combo();
                return View(model);
                //return View(bus_rubro.get_info(GetIdEmpresa(), IdRubro));

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]

        public ActionResult Anular(ro_rubro_tipo_Info info)
        {
            try
            {
                    if (!bus_rubro.anularDB(info))
                    {
                        cargar_combo();
                        return View(info);
                    }
                    else
                        return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Anular(string IdRubro )
        {
            try
            {
                cargar_combo();
                return View(bus_rubro.get_info(GetIdEmpresa(), IdRubro));

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cargar_combo()
        {
            try
            {
                lst_tipo_rubro = bus_catalogo.get_list_x_tipo(22);
                ViewBag.lst_tipo_rubro = lst_tipo_rubro;
                lst_tipo_campo = bus_catalogo.get_list_x_tipo(13);
                lst_grupo = bus_catalogo.get_list_x_tipo(14);
                lst_grupo.Add(new ro_catalogo_Info
                {
                    IdCatalogo = 0,
                    ca_descripcion = ""
                });
                lst_plancuenta = bus_plancuenta.get_list(GetIdEmpresa(), false, true);
                lst_grupo_rep_gene = bus_catalogo.get_list_x_tipo(43);
                lst_grupo_rep_gene.Add(new ro_catalogo_Info
                {
                    IdCatalogo = 0,
                    ca_descripcion = ""
                });

                ViewBag.lst_tipo_campo = lst_tipo_campo;
                ViewBag.lst_grupo = lst_grupo;
                ViewBag.lst_grupo_rep_gene = lst_grupo_rep_gene;
                ViewBag.lst_plancuenta = lst_plancuenta;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private int GetIdEmpresa()
        {
            try
            {
                if (Session["IdEmpresa"] != null)
                    return Convert.ToInt32(Session["IdEmpresa"]);
                else
                    return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
    }


    public class ro_rubro_tipo_Info_list
    {
        string variable = "ro_rubro_tipo_Info";
        public List<ro_rubro_tipo_Info> get_list()
        {
            if (HttpContext.Current.Session[variable] == null)
            {
                List<ro_rubro_tipo_Info> list = new List<ro_rubro_tipo_Info>();

                HttpContext.Current.Session[variable] = list;
            }
            return (List<ro_rubro_tipo_Info>)HttpContext.Current.Session[variable];
        }

        public void set_list(List<ro_rubro_tipo_Info> list)
        {
            HttpContext.Current.Session[variable] = list;
        }


    }

    public class ro_rubro_tipo_x_jornada_List
    {
        ro_jornada_Bus bus_jornada = new ro_jornada_Bus();
        ro_rubro_tipo_Bus bus_rubro = new ro_rubro_tipo_Bus();

        string variable = "ro_rubro_tipo_x_jornada_Info";
        public List<ro_rubro_tipo_x_jornada_Info> get_list(decimal IdTransaccionSession)
        {
            if (HttpContext.Current.Session[variable + IdTransaccionSession.ToString()] == null)
            {
                List<ro_rubro_tipo_x_jornada_Info> list = new List<ro_rubro_tipo_x_jornada_Info>();

                HttpContext.Current.Session[variable + IdTransaccionSession.ToString()] = list;
            }
            return (List<ro_rubro_tipo_x_jornada_Info>)HttpContext.Current.Session[variable + IdTransaccionSession.ToString()];
        }

        public void set_list(List<ro_rubro_tipo_x_jornada_Info> list, decimal IdTransaccionSession)
        {
            HttpContext.Current.Session[variable + IdTransaccionSession.ToString()] = list;
        }

        public void AddRow(ro_rubro_tipo_x_jornada_Info info_det, decimal IdTransaccionSession)
        {
            int IdEmpresa = string.IsNullOrEmpty(SessionFixed.IdEmpresa) ? 0 : Convert.ToInt32(SessionFixed.IdEmpresa);

            List<ro_rubro_tipo_x_jornada_Info> list = get_list(IdTransaccionSession);
            info_det.Secuencia = list.Count == 0 ? 1 : list.Max(q => q.Secuencia) + 1;
            if (info_det.IdRubroContabilizacion != null)
            {
                var info_rubro = bus_rubro.get_info(IdEmpresa, info_det.IdRubroContabilizacion);
                if (!string.IsNullOrEmpty(info_rubro.ToString()))
                    info_det.ru_descripcion = info_rubro.ru_descripcion;
            }

            if (info_det.IdJornada != 0)
            {
                var info_jornada = bus_jornada.get_info(IdEmpresa, info_det.IdJornada);
                if (!string.IsNullOrEmpty(info_jornada.ToString()))
                    info_det.Descripcion = info_jornada.Descripcion;
            }

            list.Add(info_det);
        }

        public void UpdateRow(ro_rubro_tipo_x_jornada_Info info_det, decimal IdTransaccionSession)
        {
            int IdEmpresa = string.IsNullOrEmpty(SessionFixed.IdEmpresa) ? 0 : Convert.ToInt32(SessionFixed.IdEmpresa);

            ro_rubro_tipo_x_jornada_Info edited_info = get_list(IdTransaccionSession).Where(m => m.Secuencia == info_det.Secuencia).First();
            edited_info.IdJornada = info_det.IdJornada;
            edited_info.IdRubroContabilizacion = info_det.IdRubroContabilizacion;

            if (info_det.IdRubroContabilizacion != null)
            {
                var info_rubro = bus_rubro.get_info(IdEmpresa, info_det.IdRubroContabilizacion);
                if (!string.IsNullOrEmpty(info_rubro.ToString()))
                    info_det.ru_descripcion = info_rubro.ru_descripcion;
            }

            if (info_det.IdJornada != 0)
            {
                var info_jornada = bus_jornada.get_info(IdEmpresa, info_det.IdJornada);
                if (!string.IsNullOrEmpty(info_jornada.ToString()))
                    info_det.Descripcion = info_jornada.Descripcion;
            }

            edited_info.ru_descripcion = info_det.ru_descripcion;
            edited_info.Descripcion = info_det.Descripcion;
        }

        public void DeleteRow(int secuencia, decimal IdTransaccionSession)
        {
            List<ro_rubro_tipo_x_jornada_Info> list = get_list(IdTransaccionSession);
            list.Remove(list.Where(m => m.Secuencia == secuencia).First());
        }
    }
}