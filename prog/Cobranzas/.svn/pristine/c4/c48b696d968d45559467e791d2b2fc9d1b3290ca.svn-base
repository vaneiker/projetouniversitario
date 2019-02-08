using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KSI.Cobranza.Web.Common.CustomValidators
{
    /// <summary>
    /// Author      : Lic. Carlos Ml. Lebron Batista
    /// Create Date : 10/18-2018
    /// </summary>
    public class DependencyNumericValueValidatorAttribute : ValidationAttribute
        //, IClientValidatable
    {
        public enum LogicOperatorType { MayorQue, MayorOIgual, MenorQue, MenorOIgual, Igual, Diferente }
        public enum NumberType { Decimal, Integer, Double }
        LogicOperatorType _logicOperatorType;
        NumberType _numberType;
        string _errorMessage;
        object _PropertyValue;

        public string _dependentProperty { get; set; }

        public DependencyNumericValueValidatorAttribute(string dependentProperty, string errorMessage, LogicOperatorType logicOperatorType, NumberType numberType)
        {
            _dependentProperty = dependentProperty;
            _logicOperatorType = logicOperatorType;
            _errorMessage = errorMessage;
            _numberType = numberType;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var containerType = validationContext.ObjectInstance.GetType();
            var field = containerType.GetProperty(this._dependentProperty);
            
            var dependentvalue = decimal.Parse(field.GetValue(validationContext.ObjectInstance, null).ToString());

            switch (_numberType)
            {
                case NumberType.Decimal:
                    break;
                case NumberType.Integer:
                    break;
                case NumberType.Double:
                    break;             
            }

            bool result = true;
            if (!string.IsNullOrEmpty(value.ToString()))
            {
                 _PropertyValue = decimal.Parse(value.ToString());
                var PropertyDependencyValue = dependentvalue;

                switch (_logicOperatorType)
                {
                    case LogicOperatorType.MayorQue:
                        result = (decimal)_PropertyValue > PropertyDependencyValue;
                        break;
                    case LogicOperatorType.MayorOIgual:
                        result = (decimal)_PropertyValue >= PropertyDependencyValue;
                        break;
                    case LogicOperatorType.MenorQue:
                        result = (decimal)_PropertyValue < PropertyDependencyValue;
                        break;
                    case LogicOperatorType.MenorOIgual:
                        result = (decimal)_PropertyValue <= PropertyDependencyValue;
                        break;
                    case LogicOperatorType.Igual:
                        result = (decimal)_PropertyValue == PropertyDependencyValue;
                        break;
                    case LogicOperatorType.Diferente:
                        result = (decimal)_PropertyValue != PropertyDependencyValue;
                        break;
                }
            }

            return
                  (!result) ? new ValidationResult(_errorMessage, new[] { validationContext.MemberName })
                            : ValidationResult.Success;
        }

        //public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        //{
        //    var rule = new ModelClientValidationRule()
        //    {
        //        ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
        //        ValidationType = "dependencynumericvaluevalidator",
        //    };

        //    string depProp = BuildDependentPropertyId(metadata, context as ViewContext);

        //    //// find the value on the control we depend on;
        //    //// if it's a bool, format it javascript style 
        //    //// (the default is True or False!)
        //    string targetValue = (this._PropertyValue ?? "").ToString();
        //    if (this._PropertyValue.GetType() == typeof(decimal))
        //        targetValue = targetValue.ToLower();

        //    rule.ValidationParameters.Add("dependentproperty", depProp);
        //    rule.ValidationParameters.Add("targetvalue", targetValue);

        //    yield return rule;
        //}
       

        //private string BuildDependentPropertyId(ModelMetadata metadata, ViewContext viewContext)
        //{
        //    // build the ID of the property
        //    string depProp = viewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(this._dependentProperty);
        //    // unfortunately this will have the name of the current field appended to the beginning,
        //    // because the TemplateInfo's context has had this fieldname appended to it. Instead, we
        //    // want to get the context as though it was one level higher (i.e. outside the current property,
        //    // which is the containing object (our Person), and hence the same level as the dependent property.
        //    var thisField = metadata.PropertyName + "_";
        //    if (depProp.StartsWith(thisField))
        //        // strip it off again
        //        depProp = depProp.Substring(thisField.Length);
        //    return depProp;
        //}
    }
}