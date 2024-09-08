// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Validation
// @Class     : DataValidator
// ----------------------------------------------------------------------
namespace Izayoi.Data.Validation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Data Validator
    /// </summary>
    public class DataValidator : IDataValidator
    {
        #region Fields

        /// <summary>A validation property store.</summary>
        protected readonly ValidationPropertyStore _validationPropertyStore;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DataValidator class.
        /// </summary>
        public DataValidator()
        {
            _validationPropertyStore = new ValidationPropertyStore();
        }

        ///// <summary>
        ///// Initializes a new instance of the DataValidator class with the specified validationPropertyStore.
        ///// </summary>
        ///// <param name="validationPropertyStore">A validation property store.</param>
        //public DataValidator(IValidationPropertyStore validationPropertyStore)
        //{
        //    _validationPropertyStore = validationPropertyStore;
        //}

        #endregion

        #region Public Methods

        /// <summary>
        /// Attempts to validate the property values of the specified instance.
        /// </summary>
        /// <param name="instance">The object to validate.</param>
        /// <param name="validationErrors">List of the validation error.</param>
        /// <returns><see langword="true" /> if the validated value is correct; <see langword="false" /> if it is invalid.</returns>
        public virtual bool TryValidateErrors(in object instance, out List<ValidationError> validationErrors)
        {
            validationErrors = new List<ValidationError>();

            return TryValidateErrorsRef(
                instance,
                breakOnFirstPropertyError: false,
                breakOnPerFirstPropertyError: false,
                ref validationErrors);
        }

        /// <summary>
        /// Attempts to validate the property values of the specified instance.
        /// </summary>
        /// <param name="instance">The object to validate.</param>
        /// <param name="validationErrors">List of the validation error.</param>
        /// <returns><see langword="true" /> if the validated value is correct; <see langword="false" /> if it is invalid.</returns>
        public virtual bool TryValidateErrorsRef(in object instance, ref List<ValidationError> validationErrors)
        {
            return TryValidateErrorsRef(
                instance,
                breakOnFirstPropertyError: false,
                breakOnPerFirstPropertyError: false,
                ref validationErrors);
        }

        /// <summary>
        /// Attempts to validate the property values of the specified instance.
        /// </summary>
        /// <param name="instance">The object to validate.</param>
        /// <param name="breakOnFirstPropertyError">If specify <see langword="true" />, the result will be returned when the first property validation error occurs.</param>
        /// <param name="breakOnPerFirstPropertyError">If specify <see langword="true" />, for each property, only the first validation error is validated.</param>
        /// <param name="validationErrors">List of the validation error.</param>
        /// <returns><see langword="true" /> if the validated value is correct; <see langword="false" /> if it is invalid.</returns>
        public virtual bool TryValidateErrorsRef(
            in object instance,
            in bool breakOnFirstPropertyError,
            in bool breakOnPerFirstPropertyError,
            ref List<ValidationError> validationErrors)
        {
            Type objectType = instance.GetType();

            List<ValidationPropertyInfo> validationProperties = _validationPropertyStore.GetValidationProperties(objectType);

            int errorCount = 0;

            foreach (ValidationPropertyInfo validationProperty in validationProperties)
            {
                ValidationError? validationError = ValidateProperty(instance, validationProperty, breakOnPerFirstPropertyError);

                if (validationError is null)
                {
                    continue;
                }

                validationErrors.Add(validationError);

                errorCount++;

                if (breakOnFirstPropertyError)
                {
                    break;
                }
            }

            return errorCount == 0;
        }

        /// <summary>
        /// Attempts to validate the property values of the specified instance.
        /// </summary>
        /// <param name="instance">The object to validate.</param>
        /// <param name="validationResults">List of the failed validation result.</param>
        /// <returns><see langword="true" /> if the validated value is correct; <see langword="false" /> if it is invalid.</returns>
        public virtual bool TryValidateResults(in object instance, out List<ValidationResult> validationResults)
        {
            validationResults = new List<ValidationResult>();

            return TryValidateResultsRef(
                instance,
                breakOnFirstPropertyError: false,
                breakOnPerFirstPropertyError: false,
                ref validationResults);
        }

        /// <summary>
        /// Attempts to validate the property values of the specified instance.
        /// </summary>
        /// <param name="instance">The object to validate.</param>
        /// <param name="validationResults">List of the failed validation result.</param>
        /// <returns><see langword="true" /> if the validated value is correct; <see langword="false" /> if it is invalid.</returns>
        public virtual bool TryValidateResultsRef(in object instance, ref List<ValidationResult> validationResults)
        {
            return TryValidateResultsRef(
                instance,
                breakOnFirstPropertyError: false,
                breakOnPerFirstPropertyError: false,
                ref validationResults);
        }

        /// <summary>
        /// Attempts to validate the property values of the specified instance.
        /// </summary>
        /// <param name="instance">The object to validate.</param>
        /// <param name="breakOnFirstPropertyError">If specify <see langword="true" />, the result will be returned when the first property validation error occurs.</param>
        /// <param name="breakOnPerFirstPropertyError">If specify <see langword="true" />, for each property, only the first validation error is validated.</param>
        /// <param name="validationResults">List of the failed validation result.</param>
        /// <returns><see langword="true" /> if the validated value is correct; <see langword="false" /> if it is invalid.</returns>
        public virtual bool TryValidateResultsRef(
            in object instance,
            in bool breakOnFirstPropertyError,
            in bool breakOnPerFirstPropertyError,
            ref List<ValidationResult> validationResults)
        {
            Type objectType = instance.GetType();

            List<ValidationPropertyInfo> validationProperties = _validationPropertyStore.GetValidationProperties(objectType);

            int errorCount = 0;

            foreach (ValidationPropertyInfo validationProperty in validationProperties)
            {
                ValidationError? validationError = ValidateProperty(instance, validationProperty, breakOnPerFirstPropertyError);

                if (validationError is null)
                {
                    continue;
                }

                validationResults.AddRange(validationError.ToValidationResults());

                errorCount++;

                if (breakOnFirstPropertyError)
                {
                    break;
                }
            }

            return errorCount == 0;
        }

        /// <summary>
        /// Validates the property values ​​of the specified instance.
        /// </summary>
        /// <param name="instance">The object to validate.</param>
        /// <param name="breakOnFirstPropertyError">If specify <see langword="true" />, the result will be returned when the first property validation error occurs.</param>
        /// <param name="breakOnPerFirstPropertyError">If specify <see langword="true" />, for each property, only the first validation error is validated.</param>
        /// <returns>List of the validation error.</returns>
        public virtual List<ValidationError> ValidateErrors(
            in object instance,
            in bool breakOnFirstPropertyError = false,
            in bool breakOnPerFirstPropertyError = false)
        {
            List<ValidationError> validationErrors = new();

            TryValidateErrorsRef(
                instance,
                breakOnFirstPropertyError,
                breakOnPerFirstPropertyError,
                ref validationErrors);

            return validationErrors;
        }

        /// <summary>
        /// Validates the property values ​​of the specified instance.
        /// </summary>
        /// <param name="instance">The object to validate.</param>
        /// <param name="breakOnFirstPropertyError">If specify <see langword="true" />, the result will be returned when the first property validation error occurs.</param>
        /// <param name="breakOnPerFirstPropertyError">If specify <see langword="true" />, for each property, only the first validation error is validated.</param>
        /// <returns>List of the failed validation result.</returns>
        public virtual List<ValidationResult> ValidateResults(
            in object instance,
            in bool breakOnFirstPropertyError = false,
            in bool breakOnPerFirstPropertyError = false)
        {
            List<ValidationResult> validationResults = new();

            TryValidateResultsRef(
                instance,
                breakOnFirstPropertyError,
                breakOnPerFirstPropertyError,
                ref validationResults);

            return validationResults;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Validates value of the specified property ​​of the specified instance.
        /// </summary>
        /// <param name="instance">The object to validate.</param>
        /// <param name="validationProperty">A validation property.</param>
        /// <param name="breakOnPerFirstPropertyError">If specify <see langword="true" />, the result will be returned when the first validation error occurs in the property.</param>
        /// <returns>If the validated value is correct, null is returned; if it is invalid, a validation error is returned.</returns>
        protected virtual ValidationError? ValidateProperty(
            in object? instance,
            in ValidationPropertyInfo validationProperty,
            in bool breakOnPerFirstPropertyError)
        {
            if (validationProperty.ValidationAttributes.Length == 0)
            {
                return null;
            }

            object? propertyValue = validationProperty.GetValue(instance);

            ValidationAttribute[] validationAttributes = validationProperty.ValidationAttributes;

            List<ValidationAttribute>? errorAttributes = null;

            foreach (ValidationAttribute validationAttribute in validationAttributes)
            {
                if (validationAttribute.IsValid(propertyValue))
                {
                    continue;
                }

                errorAttributes ??= new();

                errorAttributes.Add(validationAttribute);

                if (breakOnPerFirstPropertyError)
                {
                    break;
                }
            }

            if (errorAttributes is null)
            {
                return null;
            }

            return new ValidationError(
                validationProperty.PropertyInfo,
                validationProperty.DisplayAttribute,
                errorAttributes,
                propertyValue);
        }

        #endregion
    }
}
