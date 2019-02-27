﻿using Core.Erp.Info.Reportes.CuentasPorPagar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Data.Reportes.CuentasPorPagar
{
  public class CXP_014_Data
    {
         public List<CXP_014_Info> GetList()
        {
            try
            {
                List<CXP_014_Info> Lista;
                using (Entities_reportes Context = new Entities_reportes())
                {
                    Lista = Context.VWCXP_014.Select(q => new CXP_014_Info

                    {

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
