using System;
using Xunit;

namespace WalidacjaPesel.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void SprawdzPesel_PoprawnyPesel_ShouldReturnTrue()
        {
            // Arrange
            string validPesel = "92090663724"; // dobry numer pesel

            // Act
            bool result = Program.SprawdzPesel(validPesel);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void SprawdzPesel_NiepoprawnyPesel_ShouldReturnFalse()
        {
            // Arrange
            string invalidPesel = "12345678901"; // Przyk³adowy niepoprawny numer PESEL

            // Act
            bool result = Program.SprawdzPesel(invalidPesel);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void SprawdzPesel_NullInput_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => Program.SprawdzPesel(null)); // null
        }

        [Fact]
        public void SprawdzPesel_EmptyInput_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => Program.SprawdzPesel(string.Empty)); // pusty string
        }

        [Fact]
        public void SprawdzPesel_IncorrectLengthPesel_ShouldThrowException()
        {
            // Arrange
            string incorrectLengthPesel = "12345"; // Numer PESEL o niew³aœciwej d³ugoœci

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => Program.SprawdzPesel(incorrectLengthPesel));
            Assert.Equal("Numer PESEL powinien sk³adaæ siê z 11 cyfr.", exception.Message);
        }

        [Fact]
        public void SprawdzPesel_NonNumericPesel_ShouldThrowException()
        {
            // Arrange
            string nonNumericPesel = "12ABCD78901"; // Numer PESEL z niecyfrowymi znakami

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => Program.SprawdzPesel(nonNumericPesel));
            Assert.Equal("Numer PESEL powinien sk³adaæ siê tylko z cyfr.", exception.Message);
        }
    }
}
