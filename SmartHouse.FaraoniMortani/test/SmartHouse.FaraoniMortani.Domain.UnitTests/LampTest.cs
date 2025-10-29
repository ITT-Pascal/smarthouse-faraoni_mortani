using System.Security.Cryptography.X509Certificates;

namespace SmartHouse.FaraoniMortani.Domain.UnitTests
{
    public class LampTest
    {
        [Fact]
        public void LampTurnOn_WhenIsTurnedOn_IsOnIsTrue()
        {
            // Arrange
            Lamp lamp = new Lamp();

            // Act
            lamp.TurnOn();

            // Assert
            Assert.Equal(true, lamp.IsOn);
        }

        [Fact]
        public void LampTurnOn_WhenIsTurnedOn_ModeIsNormal()
        {
            // Arrange
            Lamp lamp = new Lamp();

            // Act
            lamp.TurnOn();

            // Assert
            Assert.Equal("Normal", lamp._mode);
        }

        [Fact]
        public void LampTurnOff_WhenIsTurnedOff_IsOnIsFalse()
        {
            // Arrange
            Lamp lamp = new Lamp();

            // Act
            lamp.TurnOff();

            // Assert
            Assert.Equal(false, lamp.IsOn);

        }

        [Fact]
        public void LampChangeMode_WhenTheNewModeIsFocused_ItBecomesFocused()
        {
            // Arrange
            Lamp lamp = new Lamp();

            // Act
            lamp.TurnOn();
            lamp.ChangeMode("Focused");

            //Assert
            Assert.Equal("Focused", lamp._mode);
        }

        [Fact]
        public void LampChangeMode_WhenTheNewModeIsFlashing_ItBecomesFlashing()
        {
            // Arrange
            Lamp lamp = new Lamp();

            // Act
            lamp.TurnOn();
            lamp.ChangeMode("Flashing");

            // Assert
            Assert.Equal("Flashing", lamp._mode);
        }

        [Fact]
        public void LampChangeMode_WhenTheNewModeIsNormal_ItBecomesNormal()
        {
            // Arrange
            Lamp lamp = new Lamp();

            // Act
            lamp.TurnOn();
            lamp.ChangeMode("Normal");

            // Assert
            Assert.Equal("Normal", lamp._mode);
        }

        [Fact]
        public void LampChangeMode_WhenTheNewModeIsNotBetweenNormalFocusedAndFlashing_ItIsNotAssigned()
        {
            // Arrange
            Lamp lamp = new Lamp();

            // Act
            lamp.ChangeMode("Stefano");

            // Assert
            Assert.Null(lamp._mode);

        }
    }
}