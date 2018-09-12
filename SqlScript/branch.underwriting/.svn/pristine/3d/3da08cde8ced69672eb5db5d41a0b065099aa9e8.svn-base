using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WEB.NewBusiness.Common.Thunderhead.SysFlex
{

    [XmlRoot(ElementName = "Transaction")]
    public class Transaction
    {
        [XmlElement(ElementName = "DocumentId")]
        public string DocumentId { get; set; }
        [XmlElement(ElementName = "Fullname")]
        public string Fullname { get; set; }
        [XmlElement(ElementName = "NoPoliza")]
        public string NoPoliza { get; set; }
        [XmlElement(ElementName = "TipoPoliza")]
        public string TipoPoliza { get; set; }
        [XmlElement(ElementName = "DiasVencimiento")]
        public string DiasVencimiento { get; set; }
        [XmlElement(ElementName = "AgenteComercial")]
        public string AgenteComercial { get; set; }
        [XmlElement(ElementName = "OficinaComercial")]
        public string OficinaComercial { get; set; }
        [XmlElement(ElementName = "Fianza")]
        public string Fianza { get; set; }
        [XmlElement(ElementName = "BCCopy")]
        public string BCCopy { get; set; }
        [XmlElement(ElementName = "CCopy")]
        public string CCopy { get; set; }
        [XmlElement(ElementName = "Ramo")]
        public string Ramo { get; set; }
        [XmlElement(ElementName = "FechaPago")]
        public string FechaPago { get; set; }
        [XmlElement(ElementName = "ValorVencido")]
        public string ValorVencido { get; set; }
        [XmlElement(ElementName = "Moneda")]
        public string Moneda { get; set; }
        [XmlElement(ElementName = "Supervisor")]
        public string Supervisor { get; set; }
        [XmlElement(ElementName = "FechaVencimiento")]
        public string FechaVencimiento { get; set; }
        [XmlElement(ElementName = "Username")]
        public string Username { get; set; }
        [XmlElement(ElementName = "Address")]
        public string Address { get; set; }
        [XmlElement(ElementName = "NoComprobante")]
        public string NoComprobante { get; set; }
        [XmlElement(ElementName = "DescripcionComprobante")]
        public string DescripcionComprobante { get; set; }
    }

    [XmlRoot(ElementName = "ThirdDamagesCoverages")]
    public class ThirdDamagesCoverages
    {
        [XmlElement(ElementName = "Limit")]
        public string Limit { get; set; }
        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }
    }

    [XmlRoot(ElementName = "Vehicles")]
    public class Vehicles
    {
        [XmlElement(ElementName = "EnsuredAmount")]
        public string EnsuredAmount { get; set; }
        [XmlElement(ElementName = "TotalVehiclePrime")]
        public string TotalVehiclePrime { get; set; }
        [XmlElement(ElementName = "ThirdDamagesCoverages")]
        public ThirdDamagesCoverages ThirdDamagesCoverages { get; set; }
    }

    [XmlRoot(ElementName = "Drivers")]
    public class Drivers
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "PrimeResume")]
    public class PrimeResume
    {
        [XmlElement(ElementName = "TotalAnualPrime")]
        public string TotalAnualPrime { get; set; }
        [XmlElement(ElementName = "Taxes")]
        public string Taxes { get; set; }
        [XmlElement(ElementName = "Discount")]
        public string Discount { get; set; }
        [XmlElement(ElementName = "TotalPayment")]
        public string TotalPayment { get; set; }
    }

    [XmlRoot(ElementName = "PrimeResumeInMovement")]
    public class PrimeResumeInMovement
    {
        [XmlElement(ElementName = "TotalAnualPrimeMov")]
        public string TotalAnualPrimeMov { get; set; }
        [XmlElement(ElementName = "TaxesMov")]
        public string TaxesMov { get; set; }
        [XmlElement(ElementName = "DiscountMov")]
        public string DiscountMov { get; set; }
        [XmlElement(ElementName = "TotalPaymentMov")]
        public string TotalPaymentMov { get; set; }
    }

    [XmlRoot(ElementName = "Paquete")]
    public class Paquete
    {
        [XmlElement(ElementName = "Product")]
        public string Product { get; set; }
        [XmlElement(ElementName = "Email")]
        public string Email { get; set; }
        [XmlElement(ElementName = "NumberOfPayments")]
        public string NumberOfPayments { get; set; }
        [XmlElement(ElementName = "NumberOfVehicles")]
        public string NumberOfVehicles { get; set; }
        [XmlElement(ElementName = "IdNumber")]
        public string IdNumber { get; set; }
        [XmlElement(ElementName = "StartDate")]
        public string StartDate { get; set; }
        [XmlElement(ElementName = "EndDate")]
        public string EndDate { get; set; }
        [XmlElement(ElementName = "Vehicles")]
        public Vehicles[] Vehicles { get; set; }
        [XmlElement(ElementName = "Drivers")]
        public Drivers Drivers { get; set; }
        [XmlElement(ElementName = "PrimeResume")]
        public PrimeResume PrimeResume { get; set; }
        [XmlElement(ElementName = "PrimeResumeInMovement")]
        public PrimeResumeInMovement PrimeResumeInMovement { get; set; }
        [XmlElement(ElementName = "TipoDocumento")]
        public string TipoDocumento { get; set; }
    }

    [XmlRoot(ElementName = "Cliente")]
    public class Cliente
    {
        [XmlElement(ElementName = "CodigoCliente")]
        public string CodigoCliente { get; set; }
        [XmlElement(ElementName = "TelCasa")]
        public string TelCasa { get; set; }
        [XmlElement(ElementName = "TelTrabajo")]
        public string TelTrabajo { get; set; }
        [XmlElement(ElementName = "TelMovil")]
        public string TelMovil { get; set; }
    }

    [XmlRoot(ElementName = "AntiguedadSaldo")]
    public class AntiguedadSaldo
    {
        [XmlElement(ElementName = "Cliente")]
        public string Cliente { get; set; }
        [XmlElement(ElementName = "NoPoliza")]
        public string NoPoliza { get; set; }
        [XmlElement(ElementName = "InicioVigencia")]
        public string InicioVigencia { get; set; }
        [XmlElement(ElementName = "FinVigencia")]
        public string FinVigencia { get; set; }
        [XmlElement(ElementName = "FinCobertura")]
        public string FinCobertura { get; set; }
        [XmlElement(ElementName = "UltimoPago")]
        public string UltimoPago { get; set; }
        [XmlElement(ElementName = "NoVencido")]
        public string NoVencido { get; set; }
        [XmlElement(ElementName = "Antiguedad1")]
        public string Antiguedad1 { get; set; }
        [XmlElement(ElementName = "Antiguedad2")]
        public string Antiguedad2 { get; set; }
        [XmlElement(ElementName = "Antiguedad3")]
        public string Antiguedad3 { get; set; }
        [XmlElement(ElementName = "Antiguedad4")]
        public string Antiguedad4 { get; set; }
        [XmlElement(ElementName = "Antiguedad5")]
        public string Antiguedad5 { get; set; }
        [XmlElement(ElementName = "TotalVencido")]
        public string TotalVencido { get; set; }
        [XmlElement(ElementName = "Saldo")]
        public string Saldo { get; set; }
        [XmlElement(ElementName = "Pagado")]
        public string Pagado { get; set; }
        [XmlElement(ElementName = "Financiada")]
        public string Financiada { get; set; }
        [XmlElement(ElementName = "Domiciliada")]
        public string Domiciliada { get; set; }
        [XmlElement(ElementName = "FechaFactura")]
        public string FechaFactura { get; set; }
        [XmlElement(ElementName = "NoFactura")]
        public string NoFactura { get; set; }
    }

    [XmlRoot(ElementName = "Contabilidad")]
    public class Contabilidad
    {
        [XmlElement(ElementName = "AntiguedadSaldo")]
        public List<AntiguedadSaldo> AntiguedadSaldo { get; set; }
    }

    [XmlRoot(ElementName = "Agente")]
    public class Agente
    {
        [XmlElement(ElementName = "NombreAgente")]
        public string NombreAgente { get; set; }
        [XmlElement(ElementName = "CodigoAgente")]
        public string CodigoAgente { get; set; }
        [XmlElement(ElementName = "DireccionAgente")]
        public string DireccionAgente { get; set; }
        [XmlElement(ElementName = "Cliente")]
        public Cliente[] Cliente { get; set; }
        [XmlElement(ElementName = "Contabilidad")]
        public Contabilidad Contabilidad { get; set; }
    }

    [XmlRoot(ElementName = "Supervisor")]
    public class Supervisor
    {
        [XmlElement(ElementName = "NombreSupervisor")]
        public string NombreSupervisor { get; set; }
        [XmlElement(ElementName = "CodigoSupervisor")]
        public string CodigoSupervisor { get; set; }
        [XmlElement(ElementName = "Oficina")]
        public string Oficina { get; set; }
        [XmlElement(ElementName = "Canal")]
        public string Canal { get; set; }
        [XmlElement(ElementName = "Agente")]
        public Agente[] Agente { get; set; }
    }

    [XmlRoot(ElementName = "AUTO_SYSFLEX")]
    public class AUTO_SYSFLEX
    {
        [XmlElement(ElementName = "Transaction")]
        public Transaction Transaction { get; set; }
        [XmlElement(ElementName = "Paquete")]
        public Paquete Paquete { get; set; }
        [XmlElement(ElementName = "Supervisor")]
        public Supervisor Supervisor { get; set; }
        [XmlElement(ElementName = "Contabilidad")]
        public Contabilidad Contabilidad { get; set; }
    }
}
