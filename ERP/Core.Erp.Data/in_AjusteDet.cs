//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class in_AjusteDet
    {
        public int IdEmpresa { get; set; }
        public decimal IdAjuste { get; set; }
        public int Secuencia { get; set; }
        public decimal IdProducto { get; set; }
        public string IdUnidadMedida { get; set; }
        public double StockSistema { get; set; }
        public double StockFisico { get; set; }
        public double Ajuste { get; set; }
        public double Costo { get; set; }
    
        public virtual in_Ajuste in_Ajuste { get; set; }
        public virtual in_Producto in_Producto { get; set; }
        public virtual in_UnidadMedida in_UnidadMedida { get; set; }
    }
}
