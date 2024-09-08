// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Validation.Test
// @Class     : ResourceEnUsTest
// ----------------------------------------------------------------------
namespace Izayoi.Data.Validation.Test
{
    using Izayoi.Data.Validation;
    using Izayoi.Data.Validation.Test.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using Xunit;

    public class ResourceEnUsTest
    {
        #region Fields

        private readonly IDataValidator _dataValidator;

        #endregion

        #region Constructors

        public ResourceEnUsTest()
        {
            _dataValidator = new DataValidator();

            CultureInfo.CurrentCulture = new CultureInfo("en-US", useUserOverride: false);
            CultureInfo.CurrentUICulture = new CultureInfo("en-US", useUserOverride: false);
        }

        #endregion

        #region Methods

        [Theory]
        [InlineData(null, "name1", 0, 1, "The User ID field is required.", "", "")]
        [InlineData(1, "", 0, 1, "", "The Username field is required.", "")]
        [InlineData(1, "1234567890a", 0, 1, "", "The field Username must be a string with a maximum length of 10.", "")]
        [InlineData(1, "name1", 201, 1, "", "", "The field Age must be between 0 and 200.")]
        [InlineData(null, "1234567890a", 201, 3, "The User ID field is required.", "The field Username must be a string with a maximum length of 10.", "The field Age must be between 0 and 200.")]
        public void Test_ValidateResults_invalid(int? id, string name, byte age, int errorCount,
            string idErrorMessage, string nameErrorMessage, string ageErrorMessage)
        {
            var user = new UserResource
            {
                Id = id,
                Name = name,
                Age = age,
            };

            List<ValidationResult> validationResults = _dataValidator.ValidateResults(user);

            Assert.Equal(errorCount, validationResults.Count);

            if (string.IsNullOrEmpty(idErrorMessage) == false)
            {
                Assert.True(validationResults.Exists(r => r.ErrorMessage == idErrorMessage));
            }

            if (string.IsNullOrEmpty(nameErrorMessage) == false)
            {
                Assert.True(validationResults.Exists(r => r.ErrorMessage == nameErrorMessage));
            }

            if (string.IsNullOrEmpty(ageErrorMessage) == false)
            {
                Assert.True(validationResults.Exists(r => r.ErrorMessage == ageErrorMessage));
            }
        }

        #endregion
    }
}