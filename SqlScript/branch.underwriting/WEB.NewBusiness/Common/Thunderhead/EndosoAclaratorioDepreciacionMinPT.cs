using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace WEB.NewBusiness.Common.Thunderhead.EndorsementClarifiyingDepre
{
    [XmlRoot(ElementName = "Transaction")]
    public class Transaction
    {
        [XmlElement(ElementName = "DocumentId")]
        public string DocumentId { get; set; }
        [XmlElement(ElementName = "PolicyNumber")]
        public string PolicyNumber { get; set; }
        [XmlElement(ElementName = "Intermediario")]
        public string Intermediario { get; set; }
    }

    [XmlRoot(ElementName = "Vehicles")]
    public class Vehicles
    {
        [XmlElement(ElementName = "VehicleType")]
        public string VehicleType { get; set; }
        [XmlElement(ElementName = "Brand")]
        public string Brand { get; set; }
        [XmlElement(ElementName = "Year")]
        public string Year { get; set; }
        [XmlElement(ElementName = "Chasis")]
        public string Chasis { get; set; }
        [XmlElement(ElementName = "Placa")]
        public string Placa { get; set; }
        [XmlElement(ElementName = "Plan")]
        public string Plan { get; set; }
    }

    [XmlRoot(ElementName = "Quotation")]
    public class Quotation
    {
        [XmlElement(ElementName = "StartDate")]
        public string StartDate { get; set; }
        [XmlElement(ElementName = "EndDate")]
        public string EndDate { get; set; }
        [XmlElement(ElementName = "PrincipalName")]
        public string PrincipalName { get; set; }
        [XmlElement(ElementName = "Product")]
        public string Product { get; set; }
        [XmlElement(ElementName = "Vehicles")]
        public List<Vehicles> Vehicles { get; set; }
        [XmlElement(ElementName = "QuotationNumber")]
        public string QuotationNumber { get; set; }
        [XmlElement(ElementName = "DepreciationRate")]
        public decimal DepreciationRate { get; set; }
    }

    [XmlRoot(ElementName = "POS_AUTO")]
    public class POS_AUTO
    {
        [XmlElement(ElementName = "Transaction")]
        public Transaction Transaction { get; set; }
        [XmlElement(ElementName = "Quotation")]
        public Quotation Quotation { get; set; }
    }

}
