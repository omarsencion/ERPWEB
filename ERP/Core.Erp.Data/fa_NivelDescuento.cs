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
    
    public partial class fa_NivelDescuento
    {
        public fa_NivelDescuento()
        {
            this.fa_factura = new HashSet<fa_factura>();
            this.fa_PuntoVta = new HashSet<fa_PuntoVta>();
            this.fa_cliente = new HashSet<fa_cliente>();
        }
    
        public int IdEmpresa { get; set; }
        public int IdNivel { get; set; }
        public string Descripcion { get; set; }
        public string Observacion { get; set; }
        public double Porcentaje { get; set; }
        public bool Estado { get; set; }
    
        public virtual ICollection<fa_factura> fa_factura { get; set; }
        public virtual ICollection<fa_PuntoVta> fa_PuntoVta { get; set; }
        public virtual ICollection<fa_cliente> fa_cliente { get; set; }
    }
}
