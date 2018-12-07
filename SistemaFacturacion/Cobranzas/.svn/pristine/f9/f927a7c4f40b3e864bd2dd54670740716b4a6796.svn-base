using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace KSI.Cobranza.Web.Common.Thunderhead
{
    [XmlRoot(ElementName = "Transaction")]
    public class Transaction
    {
        [XmlElement(ElementName = "DocumentId")]
        public string DocumentId { get; set; }
        [XmlElement(ElementName = "ClientName")]
        public string ClientName { get; set; }
        [XmlElement(ElementName = "IdentificationType")]
        public string IdentificationType { get; set; }
        [XmlElement(ElementName = "IdentificationNumber")]
        public string IdentificationNumber { get; set; }
    }


    [XmlRoot(ElementName = "Recipient")]
    public class Recipient
    {
        [XmlElement(ElementName = "UserEmail")]
        public string UserEmail { get; set; }
        [XmlElement(ElementName = "CCopy")]
        public string CCopy { get; set; }
        [XmlElement(ElementName = "BCCopy")]
        public string BCCopy { get; set; }
        [XmlElement(ElementName = "PhoneNumber")]
        public string PhoneNumber { get; set; }
        [XmlElement(ElementName = "SendByPhone")]
        public int SendByPhone { get; set; }
        [XmlElement(ElementName = "Message")]
        public string Message { get; set; }

    }

    [XmlRoot(ElementName = "Attachment")]
    public class Attachment
    {
        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "Path")]
        public string Path { get; set; }
    }


    [XmlRoot(ElementName = "request")]
    public class Request
    {
        [XmlElement(ElementName = "RequestNo")]
        public string RequestNo { get; set; }
        [XmlElement(ElementName = "Dealer")]
        public string Dealer { get; set; }
        [XmlElement(ElementName = "YearsWorking")]
        public string YearsWorking { get; set; }
        [XmlElement(ElementName = "Office")]
        public string Office { get; set; }
    }

    [XmlRoot(ElementName = "Vehicle")]
    public class Vehicle
    {
        [XmlElement(ElementName = "Make")]
        public string Make { get; set; }
        [XmlElement(ElementName = "Model")]
        public string Model { get; set; }
        [XmlElement(ElementName = "Year")]
        public string Year { get; set; }
        [XmlElement(ElementName = "Chasis")]
        public string Chasis { get; set; }
        [XmlElement(ElementName = "VehicleValue")]
        public string VehicleValue { get; set; }
        [XmlElement(ElementName = "Value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "Client")]
    public class Client
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "Fee")]
    public class Fee
    {
        [XmlElement(ElementName = "Number")]
        public string Number { get; set; }
        [XmlElement(ElementName = "Selected")]
        public string Selected { get; set; }
        [XmlElement(ElementName = "Date")]
        public string Date { get; set; }
        [XmlElement(ElementName = "Amount")]
        public string Amount { get; set; }
        [XmlElement(ElementName = "feeAmountString")]
        public string FeeAmountString { get; set; }
        [XmlElement(ElementName = "Capital")]
        public string Capital { get; set; }
        [XmlElement(ElementName = "Interests")]
        public string Interests { get; set; }
        [XmlElement(ElementName = "Comission")]
        public string Comission { get; set; }
        [XmlElement(ElementName = "Spends")]
        public string Spends { get; set; }
        [XmlElement(ElementName = "Total")]
        public string Total { get; set; }
    }

    [XmlRoot(ElementName = "Loan")]
    public class Loan
    {
        [XmlElement(ElementName = "operationSpends")]
        public string OperationSpends { get; set; }
        [XmlElement(ElementName = "loanNo")]
        public string LoanNo { get; set; }
        [XmlElement(ElementName = "requestedAmount")]
        public string RequestedAmount { get; set; }
        [XmlElement(ElementName = "loanAmount")]
        public string LoanAmount { get; set; }
        [XmlElement(ElementName = "loanAmountString")]
        public string LoanAmountString { get; set; }
        [XmlElement(ElementName = "feeAmount")]
        public string FeeAmount { get; set; }
        [XmlElement(ElementName = "startDate")]
        public string StartDate { get; set; }
        [XmlElement(ElementName = "discountStartDate")]
        public string DiscountStartDate { get; set; }
        [XmlElement(ElementName = "feeQuantity")]
        public string FeeQuantity { get; set; }
        [XmlElement(ElementName = "feeQuantityString")]
        public string FeeQuantityString { get; set; }
        [XmlElement(ElementName = "paymentDays")]
        public string PaymentDays { get; set; }
        [XmlElement(ElementName = "LoanType")]
        public string LoanType { get; set; }
        [XmlElement(ElementName = "interetsRate")]
        public string InteretsRate { get; set; }
        [XmlElement(ElementName = "duration")]
        public string Duration { get; set; }
        [XmlElement(ElementName = "expirationDate")]
        public string ExpirationDate { get; set; }
        [XmlElement(ElementName = "totalAmount")]
        public string TotalAmount { get; set; }
        [XmlElement(ElementName = "totalCapital")]
        public string TotalCapital { get; set; }
        [XmlElement(ElementName = "totalComissions")]
        public string TotalComissions { get; set; }
        [XmlElement(ElementName = "totalInterets")]
        public string TotalInterets { get; set; }
        [XmlElement(ElementName = "MonthlyFee")]
        public string MonthlyFee { get; set; }
        [XmlElement(ElementName = "totalSpends")]
        public string TotalSpends { get; set; }
        [XmlElement(ElementName = "initialFee")]
        public string InitialFee { get; set; }
        [XmlElement(ElementName = "preAprobedAmount")]
        public string PreAprobedAmount { get; set; }
        [XmlElement(ElementName = "monthlyRate")]
        public string MonthlyRate { get; set; }
        [XmlElement(ElementName = "insuranceMonthlyFee")]
        public string InsuranceMonthlyFee { get; set; }
        [XmlElement(ElementName = "totalMontlyFee")]
        public string TotalMontlyFee { get; set; }
        [XmlElement(ElementName = "Client")]
        public Client Client { get; set; }
        [XmlElement(ElementName = "Fee")]
        public List<Fee> Fee { get; set; }
    }

    [XmlRoot(ElementName = "Financing")]
    public class Financing
    {
        [XmlElement(ElementName = "request")]
        public Request Request { get; set; }
        [XmlElement(ElementName = "Vehicle")]
        public Vehicle Vehicle { get; set; }
        [XmlElement(ElementName = "Loan")]
        public Loan Loan { get; set; }
    }

    [XmlRoot(ElementName = "dataset")]
    public class Dataset
    {
        [XmlElement(ElementName = "Transaction")]
        public Transaction Transaction { get; set; }
        [XmlElement(ElementName = "Recipients")]
        public Recipient Recipients { get; set; }
        [XmlElement(ElementName = "Financing")]
        public Financing Financing { get; set; }
        [XmlElement(ElementName = "Attachment")]
        public List<Attachment> Attachment { get; set; }
    }

}

