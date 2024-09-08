// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Validation
// @Class     : ValidationPropertyInfo
// ----------------------------------------------------------------------
namespace Izayoi.Data.Validation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Reflection;

    /// <summary>
    /// Validation Property Information
    /// </summary>
    public class ValidationPropertyInfo
    {
        #region Fields

        protected readonly PropertyInfo _propertyInfo;

        private readonly DisplayAttribute? _displayAttribute;

        protected readonly ValidationAttribute[] _validationAttributes;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ValidationPropertyInfo class with the specified propertyInfo.
        /// </summary>
        /// <param name="propertyInfo">A property info.</param>
        public ValidationPropertyInfo(PropertyInfo propertyInfo)
        {
            _propertyInfo = propertyInfo;

            _displayAttribute = (DisplayAttribute?)Attribute.GetCustomAttribute(propertyInfo, typeof(DisplayAttribute));

            _validationAttributes = (ValidationAttribute[])Attribute.GetCustomAttributes(propertyInfo, typeof(ValidationAttribute));
        }

        #endregion

        #region Properties

        /// <summary>Gets the name of this property.</summary>
        public virtual string Name => _propertyInfo.Name;

        /// <summary>Gets the property info of this property.</summary>
        /// <value>The property info of this property.</value>
        public virtual PropertyInfo PropertyInfo => _propertyInfo;

        /// <summary>Gets a MemberTypes value indicating that this member is a property.</summary>
        /// <value>A MemberTypes value indicating that this member is a property.</value>
        public virtual MemberTypes MemberType => _propertyInfo.MemberType;

        /// <summary>Gets the type of this property.</summary>
        /// <value>The type of this property.</value>
        public virtual Type PropertyType => _propertyInfo.PropertyType;

        /// <summary>Gets the class that declares this property.</summary>
        /// <value>The Type object for the class that declares this property.</value>
        public virtual Type? DeclaringType => _propertyInfo.DeclaringType;

        /// <summary>Gets the class object that was used to obtain this instance of PropertyInfo.</summary>
        /// <value>The Type object through which this PropertyInfo object was obtained.</value>
        public virtual Type? ReflectedType => _propertyInfo.ReflectedType;

        /// <summary>Gets the module in which the type that declares the member represented by the current PropertyInfo is defined.</summary>
        /// <value>The Module in which the type that declares the member represented by the current PropertyInfo is defined.</value>
        public virtual Module Module => _propertyInfo.Module;

        /// <summary>Gets a value that identifies a metadata element.</summary>
        /// <value>A value which, in combination with Module, uniquely identifies a metadata element.</value>
        public virtual int MetadataToken => _propertyInfo.MetadataToken;

        /// <summary>Gets a value indicating whether the property can be read.</summary>
        /// <value><see langword="true" /> if this property can be read; otherwise, <see langword="false" />.</value>
        public virtual bool CanRead => _propertyInfo.CanRead;

        /// <summary>Gets a value indicating whether the property can be written to.</summary>
        /// <value><see langword="true" /> if this property can be written to; otherwise, <see langword="false" />.</value>
        public virtual bool CanWrite => _propertyInfo.CanWrite;

        ///// <summary>Gets a value that indicates whether this PropertyInfo object is part of an assembly held in a collectible AssemblyLoadContext.</summary>
        ///// <value><see langword="true" /> if the PropertyInfo is part of an assembly held in a collectible assembly load context; otherwise, <see langword="false" />.</value>
        //public virtual bool IsCollectible => _propertyInfo.IsCollectible;

        /// <summary>Gets a value indicating whether the property is the special name.</summary>
        /// <value><see langword="true" /> if this property is the special name; otherwise, <see langword="false" />.</value>
        public virtual bool IsSpecialName => _propertyInfo.IsSpecialName;

        /// <summary>Gets the attributes for this property.</summary>
        /// <value>The attributes of this property.</value>
        public virtual PropertyAttributes Attributes => _propertyInfo.Attributes;

        /// <summary>Gets a collection that contains this property's custom attributes.</summary>
        /// <value>A collection that contains this property's custom attributes.</value>
        public virtual IEnumerable<CustomAttributeData> CustomAttributes => _propertyInfo.CustomAttributes;

        /// <summary>Gets the display attribute for this property.</summary>
        /// <value>The display attribute of this property.</value>
        public virtual DisplayAttribute? DisplayAttribute => _displayAttribute;

        /// <summary>Gets a collection that contains this property's validation attributes.</summary>
        public virtual ValidationAttribute[] ValidationAttributes => _validationAttributes;

        public virtual MethodInfo? GetMethod => GetGetMethod(nonPublic: true);

        public virtual MethodInfo? SetMethod => GetSetMethod(nonPublic: true);

        #endregion

        #region Methods

        public virtual ParameterInfo[] GetIndexParameters() => _propertyInfo.GetIndexParameters();

        public virtual MethodInfo[] GetAccessors() => GetAccessors(nonPublic: false);
        public virtual MethodInfo[] GetAccessors(bool nonPublic) => _propertyInfo.GetAccessors(nonPublic);

        public virtual MethodInfo? GetGetMethod() => GetGetMethod(nonPublic: false);
        public virtual MethodInfo? GetGetMethod(bool nonPublic) => _propertyInfo.GetGetMethod(nonPublic);

        public virtual MethodInfo? GetSetMethod() => GetSetMethod(nonPublic: false);
        public virtual MethodInfo? GetSetMethod(bool nonPublic) => _propertyInfo.GetSetMethod(nonPublic);

        public virtual object? GetValue(object? obj)
            => GetValue(obj, index: null);
        public virtual object? GetValue(object? obj, object?[]? index)
            => GetValue(obj, BindingFlags.Default, binder: null, index: index, culture: null);
        public virtual object? GetValue(object? obj, BindingFlags invokeAttr, Binder? binder, object?[]? index, CultureInfo? culture)
            => _propertyInfo.GetValue(obj, invokeAttr, binder, index, culture);

        public virtual void SetValue(object? obj, object? value)
            => SetValue(obj, value, index: null);
        public virtual void SetValue(object? obj, object? value, object?[]? index)
            => SetValue(obj, value, BindingFlags.Default, binder: null, index: index, culture: null);
        public virtual void SetValue(object? obj, object? value, BindingFlags invokeAttr, Binder? binder, object?[]? index, CultureInfo? culture)
            => _propertyInfo.SetValue(obj, value, invokeAttr, binder, index, culture);

        #endregion
    }
}
