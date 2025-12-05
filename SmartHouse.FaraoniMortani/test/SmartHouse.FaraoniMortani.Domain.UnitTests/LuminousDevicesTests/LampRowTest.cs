using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.UnitTests.LuminousDevicesTests
{
    public class LampRowTest
    {
		Guid guid = new Guid();

		[Fact]
        public void AddLamp_WhenLampIsAddedInAnEmptyRow_RowHasOneLamp()
        {
            // Arrange
            AbstractLamp lamp1 = new Lamp();
            LampRow lampRow1 = new LampRow();

            // Act
            lampRow1.AddLamp(lamp1);

            // Assert
            Assert.Equal(1, lampRow1.lampRow.Count());
        }

        [Fact]
        public void AddLampInPosition_WhenInARowWith0Lamps_LampIsAddedInPosition2_RowHasOneLampAndLampIsInPosition2()
        {
            // Arrange
            AbstractLamp lamp1 = new Lamp();
            LampRow lampRow1 = new LampRow();

            // Act
            lampRow1.AddLampInPosition(lamp1, 0);

            // Assert
            Assert.Equal(1, lampRow1.lampRow.Count());
            Assert.Equal(0, lampRow1.lampRow.IndexOf(lamp1));
        }

        [Fact]
        public void RemoveLamp_WhenLampWithNameXIsRemovedInARowWithOneLamp_RowIsEmpty()
        {
            // Arrange
            AbstractLamp lamp1 = new Lamp("Stefano's Lamp");
            LampRow lampRow1 = new LampRow();

            // Act
            lampRow1.AddLamp(lamp1);
            lampRow1.RemoveLamp("Stefano's Lamp");

            // Assert
            Assert.Equal(0, lampRow1.lampRow.Count());
        }

        [Fact]
        public void RemoveLamp_WhenLampWithGuidXIsRemovedInARowWithOneLamp_RowIsEmpty()
        {
            // Arrange
            AbstractLamp lamp1 = new Lamp(guid, "Stefano's Lamp");
            LampRow lampRow1 = new LampRow();
            
            // Act
            lampRow1.AddLamp(lamp1);
            lampRow1.RemoveLamp(guid);

            // Assert
            Assert.Equal(0, lampRow1.lampRow.Count());
        }

        [Fact]
        public void RemoveLampInPosition_WhenInARowWithOneLamp_LampIsRemovedFromPosition2_RowHasZeroLamps()
        {
            // Arrange
            AbstractLamp lamp1 = new Lamp();
            LampRow lampRow1 = new LampRow();

            // Act
            lampRow1.AddLampInPosition(lamp1, 0);
            lampRow1.RemoveLampInPosition(0);

            // Assert
            Assert.Equal(0, lampRow1.lampRow.Count());
        }

        [Fact]
        public void TurnOnSingleLamp_WhenLampWithGuidXInPosition0IsTurnedOn_LampIsOn()
        {
            // Arrange
            AbstractLamp lamp1 = new Lamp(guid, "Stefano's Lamp");
            LampRow lampRow1 = new LampRow();

            // Act
            lampRow1.AddLamp(lamp1);
            lampRow1.TurnOnSingleLamp(guid);

            // Assert
            Assert.Equal(DeviceStatus.On, lamp1.Status);
        }

        [Fact]
        public void TurnOnSingleLamp_WhenLampWithNameXInPosition0IsTurnedOn_LampIsOn()
        {
            // Arrange
            AbstractLamp lamp1 = new Lamp(guid, "Stefano's Lamp");
            LampRow lampRow1 = new LampRow();

            // Act
            lampRow1.AddLamp(lamp1);
            lampRow1.TurnOnSingleLamp("Stefano's Lamp");

            // Assert
            Assert.Equal(DeviceStatus.On, lamp1.Status);
        }

        [Fact]
        public void TurnOnAllLamps_WhenAll2LampsAreTurnedOn_BothLampsAreOn()
        {
            // Arrange
            AbstractLamp lamp1 = new Lamp();
            AbstractLamp lamp2 = new Lamp();
            LampRow lampRow1 = new LampRow();

            // Act
            lampRow1.AddLamp(lamp1);
            lampRow1.AddLamp(lamp2);
            lampRow1.TurnOnAllLamps();

            // Assert
            Assert.Equal(DeviceStatus.On, lamp1.Status);
            Assert.Equal(DeviceStatus.On, lamp2.Status);
        }

        [Fact]
        public void TurnOffSingleLamp_WhenLampWithGuidXInPosition0IsTurnedOff_LampIsOff()
        {
            // Arrange
            AbstractLamp lamp1 = new Lamp(guid, "Stefano's Lamp");
            LampRow lampRow1 = new LampRow();

            // Act
            lampRow1.AddLamp(lamp1);
            lampRow1.TurnOnSingleLamp(guid);
            lampRow1.TurnOffSingleLamp(guid);

            // Assert
            Assert.Equal(DeviceStatus.Off, lamp1.Status);
        }

        [Fact]
        public void TurnOffSingleLamp_WhenLampWithNameXInPosition0IsTurnedOff_LampIsOff()
        {
            // Arrange
            AbstractLamp lamp1 = new Lamp(guid, "Stefano's Lamp");
            LampRow lampRow1 = new LampRow();

            // Act
            lampRow1.AddLamp(lamp1);
            lampRow1.TurnOnSingleLamp("Stefano's Lamp");
            lampRow1.TurnOffSingleLamp("Stefano's Lamp");
            
            // Assert
            Assert.Equal(DeviceStatus.Off, lamp1.Status);
        }

        [Fact]
        public void TurnOffAllLamps_WhenAll2LampsAreTurnedOff_BothLampsAreOff()
        {    
            // Arrange
            AbstractLamp lamp1 = new Lamp();
            AbstractLamp lamp2 = new Lamp();
            LampRow lampRow1 = new LampRow();

            // Act
            lampRow1.AddLamp(lamp1);
            lampRow1.AddLamp(lamp2);
            lampRow1.TurnOnAllLamps();
            lampRow1.TurnOffAllLamps();

            // Assert
            Assert.Equal(DeviceStatus.Off, lamp1.Status);
            Assert.Equal(DeviceStatus.Off, lamp2.Status);
        }

        [Fact]
        public void SetBrightnessForLamp_WhenLampWithGuidXIsSetToBrightness50_BrightnessValueIs50()
        {    
            // Arrange
            AbstractLamp lamp1 = new Lamp(guid, "Stefano's Lamp");
            LampRow lampRow1 = new LampRow();

            // Act
            lampRow1.AddLamp(lamp1);
            lampRow1.SetBrightnessForLamp(guid, 50);

            // Assert
            Assert.Equal(50, lamp1.BrightnessLevel);
        }

        [Fact]
        public void SetBrightnessForLamp_WhenLampWithNameXIsSetToBrightness50_BrightnessValueIs50()
        {
            // Arrange
            AbstractLamp lamp1 = new Lamp(guid, "Stefano's Lamp");
            LampRow lampRow1 = new LampRow();

            // Act
            lampRow1.AddLamp(lamp1);
            lampRow1.SetBrightnessForLamp("Stefano's Lamp", 50);

            // Assert
            Assert.Equal(50, lamp1.BrightnessLevel);
        }

        [Fact]
        public void SetBrightnessForAllLamps_WhenAll2LampsAreSetToBrightness50_BothLampsBrightnessValueIs50()
        {
            // Arrange
            AbstractLamp lamp1 = new Lamp();
            AbstractLamp lamp2 = new Lamp();
            LampRow lampRow1 = new LampRow();

            // Act
            lampRow1.AddLamp(lamp1);
            lampRow1.AddLamp(lamp2);
            lampRow1.SetBrightnessForAllLamps(50);

            // Assert
            Assert.Equal(50, lamp1.BrightnessLevel);
            Assert.Equal(50, lamp2.BrightnessLevel);
        }
    }
}
