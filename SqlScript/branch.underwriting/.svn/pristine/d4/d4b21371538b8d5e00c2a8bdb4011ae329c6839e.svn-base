using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WEB.NewBusiness.Common.Thunderhead.LineasAliadas
{
    [XmlRoot(ElementName = "Transaction")]
    public class Transaction
    {
        [XmlElement(ElementName = "DocumentId")]
        public string DocumentId { get; set; }
        [XmlElement(ElementName = "Username")]
        public string Username { get; set; }
        [XmlElement(ElementName = "Email")]
        public string Email { get; set; }
        [XmlElement(ElementName = "BCCopy")]
        public string BCCopy { get; set; }
        [XmlElement(ElementName = "CCopy")]
        public string CCopy { get; set; }
    }

    [XmlRoot(ElementName = "PolicyInfo")]
    public class PolicyInfo
    {
        [XmlElement(ElementName = "NoPoliza")]
        public string NoPoliza { get; set; }
        [XmlElement(ElementName = "Ramo")]
        public string Ramo { get; set; }
        [XmlElement(ElementName = "Product")]
        public string Product { get; set; }
        [XmlElement(ElementName = "AgenteComercial")]
        public string AgenteComercial { get; set; }
        [XmlElement(ElementName = "InsuredAmount")]
        public decimal InsuredAmount { get; set; }
        [XmlElement(ElementName = "PolicyPeriodStart")]
        public string PolicyPeriodStart { get; set; }
        [XmlElement(ElementName = "PolicyPeriodEnd")]
        public string PolicyPeriodEnd { get; set; }
        [XmlElement(ElementName = "Branch")]
        public string Branch { get; set; }
    }

    [XmlRoot(ElementName = "Cliente")]
    public class Cliente
    {
        [XmlElement(ElementName = "FullName")]
        public string FullName { get; set; }
        [XmlElement(ElementName = "IdNumber")]
        public string IdNumber { get; set; }
        [XmlElement(ElementName = "TelephoneNumber")]
        public string TelephoneNumber { get; set; }
        [XmlElement(ElementName = "ShippingAddress")]
        public string ShippingAddress { get; set; }
        [XmlElement(ElementName = "Email")]
        public string Email { get; set; }
        [XmlElement(ElementName = "Direccion")]
        public string Direccion { get; set; }
    }

    [XmlRoot(ElementName = "CoInsurance")]
    public class CoInsurance
    {
        [XmlElement(ElementName = "CoInsurers")]
        public string CoInsurers { get; set; }
        [XmlElement(ElementName = "ParticipationP")]
        public decimal ParticipationP { get; set; }
    }


    [XmlRoot(ElementName = "ElementoAsegurado")]
    public class ElementoAsegurado
    {
        [XmlElement(ElementName = "Descripcion")]
        public string Descripcion { get; set; }
        [XmlElement(ElementName = "Valor")]
        public string Valor { get; set; }
    }


    [XmlRoot(ElementName = "Endorsement")]
    public class Endorsement
    {
        [XmlElement(ElementName = "Beneficiary")]
        public string Beneficiary { get; set; }
        [XmlElement(ElementName = "AmountCeded")]
        public decimal AmountCeded { get; set; }
    }


    [XmlRoot(ElementName = "CotizacionFire")]
    public class CotizacionFire
    {
        [XmlElement(ElementName = "TipoNegocio")]
        public string TipoNegocio { get; set; }
        [XmlElement(ElementName = "Actividad")]
        public string Actividad { get; set; }
        [XmlElement(ElementName = "TipoConstruccion")]
        public string TipoConstruccion { get; set; }
        [XmlElement(ElementName = "Location")]
        public string Location { get; set; }    
        [XmlElement(ElementName = "CondicionesPago")]
        public CondicionesPago CondicionesPago { get; set; }
        [XmlElement(ElementName = "ElementoAsegurado")]
        public List<ElementoAsegurado> ElementoAsegurado { get; set; }
    }


    [XmlRoot(ElementName = "Coverages")]
    public class Coverages
    {
        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "Percentage")]
        public string Percentage { get; set; }
        [XmlElement(ElementName = "Limit")]
        public string Limit { get; set; }
        [XmlElement(ElementName = "Base")]
        public string Base { get; set; }
        [XmlElement(ElementName = "DeducibleP")]
        public decimal DeducibleP { get; set; }

        [XmlElement(ElementName = "Minimo")]
        public decimal Minimo { get; set; }
        [XmlElement(ElementName = "Maximo")]
        public decimal Maximo { get; set; }
        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "Additionals")]
    public class Additionals
    {
        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "Limit")]
        public decimal Limit { get; set; }
    }

    [XmlRoot(ElementName = "EndorsementsClauses")]
    public class EndorsementsClauses
    {
        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }
    }

    
    [XmlRoot(ElementName = "CondicionesPago")]
    public class CondicionesPago
    {
        [XmlElement(ElementName = "NetPrime")]
        public decimal NetPrime { get; set; }
        [XmlElement(ElementName = "ISC")]
        public decimal ISC { get; set; }
        [XmlElement(ElementName = "TotalPrime")]
        public decimal TotalPrime { get; set; }
    }

    [XmlRoot(ElementName = "PaymentDetail")]
    public class PaymentDetail
    {
        [XmlElement(ElementName = "Currency")]
        public string Currency { get; set; }
        [XmlElement(ElementName = "NoFactura")]
        public string NoFactura { get; set; }
    }

    [XmlRoot(ElementName = "dataset")]
    public class Dataset
    {
        [XmlElement(ElementName = "Transaction")]
        public Transaction Transaction { get; set; }
        [XmlElement(ElementName = "PolicyInfo")]
        public PolicyInfo PolicyInfo { get; set; }
        [XmlElement(ElementName = "Cliente")]
        public Cliente Cliente { get; set; }
        [XmlElement(ElementName = "CoInsurance")]
        public CoInsurance CoInsurance { get; set; }
        [XmlElement(ElementName = "Coverages")]
        
        public List<Coverages> Coverages { get; set; }

        [XmlElement(ElementName = "Additionals")]
        public List<Additionals> Additionals { get; set; }
        [XmlElement(ElementName = "PaymentDetail")]
        public PaymentDetail PaymentDetail { get; set; }
        [XmlElement(ElementName = "CotizacionFire")]
        public List<CotizacionFire> CotizacionFire { get; set; }
        [XmlElement(ElementName = "EndorsementsClauses")]
        public List<EndorsementsClauses> EndorsementsClauses { get; set; }
        [XmlElement(ElementName = "Endorsement")]
        public Endorsement Endorsement { get; set; }
    }
}

