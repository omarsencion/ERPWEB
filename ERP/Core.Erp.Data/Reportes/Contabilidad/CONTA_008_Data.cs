﻿using Core.Erp.Data.General;
using Core.Erp.Data.Reportes.Base;
using Core.Erp.Info.Reportes.Contabilidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Erp.Data.Reportes.Contabilidad
{
    public class CONTA_008_Data
    {
        tb_sucursal_Data data_sucursal = new tb_sucursal_Data();
        string Su_Descripcion = "";
        public List<CONTA_008_Info> get_list(int IdEmpresa, DateTime fechaIni, DateTime fechaFin, string IdUsuario, bool mostrarSaldo0, bool MostrarSaldoAcumulado)
        {
            try
            {
                List<CONTA_008_Info> Lista = new List<CONTA_008_Info>();
                using (Entities_reportes Context = new Entities_reportes())
                {
                    Lista = (from q in Context.SPCONTA_008(IdEmpresa, fechaIni, fechaFin, IdUsuario, mostrarSaldo0, MostrarSaldoAcumulado)
                             select new CONTA_008_Info
                             {
                                 IdUsuario = q.IdUsuario,
                                 IdEmpresa = q.IdEmpresa,
                                 IdCtaCble = q.IdCtaCble,
                                 pc_Cuenta = q.pc_Cuenta,
                                 IdCtaCblePadre = q.IdCtaCblePadre,
                                 EsCtaUtilidad = q.EsCtaUtilidad,
                                 IdNivelCta = q.IdNivelCta,
                                 IdGrupoCble = q.IdGrupoCble,
                                 gc_estado_financiero = q.gc_estado_financiero,
                                 gc_GrupoCble = q.gc_GrupoCble,
                                 gc_Orden = q.gc_Orden,
                                 SaldoFinal = q.SaldoFinal,
                                 EsCuentaMovimiento = q.EsCuentaMovimiento,
                                 Naturaleza = q.Naturaleza,
                                 SaldoFinalNaturaleza = q.SaldoFinalNaturaleza,
                                 Su_Descripcion = Su_Descripcion
                             }).ToList();
                }
                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
