// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Validation.Test
// @Class     : ResourceJaJpTest
// ----------------------------------------------------------------------
namespace Izayoi.Data.Validation.Test
{
    using Izayoi.Data.Validation;
    using Izayoi.Data.Validation.Test.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using Xunit;

    public class ResourceJaJpTest
    {
        #region Fields

        private readonly IDataValidator _dataValidator;

        #endregion

        #region Constructors

        public ResourceJaJpTest()
        {
            _dataValidator = new DataValidator();

            CultureInfo.CurrentCulture = new CultureInfo("ja-JP", useUserOverride: false);
            CultureInfo.CurrentUICulture = new CultureInfo("ja-JP", useUserOverride: false);
        }

        #endregion

        #region Methods

        [Theory]
        [InlineData(null, "name1", 0, 1, "ユーザーID フィールドは必須です。", "", "")]
        [InlineData(1, "", 0, 1, "", "ユーザー名 フィールドは必須です。", "")]
        [InlineData(1, "1234567890a", 0, 1, "", "ユーザー名 フィールドは10文字以内である必要があります。", "")]
        [InlineData(1, "name1", 201, 1, "", "", "年齢 フィールド は 0 から 200 の間である必要があります。")]
        [InlineData(null, "1234567890a", 201, 3, "ユーザーID フィールドは必須です。", "ユーザー名 フィールドは10文字以内である必要があります。", "年齢 フィールド は 0 から 200 の間である必要があります。")]
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