﻿using Core.Erp.Info.Contabilidad;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Data.Contabilidad
{
    public class ct_punto_cargo_grupo_Data
    {
        public List<ct_punto_cargo_grupo_Info> GetList(int IdEmpresa, bool mostrar_anulados)
        {
            try
            {
                List<ct_punto_cargo_grupo_Info> Lista;
                using (Entities_contabilidad Context = new Entities_contabilidad())
                {
                    if(mostrar_anulados)
                        Lista = Context.ct_punto_cargo_grupo.Where(q => q.IdEmpresa == IdEmpresa).Select(q => new ct_punto_cargo_grupo_Info
                        {
                            IdEmpresa = q.IdEmpresa,
                            cod_Punto_cargo_grupo = q.cod_Punto_cargo_grupo,
                            estado = q.Estado,
                            nom_punto_cargo_grupo = q.nom_punto_cargo_grupo,
                            IdPunto_cargo_grupo = q.IdPunto_cargo_grupo,

                        }).ToList();
                    else
                        Lista = Context.ct_punto_cargo_grupo.Where(q => q.IdEmpresa == IdEmpresa && q.Estado == true).Select(q => new ct_punto_cargo_grupo_Info
                        {
                            IdEmpresa = q.IdEmpresa,
                            cod_Punto_cargo_grupo = q.cod_Punto_cargo_grupo,
                            estado = q.Estado,
                            nom_punto_cargo_grupo = q.nom_punto_cargo_grupo,
                            IdPunto_cargo_grupo = q.IdPunto_cargo_grupo,

                        }).ToList();
                }
                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ct_punto_cargo_grupo_Info GetInfo(int IdEmpresa, int IdPunto_cargo_grupo)
        {
            try
            {
                ct_punto_cargo_grupo_Info info = new ct_punto_cargo_grupo_Info();
                using (Entities_contabilidad Context = new Entities_contabilidad())
                {
                    ct_punto_cargo_grupo Entity = Context.ct_punto_cargo_grupo.Where(q => q.IdEmpresa == IdEmpresa && q.IdPunto_cargo_grupo == IdPunto_cargo_grupo).FirstOrDefault();
                    if (Entity == null) return null;
                    info = new ct_punto_cargo_grupo_Info
                    {
                        IdEmpresa = Entity.IdEmpresa,
                        cod_Punto_cargo_grupo = Entity.cod_Punto_cargo_grupo,
                        estado = Entity.Estado,
                        nom_punto_cargo_grupo = Entity.nom_punto_cargo_grupo,
                        IdPunto_cargo_grupo = Entity.IdPunto_cargo_grupo
                    };
                }
                return info;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private int GetId(int IdEmpresa)
        {
            try
            {
                int Id = 1;
                using (Entities_contabilidad Context = new Entities_contabilidad())
                {
                    var lst = from q in Context.ct_punto_cargo_grupo
                              where q.IdEmpresa == IdEmpresa
                              select q;
                    if (lst.Count() > 0)
                        Id = lst.Max(q => q.IdPunto_cargo_grupo) + 1;
                }
                return Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardarDB(ct_punto_cargo_grupo_Info info)
        {
            try
            {
                using (Entities_contabilidad Context = new Entities_contabilidad())
                {
                    Context.ct_punto_cargo_grupo.Add(new ct_punto_cargo_grupo
                    {
                        IdEmpresa = info.IdEmpresa,
                        IdPunto_cargo_grupo = info.IdPunto_cargo_grupo=GetId(info.IdEmpresa),
                        cod_Punto_cargo_grupo = info.cod_Punto_cargo_grupo,
                        Estado = true,
                        nom_punto_cargo_grupo = info.nom_punto_cargo_grupo,
                        IdUsuarioCreacion = info.IdUsuarioCreacion,
                        FechaCreacion = DateTime.Now
                    });
                    Context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ModificarDB(ct_punto_cargo_grupo_Info info)
        {
            try
            {
                using (Entities_contabilidad Context = new Entities_contabilidad())
                {
                    ct_punto_cargo_grupo Entity = Context.ct_punto_cargo_grupo.Where(q => q.IdEmpresa == info.IdEmpresa && q.IdPunto_cargo_grupo == info.IdPunto_cargo_grupo).FirstOrDefault();
                    if (Entity == null) return false;
                    Entity.cod_Punto_cargo_grupo = info.cod_Punto_cargo_grupo;
                    Entity.nom_punto_cargo_grupo = info.nom_punto_cargo_grupo;
                    Entity.IdUsuarioModificacion = info.IdUsuarioModificacion;
                    Entity.FechaModificacion = DateTime.Now;
                    Context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AnularDB(ct_punto_cargo_grupo_Info info)
        {
            try
            {
                using (Entities_contabilidad Context = new Entities_contabilidad())
                {
                    ct_punto_cargo_grupo Entity = Context.ct_punto_cargo_grupo.Where(q => q.IdEmpresa == info.IdEmpresa && q.IdPunto_cargo_grupo == info.IdPunto_cargo_grupo).FirstOrDefault();
                    if (Entity == null) return false;
                    Entity.Estado = false;
                    Entity.IdUsuarioAnulacion = info.IdUsuarioAnulacion;
                    Entity.FechaAnulacion = DateTime.Now;
                    Context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region Punto cargo grupo
        public List<ct_punto_cargo_grupo_Info> get_list_bajo_demanda(ListEditItemsRequestedByFilterConditionEventArgs args, int IdEmpresa)
        {
            var skip = args.BeginIndex;
            var take = args.EndIndex - args.BeginIndex + 1;
            List<ct_punto_cargo_grupo_Info> Lista = new List<ct_punto_cargo_grupo_Info>();
            Lista = get_list(IdEmpresa, skip, take, args.Filter);
            return Lista;
        }

        public List<ct_punto_cargo_grupo_Info> get_list(int IdEmpresa, int skip, int take, string filter)
        {
            try
            {
                List<ct_punto_cargo_grupo_Info> Lista = new List<ct_punto_cargo_grupo_Info>();

                using (Entities_contabilidad context_g = new Entities_contabilidad())
                {
                    Lista = context_g.ct_punto_cargo_grupo.Where(q => q.IdEmpresa == IdEmpresa && q.Estado && (q.IdPunto_cargo_grupo + " " + q.nom_punto_cargo_grupo).Contains(filter)).OrderBy(q => q.IdPunto_cargo_grupo).Skip(skip).Take(take).ToList().Select(q => new ct_punto_cargo_grupo_Info
                    {
                        IdPunto_cargo_grupo = q.IdPunto_cargo_grupo,
                        nom_punto_cargo_grupo = q.nom_punto_cargo_grupo
                    }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ct_punto_cargo_grupo_Info get_info_bajo_demanda(ListEditItemRequestedByValueEventArgs args, int IdEmpresa)
        {
            //La variable args del devexpress ya trae el ID seleccionado en la propiedad Value, se pasa el IdEmpresa porque es un filtro que no tiene
            return GetInfo(IdEmpresa, args.Value == null ? 0 : Convert.ToInt32(args.Value));
        }
        #endregion

    }
}
