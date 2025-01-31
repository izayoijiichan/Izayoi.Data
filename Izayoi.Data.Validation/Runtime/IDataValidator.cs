// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Validation
// @Interface : IDataValidator
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Validation
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Data Validator interface
    /// </summary>
    public interface IDataValidator
    {
        #region Methods

        /// <summary>
        /// Attempts to validate the property values of the specified instance.
        /// </summary>
        /// <param name="instance">The object to validate.</param>
        /// <param name="validationErrors">List of the validation error.</param>
        /// <returns><see langword="true" /> if the validated value is correct; <see langword="false" /> if it is invalid.</returns>
        bool TryValidateErrors(in object instance, out List<ValidationError> validationErrors);

        /// <summary>
        /// Attempts to validate the property values of the specified instance.
        /// </summary>
        /// <param name="instance">The object to validate.</param>
        /// <param name="validationErrors">List of the validation error.</param>
        /// <returns><see langword="true" /> if the validated value is correct; <see langword="false" /> if it is invalid.</returns>
        bool TryValidateErrorsRef(in object instance, ref List<ValidationError> validationErrors);

        /// <summary>
        /// Attempts to validate the property values of the specified instance.
        /// </summary>
        /// <param name="instance">The object to validate.</param>
        /// <param name="breakOnFirstPropertyError">If specify <see langword="true" />, the result will be returned when the first property validation error occurs.</param>
        /// <param name="breakOnPerFirstPropertyError">If specify <see langword="true" />, for each property, only the first validation error is validated.</param>
        /// <param name="validationErrors">List of the validation error.</param>
        bool TryValidateErrorsRef(
            in object instance,
            in bool breakOnFirstPropertyError,
            in bool breakOnPerFirstPropertyError,
            ref List<ValidationError> validationErrors);

        /// <summary>
        /// Attempts to validate the property values of the specified instance.
        /// </summary>
        /// <param name="instance">The object to validate.</param>
        /// <param name="validationResults">List of the failed validation result.</param>
        /// <returns><see langword="true" /> if the validated value is correct; <see langword="false" /> if it is invalid.</returns>
        bool TryValidateResults(in object instance, out List<ValidationResult> validationResults);

        /// <summary>
        /// Attempts to validate the property values of the specified instance.
        /// </summary>
        /// <param name="instance">The object to validate.</param>
        /// <param name="validationResults">List of the failed validation result.</param>
        /// <returns><see langword="true" /> if the validated value is correct; <see langword="false" /> if it is invalid.</returns>
        bool TryValidateResultsRef(in object instance, ref List<ValidationResult> validationResults);

        /// <summary>
        /// Attempts to validate the property values of the specified instance.
        /// </summary>
        /// <param name="instance">The object to validate.</param>
        /// <param name="breakOnFirstPropertyError">If specify <see langword="true" />, the result will be returned when the first property validation error occurs.</param>
        /// <param name="breakOnPerFirstPropertyError">If specify <see langword="true" />, for each property, only the first validation error is validated.</param>
        /// <param name="validationResults">List of the failed validation result.</param>
        bool TryValidateResultsRef(
            in object instance,
            in bool breakOnFirstPropertyError,
            in bool breakOnPerFirstPropertyError,
            ref List<ValidationResult> validationResults);

        /// <summary>
        /// Validates the property values ​​of the specified instance.
        /// </summary>
        /// <param name="instance">The object to validate.</param>
        /// <param name="breakOnFirstPropertyError">If specify <see langword="true" />, the result will be returned when the first property validation error occurs.</param>
        /// <param name="breakOnPerFirstPropertyError">If specify <see langword="true" />, for each property, only the first validation error is validated.</param>
        /// <returns>List of the validation error.</returns>
        List<ValidationError> ValidateErrors(
            in object instance,
            in bool breakOnFirstPropertyError = false,
            in bool breakOnPerFirstPropertyError = false);

        /// <summary>
        /// Validates the property values ​​of the specified instance.
        /// </summary>
        /// <param name="instance">The object to validate.</param>
        /// <param name="breakOnFirstPropertyError">If specify <see langword="true" />, the result will be returned when the first property validation error occurs.</param>
        /// <param name="breakOnPerFirstPropertyError">If specify <see langword="true" />, for each property, only the first validation error is validated.</param>
        /// <returns>List of the failed validation result.</returns>
        List<ValidationResult> ValidateResults(
            in object instance,
            in bool breakOnFirstPropertyError = false,
            in bool breakOnPerFirstPropertyError = false);

        #endregion
    }
}
