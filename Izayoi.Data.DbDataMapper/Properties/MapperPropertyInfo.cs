// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data
// @Class     : MapperPropertyInfo
// ----------------------------------------------------------------------
namespace Izayoi.Data
{
    using Izayoi.Data.Extensions;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Globalization;
    using System.Reflection;

    /// <summary>
    /// Mapper Property Info
    /// </summary>
    public class MapperPropertyInfo
    {
        #region Fields

        protected readonly PropertyInfo _propertyInfo;

        protected string? _columnName;

        protected bool? _isKey;

        protected bool? _isNotMapped;

        private bool? _isNullable;

        protected bool _checkedEnum;

        protected bool _isEnum;

        protected Type? _enumType;

        protected Type? _enumUnderlyingType;

        protected bool _checkedUnderlyingType;

        protected Type? _underlyingType;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the MapperPropertyInfo class with the specified propertyInfo.
        /// </summary>
        /// <param name="propertyInfo">A property info.</param>
        public MapperPropertyInfo(PropertyInfo propertyInfo)
        {
            _propertyInfo = propertyInfo;
        }

        #endregion

        #region Properties

        /// <summary>Gets the name of this property.</summary>
        public virtual string Name => _propertyInfo.Name;

        /// <summary>Gets the column name of this property.</summary>
        /// <value>The name of the [Column] attribute, or empty string.</value>
        public virtual string ColumnName
        {
            get => _columnName ??= GetColumnName(inherit: true);
            set => _columnName = value;
        }

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

        /// <summary>Gets a value that indicates whether this PropertyInfo object is part of an assembly held in a collectible AssemblyLoadContext.</summary>
        /// <value><see langword="true" /> if the PropertyInfo is part of an assembly held in a collectible assembly load context; otherwise, <see langword="false" />.</value>
        public virtual bool IsCollectible => _propertyInfo.IsCollectible;

        /// <summary>Gets a value indicating whether the property is the special name.</summary>
        /// <value><see langword="true" /> if this property is the special name; otherwise, <see langword="false" />.</value>
        public virtual bool IsSpecialName => _propertyInfo.IsSpecialName;

        /// <summary>Gets whether this property is key.</summary>
        /// <value><see langword="true" /> if this property has [Key] attribute; otherwise, <see langword="false" />.</value>
        public virtual bool IsKey
        {
            get => _isKey ??= _propertyInfo.HasCustomAttribute<KeyAttribute>(inherit: true);
            set => _isKey = value;
        }

        /// <summary>Gets whether this property is not mapped.</summary>
        /// <value><see langword="true" /> if this property has [NotMapped] attribute; otherwise, <see langword="false" />.</value>
        public virtual bool IsNotMapped
        {
            get => _isNotMapped ??= _propertyInfo.HasCustomAttribute<NotMappedAttribute>(inherit: true);
            set => _isNotMapped = value;
        }

        /// <summary>Gets whether this property is nullable.</summary>
        /// <value><see langword="true" /> if this property is nullable type; otherwise, <see langword="false" />.</value>
        public virtual bool IsNullable
             => _isNullable ??= IsNullableType();

        /// <summary>Gets whether this property is enum.</summary>
        /// <value><see langword="true" /> if this property is enum or nullable enum; otherwise, <see langword="false" />.</value>
        public virtual bool IsEnum
        {
            get
            {
                if (_checkedEnum == false)
                {
                    CheckEnum();

                    _checkedEnum = true;
                }

                return _isEnum;
            }
        }

        /// <summary>Gets the type of the enum or nullable enum, in this property.</summary>
        /// <value>The type of the enum or nullable enum.</value>
        public virtual Type? EnumType
        {
            get
            {
                if (_checkedEnum == false)
                {
                    CheckEnum();

                    _checkedEnum = true;
                }

                return _enumType;
            }
        }

        /// <summary>Gets the underlying type of the enum or nullable enum, in this property.</summary>
        /// <value>The underlying type of the enum or nullable enum.</value>
        public virtual Type? EnumUnderlyingType
        {
            get
            {
                if (_checkedEnum == false)
                {
                    CheckEnum();

                    _checkedEnum = true;
                }

                return _enumUnderlyingType;
            }
        }

        /// <summary>Gets the underlying type.</summary>
        /// <value>
        /// If the property is an Enum, returns the UnderlyingType of the Enum,
        /// if it is Nullable, returns the ArgumentType,
        /// if it is an Array or GenericType, returns null;
        /// otherwise returns the PropertyType.
        /// </value>
        public virtual Type? UnderlyingType
        {
            get
            {
                if (_checkedUnderlyingType == false)
                {
                    CheckUnderlyingType();

                    _checkedUnderlyingType = true;
                }

                return _underlyingType;
            }
        }

        /// <summary>Gets the attributes for this property.</summary>
        /// <value>The attributes of this property.</value>
        public virtual PropertyAttributes Attributes => _propertyInfo.Attributes;

        /// <summary>Gets a collection that contains this property's custom attributes.</summary>
        /// <value>A collection that contains this property's custom attributes.</value>
        public virtual IEnumerable<CustomAttributeData> CustomAttributes => _propertyInfo.CustomAttributes;

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

        /// <summary>
        /// Gets the column name.
        /// </summary>
        /// <param name="inherit">If <see langword="true" />, specifies to also search the ancestors of element for column attribute.</param>
        /// <returns>If the property info has a column attribute, returns the attribute name; otherwise returns empty string.</returns>
        public virtual string GetColumnName(bool inherit)
        {
            string columnName;

            ColumnAttribute? columnAttribute = Attribute.GetCustomAttribute(_propertyInfo, AttributeType.Column, inherit) as ColumnAttribute;

            if (columnAttribute is null)
            {
                columnName = string.Empty;
            }
            else if (columnAttribute.Name is null)
            {
                columnName = string.Empty;
            }
            else
            {
                columnName = columnAttribute.Name;
            }

            _columnName = columnName;

            return columnName;
        }

        /// <summary>
        /// Gets the column name or property name of the specified property info.
        /// </summary>
        /// <param name="inherit">If <see langword="true" />, specifies to also search the ancestors of element for column attribute.</param>
        /// <returns>If the property info has a column attribute, returns the attribute name; otherwise returns the property name.</returns>
        public virtual string GetColumnNameOrPropertyName(bool inherit)
        {
            _columnName ??= GetColumnName(inherit);

            if (_columnName.Length > 0)
            {
                return _columnName;
            }

            return _propertyInfo.Name;
        }

        protected virtual bool IsNullableType()
        {
            if (_propertyInfo.PropertyType.IsGenericType)
            {
                return _propertyInfo.PropertyType.GetGenericTypeDefinition() == DataType.GenericNullable;
            }

            return false;
        }

        protected virtual void CheckEnum()
        {
            _isEnum = false;

            _enumType = null;

            _enumUnderlyingType = null;

            if (IsNullable)
            {
                Type argumentType = _propertyInfo.PropertyType.GenericTypeArguments[0];

                if (argumentType.IsEnum)
                {
                    _isEnum = true;

                    _enumType = argumentType;

                    _enumUnderlyingType = argumentType.GetEnumUnderlyingType();
                }
            }
            else
            {
                if (_propertyInfo.PropertyType.IsEnum)
                {
                    _isEnum = true;

                    _enumType = _propertyInfo.PropertyType;

                    _enumUnderlyingType = _enumType.GetEnumUnderlyingType();
                }
            }
        }

        protected virtual void CheckUnderlyingType()
        {
            if (IsNullable)
            {
                Type argumentType = _propertyInfo.PropertyType.GenericTypeArguments[0];

                if (argumentType.IsArray)
                {
                    _underlyingType = null;

                    return;
                }

                if (argumentType.IsGenericType)
                {
                    _underlyingType = null;

                    return;
                }

                if (argumentType.IsEnum)
                {
                    _underlyingType = argumentType.GetEnumUnderlyingType();

                    return;
                }

                _underlyingType = argumentType;
            }
            else
            {
                Type propertyType = _propertyInfo.PropertyType;

                if (propertyType.IsArray)
                {
                    _underlyingType = null;

                    return;
                }

                if (propertyType.IsGenericType)
                {
                    _underlyingType = null;

                    return;
                }

                if (propertyType.IsEnum)
                {
                    _underlyingType = propertyType.GetEnumUnderlyingType();

                    return;
                }

                _underlyingType = propertyType;
            }
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(ColumnName)}: {ColumnName}, {nameof(PropertyType)}: {PropertyType}, {nameof(CanRead)}: {CanRead.ToString().ToLower()}, {nameof(CanWrite)}: {CanWrite.ToString().ToLower()}, {nameof(IsKey)}: {IsKey.ToString().ToLower()}, {nameof(IsNotMapped)}: {IsNotMapped.ToString().ToLower()}";
        }

        #endregion
    }
}
