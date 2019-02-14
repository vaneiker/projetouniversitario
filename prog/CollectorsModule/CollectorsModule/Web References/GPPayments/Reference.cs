﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace CollectorsModule.GPPayments {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="BasicHttpBinding_IGPPayments", Namespace="http://tempuri.org/")]
    public partial class GPPayments : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback NewCashPaymentOperationCompleted;
        
        private System.Threading.SendOrPostCallback NewCheckPaymentOperationCompleted;
        
        private System.Threading.SendOrPostCallback NewACHPaymentOperationCompleted;
        
        private System.Threading.SendOrPostCallback NewCreditCardPaymentOperationCompleted;
        
        private System.Threading.SendOrPostCallback NewSTBPaymentOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public GPPayments() {
            this.Url = global::CollectorsModule.Properties.Settings.Default.CollectorsModule_GPPayments_GPPayments;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event NewCashPaymentCompletedEventHandler NewCashPaymentCompleted;
        
        /// <remarks/>
        public event NewCheckPaymentCompletedEventHandler NewCheckPaymentCompleted;
        
        /// <remarks/>
        public event NewACHPaymentCompletedEventHandler NewACHPaymentCompleted;
        
        /// <remarks/>
        public event NewCreditCardPaymentCompletedEventHandler NewCreditCardPaymentCompleted;
        
        /// <remarks/>
        public event NewSTBPaymentCompletedEventHandler NewSTBPaymentCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IGPPayments/NewCashPayment", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public GPPaymentResult NewCashPayment([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] CashPayment cpPayment) {
            object[] results = this.Invoke("NewCashPayment", new object[] {
                        cpPayment});
            return ((GPPaymentResult)(results[0]));
        }
        
        /// <remarks/>
        public void NewCashPaymentAsync(CashPayment cpPayment) {
            this.NewCashPaymentAsync(cpPayment, null);
        }
        
        /// <remarks/>
        public void NewCashPaymentAsync(CashPayment cpPayment, object userState) {
            if ((this.NewCashPaymentOperationCompleted == null)) {
                this.NewCashPaymentOperationCompleted = new System.Threading.SendOrPostCallback(this.OnNewCashPaymentOperationCompleted);
            }
            this.InvokeAsync("NewCashPayment", new object[] {
                        cpPayment}, this.NewCashPaymentOperationCompleted, userState);
        }
        
        private void OnNewCashPaymentOperationCompleted(object arg) {
            if ((this.NewCashPaymentCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.NewCashPaymentCompleted(this, new NewCashPaymentCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IGPPayments/NewCheckPayment", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public GPPaymentResult NewCheckPayment([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] CheckPayment cpPayment) {
            object[] results = this.Invoke("NewCheckPayment", new object[] {
                        cpPayment});
            return ((GPPaymentResult)(results[0]));
        }
        
        /// <remarks/>
        public void NewCheckPaymentAsync(CheckPayment cpPayment) {
            this.NewCheckPaymentAsync(cpPayment, null);
        }
        
        /// <remarks/>
        public void NewCheckPaymentAsync(CheckPayment cpPayment, object userState) {
            if ((this.NewCheckPaymentOperationCompleted == null)) {
                this.NewCheckPaymentOperationCompleted = new System.Threading.SendOrPostCallback(this.OnNewCheckPaymentOperationCompleted);
            }
            this.InvokeAsync("NewCheckPayment", new object[] {
                        cpPayment}, this.NewCheckPaymentOperationCompleted, userState);
        }
        
        private void OnNewCheckPaymentOperationCompleted(object arg) {
            if ((this.NewCheckPaymentCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.NewCheckPaymentCompleted(this, new NewCheckPaymentCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IGPPayments/NewACHPayment", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public GPPaymentResult NewACHPayment([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] ACHPayment cpPayment) {
            object[] results = this.Invoke("NewACHPayment", new object[] {
                        cpPayment});
            return ((GPPaymentResult)(results[0]));
        }
        
        /// <remarks/>
        public void NewACHPaymentAsync(ACHPayment cpPayment) {
            this.NewACHPaymentAsync(cpPayment, null);
        }
        
        /// <remarks/>
        public void NewACHPaymentAsync(ACHPayment cpPayment, object userState) {
            if ((this.NewACHPaymentOperationCompleted == null)) {
                this.NewACHPaymentOperationCompleted = new System.Threading.SendOrPostCallback(this.OnNewACHPaymentOperationCompleted);
            }
            this.InvokeAsync("NewACHPayment", new object[] {
                        cpPayment}, this.NewACHPaymentOperationCompleted, userState);
        }
        
        private void OnNewACHPaymentOperationCompleted(object arg) {
            if ((this.NewACHPaymentCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.NewACHPaymentCompleted(this, new NewACHPaymentCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IGPPayments/NewCreditCardPayment", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public GPPaymentResult NewCreditCardPayment([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] CreditCardPayment cpPayment) {
            object[] results = this.Invoke("NewCreditCardPayment", new object[] {
                        cpPayment});
            return ((GPPaymentResult)(results[0]));
        }
        
        /// <remarks/>
        public void NewCreditCardPaymentAsync(CreditCardPayment cpPayment) {
            this.NewCreditCardPaymentAsync(cpPayment, null);
        }
        
        /// <remarks/>
        public void NewCreditCardPaymentAsync(CreditCardPayment cpPayment, object userState) {
            if ((this.NewCreditCardPaymentOperationCompleted == null)) {
                this.NewCreditCardPaymentOperationCompleted = new System.Threading.SendOrPostCallback(this.OnNewCreditCardPaymentOperationCompleted);
            }
            this.InvokeAsync("NewCreditCardPayment", new object[] {
                        cpPayment}, this.NewCreditCardPaymentOperationCompleted, userState);
        }
        
        private void OnNewCreditCardPaymentOperationCompleted(object arg) {
            if ((this.NewCreditCardPaymentCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.NewCreditCardPaymentCompleted(this, new NewCreditCardPaymentCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IGPPayments/NewSTBPayment", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public GPPaymentResult NewSTBPayment([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] STBPayment cpPayment) {
            object[] results = this.Invoke("NewSTBPayment", new object[] {
                        cpPayment});
            return ((GPPaymentResult)(results[0]));
        }
        
        /// <remarks/>
        public void NewSTBPaymentAsync(STBPayment cpPayment) {
            this.NewSTBPaymentAsync(cpPayment, null);
        }
        
        /// <remarks/>
        public void NewSTBPaymentAsync(STBPayment cpPayment, object userState) {
            if ((this.NewSTBPaymentOperationCompleted == null)) {
                this.NewSTBPaymentOperationCompleted = new System.Threading.SendOrPostCallback(this.OnNewSTBPaymentOperationCompleted);
            }
            this.InvokeAsync("NewSTBPayment", new object[] {
                        cpPayment}, this.NewSTBPaymentOperationCompleted, userState);
        }
        
        private void OnNewSTBPaymentOperationCompleted(object arg) {
            if ((this.NewSTBPaymentCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.NewSTBPaymentCompleted(this, new NewSTBPaymentCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(STBPayment))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CreditCardPayment))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ACHPayment))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CheckPayment))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/CSToGP")]
    public partial class CashPayment {
        
        private string currencyIDField;
        
        private decimal paymentAmountField;
        
        private bool paymentAmountFieldSpecified;
        
        private System.DateTime paymentDateField;
        
        private bool paymentDateFieldSpecified;
        
        private string paymentNotesField;
        
        private string policyNumberField;
        
        private string quoteNumberField;
        
        private string receivedByField;
        
        private string sourcePlatformField;
        
        private string sourceTransactionIDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string CurrencyID {
            get {
                return this.currencyIDField;
            }
            set {
                this.currencyIDField = value;
            }
        }
        
        /// <remarks/>
        public decimal PaymentAmount {
            get {
                return this.paymentAmountField;
            }
            set {
                this.paymentAmountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PaymentAmountSpecified {
            get {
                return this.paymentAmountFieldSpecified;
            }
            set {
                this.paymentAmountFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime PaymentDate {
            get {
                return this.paymentDateField;
            }
            set {
                this.paymentDateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PaymentDateSpecified {
            get {
                return this.paymentDateFieldSpecified;
            }
            set {
                this.paymentDateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string PaymentNotes {
            get {
                return this.paymentNotesField;
            }
            set {
                this.paymentNotesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string PolicyNumber {
            get {
                return this.policyNumberField;
            }
            set {
                this.policyNumberField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string QuoteNumber {
            get {
                return this.quoteNumberField;
            }
            set {
                this.quoteNumberField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string ReceivedBy {
            get {
                return this.receivedByField;
            }
            set {
                this.receivedByField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string SourcePlatform {
            get {
                return this.sourcePlatformField;
            }
            set {
                this.sourcePlatformField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string SourceTransactionID {
            get {
                return this.sourceTransactionIDField;
            }
            set {
                this.sourceTransactionIDField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/CSToGP")]
    public partial class GPPaymentResult {
        
        private decimal customerBalanceField;
        
        private bool customerBalanceFieldSpecified;
        
        private string paymentNumberField;
        
        private bool resultField;
        
        private bool resultFieldSpecified;
        
        /// <remarks/>
        public decimal CustomerBalance {
            get {
                return this.customerBalanceField;
            }
            set {
                this.customerBalanceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CustomerBalanceSpecified {
            get {
                return this.customerBalanceFieldSpecified;
            }
            set {
                this.customerBalanceFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string PaymentNumber {
            get {
                return this.paymentNumberField;
            }
            set {
                this.paymentNumberField = value;
            }
        }
        
        /// <remarks/>
        public bool Result {
            get {
                return this.resultField;
            }
            set {
                this.resultField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ResultSpecified {
            get {
                return this.resultFieldSpecified;
            }
            set {
                this.resultFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/CSToGP")]
    public partial class STBPayment : CashPayment {
        
        private string bankAccountHolderField;
        
        private string bankAccountNumberField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string BankAccountHolder {
            get {
                return this.bankAccountHolderField;
            }
            set {
                this.bankAccountHolderField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string BankAccountNumber {
            get {
                return this.bankAccountNumberField;
            }
            set {
                this.bankAccountNumberField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/CSToGP")]
    public partial class CreditCardPayment : CashPayment {
        
        private string creditCardIssuerField;
        
        private string creditCardMaskedCardNumberField;
        
        private string creditCardProcessorTransactionNumberField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string CreditCardIssuer {
            get {
                return this.creditCardIssuerField;
            }
            set {
                this.creditCardIssuerField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string CreditCardMaskedCardNumber {
            get {
                return this.creditCardMaskedCardNumberField;
            }
            set {
                this.creditCardMaskedCardNumberField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string CreditCardProcessorTransactionNumber {
            get {
                return this.creditCardProcessorTransactionNumberField;
            }
            set {
                this.creditCardProcessorTransactionNumberField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/CSToGP")]
    public partial class ACHPayment : CashPayment {
        
        private string bankAccountHolderField;
        
        private string bankAccountHolderGovernmentIDField;
        
        private string bankAccountNumberField;
        
        private int bankAccountTypeField;
        
        private bool bankAccountTypeFieldSpecified;
        
        private string bankRoutingNumberField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string BankAccountHolder {
            get {
                return this.bankAccountHolderField;
            }
            set {
                this.bankAccountHolderField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string BankAccountHolderGovernmentID {
            get {
                return this.bankAccountHolderGovernmentIDField;
            }
            set {
                this.bankAccountHolderGovernmentIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string BankAccountNumber {
            get {
                return this.bankAccountNumberField;
            }
            set {
                this.bankAccountNumberField = value;
            }
        }
        
        /// <remarks/>
        public int BankAccountType {
            get {
                return this.bankAccountTypeField;
            }
            set {
                this.bankAccountTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BankAccountTypeSpecified {
            get {
                return this.bankAccountTypeFieldSpecified;
            }
            set {
                this.bankAccountTypeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string BankRoutingNumber {
            get {
                return this.bankRoutingNumberField;
            }
            set {
                this.bankRoutingNumberField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/CSToGP")]
    public partial class CheckPayment : CashPayment {
        
        private string checkNumberField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string CheckNumber {
            get {
                return this.checkNumberField;
            }
            set {
                this.checkNumberField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    public delegate void NewCashPaymentCompletedEventHandler(object sender, NewCashPaymentCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class NewCashPaymentCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal NewCashPaymentCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public GPPaymentResult Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((GPPaymentResult)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    public delegate void NewCheckPaymentCompletedEventHandler(object sender, NewCheckPaymentCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class NewCheckPaymentCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal NewCheckPaymentCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public GPPaymentResult Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((GPPaymentResult)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    public delegate void NewACHPaymentCompletedEventHandler(object sender, NewACHPaymentCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class NewACHPaymentCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal NewACHPaymentCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public GPPaymentResult Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((GPPaymentResult)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    public delegate void NewCreditCardPaymentCompletedEventHandler(object sender, NewCreditCardPaymentCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class NewCreditCardPaymentCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal NewCreditCardPaymentCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public GPPaymentResult Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((GPPaymentResult)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    public delegate void NewSTBPaymentCompletedEventHandler(object sender, NewSTBPaymentCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class NewSTBPaymentCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal NewSTBPaymentCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public GPPaymentResult Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((GPPaymentResult)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591