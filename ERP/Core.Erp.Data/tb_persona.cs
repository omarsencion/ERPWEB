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
    
    public partial class tb_persona
    {
        public decimal IdPersona { get; set; }
        public string CodPersona { get; set; }
        public string pe_Naturaleza { get; set; }
        public string pe_nombreCompleto { get; set; }
        public string pe_razonSocial { get; set; }
        public string pe_apellido { get; set; }
        public string pe_nombre { get; set; }
        public string IdTipoDocumento { get; set; }
        public string pe_cedulaRuc { get; set; }
        public string pe_direccion { get; set; }
        public string pe_telfono_Contacto { get; set; }
        public string pe_celular { get; set; }
        public string pe_correo { get; set; }
        public string pe_sexo { get; set; }
        public string IdEstadoCivil { get; set; }
        public Nullable<System.DateTime> pe_fechaNacimiento { get; set; }
        public string pe_estado { get; set; }
        public Nullable<System.DateTime> pe_fechaCreacion { get; set; }
        public Nullable<System.DateTime> pe_fechaModificacion { get; set; }
        public string pe_UltUsuarioModi { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string MotivoAnulacion { get; set; }
        public string IdTipoCta_acreditacion_cat { get; set; }
        public string num_cta_acreditacion { get; set; }
        public Nullable<int> IdBanco_acreditacion { get; set; }
    
        public virtual tb_banco tb_banco { get; set; }
        public virtual tb_Catalogo tb_Catalogo { get; set; }
        public virtual tb_Catalogo tb_Catalogo1 { get; set; }
        public virtual tb_Catalogo tb_Catalogo2 { get; set; }
        public virtual tb_Catalogo tb_Catalogo3 { get; set; }
        public virtual tb_Catalogo tb_Catalogo4 { get; set; }
        public virtual tb_Catalogo tb_Catalogo5 { get; set; }
        public virtual tb_Catalogo tb_Catalogo6 { get; set; }
    }
}
