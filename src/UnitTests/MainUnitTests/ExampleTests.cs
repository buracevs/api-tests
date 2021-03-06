using web_api.BL;
using Xunit;

namespace MainUnitTests
{
    public class ExampleTests
    {
        [Fact]
        public void HelloName_Returns_CorrectString()
        {
            // Arrange
            var name = "vasea";

            // Act
            var result = AnotherExample.Hello1(name);

            // Assert
            Assert.Equal("Hello: vasea", result);
        }

        [Fact]
        public void HelloName_returns_Ok()
        {
            // Arrange
            var name = "vasea";

            // Act
            var result = Example.HelloName(name);

            // Assert
            Assert.Equal("Hello: vasea", result);

        }

        [Fact]
        public void HashingReturnCorrectValue()
        {
            var result = Example.GetHash("1");
            Assert.NotNull(result);
            Assert.Equal("c4ca4238a0b923820dcc509a6f75849b", result);
        }
    }
}
