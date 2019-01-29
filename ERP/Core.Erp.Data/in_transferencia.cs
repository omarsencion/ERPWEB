//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class in_transferencia
    {
        public in_transferencia()
        {
            this.in_transferencia_det = new HashSet<in_transferencia_det>();
        }
    
        public int IdEmpresa { get; set; }
        public int IdSucursalOrigen { get; set; }
        public int IdBodegaOrigen { get; set; }
        public decimal IdTransferencia { get; set; }
        public string Codigo { get; set; }
        public int IdSucursalDest { get; set; }
        public int IdBodegaDest { get; set; }
        public string tr_Observacion { get; set; }
        public System.DateTime tr_fecha { get; set; }
        public Nullable<int> IdEmpresa_Ing_Egr_Inven_Origen { get; set; }
        public Nullable<int> IdSucursal_Ing_Egr_Inven_Origen { get; set; }
        public Nullable<int> IdMovi_inven_tipo_SucuOrig { get; set; }
        public Nullable<decimal> IdNumMovi_Ing_Egr_Inven_Origen { get; set; }
        public Nullable<int> IdEmpresa_Ing_Egr_Inven_Destino { get; set; }
        public Nullable<int> IdSucursal_Ing_Egr_Inven_Destino { get; set; }
        public Nullable<int> IdMovi_inven_tipo_SucuDest { get; set; }
        public Nullable<decimal> IdNumMovi_Ing_Egr_Inven_Destino { get; set; }
        public string IdUsuario { get; set; }
        public string Estado { get; set; }
        public string tr_userAnulo { get; set; }
        public Nullable<System.DateTime> tr_fechaAnulacion { get; set; }
        public Nullable<System.DateTime> tr_fecha_transaccion { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string motivo_anula { get; set; }
        public string IdEstadoAprobacion_cat { get; set; }
    
        public virtual in_Catalogo in_Catalogo { get; set; }
        public virtual in_Ing_Egr_Inven in_Ing_Egr_Inven { get; set; }
        public virtual in_Ing_Egr_Inven in_Ing_Egr_Inven1 { get; set; }
        public virtual ICollection<in_transferencia_det> in_transferencia_det { get; set; }
    }
}
