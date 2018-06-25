﻿using Core.Erp.Data.SeguridadAcceso;
using Core.Erp.Info.SeguridadAcceso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Bus.SeguridadAcceso
{
    public class seg_Menu_x_Empresa_Bus
    {
        seg_Menu_x_Empresa_Data odata = new seg_Menu_x_Empresa_Data();

        public List<seg_Menu_x_Empresa_Info> get_list(int IdEmpresa)
        {
            try
            {
                return odata.get_list(IdEmpresa);
            }
            catch (Exception)
            {

                throw;
            }            
        }

        public bool eliminarDB(int IdEmpresa)
        {
            try
            {
                return odata.eliminarDB(IdEmpresa);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(List<seg_Menu_x_Empresa_Info> Lista, string IdUsuario = "")
        {
            try
            {
                return odata.guardarDB(Lista, IdUsuario);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
