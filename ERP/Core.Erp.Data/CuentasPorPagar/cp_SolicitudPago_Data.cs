﻿using Core.Erp.Info.CuentasPorPagar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Data.CuentasPorPagar
{
  public  class cp_SolicitudPago_Data
    {
        public List<cp_SolicitudPago_Info> GetList(int IdEmpresa , int IdSucursal, DateTime Fecha_ini, DateTime Fecha_fin, bool mostrar_anulados)
        {
            try
            {

                Fecha_ini = Fecha_ini.Date;
                Fecha_fin = Fecha_fin.Date; List<cp_SolicitudPago_Info> Lista;
                using (Entities_cuentas_por_pagar Context = new Entities_cuentas_por_pagar())
                {
                    if(mostrar_anulados)
                    Lista = Context.cp_SolicitudPago.Where(q => q.IdEmpresa == IdEmpresa
                             && q.IdSucursal == IdSucursal
                             && Fecha_ini <= q.Fecha && q.Fecha <= Fecha_fin).Select(q => new cp_SolicitudPago_Info
                    {
                        IdEmpresa = q.IdEmpresa,
                        IdSolicitud = q.IdSolicitud,
                        IdSucursal = q. IdSucursal,
                        IdProveedor = q.IdProveedor,
                        Concepto = q.Concepto,
                        Estado = q.Estado,
                        Fecha = q.Fecha,
                        Solicitante = q.Solicitante,
                        Valor = q.Valor,
                        IdUsuarioCreacion = q.IdUsuarioCreacion
                    }).ToList();

                    else
                        Lista =  Context.cp_SolicitudPago.Where(q => q.IdEmpresa == IdEmpresa 
                        && q.IdSucursal == IdSucursal
                        && Fecha_ini <= q.Fecha && q.Fecha <= Fecha_fin
                        && q.Estado == true).Select(q => new cp_SolicitudPago_Info
                        {
                            IdEmpresa = q.IdEmpresa,
                            IdSolicitud = q.IdSolicitud,
                            IdSucursal = q.IdSucursal,
                            IdProveedor = q.IdProveedor,
                            Concepto = q.Concepto,
                            Estado = q.Estado,
                            Fecha = q.Fecha,
                            Solicitante = q.Solicitante,
                            Valor = q.Valor,
                        IdUsuarioCreacion = q.IdUsuarioCreacion
                        }).ToList();
                }
                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public cp_SolicitudPago_Info GetInfo(int IdEmpresa, decimal IdSolicitud)
        {
            try
            {
                cp_SolicitudPago_Info info = new cp_SolicitudPago_Info();
                using (Entities_cuentas_por_pagar Context = new Entities_cuentas_por_pagar())
                {
                    cp_SolicitudPago Entity = Context.cp_SolicitudPago.Where(q => q.IdEmpresa == IdEmpresa && q.IdSolicitud == IdSolicitud).FirstOrDefault();
                    if (Entity == null) return null;
                    info = new cp_SolicitudPago_Info
                    {
                        IdEmpresa = Entity.IdEmpresa,
                        IdSolicitud = Entity.IdSolicitud,
                        IdSucursal = Entity.IdSucursal,
                        IdProveedor = Entity.IdProveedor,
                        Concepto = Entity.Concepto,
                        Estado = Entity.Estado,
                        Fecha = Entity.Fecha,
                        Solicitante = Entity.Solicitante,
                        Valor = Entity.Valor,
                        IdUsuarioCreacion = Entity.IdUsuarioCreacion
                    };
                }
                return info;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private decimal GetID(int IdEmpresa)
        {
            try
            {
                decimal ID = 1;
                using (Entities_cuentas_por_pagar Context = new Entities_cuentas_por_pagar())
                {
                    var lst = Context.cp_SolicitudPago.Where(q => q.IdEmpresa == IdEmpresa).ToList();
                    if (lst.Count > 0)
                        ID = lst.Max(q => q.IdSolicitud) +1;
                }
                return ID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardarDB(cp_SolicitudPago_Info info)
        {
            try
            {
                using (Entities_cuentas_por_pagar Context = new Entities_cuentas_por_pagar())
                {
                    cp_SolicitudPago Entity = Context.cp_SolicitudPago.Add(new cp_SolicitudPago
                    {
                        IdEmpresa = info.IdEmpresa,
                        IdSolicitud = info.IdSolicitud=GetID(info.IdEmpresa),
                        IdSucursal = info.IdSucursal,
                        IdProveedor = info.IdProveedor,
                        Concepto = info.Concepto,
                        Estado = true,
                        Fecha = info.Fecha.Date,
                        Solicitante = info.Solicitante,
                        Valor = info.Valor,
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

        public bool ModificarDB(cp_SolicitudPago_Info info)
        {
            try
            {
                using (Entities_cuentas_por_pagar Context = new Entities_cuentas_por_pagar())
                {
                    cp_SolicitudPago Entity = Context.cp_SolicitudPago.Where(q => q.IdEmpresa == info.IdEmpresa && q.IdSolicitud == info.IdSolicitud).FirstOrDefault();
                    if (Entity == null) return false;


                    Entity.IdSucursal = info.IdSucursal;
                    Entity.IdProveedor = info.IdProveedor;
                    Entity.Concepto = info.Concepto;
                    Entity.Fecha = info.Fecha.Date;
                    Entity.Solicitante = info.Solicitante;
                    Entity.Valor = info.Valor;
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

        public bool AnularDB(cp_SolicitudPago_Info info)
        {
            try
            {
                using (Entities_cuentas_por_pagar Context = new Entities_cuentas_por_pagar())
                {
                    cp_SolicitudPago Entity = Context.cp_SolicitudPago.Where(q => q.IdEmpresa == info.IdEmpresa && q.IdSolicitud == info.IdSolicitud).FirstOrDefault();
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

    }
}