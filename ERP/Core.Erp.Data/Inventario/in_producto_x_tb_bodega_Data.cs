﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Erp.Info.Inventario;
namespace Core.Erp.Data.Inventario
{
   public class in_producto_x_tb_bodega_Data
    {

        public List<in_producto_x_tb_bodega_Info> get_lis(int IdEmpresa, decimal IdProducto)
        {
            List<in_producto_x_tb_bodega_Info> lista=null;
            int secuancia = 0;
            try
            {
                using (Entities_inventario Context=new Entities_inventario())
                {

                    lista = (from q in Context.vwin_producto_x_tb_bodega
                             where q.IdEmpresa == IdEmpresa
                             && q.IdProducto == IdProducto
                             select new in_producto_x_tb_bodega_Info
                             {
                                IdEmpresa=q.IdEmpresa,
                                IdSucursal=q.IdSucursal,
                                IdBodega=q.IdBodega,
                                IdProducto=q.IdProducto,
                                Su_Descripcion =q.Su_Descripcion,
                                bo_Descripcion = q.bo_Descripcion,
                                IdCtaCble_Costo = q.IdCtaCble_Costo,
                                Stock_minimo = q.Stock_minimo,
                                 pc_Cuenta = q.pc_Cuenta,
                                 pr_codigo= q.pr_codigo,
                                 pr_descripcion = q.pr_descripcion,
                                 ca_Categoria = q.ca_Categoria

                             }).ToList();
                        
                }
                lista.ForEach(v => { v.Secuencia = secuancia++; v.IdString = v.IdSucursal.ToString("000") + v.IdBodega.ToString("000"); });
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<in_producto_x_tb_bodega_Info> get_lis(int IdEmpresa, int IdSucursal)
        {
            int secuancia = 0;
            List<in_producto_x_tb_bodega_Info> lista = null;
            try
            {
                int IdSucursalIni = IdSucursal;
                int IdSucursalFin = IdSucursal == 0 ? 99999 : IdSucursal;

                using (Entities_general Context = new Entities_general())
                {

                    lista = (from q in Context.vwtb_bodega_x_sucursal
                             where q.IdEmpresa == IdEmpresa
                             && IdSucursalIni <= q.IdSucursal 
                             && q.IdSucursal <= IdSucursalFin
                             select new in_producto_x_tb_bodega_Info
                             {
                                 IdEmpresa = q.IdEmpresa,
                                 IdSucursal = q.IdSucursal,
                                 IdBodega = q.IdBodega,
                                 Su_Descripcion = q.Su_Descripcion,
                                 bo_Descripcion = q.bo_Descripcion
                             }).ToList();

                }
                lista.ForEach(v => { v.Secuencia = secuancia++; v.IdString = v.IdSucursal.ToString("000") + v.IdBodega.ToString("000"); });
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public List<in_producto_x_tb_bodega_Info> get_list_x_bodega(int IdEmpresa, int IdSucursal, int IdBodega)
        {
            int secuencia = 1;
            int IdBodega_ini = IdBodega;
            int IdBodega_fin = IdBodega == 0 ? 999999 : IdBodega;
            List<in_producto_x_tb_bodega_Info> lista = null;
            try
            {
                int IdSucursalIni = IdSucursal;
                int IdSucursalFin = IdSucursal == 0 ? 99999 : IdSucursal;

                using (Entities_inventario Context = new Entities_inventario())
                {

                    lista = (from q in Context.vwin_producto_x_tb_bodega
                             where q.IdEmpresa == IdEmpresa
                             && IdSucursalIni <= q.IdSucursal
                             && q.IdSucursal <= IdSucursalFin
                             && IdBodega_ini <= q.IdBodega
                             && q.IdBodega <= IdBodega_fin
                             select new in_producto_x_tb_bodega_Info
                             {
                                 IdEmpresa = q.IdEmpresa,
                                 IdSucursal = q.IdSucursal,
                                 IdBodega = q.IdBodega,
                                 IdProducto = q.IdProducto,
                                 Su_Descripcion = q.Su_Descripcion,
                                 bo_Descripcion = q.bo_Descripcion,
                                 IdCtaCble_Costo = q.IdCtaCble_Costo,
                                 Stock_minimo = q.Stock_minimo,
                                 pc_Cuenta = q.pc_Cuenta,
                                 pr_codigo = q.pr_codigo,
                                 pr_descripcion = q.pr_descripcion,
                                 ca_Categoria = q.ca_Categoria                                 
                             }).ToList();

                }
                lista.ForEach(v => { v.Secuencia = secuencia++; v.IdString = v.IdSucursal.ToString("000") + v.IdBodega.ToString("000"); });
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool modificarDB(in_producto_x_tb_bodega_Info info)
        {
            try
            {
                using (Entities_inventario Context = new Entities_inventario())
                {
                    in_producto_x_tb_bodega Entity = Context.in_producto_x_tb_bodega.Where(q => q.IdEmpresa == info.IdEmpresa && q.IdSucursal == info.IdSucursal && q.IdBodega == info.IdBodega && q.IdProducto == info.IdProducto).FirstOrDefault();
                    if (Entity == null) return false;

                    Entity.IdCtaCble_Costo = info.IdCtaCble_Costo;

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
