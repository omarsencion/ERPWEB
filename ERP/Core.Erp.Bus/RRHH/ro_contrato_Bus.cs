﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Erp.Data.RRHH;
using Core.Erp.Info.RRHH;
using Core.Erp.Info.Helps;

namespace Core.Erp.Bus.RRHH
{
  public class ro_contrato_Bus
    {
        ro_contrato_Data odata = new ro_contrato_Data();

        ro_empleado_Data data_empleado = new ro_empleado_Data();
        public List<ro_contrato_Info> get_list(int IdEmpresa, bool estado)
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
        public List<ro_contrato_Info> get_list(int IdEmpresa, decimal IdEmpleado, DateTime FechaInicio, DateTime FechaFin)
        {
            try
            {
               return odata.get_list(IdEmpresa, IdEmpleado, FechaInicio, FechaFin);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ro_contrato_Info get_info(int IdEmpresa, decimal IdEmpleado, int IdContrato)
        {
            try
            {
                return odata.get_info(IdEmpresa, IdEmpleado, IdContrato);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(ro_contrato_Info info)
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

        public bool modificarDB(ro_contrato_Info info)
        {
            try
            {
                bool bandera = true;
                if(info.EstadoContrato==cl_enumeradores.eEstadoContratoRRHH.ECT_PLQ.ToString())
                {
                    bandera= data_empleado.modificar_estadoDB(info.IdEmpresa, info.IdEmpleado, cl_enumeradores.eEstadoEmpleadoRRHH.EST_PLQ.ToString(), info.FechaFin.Date);
                }

                bandera= odata.modificarDB(info);

                return bandera;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool anularDB(ro_contrato_Info info)
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

        public double get_ultimo_sueldo(int IdEmpresa, decimal IdEmpleado)
        {
            try
            {
                return odata.get_ultimo_sueldo(IdEmpresa, IdEmpleado);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ro_contrato_Info get_info_contato_a_liquidar(int IdEmpresa, decimal IdEmpleado)
        {
            try
            {
                return odata.get_info_contato_a_liquidar(IdEmpresa, IdEmpleado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public decimal get_sueldo_actual(int IdEmpresa, decimal IdEmpleado)
        {
            try
            {
                return odata.get_sueldo_actual(IdEmpresa, IdEmpleado);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
