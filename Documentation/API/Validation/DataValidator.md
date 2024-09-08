# DataValidator

[Top](../../../README.md) / [Documentation](../../Documentation.md)

## Definition

|||
|--|--|
|Namespace|Izayoi.Data.Validation|
|Assembly|Izayoi.Data.Validation.dll|

Represents a data varidator.

~~~csharp
public class DataValidator : IDataValidator
~~~

### Inheritance
Object -> DataValidator

## Constructors

|Name|Summary|
|--|--|
|DataValidator()|Initializes an instance of the DataValidator class.|

## Methods

|Name|Returns|Summary|
|--|--|--|
|TryValidateErrors(in object instance, out List\<ValidationError> validationErrors)|bool|Attempts to validate the property values of the specified instance.|
|TryValidateErrorsRef(in object instance, ref List\<ValidationError> validationErrors)|bool|Attempts to validate the property values of the specified instance.|
|TryValidateErrorsRef(in object instance, in bool breakOnFirstPropertyError, in bool breakOnPerFirstPropertyError, ref List\<ValidationError> validationErrors)|bool|Attempts to validate the property values of the specified instance.|
|TryValidateResults(in object instance, out List\<ValidationResult> validationResults)|bool|Attempts to validate the property values of the specified instance.|
|TryValidateResultsRef(in object instance, ref List\<ValidationResult> validationResults)|bool|Attempts to validate the property values of the specified instance.|
|TryValidateResultsRef(in object instance, in bool breakOnFirstPropertyError, in bool breakOnPerFirstPropertyError, ref List\<ValidationResult> validationResults)|bool|Attempts to validate the property values of the specified instance.|
|ValidateErrors(in object instance, in bool breakOnFirstPropertyError = false, in bool breakOnPerFirstPropertyError = false)|List\<ValidationError>|Validates the property values of the specified instance.|
|ValidateResults(in object instance, in bool breakOnFirstPropertyError = false, in bool breakOnPerFirstPropertyError = false)|List\<ValidationResult>|Validates the property values of the specified instance.|

## Remarks

Reuse a `DataValidator` object whenever possible.

## Examples

### Basic

#### Model Class

~~~csharp
using System;
using System.ComponentModel.DataAnnotations;

public class User
{
    [Display(Name = "ID")]
    [Required]
    public int? Id { get; set; }

    [Required]
    [StringLength(10)]
    public string? Name { get; set; }

    [Required]
    [Range(0, 200)]
    public byte? Age { get; set; }
}
~~~

#### Validation

~~~csharp
using Izayoi.Data.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Example()
{
    private readonly IDataValidator dataValidator = new DataValidator();

    public void Method()
    {
        var user = new User
        {
            Id = null,
            Name = "1234567890a",
            Age = 201,
        };

        bool isValid = dataValidator.TryValidateResults(user, out List<ValidationResult> validationResults);

        // isValid: false

        // validationResult[0]
        //   ErrorMessage: "The ID field is required."
        // validationResult[1]
        //   ErrorMessage: "The field Name must be a string with a maximum length of 10."
        // validationResult[2]
        //   ErrorMessage: "The field Age must be between 0 and 200."
    }
}
~~~

### Localization

#### Resoureces

DataAnnotations.resx

|name|value|
|--|--|
|RangeAttribute_ValidationError|The field {0} must be between {1} and {2}.|
|StringLengthAttribute_ValidationError|The field {0} must be a string with a maximum length of {1}.|
|RequiredAttribute_ValidationError|The {0} field is required.|

Models.resx

|name|value|
|--|--|
|User_Age|Age|
|User_Id|User ID|
|User_Name|Username|

#### Model Class (Resource)

~~~csharp
using Resources;
using System;
using System.ComponentModel.DataAnnotations;

public class User
{
    [Display(Name = nameof(Models.User_Id), ResourceType = typeof(Models))]
    [Required(ErrorMessageResourceName = nameof(DataAnnotations.RequiredAttribute_ValidationError), ErrorMessageResourceType = typeof(DataAnnotations))]
    public int? Id { get; set; }

    [Display(Name = nameof(Models.User_Name), ResourceType = typeof(Models))]
    [Required(ErrorMessageResourceName = nameof(DataAnnotations.RequiredAttribute_ValidationError), ErrorMessageResourceType = typeof(DataAnnotations))]
    [StringLength(10, ErrorMessageResourceName = nameof(DataAnnotations.StringLengthAttribute_ValidationError), ErrorMessageResourceType = typeof(DataAnnotations))]
    public string? Name { get; set; }

    [Display(Name = nameof(Models.User_Age), ResourceType = typeof(Models))]
    [Required(ErrorMessageResourceName = nameof(DataAnnotations.RequiredAttribute_ValidationError), ErrorMessageResourceType = typeof(DataAnnotations))]
    [Range(0, 200, ErrorMessageResourceName = nameof(DataAnnotations.RangeAttribute_ValidationError), ErrorMessageResourceType = typeof(DataAnnotations))]
    public byte? Age { get; set; }
}
~~~

To create your own attribute, create a new class that inherits from `ValidationAttribute` class.

#### Validation (Resource)

~~~csharp
using Izayoi.Data.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Example()
{
    private readonly IDataValidator dataValidator = new DataValidator();

    public void Method()
    {
        var user = new User
        {
            Id = null,
            Name = "1234567890a",
            Age = 201,
        };

        bool isValid = dataValidator.TryValidateResults(user, out List<ValidationResult> validationResults);

        // isValid: false

        // validationResult[0]
        //   ErrorMessage: "The User ID field is required."
        // validationResult[1]
        //   ErrorMessage: "The field Username must be a string with a maximum length of 10."
        // validationResult[2]
        //   ErrorMessage: "The field Age must be between 0 and 200."
    }
}
~~~

## Applies to

|Product|Versions|
|--|--|
|.NET|8|
|.NET Standard|2.0, 2.1|
