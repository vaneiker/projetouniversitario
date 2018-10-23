﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KSI.Cobranza.Web.Common.CustomValidators
{
    /// <summary>
    /// Author      : Lic. Carlos Ml. Lebron Batista
    /// Create Date : 10/18-2018
    /// </summary>
    public class DependencyNumericValueValidator : ValidationAttribute
    {
        public enum LogicOperatorType { MayorQue, MayorOIgual, MenorQue, MenorOIgual, Igual, Diferente }
        LogicOperatorType _logicOperatorType;
        string _errorMessage;

        public string _dependentProperty { get; set; }

        public DependencyNumericValueValidator(string dependentProperty, string errorMessage, LogicOperatorType logicOperatorType)
        {
            _dependentProperty = dependentProperty;
            _logicOperatorType = logicOperatorType;
            _errorMessage = errorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var containerType = validationContext.ObjectInstance.GetType();
            var field = containerType.GetProperty(this._dependentProperty);
            var dependentvalue = decimal.Parse(field.GetValue(validationContext.ObjectInstance, null).ToString());

            bool result= true;
            if (!string.IsNullOrEmpty(value.ToString()))
            {
                var PropertyValue = decimal.Parse(value.ToString());
                var PropertyDependencyValue = dependentvalue;

                switch (_logicOperatorType)
                {
                    case LogicOperatorType.MayorQue:
                        result = PropertyValue > PropertyDependencyValue;
                        break;
                    case LogicOperatorType.MayorOIgual:
                        result = PropertyValue >= PropertyDependencyValue;
                        break;
                    case LogicOperatorType.MenorQue:
                        result = PropertyValue < PropertyDependencyValue;
                        break;
                    case LogicOperatorType.MenorOIgual:
                        result = PropertyValue <= PropertyDependencyValue;
                        break;
                    case LogicOperatorType.Igual:
                        result = PropertyValue == PropertyDependencyValue;
                        break;
                    case LogicOperatorType.Diferente:
                        result = PropertyValue != PropertyDependencyValue;
                        break;
                }
            }

            return
                  (!result) ? new ValidationResult(this._errorMessage, new[] { validationContext.MemberName })
                            : ValidationResult.Success;
        }
    }
}