//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data.Reportes.Base
{
    using System;
    
    public partial class SPACTF_004_detalle_Result
    {
        public int IdEmpresa { get; set; }
        public int IdActivoFijo { get; set; }
        public string IdUsuario { get; set; }
        public int IdSucursal { get; set; }
        public string Su_Descripcion { get; set; }
        public string CodActivoFijo { get; set; }
        public string Af_Nombre { get; set; }
        public int IdActivoFijoTipo { get; set; }
        public string tipo_AF { get; set; }
        public int IdCategoria_Af { get; set; }
        public string Categoria_AF { get; set; }
        public double Af_costo_compra { get; set; }
        public double Af_Depreciacion_acum { get; set; }
        public double Costo_actual { get; set; }
        public double valor_ult_depreciacion { get; set; }
        public System.DateTime Af_fecha_compra { get; set; }
    }
}