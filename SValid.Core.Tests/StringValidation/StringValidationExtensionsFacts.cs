using SValid.Core.StringValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SValid.Core.Tests.StringValidation
{
    using StringValidationResult = Result<string, string>;

    public class StringValidationExtensionsFacts
    {
        [Theory]
        [InlineData("fdjaofdosjfldsf")]
        [InlineData("gfdgfdgfd")]
        [InlineData("33ff")]
        [InlineData("fdfdfd")]
        public void NotEmpty_Ok_IfNotEmpty(string sample)
        {
            // Arrange

            // Act
            var res = sample.NotEmpty();

            // Assert
            Assert.True(res.IsOk());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void NotEmpty_Error_IfEmpty(string sample)
        {
            // Arrange

            // Act
            var res = sample.NotEmpty();

            // Assert
            Assert.True(res.IsError());
            Assert.Equal(StringValidationExtensions.EmptyErrorCode, res.Error);
        }

        [Theory]
        [InlineData("fggt", 4)]
        [InlineData("fggtrerewr", 5)]
        [InlineData("r", 1)]
        public void MinLength_Ok_IfLonger(string sample, uint minLength)
        {
            // Arrange

            // Act
            var res = sample.MinLength(minLength);

            // Assert
            Assert.True(res.IsOk());
        }

        [Theory]
        [InlineData("fggt", 5)]
        [InlineData("fggtrerewr", 15)]
        [InlineData("r", 2)]
        public void MinLength_Error_IfShorter(string sample, uint minLength)
        {
            // Arrange

            // Act
            var res = sample.MinLength(minLength);

            // Assert
            Assert.True(res.IsError());
            Assert.Equal(StringValidationExtensions.TooShortErrorCode, res.Error);
        }

        [Theory]
        [InlineData("fggt", 4)]
        [InlineData("fggtrerewr", 15)]
        [InlineData("r", 1)]
        public void MaxLength_Ok_IfShorter(string sample, uint minLength)
        {
            // Arrange

            // Act
            var res = sample.MaxLength(minLength);

            // Assert
            Assert.True(res.IsOk());
        }

        [Theory]
        [InlineData("fggt", 3)]
        [InlineData("fggtrerewr", 7)]
        [InlineData("r", 0)]
        public void MaxLength_Error_IfLonger(string sample, uint minLength)
        {
            // Arrange

            // Act
            var res = sample.MaxLength(minLength);

            // Assert
            Assert.True(res.IsError());
            Assert.Equal(StringValidationExtensions.TooLongErrorCode, res.Error);
        }

        [Theory]
        [InlineData("fggt", 3, 4)]
        [InlineData("fggtrerewr", 3, 15)]
        [InlineData("r", 1, 1)]
        [InlineData("rgdg44444", 9, 1434)]
        [InlineData("rfd8eueje", 4, 20)]
        public void SpecifiedLength_Ok_IfWithinRange(string sample, uint minLength, uint maxLength)
        {
            // Arrange

            // Act
            var res = sample.SpecifiedLength(minLength, maxLength);

            // Assert
            Assert.True(res.IsOk());
        }

        [Theory]
        [InlineData("fggt", 0, 3)]
        [InlineData("fggtrerewr", 11, 15)]
        [InlineData("r", 2, 1)]
        [InlineData("rr", 2, 1)]
        [InlineData("asdf", 1, 3)]
        public void SpecifiedLength_Error_IfOutsideRange(string sample, uint minLength, uint maxLength)
        {
            // Arrange

            // Act
            var res = sample.SpecifiedLength(minLength, maxLength);

            // Assert
            Assert.True(res.IsError());
            Assert.Equal(StringValidationExtensions.InvalidLengthErrorCode, res.Error);
        }
    }
}
