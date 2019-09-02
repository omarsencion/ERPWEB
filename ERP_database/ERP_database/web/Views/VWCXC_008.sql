﻿CREATE VIEW [web].[VWCXC_008]
AS
SELECT dbo.fa_factura.IdEmpresa, dbo.fa_factura.IdSucursal, dbo.fa_factura.IdBodega, dbo.fa_factura.IdCbteVta, dbo.fa_factura.vt_tipoDoc, 
                  dbo.fa_factura.vt_serie1 + '-' + dbo.fa_factura.vt_serie2 + '-' + dbo.fa_factura.vt_NumFactura AS vt_NumFactura, dbo.fa_factura.vt_fecha, dbo.cxc_cobro_det.IdCobro, dbo.cxc_cobro_det.dc_ValorPago, dbo.cxc_cobro_tipo.tc_descripcion, 
                  dbo.cxc_cobro.cr_fecha, dbo.cxc_cobro.cr_estado, dbo.cxc_cobro.cr_observacion, dbo.cxc_cobro.IdCliente, dbo.tb_persona.pe_nombreCompleto, dbo.tb_sucursal.Su_Descripcion, dbo.cxc_cobro_det.IdCobro_tipo, 
                  comc.Fecha AS FechaLiquidacion
FROM     dbo.cxc_cobro_tipo INNER JOIN
                  dbo.cxc_cobro_det INNER JOIN
                  dbo.cxc_cobro ON dbo.cxc_cobro_det.IdEmpresa = dbo.cxc_cobro.IdEmpresa AND dbo.cxc_cobro_det.IdSucursal = dbo.cxc_cobro.IdSucursal AND dbo.cxc_cobro_det.IdCobro = dbo.cxc_cobro.IdCobro ON 
                  dbo.cxc_cobro_tipo.IdCobro_tipo = dbo.cxc_cobro_det.IdCobro_tipo INNER JOIN
                  dbo.fa_factura INNER JOIN
                  dbo.fa_cliente ON dbo.fa_factura.IdEmpresa = dbo.fa_cliente.IdEmpresa AND dbo.fa_factura.IdCliente = dbo.fa_cliente.IdCliente INNER JOIN
                  dbo.tb_persona ON dbo.fa_cliente.IdPersona = dbo.tb_persona.IdPersona ON dbo.cxc_cobro_det.IdEmpresa = dbo.fa_factura.IdEmpresa AND dbo.cxc_cobro_det.IdSucursal = dbo.fa_factura.IdSucursal AND 
                  dbo.cxc_cobro_det.IdBodega_Cbte = dbo.fa_factura.IdBodega AND dbo.cxc_cobro_det.IdCbte_vta_nota = dbo.fa_factura.IdCbteVta AND dbo.cxc_cobro_det.dc_TipoDocumento = dbo.fa_factura.vt_tipoDoc INNER JOIN
                  dbo.tb_sucursal ON dbo.tb_sucursal.IdEmpresa = dbo.cxc_cobro.IdEmpresa AND dbo.tb_sucursal.IdSucursal = dbo.cxc_cobro.IdSucursal LEFT OUTER JOIN
                  dbo.cxc_LiquidacionTarjeta_x_cxc_cobro AS com ON dbo.cxc_cobro.IdEmpresa = com.IdEmpresa AND dbo.cxc_cobro.IdSucursal = com.IdSucursal AND dbo.cxc_cobro.IdCobro = com.IdCobro LEFT OUTER JOIN
                  dbo.cxc_LiquidacionTarjeta AS comc ON comc.IdEmpresa = com.IdEmpresa AND comc.IdSucursal = com.IdSucursal AND comc.IdLiquidacion = com.IdLiquidacion
UNION ALL
SELECT fa_notaCreDeb.IdEmpresa, fa_notaCreDeb.IdSucursal, fa_notaCreDeb.IdBodega, fa_notaCreDeb.IdNota, fa_notaCreDeb.CodDocumentoTipo, fa_notaCreDeb.CodNota, fa_notaCreDeb.no_fecha, cxc_cobro_det.IdCobro, 
                  cxc_cobro_det.dc_ValorPago, cxc_cobro_tipo.tc_descripcion, cxc_cobro.cr_fecha, cxc_cobro.cr_estado, cxc_cobro.cr_observacion, cxc_cobro.IdCliente, tb_persona.pe_nombreCompleto, tb_sucursal.Su_Descripcion, 
                  cxc_cobro_det.IdCobro_tipo, comc.Fecha
FROM     cxc_cobro_tipo INNER JOIN
                  cxc_cobro_det INNER JOIN
                  cxc_cobro ON cxc_cobro_det.IdEmpresa = cxc_cobro.IdEmpresa AND cxc_cobro_det.IdSucursal = cxc_cobro.IdSucursal AND cxc_cobro_det.IdCobro = cxc_cobro.IdCobro ON 
                  cxc_cobro_tipo.IdCobro_tipo = cxc_cobro_det.IdCobro_tipo INNER JOIN
                  fa_notaCreDeb ON cxc_cobro_det.IdEmpresa = fa_notaCreDeb.IdEmpresa AND cxc_cobro_det.IdSucursal = fa_notaCreDeb.IdSucursal AND cxc_cobro_det.IdBodega_Cbte = fa_notaCreDeb.IdBodega AND 
                  cxc_cobro_det.IdCbte_vta_nota = fa_notaCreDeb.IdNota AND cxc_cobro_det.dc_TipoDocumento = fa_notaCreDeb.CodDocumentoTipo INNER JOIN
                  fa_cliente INNER JOIN
                  tb_persona ON fa_cliente.IdPersona = tb_persona.IdPersona ON fa_notaCreDeb.IdEmpresa = fa_cliente.IdEmpresa AND fa_notaCreDeb.IdCliente = fa_cliente.IdCliente INNER JOIN
                  tb_sucursal ON tb_sucursal.IdEmpresa = cxc_cobro.IdEmpresa AND tb_sucursal.IdSucursal = cxc_cobro.IdSucursal LEFT OUTER JOIN
                  dbo.cxc_LiquidacionTarjeta_x_cxc_cobro AS com ON dbo.cxc_cobro.IdEmpresa = com.IdEmpresa AND dbo.cxc_cobro.IdSucursal = com.IdSucursal AND dbo.cxc_cobro.IdCobro = com.IdCobro LEFT OUTER JOIN
                  dbo.cxc_LiquidacionTarjeta AS comc ON comc.IdEmpresa = com.IdEmpresa AND comc.IdSucursal = com.IdSucursal AND comc.IdLiquidacion = com.IdLiquidacion
UNION ALL
SELECT c.IdEmpresa, caj.IdSucursal, 1, c.IdCbteCble,'INCAJ', C.CodMoviCaja, c.cm_fecha, 0,d.cr_Valor, t.tm_descripcion, c.cm_fecha, c.Estado, c.cm_observacion, c.IdEntidad, per.pe_nombreCompleto, su.Su_Descripcion,
d.IdCobro_tipo,null
FROM caj_Caja_Movimiento AS C inner join 
caj_Caja as caj on c.IdEmpresa = caj.IdEmpresa and c.IdCaja = caj.IdCaja inner join 
caj_Caja_Movimiento_det as d on c.IdEmpresa = d.IdEmpresa and c.IdTipoCbte = d.IdTipocbte AND C.IdCbteCble = d.IdCbteCble inner join
caj_Caja_Movimiento_Tipo as t on c.IdEmpresa = t.IdEmpresa and c.IdTipoMovi = t.IdTipoMovi inner join
tb_persona as per on c.IdPersona = per.IdPersona inner join 
tb_sucursal as su on caj.IdEmpresa = su.IdEmpresa and caj.IdSucursal = su.IdSucursal 
where t.SeDeposita = 1 and t.tm_Signo = '+' and not exists(
select f.ct_IdEmpresa from cxc_cobro_x_ct_cbtecble as f
where c.IdEmpresa = f.ct_IdEmpresa
and c.IdTipocbte = f.ct_IdTipoCbte
and c.IdCbteCble = f.ct_IdCbteCble
)