using SmartHouse.FaraoniMortani.Domain.Devices.Abstractions;
using SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices;
using System.Security.Cryptography.X509Certificates;

namespace SmartHouse.FaraoniMortani.Domain.UnitTests.LuminousDevicesTests
{
    public class LampTest
    {
        Guid id = new Guid();

        [Fact]
        public void Switch_WhenSwitchIsUsedAndLampIsTurnedOff_LampIsOn()
        {
            // Arrange
            Lamp lamp = new Lamp(id, "Stefano's lamp");

            // Act
            lamp.Toggle();

            // Assert
            Assert.Equal(DeviceStatus.On, lamp.Status);
        }

        [Fact]
        public void Switch_WhenSwitchIsUsedAndLampIsTurnedOn_LampIsOff()
        {
            // Arrange
            Lamp lamp = new Lamp(id, "Stefano's lamp");

            // Act
            lamp.Toggle();
            lamp.Toggle();

            // Assert
            Assert.Equal(DeviceStatus.Off, lamp.Status);
        }

        [Fact]
        public void Switch_WhenSwitchOnIsUsed_LampIsOn()
        {
            // Arrange
            Lamp lamp = new Lamp(id, "Stefano's lamp");

            // Act
            lamp.Toggle();

            // Assert
            Assert.Equal(DeviceStatus.On, lamp.Status);
        }

        [Fact]
        public void Switch_WhenSwitchOffIsUsed_LampIsOff()
        {
            // Arrange
            Lamp lamp = new Lamp(id, "Stefano's lamp");

            // Act
            lamp.Toggle();
            lamp.Toggle();

            // Assert
            Assert.Equal(DeviceStatus.Off, lamp.Status);
        }

        [Fact]
        public void ChangeBrightness_WhenBrightnessLevelIsSetTo100AssignBrightnessValue()
        {
            // Arrange
            Lamp lamp = new Lamp(id, "Stefano's lamp");

            // Act
            lamp.Toggle();
            lamp.SetBrightness(new Brightness(100));

            // Assert
            Assert.Equal(100, lamp.BrightnessLevel.Value);
        }

        [Fact]
        public void SetBrightness_WhenBrightnessLevelIsSetTo0LampGetsTurnedOff()
        {
            // Arrange
            Lamp lamp = new Lamp(id, "Stefano's lamp");

            // Act
            lamp.Toggle();
            lamp.SetBrightness(new Brightness(0));

            // Assert
            Assert.Equal(DeviceStatus.Off, lamp.Status);
        }

        [Fact]
        public void SetBrightness_WhenBrightnessLevelIsSetToANegativeNumberThrowArgument()
        {
            // Arrange
            Lamp lamp = new Lamp(id, "Stefano's lamp");

            // Act
            lamp.Toggle();

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => lamp.SetBrightness(new Brightness(-1)));
        }

        [Fact]
        public void SetBrightness_WhenBrightnessLevelIsSetToANumberGreaterThanMaximumLimitThrowArgument()
        {
            // Arrange
            Lamp lamp = new Lamp(id, "Stefano's lamp");
            
            // Act 
            lamp.Toggle();

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => lamp.SetBrightness(new Brightness(101)));
        }

        [Fact]
        public void Dimmer_IfDeviceStatusIsOff_ThrowsException()
        {
            // Arrange
            Lamp lamp = new Lamp(id, "Stefano's lamp");

            // Assert
            Assert.Throws<InvalidOperationException>(() => lamp.Dimmer(10));
        }

        [Fact]
        public void Dimmer_IfAmountIsLowerThanOne_ThrowsException()
        {
            // Arrange
            Lamp lamp = new Lamp(id, "Stefano's lamp");

            // Act
            lamp.Toggle();
            
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => lamp.Dimmer(0));
        }

        [Fact]
        public void Dimmer_IfDeviceStatusIsOnAndAmountIs30_BrightnessIs70()
        {
            // Arrange
            Lamp lamp = new Lamp(id, "Stefano's lamp");

            // Act
            lamp.Toggle();
            lamp.Dimmer(30);

            // Assert
            Assert.Equal(70, lamp.BrightnessLevel.Value);
        }

        [Fact]
        public void Dimmer_IfDeviceStatusIsOnAndAmountIs120_BrightnessIs0()
        {
            // Arrange
            Lamp lamp = new Lamp(id, "Stefano's lamp");

            // Act
            lamp.Toggle();
            lamp.Dimmer(120);

            // Assert
            Assert.Equal(0, lamp.BrightnessLevel.Value);
        }

        [Fact]
        public void Brighten_IfDeviceStatusIsOff_ThrowsException()
        {
            // Arrange
            Lamp lamp = new Lamp(id, "Stefano's lamp");

            // Assert
            Assert.Throws<InvalidOperationException>(() => lamp.Brighten(10));
        }

        [Fact]
        public void Brighten_IfAmountIsLowerThanOne_ThrowsException()
        {
            // Arrange
            Lamp lamp = new Lamp(id, "Stefano's lamp");

            // Act
            lamp.Toggle();

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => lamp.Brighten(0));
        }

        [Fact]
        public void Brighten_WhenBrightessLevelIs80AndAmountIs30_BrightnessBecome100()
        {
            // Arrange
            Lamp lamp = new Lamp(id, "Stefano's lamp");

            // Act
            lamp.Toggle();
            lamp.SetBrightness(new Brightness(80));
            lamp.Brighten(30);

            // Assert
            Assert.Equal(100, lamp.BrightnessLevel.Value);
        }

        [Fact]
        public void Brighten_IfDeviceStatusIsOnAndBrightnessLevelIs40AndAmountIs30_BrightnessIs70()
        {
            // Arrange
            Lamp lamp = new Lamp(id, "Stefano's lamp");

            // Act
            lamp.Toggle();
            lamp.SetBrightness(new Brightness(40));
            lamp.Brighten(30);

            // Assert
            Assert.Equal(70, lamp.BrightnessLevel.Value);
        }
    }
}