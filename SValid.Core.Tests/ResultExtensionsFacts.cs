using System;
using System.Linq;
using Xunit;

namespace SValid.Core.Tests
{
    using StringResult = Result<string, string>;

    public class ResultExtensionsFacts
    {
        [Fact]
        public void Bind_InputOk_ReturnsDelegateResult()
        {
            // Arrange
            var input = StringResult.CreateOk("Ok string");

            // Act
            var res = input.Bind(s => StringResult.CreateOk(s + " appended"));

            // Assert
            Assert.True(res.IsOk());
            Assert.Equal("Ok string appended", res.Ok);
        }

        [Fact]
        public void Bind_InputError_ReturnsOriginalError()
        {
            // Arrange
            var input = StringResult.CreateError("E9023");

            // Act
            var res = input.Bind(s => StringResult.CreateError("E786"));

            // Assert
            Assert.True(res.IsError());
            Assert.Equal("E9023", res.Error);
        }

        [Fact]
        public void Bind_InputError_ContinuationIsNotCalled()
        {
            // Arrange
            var input = StringResult.CreateError("E9023");
            bool continuationCalled = false;

            // Act
            var res = input.Bind(s =>
            {
                continuationCalled = true;
                return StringResult.CreateError("E545");
            });

            // Assert
            Assert.False(continuationCalled);
        }

        [Fact]
        public void Merge_Ok_Ok_ReturnsFirstOk()
        {
            // Arrange
            var inp1 = StringResult.CreateOk("Ok1");
            var inp2 = StringResult.CreateOk("Ok2");

            // Act
            var res = inp1.Merge(inp2);

            // Assert
            Assert.True(res.IsOk());
            Assert.Equal(inp1.Ok, res.Ok);
        }

        [Fact]
        public void Merge_Ok_Error_ReturnsError()
        {
            // Arrange
            var inp1 = StringResult.CreateOk("Ok");
            var inp2 = StringResult.CreateError("Error");

            // Act
            var res = inp1.Merge(inp2);

            // Assert
            Assert.True(res.IsError());
            Assert.Equal(inp2.Error, res.Error.First());
        }

        [Fact]
        public void Merge_Error_Ok_ReturnsError()
        {
            // Arrange
            var inp1 = StringResult.CreateError("Error");
            var inp2 = StringResult.CreateOk("Ok");

            // Act
            var res = inp1.Merge(inp2);

            // Assert
            Assert.True(res.IsError());
            Assert.Equal(inp1.Error, res.Error.First());
        }

        [Fact]
        public void Merge_Error_Error_ReturnsMergedErrors()
        {
            // Arrange
            var inp1 = StringResult.CreateError("Error1");
            var inp2 = StringResult.CreateError("Error2");

            // Act
            var res = inp1.Merge(inp2);

            // Assert
            Assert.True(res.IsError());
            Assert.Equal(inp1.Error, res.Error.First());
            Assert.Equal(inp2.Error, res.Error[1]);
        }
    }
}
