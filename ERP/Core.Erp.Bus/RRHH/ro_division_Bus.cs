﻿using Core.Erp.Data.RRHH;
using Core.Erp.Info.RRHH;
using DevExpress.Web;
using System;
using System.Collections.Generic;
namespace Core.Erp.Bus.RRHH
{
    public class ro_division_Bus
    {
        ro_division_Data odata = new ro_division_Data();
        public List<ro_division_Info> get_list(int IdEmpresa, bool estado)
        {
            try
            {
                return odata.get_list(IdEmpresa, estado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ro_division_Info get_info(int IdEmpresa, int IdDivision)
        {
            try
            {
                return odata.get_info(IdEmpresa, IdDivision);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(ro_division_Info info)
        {
            try
            {
                return odata.guardarDB(info);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool modificarDB(ro_division_Info info)
        {
            try
            {

                return odata.modificarDB(info);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool anularDB(ro_division_Info info)
        {
            try
            {
                return odata.anularDB(info);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ro_division_Info> get_list_bajo_demanda_division(ListEditItemsRequestedByFilterConditionEventArgs args, int IdEmpresa, bool MostrarAnulados)
        {
            try
            {
                return odata.get_list_bajo_demanda(args, IdEmpresa, MostrarAnulados);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ro_division_Info get_info_bajo_demanda_division(ListEditItemRequestedByValueEventArgs args, int IdEmpresa)
        {
            try
            {
                return odata.get_info_bajo_demanda(args, IdEmpresa);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
