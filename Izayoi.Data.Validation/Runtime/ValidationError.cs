// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Validation
// @Class     : ValidationError
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Validation
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;

    /// <summary>
    /// Validation Error
    /// </summary>
    public class ValidationError //: IValidationError
    {
        #region Fields

        /// <summary>The property information.</summary>
        protected readonly PropertyInfo _propertyInfo;

        /// <summary>The property value.</summary>
        protected readonly object? _propertyValue;

        /// <summary>The display attribute.</summary>
        protected readonly DisplayAttribute? _displayAttribute;

        /// <summary>List of the validation attribute that failed validation.</summary>
        protected readonly List<ValidationAttribute> _errorValidationAttributes;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ValidationError class with the specified propertyInfo, displayAttribute, errorValidationAttributes and propertyValue.
        /// </summary>
        /// <param name="propertyInfo">A property information.</param>
        /// <param name="displayAttribute">A display attribute.</param>
        /// <param name="errorValidationAttributes">List of the validation attribute that failed validation.</param>
        /// <param name="propertyValue">A property value.</param>
        public ValidationError(
            PropertyInfo propertyInfo,
            DisplayAttribute? displayAttribute,
            List<ValidationAttribute> errorValidationAttributes,
            object? propertyValue)
        {
            _propertyInfo = propertyInfo;

            _propertyValue = propertyValue;

            _displayAttribute = displayAttribute;

            _errorValidationAttributes = errorValidationAttributes;
        }

        #endregion

        #region Properties

        /// <summary>Gets the property information.</summary>
        public virtual PropertyInfo PropertyInfo => _propertyInfo;

        /// <summary>Gets the name of the property.</summary>
        public virtual string PropertyName => _propertyInfo.Name;

        /// <summary>Gets the value of the property.</summary>
        public virtual object? PropertyValue => _propertyValue;

        /// <summary>Gets the display attribute.</summary>
        public virtual DisplayAttribute? DisplayAttribute => _displayAttribute;

        /// <summary>Gets list of the validation attribute that failed validation.</summary>
        public virtual List<ValidationAttribute> ErrorValidationAttributes => _errorValidationAttributes;

        #endregion

        #region Methods

        /// <summary>
        /// Converts this ValidationError to list of the ValidationResult.
        /// </summary>
        /// <returns>List of the validation result.</returns>
        /// <remarks>
        /// If you use a resource file (.resx), localization will be performed according to CultureInfo.
        /// </remarks>
        public virtual List<ValidationResult> ToValidationResults()
        {
            List<ValidationResult> validationResults = new();

            foreach (ValidationAttribute errorValidationAttribute in _errorValidationAttributes)
            {
                string name;

                if (_displayAttribute is null)
                {
                    name = _propertyInfo.Name;
                }
                else
                {
                    // @important
                    // Set (Name) or (Name and ResourceType)
                    string? displayName = _displayAttribute.GetName();

                    if (string.IsNullOrEmpty(displayName))
                    {
                        name = _propertyInfo.Name;
                    }
                    else
                    {
                        name = displayName;
                    }
                }

                // @important
                // Set (ErrorMessage) or (ErrorMessageResourceName and ErrorMessageResourceType)
                string? errorMessage = errorValidationAttribute.FormatErrorMessage(name);

                ValidationResult validationResult = new(errorMessage, new string[] { _propertyInfo.Name });

                validationResults.Add(validationResult);
            }

            return validationResults;
        }

        #endregion
    }
}
