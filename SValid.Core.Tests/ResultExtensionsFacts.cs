using System.Linq;
using Xunit;

namespace SValid.Core.Tests
{
    using StringResult = Result<string>;

    public class ResultExtensionsFacts
    {
        [Fact]
        public void Merge_Ok_Ok_ReturnsFirstOk()
        {
            // Arrange
            var inp1 = StringResult.CreateOk("Ok1");
            var inp2 = StringResult.CreateOk("Ok2");

            // Act
            var res = inp1 & inp2;

            // Assert
            Assert.True(res.IsOk());
            Assert.Equal(inp1.Ok, res.Ok);
        }

        [Fact]
        public void Merge_Ok_Error_ReturnsError()
        {
            // Arrange
            var inp1 = StringResult.CreateOk("Ok");
            var inp2 = StringResult.CreateError("Error".ToError());

            // Act
            var res = inp1 & inp2;

            // Assert
            Assert.True(res.IsError());
            Assert.Equal(inp2.Error, res.Error);
        }

        [Fact]
        public void Merge_Error_Ok_ReturnsError()
        {
            // Arrange
            var inp1 = StringResult.CreateError("Error".ToError());
            var inp2 = StringResult.CreateOk("Ok");

            // Act
            var res = inp1 & inp2;

            // Assert
            Assert.True(res.IsError());
            Assert.Equal(inp1.Error, res.Error);
        }

        [Fact]
        public void Merge_Error_Error_ReturnsMergedErrors()
        {
            // Arrange
            var inp1 = StringResult.CreateError("Error1".ToError());
            var inp2 = StringResult.CreateError("Error2".ToError());

            // Act
            var res = inp1 & inp2;

            // Assert
            Assert.True(res.IsError());

            MultipleErrors multipleErrors = res.Error as MultipleErrors;
            Assert.NotNull(multipleErrors);

            Assert.Equal(inp1.Error, multipleErrors.Errors.First());
            Assert.Equal(inp2.Error, multipleErrors.Errors[1]);
        }
    }
}
