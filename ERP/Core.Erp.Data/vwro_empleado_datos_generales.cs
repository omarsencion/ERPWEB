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
    
    public partial class vwro_empleado_datos_generales
    {
        public int IdEmpresa { get; set; }
        public Nullable<decimal> IdEmpleado_Supervisor { get; set; }
        public decimal IdPersona { get; set; }
        public int IdSucursal { get; set; }
        public string IdTipoEmpleado { get; set; }
        public string em_codigo { get; set; }
        public string Codigo_Biometrico { get; set; }
        public string em_lugarNacimiento { get; set; }
        public string em_CarnetIees { get; set; }
        public string em_cedulaMil { get; set; }
        public Nullable<System.DateTime> em_fechaSalida { get; set; }
        public Nullable<System.DateTime> em_fechaIngaRol { get; set; }
        public string em_tipoCta { get; set; }
        public string em_NumCta { get; set; }
        public string em_estado { get; set; }
        public Nullable<int> IdCodSectorial { get; set; }
        public int IdDepartamento { get; set; }
        public string IdTipoSangre { get; set; }
        public Nullable<int> IdCargo { get; set; }
        public string IdCtaCble_Emplea { get; set; }
        public string IdCiudad { get; set; }
        public string em_mail { get; set; }
        public string IdTipoLicencia { get; set; }
        public Nullable<int> IdBanco { get; set; }
        public Nullable<int> IdArea { get; set; }
        public Nullable<int> IdDivision { get; set; }
        public double por_discapacidad { get; set; }
        public string carnet_conadis { get; set; }
        public Nullable<double> talla_pant { get; set; }
        public string talla_camisa { get; set; }
        public Nullable<double> talla_zapato { get; set; }
        public string em_status { get; set; }
        public string IdCondicionDiscapacidadSRI { get; set; }
        public string IdTipoIdentDiscapacitadoSustitutoSRI { get; set; }
        public string IdentDiscapacitadoSustitutoSRI { get; set; }
        public string IdAplicaConvenioDobleImposicionSRI { get; set; }
        public string IdTipoResidenciaSRI { get; set; }
        public string IdTipoSistemaSalarioNetoSRI { get; set; }
        public bool es_AcreditaHorasExtras { get; set; }
        public string IdTipoAnticipo { get; set; }
        public Nullable<double> ValorAnticipo { get; set; }
        public string CodigoSectorial { get; set; }
        public Nullable<double> em_AnticipoSueldo { get; set; }
        public bool Marca_Biometrico { get; set; }
        public Nullable<int> IdHorario { get; set; }
        public string pe_Naturaleza { get; set; }
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
        public string Su_Descripcion { get; set; }
        public string de_descripcion { get; set; }
        public string ca_descripcion { get; set; }
        public string Descripcion { get; set; }
        public decimal IdEmpleado { get; set; }
        public string pe_apellido { get; set; }
        public bool Tiene_ingresos_compartidos { get; set; }
        public bool Pago_por_horas { get; set; }
        public Nullable<double> Valor_horas_vespertina { get; set; }
        public Nullable<double> Valor_horas_matutino { get; set; }
        public Nullable<double> Valor_maximo_horas_vesp { get; set; }
        public Nullable<double> Valor_maximo_horas_mat { get; set; }
        public Nullable<double> Valor_horas_brigada { get; set; }
        public Nullable<double> Valor_horas_extras { get; set; }
        public bool GozaMasDeQuinceDiasVaciones { get; set; }
        public double DiasVacaciones { get; set; }
    }
}
