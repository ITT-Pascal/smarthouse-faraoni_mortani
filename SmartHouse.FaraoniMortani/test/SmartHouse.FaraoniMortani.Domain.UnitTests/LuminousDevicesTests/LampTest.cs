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
            lamp.Switch();

            // Assert
            Assert.Equal(DeviceStatus.On, lamp.Status);
        }

        [Fact]
        public void Switch_WhenSwitchIsUsedAndLampIsTurnedOn_LampIsOff()
        {
            // Arrange
            Lamp lamp = new Lamp(id, "Stefano's lamp");

            // Act
            lamp.Switch();
            lamp.Switch();

            // Assert
            Assert.Equal(DeviceStatus.Off, lamp.Status);
        }

        [Fact]
        public void Switch_WhenSwitchOnIsUsed_LampIsOn()
        {
            // Arrange
            Lamp lamp = new Lamp(id, "Stefano's lamp");

            // Act
            lamp.SwitchOn();

            // Assert
            Assert.Equal(DeviceStatus.On, lamp.Status);
        }

        [Fact]
        public void Switch_WhenSwitchOffIsUsed_LampIsOff()
        {
            // Arrange
            Lamp lamp = new Lamp(id, "Stefano's lamp");

            // Act
            lamp.SwitchOn();
            lamp.SwitchOff();

            // Assert
            Assert.Equal(DeviceStatus.Off, lamp.Status);
        }

        [Fact]
        public void ChangeBrightness_WhenBrightnessLevelIsSetTo100AssignBrightnessValue()
        {
            Lamp lamp = new Lamp(id, "Stefano's lamp");

            lamp.Switch();
            lamp.SetBrightness(100);

            Assert.Equal(100, lamp.BrightnessLevel);
        }

        [Fact]
        public void SetBrightness_WhenBrightnessLevelIsSetTo0LampGetsTurnedOff()
        {
            Lamp lamp = new Lamp(id, "Stefano's lamp");

            lamp.Switch();
            lamp.SetBrightness(0);

            Assert.Equal(DeviceStatus.Off, lamp.Status);
        }

        [Fact]
        public void SetBrightness_WhenBrightnessLevelIsSetToANegativeNumberThrowArgument()
        {
            Lamp lamp = new Lamp(id, "Stefano's lamp");

            lamp.Switch();

            Assert.Throws<ArgumentOutOfRangeException>(() => lamp.SetBrightness(-1));
        }

        [Fact]
        public void SetBrightness_WhenBrightnessLevelIsSetToANumberGreaterThanMaximumLimitThrowArgument()
        {
            Lamp lamp = new Lamp(id, "Stefano's lamp");
            lamp.Switch();
            Assert.Throws<ArgumentOutOfRangeException>(() => lamp.SetBrightness(101));
        }

        [Fact]
        public void Dimmer_IfDeviceStatusIsOff_ThrowsException()
        {
            Lamp lamp = new Lamp(id, "Stefano's lamp");
            lamp.SwitchOn();
            Assert.Throws<InvalidOperationException>(() => lamp.Dimmer(10));
        }

        [Fact]
        public void Dimmer_IfAmountIsLowerThanOne_ThrowsException()
        {
            Lamp lamp = new Lamp(id, "Stefano's lamp");
            lamp.SwitchOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => lamp.Dimmer(0));
        }

        [Fact]
        public void Dimmer_IfDeviceStatusIsOnAndAmountIs30_BrightnessIs70()
        {
            Lamp lamp = new Lamp(id, "Stefano's lamp");
            lamp.SwitchOn();
            lamp.Dimmer(30);
            Assert.Equal(70, lamp.BrightnessLevel);
        }

        [Fact]
        public void Dimmer_IfDeviceStatusIsOnAndAmountIs120_BrightnessIs1()
        {
            Lamp lamp = new Lamp(id, "Stefano's lamp");
            lamp.SwitchOn();
            lamp.Dimmer(120);
            Assert.Equal(1, lamp.BrightnessLevel);
        }

        [Fact]
        public void Brighten_IfDeviceStatusIsOff_ThrowsException()
        {
            Lamp lamp = new Lamp(id, "Stefano's lamp");
            Assert.Throws<InvalidOperationException>(() => lamp.Brighten(10));
        }

        [Fact]
        public void Brighten_IfAmountIsLowerThanOne_ThrowsException()
        {
            Lamp lamp = new Lamp(id, "Stefano's lamp");

            lamp.SwitchOn();

            Assert.Throws<ArgumentOutOfRangeException>(() => lamp.Brighten(0));
        }

        [Fact]
        public void Brighten_IfDeviceStatusIsOnAndBrightnessLevelIs40AndAmountIs30_BrightnessIs70()
        {
            Lamp lamp = new Lamp(id, "Stefano's lamp");
            lamp.SetBrightness(40);
            lamp.Brighten(30);
            Assert.Equal(70, lamp.BrightnessLevel);
        }

        [Fact]
        public void Brighten_o()
        {
            Lamp lamp = new Lamp(id, "Stefano's lamp");

        }

        // TODO: Finish tests

    }
}