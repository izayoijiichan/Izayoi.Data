// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Validation.Test
// @Class     : BasicTest
// ----------------------------------------------------------------------
namespace Izayoi.Data.Validation.Test
{
    using Izayoi.Data.Validation;
    using Izayoi.Data.Validation.Test.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Xunit;

    public class BasicTest
    {
        #region Fields

        private readonly IDataValidator _dataValidator;

        #endregion

        #region Constructors

        public BasicTest()
        {
            _dataValidator = new DataValidator();
        }

        #endregion

        #region Methods

        [Theory]
        [InlineData(1, "name1", 0)]
        public void Test_ValidateErrors_valid(int id, string name, byte age)
        {
            var user = new User
            {
                Id = id,
                Name = name,
                Age = age,
            };

            List<ValidationError> validationErrors = _dataValidator.ValidateErrors(user);

            Assert.Empty(validationErrors);
        }

        [Fact]
        public void Test_ValidateErrors_invalid_breakOnFirstPropertyError()
        {
            var user = new User
            {
                Id = null,  // invalid value
                Name = "",  // invalid value
                Age = 201,  // invalid value
            };

            List<ValidationError> validationErrors = _dataValidator.ValidateErrors(user, breakOnFirstPropertyError: true);

            Assert.Single(validationErrors);

            Assert.Equal(nameof(User.Id), validationErrors[0].PropertyName);
        }

        [Theory]
        [InlineData(null, "name1", 0, 1, false, true, true)]
        [InlineData(1, "", 0, 1, true, false, true)]
        [InlineData(1, "name1", 201, 1, true, true, false)]
        [InlineData(null, "", 201, 3, false, false, false)]
        public void Test_ValidateErrors_invalid(int? id, string name, byte age, int errorCount, bool idResult, bool nameResult, bool ageResult)
        {
            var user = new User
            {
                Id = id,
                Name = name,
                Age = age,
            };

            List<ValidationError> validationErrors = _dataValidator.ValidateErrors(user);

            Assert.Equal(errorCount, validationErrors.Count);

            if (idResult == false)
            {
                Assert.True(validationErrors.Exists(e => e.PropertyName == nameof(User.Id)));
            }

            if (nameResult == false)
            {
                Assert.True(validationErrors.Exists(e => e.PropertyName == nameof(User.Name)));
            }

            if (ageResult == false)
            {
                Assert.True(validationErrors.Exists(e => e.PropertyName == nameof(User.Age)));
            }
        }

        [Fact]
        public void Test_ValidateResults_invalid_breakOnFirstPropertyError()
        {
            var user = new User
            {
                Id = null,  // invalid value
                Name = "",  // invalid value
                Age = 201,  // invalid value
            };

            List<ValidationResult> validationResults = _dataValidator.ValidateResults(user, breakOnFirstPropertyError: true);

            Assert.Single(validationResults);

            Assert.Equal("The ID field is required.", validationResults[0].ErrorMessage);
        }

        [Theory]
        [InlineData(null, "name1", 0, 1, "The ID field is required.", "", "")]
        [InlineData(1, "", 0, 1, "", "The Name field is required.", "")]
        [InlineData(1, "1234567890a", 0, 1, "", "The field Name must be a string with a maximum length of 10.", "")]
        [InlineData(1, "name1", 201, 1, "", "", "The field Age must be between 0 and 200.")]
        [InlineData(null, "1234567890a", 201, 3, "The ID field is required.", "The field Name must be a string with a maximum length of 10.", "The field Age must be between 0 and 200.")]
        public void Test_ValidateResults_invalid(int? id, string name, byte age, int errorCount,
            string idErrorMessage, string nameErrorMessage, string ageErrorMessage)
        {
            var user = new User
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