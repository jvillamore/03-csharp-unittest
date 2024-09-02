using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Moq;
using StringManipulation;

namespace _03_csharp_unittest.Test
{
    public class StringOperationTest
    {
        [Fact]
        public void ConcatenateStringsTest_True()
        {
            // Arrange
            var stringOperations = new StringOperations();
            var input1 = "abc";
            var input2 = "def";
            // Act
            var result = stringOperations.ConcatenateStrings(input1, input2);
            // Assert
            Assert.NotEmpty(result);
            Assert.NotNull(result);
            Assert.Equal(result, $"{input1} {input2}");
        }

        [Fact]
        public void ConcatenateStringsTest_False()
        {
            // Arrange
            var stringOperations = new StringOperations();
            var input1 = "abc";
            var input2 = "def";
            // Act
            var result = stringOperations.ConcatenateStrings(input1, input2);
            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.NotEqual(result, $"{input1}{input2}");
        }

        [Fact(Skip = "Prueba no concluyente")]
        public void ConcatenateStringsTest_Skiped()
        {
            // Arrange
            var stringOperations = new StringOperations();
            var input1 = "abc";
            var input2 = "def";
            // Act
            var result = stringOperations.ConcatenateStrings(input1, input2);
            // Assert
            Assert.NotEqual(result, $"{input1}{input2}");
        }

        [Theory]
        [InlineData("V", 5)]
        [InlineData("VI", 6)]
        [InlineData("X", 10)]
        public void FromRomanToNumber(string romanNumber, int expected)
        {
            // Arrange
            var stringOperations = new StringOperations();
            // Act
            var result = stringOperations.FromRomanToNumber(romanNumber);
            // Assert
            Assert.Equal(result, expected);
        }


        [Theory]
        [InlineData("Hello platzi", 'l', 3)]
        [InlineData("Hello platzi", 't', 1)]
        [InlineData("Hello platzi", 'H', 1)]
        public void CountOccurrences(string romanNumber, char letter, int expected)
        {
            // Arrange
            var moqLogger = new Mock<ILogger<StringOperations>>();
            var stringOperations = new StringOperations(moqLogger.Object);
            // Act
            var result = stringOperations.CountOccurrences(romanNumber, letter);
            // Assert
            Assert.IsType<int>(result);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void ReadFileTest()
        {
            // Given
            var stringOperations = new StringOperations();
            var mockFileReader = new Mock<IFileReaderConector>();
            mockFileReader.Setup(p => p.ReadString(It.IsAny<string>())).Returns("texto");
            // When
            var result = stringOperations.ReadFile(mockFileReader.Object, "file.txt");

            // Then
            Assert.NotNull(result);
            Assert.Equal("texto", result);
        }



    }
}