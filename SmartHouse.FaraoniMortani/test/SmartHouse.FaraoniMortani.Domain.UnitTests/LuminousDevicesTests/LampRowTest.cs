using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.UnitTests.LuminousDevicesTests
{
    public class LampRowTest
    {
        [Fact]
        public void AddLamp_WhenLampIsAddedInAnEmptyRow_RowHasOneLamp()
        {
            AbstractLamp lamp1 = new Lamp();
            LampRow lampRow1 = new LampRow();

            lampRow1.AddLamp(lamp1);

            Assert.Equal(1, lampRow1.lampRow.Count());
        }

        [Fact]
        public void AddLampInPosition_WhenInARowWith0Lamps_LampIsAddedInPosition2_RowHasOneLampAndLampIsInPosition2()
        {
            AbstractLamp lamp1 = new Lamp();
            LampRow lampRow1 = new LampRow();

            lampRow1.AddLampInPosition(lamp1, 0);

            Assert.Equal(1, lampRow1.lampRow.Count());
            Assert.Equal(0, lampRow1.lampRow.IndexOf(lamp1));
        }

        [Fact]
        public void RemoveLamp_WhenLampWithNameXIsRemovedInARowWithOneLamp_RowIsEmpty()
        {
            AbstractLamp lamp1 = new Lamp("Lamp1");
            LampRow lampRow1 = new LampRow();

            lampRow1.AddLamp(lamp1);
            lampRow1.RemoveLamp("Lamp1");

            Assert.Equal(0, lampRow1.lampRow.Count());
        }

        [Fact]
        public void RemoveLamp_WhenLampWithGuidXIsRemovedInARowWithOneLamp_RowIsEmpty()
        {
            Guid guid1 = new Guid();
            AbstractLamp lamp1 = new Lamp(guid1, "Lamp1");
            LampRow lampRow1 = new LampRow();
            

            lampRow1.AddLamp(lamp1);
            lampRow1.RemoveLamp(guid1);

            Assert.Equal(0, lampRow1.lampRow.Count());
        }

        [Fact]
        public void RemoveLampInPosition_WhenInARowWithOneLamp_LampIsRemovedFromPosition2_RowHasZeroLamps()
        {
            AbstractLamp lamp1 = new Lamp();
            LampRow lampRow1 = new LampRow();

            lampRow1.AddLampInPosition(lamp1, 0);
            lampRow1.RemoveLampInPosition(0);

            Assert.Equal(0, lampRow1.lampRow.Count());
        }

        [Fact]
        public void TurnOnSingleLamp_WhenLampWithGuidXInPosition0IsTurnedOn_LampIsOn()
        {
            Guid guid1 = new Guid();
            AbstractLamp lamp1 = new Lamp(guid1, "Lamp1");
            LampRow lampRow1 = new LampRow();

            lampRow1.AddLamp(lamp1);
            lampRow1.TurnOnSingleLamp(guid1);

            Assert.Equal(DeviceStatus.On, lamp1.Status);
        }

        [Fact]
        public void TurnOnSingleLamp_WhenLampWithNameXInPosition0IsTurnedOn_LampIsOn()
        {
            Guid guid1 = new Guid();
            AbstractLamp lamp1 = new Lamp(guid1, "Lamp1");
            LampRow lampRow1 = new LampRow();

            lampRow1.AddLamp(lamp1);
            lampRow1.TurnOnSingleLamp("lamp1");

            Assert.Equal(DeviceStatus.On, lamp1.Status);
        }

        [Fact]
        public void TurnOnAllLamps_WhenAll2LampsAreTurnedOn_BothLampsAreOn()
        {
            AbstractLamp lamp1 = new Lamp();
            AbstractLamp lamp2 = new Lamp();
            LampRow lampRow1 = new LampRow();

            lampRow1.AddLamp(lamp1);
            lampRow1.AddLamp(lamp2);
            lampRow1.TurnOnAllLamps();

            Assert.Equal(DeviceStatus.On, lamp1.Status);
            Assert.Equal(DeviceStatus.On, lamp2.Status);
        }

        [Fact]
        public void TurnOffSingleLamp_WhenLampWithGuidXInPosition0IsTurnedOff_LampIsOff()
        {
            Guid guid1 = new Guid();
            AbstractLamp lamp1 = new Lamp(guid1, "Lamp1");
            LampRow lampRow1 = new LampRow();

            lampRow1.AddLamp(lamp1);
            lampRow1.TurnOnSingleLamp(guid1);
            lampRow1.TurnOffSingleLamp(guid1);

            Assert.Equal(DeviceStatus.Off, lamp1.Status);
        }

        [Fact]
        public void TurnOffSingleLamp_WhenLampWithNameXInPosition0IsTurnedOff_LampIsOff()
        {
            Guid guid1 = new Guid();
            AbstractLamp lamp1 = new Lamp(guid1, "Lamp1");
            LampRow lampRow1 = new LampRow();

            lampRow1.AddLamp(lamp1);
            lampRow1.TurnOnSingleLamp("lamp1");
            lampRow1.TurnOffSingleLamp("lamp1");

            Assert.Equal(DeviceStatus.Off, lamp1.Status);
        }

        [Fact]
        public void TurnOffAllLamps_WhenAll2LampsAreTurnedOff_BothLampsAreOff()
        {
            AbstractLamp lamp1 = new Lamp();
            AbstractLamp lamp2 = new Lamp();
            LampRow lampRow1 = new LampRow();

            lampRow1.AddLamp(lamp1);
            lampRow1.AddLamp(lamp2);
            lampRow1.TurnOnAllLamps();
            lampRow1.TurnOffAllLamps();

            Assert.Equal(DeviceStatus.Off, lamp1.Status);
            Assert.Equal(DeviceStatus.Off, lamp2.Status);
        }

        [Fact]
        public void SetBrightnessForLamp_WhenLampWithGuidXIsSetToBrightness50_BrightnessValueIs50()
        {
            Guid guid1 = new Guid();
            AbstractLamp lamp1 = new Lamp(guid1, "Lamp1");
            LampRow lampRow1 = new LampRow();
            lampRow1.AddLamp(lamp1);
            lampRow1.SetBrightnessForLamp(guid1, 50);

            Assert.Equal(50, lamp1.BrightnessLevel);
        }

        [Fact]
        public void SetBrightnessForLamp_WhenLampWithNameXIsSetToBrightness50_BrightnessValueIs50()
        {
            Guid guid1 = new Guid();
            AbstractLamp lamp1 = new Lamp(guid1, "Lamp1");
            LampRow lampRow1 = new LampRow();
            lampRow1.AddLamp(lamp1);
            lampRow1.SetBrightnessForLamp("lamp1", 50);

            Assert.Equal(50, lamp1.BrightnessLevel);
        }

        [Fact]
        public void SetBrightnessForAllLamps_WhenAll2LampsAreSetToBrightness50_BothLampsBrightnessValueIs50()
        {
            AbstractLamp lamp1 = new Lamp();
            AbstractLamp lamp2 = new Lamp();
            LampRow lampRow1 = new LampRow();

            lampRow1.AddLamp(lamp1);
            lampRow1.AddLamp(lamp2);
            lampRow1.SetBrightnessForAllLamps(50);

            Assert.Equal(50, lamp1.BrightnessLevel);
            Assert.Equal(50, lamp2.BrightnessLevel);
        }
    }
}
