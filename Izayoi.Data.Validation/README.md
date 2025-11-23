# Izayoi.Data.Validation

This is a fast validator.

## Feature

1. Validation
    - Provide a validation method using the `ValidationAttribute`.
    - It also supports your own ValidationAttributes.
    - It is simple and fast.

2. Localization
    - Validation error messages can be localized.
    - Using resource files makes localization simple and easy to implement.
    - Supports defined CultureInfo.

## Examples

### Model Class

~~~csharp
using System;
using System.ComponentModel.DataAnnotations;

public class User
{
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

### Validation

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
        //   ErrorMessage: "The Id field is required."
        // validationResult[1]
        //   ErrorMessage: "The field Name must be a string with a maximum length of 10."
        // validationResult[2]
        //   ErrorMessage: "The field Age must be between 0 and 200."
    }
}
~~~

## Localization

Validation error messages can be localized.  
You need to prepare resource files (.resx), `ValidationAttribute` and `DisplayAttribute`.

For more information, see the Documentation or Wiki.

## Applies to

|Product|Versions|
|---|---|
|.NET|8, 9, 10|
|.NET Standard|2.0, 2.1|
|Unity|2021, 2022, 6000|

## Wiki

[Wiki](https://github.com/izayoijiichan/Izayoi.Data/wiki)

___
Last updated: 24 November, 2025  
Editor: Izayoi Jiichan

*Copyright (C) 2024 Izayoi Jiichan. All Rights Reserved.*
