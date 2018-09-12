using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WEB.NewBusiness.Common.RiskInspection.Thunderhead
{
    [XmlRoot(ElementName = "Transaction")]
    public class Transaction
    {
        [XmlElement(ElementName = "DocumentId")]
        public string DocumentId { get; set; }
        [XmlElement(ElementName = "Email")]
        public string Email { get; set; }
    }

    [XmlRoot(ElementName = "PolicyInfo")]
    public class PolicyInfo
    {
        [XmlElement(ElementName = "FullName")]
        public string FullName { get; set; }
        [XmlElement(ElementName = "NoPoliza")]
        public string NoPoliza { get; set; }
        [XmlElement(ElementName = "AgenteComercial")]
        public string AgenteComercial { get; set; }
        [XmlElement(ElementName = "TipoMoneda")]
        public string TipoMoneda { get; set; }
        [XmlElement(ElementName = "PolicyPeriodStart")]
        public string PolicyPeriodStart { get; set; }
        [XmlElement(ElementName = "PolicyPeriodEnd")]
        public string PolicyPeriodEnd { get; set; }
        [XmlElement(ElementName = "IssueDate")]
        public string IssueDate { get; set; }
    }

    [XmlRoot(ElementName = "Coverages")]
    public class Coverages
    {
        [XmlElement(ElementName = "Code")]
        public string Code { get; set; }
        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "Limit")]
        public string Limit { get; set; }
        [XmlElement(ElementName = "Percentage")]
        public string Percentage { get; set; }
    }

    [XmlRoot(ElementName = "ElementoAsegurado")]
    public class ElementoAsegurado
    {
        [XmlElement(ElementName = "Descripcion")]
        public string Descripcion { get; set; }
        [XmlElement(ElementName = "Valor")]
        public string Valor { get; set; }
    }

    [XmlRoot(ElementName = "CotizacionFire")]
    public class CotizacionFire
    {
        [XmlElement(ElementName = "TipoMoneda")]
        public string TipoMoneda { get; set; }
        [XmlElement(ElementName = "ColindanciaNorte")]
        public string ColindanciaNorte { get; set; }
        [XmlElement(ElementName = "ColindanciaSur")]
        public string ColindanciaSur { get; set; }
        [XmlElement(ElementName = "ColindanciaEste")]
        public string ColindanciaEste { get; set; }
        [XmlElement(ElementName = "ColindanciaOeste")]
        public string ColindanciaOeste { get; set; }
        [XmlElement(ElementName = "ElementoAsegurado")]
        public List<ElementoAsegurado> ElementoAsegurado { get; set; }
    }

    [XmlRoot(ElementName = "Cliente")]
    public class Cliente
    {
        [XmlElement(ElementName = "FullName")]
        public string FullName { get; set; }
        [XmlElement(ElementName = "IdNumber")]
        public string IdNumber { get; set; }
        [XmlElement(ElementName = "DUI")]
        public string DUI { get; set; }
        [XmlElement(ElementName = "NIT")]
        public string NIT { get; set; }
        [XmlElement(ElementName = "TelephoneNumber")]
        public string TelephoneNumber { get; set; }
        [XmlElement(ElementName = "Direccion")]
        public string Direccion { get; set; }
        [XmlElement(ElementName = "Email")]
        public string Email { get; set; }
        [XmlElement(ElementName = "TelResidencia")]
        public string TelResidencia { get; set; }
        [XmlElement(ElementName = "TelOficina")]
        public string TelOficina { get; set; }
        [XmlElement(ElementName = "TelCelular")]
        public string TelCelular { get; set; }
    }

    [XmlRoot(ElementName = "Descripcion")]
    public class Descripcion
    {
        [XmlElement(ElementName = "Detalle")]
        public string Detalle { get; set; }
        [XmlElement(ElementName = "Tipo")]
        public string Tipo { get; set; }
    }

    [XmlRoot(ElementName = "Nivel")]
    public class Nivel
    {
        [XmlElement(ElementName = "AreaPorPiso")]
        public string AreaPorPiso { get; set; }
        [XmlElement(ElementName = "AreaPorAptOficina")]
        public string AreaPorAptOficina { get; set; }
        [XmlElement(ElementName = "CantidadLocales")]
        public string CantidadLocales { get; set; }
    }

    [XmlRoot(ElementName = "Perdida")]
    public class Perdida
    {
        [XmlElement(ElementName = "Tiene")]
        public string Tiene { get; set; }
        [XmlElement(ElementName = "Nivel")]
        public string Nivel { get; set; }
        [XmlElement(ElementName = "Tipo")]
        public string Tipo { get; set; }
        [XmlElement(ElementName = "Otros")]
        public string Otros { get; set; }
    }

    [XmlRoot(ElementName = "Peligro")]
    public class Peligro
    {
        [XmlElement(ElementName = "Descripcion")]
        public string Descripcion { get; set; }
        [XmlElement(ElementName = "Valor")]
        public string Valor { get; set; }
        [XmlElement(ElementName = "Comentario")]
        public string Comentario { get; set; }
    }

    [XmlRoot(ElementName = "Proteccion")]
    public class Proteccion
    {
        [XmlElement(ElementName = "Descripcion")]
        public string Descripcion { get; set; }
        [XmlElement(ElementName = "Valor")]
        public string Valor { get; set; }
        [XmlElement(ElementName = "Cantidad")]
        public string Cantidad { get; set; }
        [XmlElement(ElementName = "Horario")]
        public string Horario { get; set; }
    }

    [XmlRoot(ElementName = "Exposures")]
    public class Exposures
    {
        [XmlElement(ElementName = "Descripcion")]
        public string Descripcion { get; set; }
        [XmlElement(ElementName = "Exposure")]
        public string Exposure { get; set; }
        [XmlElement(ElementName = "MPL")]
        public string MPL { get; set; }
        [XmlElement(ElementName = "EML")]
        public string EML { get; set; }
    }

    [XmlRoot(ElementName = "Inspeccion")]
    public class Inspeccion
    {
        [XmlElement(ElementName = "FechaInspeccion")]
        public string FechaInspeccion { get; set; }
        [XmlElement(ElementName = "Inspector")]
        public string Inspector { get; set; }
        [XmlElement(ElementName = "Entrevistador")]
        public string Entrevistador { get; set; }
    }

    [XmlRoot(ElementName = "Propiedad")]
    public class Propiedad
    {
        [XmlElement(ElementName = "Propiedad")]
        public string propiedad { get; set; }
        [XmlElement(ElementName = "DescripcionRiesgo")]
        public string DescripcionRiesgo { get; set; }
        [XmlElement(ElementName = "Tipo")]
        public string Tipo { get; set; }
        [XmlElement(ElementName = "Direccion")]
        public string Direccion { get; set; }
        [XmlElement(ElementName = "MovimientoComercial")]
        public string MovimientoComercial { get; set; }
        [XmlElement(ElementName = "NoEmpleados")]
        public string NoEmpleados { get; set; }
        [XmlElement(ElementName = "Horario")]
        public string Horario { get; set; }
        [XmlElement(ElementName = "AseguradoraAnterior")]
        public string AseguradoraAnterior { get; set; }
        [XmlElement(ElementName = "EdadConstrucccion")]
        public string EdadConstrucccion { get; set; }
        [XmlElement(ElementName = "FechaDeConstruccion")]
        public string FechaDeConstruccion { get; set; }
        [XmlElement(ElementName = "CantidadDeNiveles")]
        public string CantidadDeNiveles { get; set; }
        [XmlElement(ElementName = "FormaDeOcupacion")]
        public string FormaDeOcupacion { get; set; }
        [XmlElement(ElementName = "OrganizacionContable")]
        public string OrganizacionContable { get; set; }
        [XmlElement(ElementName = "TipoEdificio")]
        public string TipoEdificio { get; set; }
        [XmlElement(ElementName = "TipoEdificioOtro")]
        public string TipoEdificioOtro { get; set; }
        [XmlElement(ElementName = "TipoEdificacion")]
        public string TipoEdificacion { get; set; }
        [XmlElement(ElementName = "TipoEdificacionOtra")]
        public string TipoEdificacionOtra { get; set; }
        [XmlElement(ElementName = "NiveldeSiniestroEnZona")]
        public string NiveldeSiniestroEnZona { get; set; }
        [XmlElement(ElementName = "SiniestralidadDesc")]
        public string SiniestralidadDesc { get; set; }
        [XmlElement(ElementName = "Street")]
        public string Street { get; set; }
        [XmlElement(ElementName = "Sector")]
        public string Sector { get; set; }
        [XmlElement(ElementName = "Municipio")]
        public string Municipio { get; set; }
        [XmlElement(ElementName = "Provincia")]
        public string Provincia { get; set; }
        [XmlElement(ElementName = "Departamento")]
        public string Departamento { get; set; }
        [XmlElement(ElementName = "Longitud")]
        public string Longitud { get; set; }
        [XmlElement(ElementName = "Latitud")]
        public string Latitud { get; set; }
        [XmlElement(ElementName = "Categoria")]
        public string Categoria { get; set; }
        [XmlElement(ElementName = "Texto")]
        public string Texto { get; set; }
        [XmlElement(ElementName = "OpinionRiesgo")]
        public string OpinionRiesgo { get; set; }
        [XmlElement(ElementName = "RecomendacionesTecnicas")]
        public string RecomendacionesTecnicas { get; set; }
        [XmlElement(ElementName = "RecomendacionesHechas")]
        public string RecomendacionesHechas { get; set; }
        [XmlElement(ElementName = "Descripcion")]
        public List<Descripcion> Descripcion { get; set; }
        [XmlElement(ElementName = "Nivel")]
        public Nivel Nivel { get; set; }
        [XmlElement(ElementName = "Perdida")]
        public Perdida Perdida { get; set; }
        [XmlElement(ElementName = "Peligro")]
        public List<Peligro> Peligro { get; set; }
        [XmlElement(ElementName = "Proteccion")]
        public List<Proteccion> Proteccion { get; set; }
        [XmlElement(ElementName = "Exposures")]
        public List<Exposures> Exposures { get; set; }
        [XmlElement(ElementName = "Inspeccion")]
        public Inspeccion Inspeccion { get; set; }
    }

    [XmlRoot(ElementName = "dataset")]
    public class Dataset
    {
        [XmlElement(ElementName = "Transaction")]
        public Transaction Transaction { get; set; }
        [XmlElement(ElementName = "PolicyInfo")]
        public PolicyInfo PolicyInfo { get; set; }
        [XmlElement(ElementName = "Coverages")]
        public List<Coverages> Coverages { get; set; }
        [XmlElement(ElementName = "CotizacionFire")]
        public List<CotizacionFire> CotizacionFire { get; set; }
        [XmlElement(ElementName = "Cliente")]
        public Cliente Cliente { get; set; }
        [XmlElement(ElementName = "Propiedad")]
        public List<Propiedad> Propiedad { get; set; }
    }
}
