# ValidationError

[Top](../../../README.md) / [Documentation](../../Documentation.md)

## Definition

|||
|---|---|
|Namespace|Izayoi.Data.Validation|
|Assembly|Izayoi.Data.Validation.dll|

Represents a validation error.

~~~csharp
public class ValidationError
~~~

### Inheritance
Object -> ValidationError

## Constructors

|Name|Summary|
|---|---|
|ValidationError(PropertyInfo propertyInfo, DisplayAttribute? displayAttribute, List\<ValidationAttribute> errorValidationAttributes, object? propertyValue)|Initializes a new instance of the ValidationError class.|

## Properties

#### `PropertyInfo` PropertyInfo

Gets the property information.

#### `PropertyName` string

Gets the name of the property.

#### `PropertyValue` object?

Gets the value of the property.

#### `DisplayAttribute` DisplayAttribute?

Gets the display attribute.

#### `ErrorValidationAttributes` List\<ValidationAttribute>

Gets list of the validation attribute that failed validation.

## Methods

|Name|Returns|Summary|
|---|---|---|
|ToValidationResults()|List\<ValidationResult>|Converts this ValidationError to list of the ValidationResult.|

## Applies to

|Product|Versions|
|---|---|
|.NET|8, 9, 10|
|.NET Standard|2.0, 2.1|
