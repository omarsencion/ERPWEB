﻿using Core.Erp.Info.Contabilidad;
using Core.Erp.Data.Contabilidad;
using Core.Erp.Info.Reportes.Contabilidad;
using System;
using System.Collections.Generic;
using System.Linq;
using Core.Erp.Data.Reportes.Base;
namespace Core.Erp.Data.Reportes.Contabilidad
{
    public class CONTA_002_Data
    {
        ct_plancta_Data data = new ct_plancta_Data();
        public List<CONTA_002_Info> get_list(int IdEmpresa, string IdCtaCble, string IdCtaCbleFin, int IdSucursal, DateTime fechaIni, DateTime fechaFin, int IdPuntoCargo, int IdPuntoCargoGrupo)
        {
             
            try
            {
                List<CONTA_002_Info> Lista = new List<CONTA_002_Info>();
                List<CONTA_002_Info> ListaReporte = new List<CONTA_002_Info>();
                fechaIni = fechaIni.Date;
                fechaFin = fechaFin.Date;
                int IdSucursalIni = IdSucursal;
                int IdSucursalFin = IdSucursal == 0 ? 99999 : IdSucursal;
                int IdPuntoCargo_ini = IdPuntoCargo;
                int IdPuntoCargo_fin = IdPuntoCargo == 0 ? 9999999 : IdPuntoCargo;
                int IdPuntoCargoGrupo_ini = IdPuntoCargoGrupo;
                int IdPuntoCargoGrupo_fin = IdPuntoCargoGrupo == 0 ? 9999999 : IdPuntoCargoGrupo;

                List<ct_plancta_Info> ListaCta = data.get_list_rango_cta(IdEmpresa, IdCtaCble, IdCtaCbleFin);

                using (Entities_reportes Context = new Entities_reportes())
                {
                    foreach (var item in ListaCta)
                    {
                        Lista = (from q in Context.SPCONTA_002(IdEmpresa, IdSucursalIni, IdSucursalFin, item.IdCtaCble, fechaIni, fechaFin,IdPuntoCargoGrupo_ini, IdPuntoCargoGrupo_fin, IdPuntoCargo_ini, IdPuntoCargo_fin)
                                 select new CONTA_002_Info
                                 {
                                     IdEmpresa = q.IdEmpresa,
                                     IdTipoCbte = q.IdTipoCbte,
                                     IdCbteCble = q.IdCbteCble,
                                     secuencia = q.secuencia,
                                     IdCtaCble = q.IdCtaCble,
                                     pc_Cuenta = q.pc_Cuenta,
                                     dc_Valor = q.dc_Valor,
                                     dc_Valor_Debe = q.dc_Valor_Debe,
                                     dc_Valor_Haber = q.dc_Valor_Haber,
                                     Saldo = q.Saldo,
                                     SaldoInicial = q.SaldoInicial,
                                     cb_Estado = q.cb_Estado,
                                     cb_Fecha = q.cb_Fecha ,
                                     cb_Observacion = q.cb_Observacion,
                                     tc_TipoCbte = q.tc_TipoCbte,
                                     IdMes = q.IdMes,
                                     smes = q.smes,
                                     IdAnio = (q.cb_Fecha ?? DateTime.Now.Date).Year,
                                     IdSucursal = q.IdSucursal,
                                     Su_Descripcion = q.Su_Descripcion,
                                     nom_punto_cargo = q.nom_punto_cargo,
                                     nom_punto_cargo_grupo = q.nom_punto_cargo_grupo
                                 }).ToList();

                        ListaReporte.AddRange(Lista);
                    }
                    
                }
                return ListaReporte;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
