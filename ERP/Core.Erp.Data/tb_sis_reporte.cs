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
    
    public partial class tb_sis_reporte
    {
        public tb_sis_reporte()
        {
            this.tb_sis_reporte_x_seg_usuario = new HashSet<tb_sis_reporte_x_seg_usuario>();
            this.tb_sis_reporte_x_tb_empresa = new HashSet<tb_sis_reporte_x_tb_empresa>();
        }
    
        public string CodReporte { get; set; }
        public string nom_reporte { get; set; }
        public string CodModulo { get; set; }
        public string rpt_vista { get; set; }
        public bool rpt_usa_store_procedure { get; set; }
        public string rpt_store_procedure { get; set; }
        public string rpt_clase_info { get; set; }
        public string rpt_clase_data { get; set; }
        public string rpt_clase_bus { get; set; }
        public string rpt_clase_rpt { get; set; }
        public string mvc_area { get; set; }
        public string mvc_controlador { get; set; }
        public string mvc_accion { get; set; }
        public bool estado { get; set; }
        public bool se_muestra_administrador_reportes { get; set; }
        public int orden { get; set; }
        public string observacion { get; set; }
        public bool Se_Mustra_Disenador_rpt { get; set; }
    
        public virtual tb_modulo tb_modulo { get; set; }
        public virtual ICollection<tb_sis_reporte_x_seg_usuario> tb_sis_reporte_x_seg_usuario { get; set; }
        public virtual ICollection<tb_sis_reporte_x_tb_empresa> tb_sis_reporte_x_tb_empresa { get; set; }
    }
}
