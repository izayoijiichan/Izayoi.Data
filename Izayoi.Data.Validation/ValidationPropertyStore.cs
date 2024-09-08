// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Validation
// @Class     : ValidationPropertyStore
// ----------------------------------------------------------------------
namespace Izayoi.Data.Validation
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// Validation Property Store
    /// </summary>
    public class ValidationPropertyStore //: IValidationPropertyStore
    {
        #region Fields

        /// <summary>A dictionary that caches object property info.</summary>
        protected readonly ConcurrentDictionary<Type, List<ValidationPropertyInfo>> _store;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ValidationPropertyStore class.
        /// </summary>
        public ValidationPropertyStore()
        {
            _store = new();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the validation properties.
        /// </summary>
        /// <param name="objectType">The object type for which you want to get the validation property information.</param>
        /// <returns>List of the validation property information.</returns>
        public List<ValidationPropertyInfo> GetValidationProperties(Type objectType)
        {
            if (_store.TryGetValue(objectType, out var validationPropertyInfoList))
            {
                return validationPropertyInfoList;
            }

            PropertyInfo[] propertyInfoArray = objectType.GetProperties();

            validationPropertyInfoList = new List<ValidationPropertyInfo>(propertyInfoArray.Length);

            foreach (PropertyInfo propertyInfo in propertyInfoArray)
            {
                ValidationPropertyInfo validationPropertyInfo = new(propertyInfo);

                validationPropertyInfoList.Add(validationPropertyInfo);
            }

            return validationPropertyInfoList;
        }

        #endregion
    }
}
