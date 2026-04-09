using SmartHouse.FaraoniMortani.Domain.Devices.Abstractions;
using SmartHouse.FaraoniMortani.Domain.Devices.LuminousDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.UnitTests.LuminousDevicesTests
{
    public class MatrixLampTest
    {
        [Fact]
        public void AddLamp_WhenLampIsAddedInAnEmpty5x5Matrix_PositionRow0Column0HasALamp()
        {
            MatrixLamp matrixLamp = new MatrixLamp(5, 5);
            AbstractLamp lamp = new Lamp();

            matrixLamp.AddLamp(lamp);

            Assert.NotNull(matrixLamp.matrix[0, 0]);
        }

        [Fact]
        public void AddLampInPosition_WhenLampIsAddedInPositionRow0Column4InAnEmpty5x5Matrix_PositionRow0Column4HasALamp()
        {
            MatrixLamp matrixLamp = new MatrixLamp(5, 5);
            AbstractLamp lamp = new Lamp();

            matrixLamp.AddLampInPosition(lamp, 0, 4);

            Assert.NotNull(matrixLamp.matrix[0, 4]);
        }

        [Fact]
        public void AddLampInPosition_WhenLampIsAddedInPositionRow0Column4InAnEmpty5x5Matrix_PositionRow0Column0DoesNotHaveALamp()
        {
            MatrixLamp matrixLamp = new MatrixLamp(5, 5);
            AbstractLamp lamp = new Lamp();

            matrixLamp.AddLampInPosition(lamp, 0, 4);

            Assert.Null(matrixLamp.matrix[0, 0]);
        }

        [Fact]
        public void AddLampInPosition_WhenLampIsAddedInPositionWithRowOutsideAnEmpty5x5Matrix_ExceptionIsThrown()
        {
            MatrixLamp matrixLamp = new MatrixLamp(5, 5);
            AbstractLamp lamp = new Lamp();

            Assert.Throws<IndexOutOfRangeException>(() => matrixLamp.AddLampInPosition(lamp, 5, 4));
        }

        [Fact]
        public void AddLampInPosition_WhenLampIsAddedInPositionWithColumnOutsideAnEmpty5x5Matrix_ExceptionIsThrown()
        {
            MatrixLamp matrixLamp = new MatrixLamp(5, 5);
            AbstractLamp lamp = new Lamp();

            Assert.Throws<IndexOutOfRangeException>(() => matrixLamp.AddLampInPosition(lamp, 4, 5));
        }

        [Fact]
        public void AddLampInPosition_WhenLampIsAddedInPositionRow0Column4InAnEmpty5x5MatrixAndAnotherLampIsAddedInTheSamePosition_ExceptionIsThrown()
        {
            MatrixLamp matrixLamp = new MatrixLamp(5, 5);
            AbstractLamp lamp = new Lamp();

            matrixLamp.AddLampInPosition(lamp, 0, 4);

            Assert.Throws<ArgumentException>(() => matrixLamp.AddLampInPosition(lamp, 0, 4));
        }

        [Fact]
        public void RemoveLamp_WhenLampIsAddedInPositionRow0Column4InAnEmpty5x5MatrixAndIsThenRemoved_PositionRow0Column4DoesNotHaveALamp()
        {
            MatrixLamp matrixLamp = new MatrixLamp(5, 5);
            AbstractLamp lamp = new Lamp();

            matrixLamp.AddLampInPosition(lamp, 0, 4);
            matrixLamp.RemoveLamp(0, 4);

            Assert.Null(matrixLamp.matrix[0, 4]);
        }

        [Fact]
        public void RemoveLamp_WhenLampIsRemovedInPositionWithRowOutsideAnEmpty5x5Matrix_ExceptionIsThrown()
        {
            MatrixLamp matrixLamp = new MatrixLamp(5, 5);

            Assert.Throws<IndexOutOfRangeException>(() => matrixLamp.RemoveLamp(5, 4));
        }


        [Fact]
        public void RemoveLamp_WhenLampIsRemovedInPositionWithColumnOutsideAnEmpty5x5Matrix_ExceptionIsThrown()
        {
            MatrixLamp matrixLamp = new MatrixLamp(5, 5);

            Assert.Throws<IndexOutOfRangeException>(() => matrixLamp.RemoveLamp(4, 5));
        }

        [Fact]
        public void RemoveLamp_WhenLampIsRemovedInEmptyPositionRow0Column4_ExceptionIsThrown()
        {
            MatrixLamp matrixLamp = new MatrixLamp(5, 5);

            Assert.Throws<ArgumentException>(() => matrixLamp.RemoveLamp(0, 4));
        }

        [Fact]
        public void TurnOnLamp_WhenLampInPositionRow0Column0InA5x5MatrixIsOffAndIsTurnedOn_LampIsTurnedOn()
        {
            MatrixLamp matrixLamp = new MatrixLamp(5, 5);
            AbstractLamp lamp = new Lamp();

            matrixLamp.AddLamp(lamp);
            matrixLamp.TurnOnLamp(0, 0);

            Assert.Equal(DeviceStatus.On, matrixLamp.matrix[0, 0].Status);
        }

        [Fact]
        public void TurnOnLamp_WhenLampInPositionWithRowOutsideA5x5MatrixIsTurnedOn_ExceptionIsThrown()
        {
            MatrixLamp matrixLamp = new MatrixLamp(5, 5);
            AbstractLamp lamp = new Lamp();

            matrixLamp.AddLamp(lamp);

            Assert.Throws<IndexOutOfRangeException>(() => matrixLamp.TurnOnLamp(5, 4));
        }

        [Fact]
        public void TurnOnLamp_WhenLampInPositionWithColumnOutsideA5x5MatrixIsTurnedOn_ExceptionIsThrown()
        {
            MatrixLamp matrixLamp = new MatrixLamp(5, 5);
            AbstractLamp lamp = new Lamp();

            matrixLamp.AddLamp(lamp);

            Assert.Throws<IndexOutOfRangeException>(() => matrixLamp.TurnOnLamp(4, 5));
        }

        [Fact]
        public void TurnOnLamp_WhenLampInPositionRow0Column0InA5x5MatrixIsOffAndIsTurnedOn_ThenTurnedOnAgain_ExceptionIsThrown()
        {
            MatrixLamp matrixLamp = new MatrixLamp(5, 5);
            AbstractLamp lamp = new Lamp();

            matrixLamp.AddLamp(lamp);
            matrixLamp.TurnOnLamp(0, 0);

            Assert.Throws<Exception>(() => matrixLamp.TurnOnLamp(0, 0));
        }

        [Fact]
        public void TurnOnLamp_WhenLampInEmptyPositionRow0Column1InA5x5MatrixIsOffAndIsTurnedOn_ExceptionIsThrown()
        {
            MatrixLamp matrixLamp = new MatrixLamp(5, 5);
            AbstractLamp lamp = new Lamp();

            matrixLamp.AddLamp(lamp);

            Assert.Throws<ArgumentException>(() => matrixLamp.TurnOnLamp(0, 1));
        }

        [Fact]
        public void TurnOffLamp_WhenLampInPositionRow0Column0InA5x5MatrixIsOnAndIsTurnedOff_LampIsTurnedOff()
        {
            MatrixLamp matrixLamp = new MatrixLamp(5, 5);
            AbstractLamp lamp = new Lamp();

            matrixLamp.AddLamp(lamp);
            matrixLamp.TurnOnLamp(0, 0);
            matrixLamp.TurnOffLamp(0, 0);

            Assert.Equal(DeviceStatus.Off, matrixLamp.matrix[0, 0].Status);
        }

        [Fact]
        public void TurnOffLamp_WhenLampInPositionWithRowOutsideA5x5MatrixIsTurnedOn_ExceptionIsThrown()
        {
            MatrixLamp matrixLamp = new MatrixLamp(5, 5);
            AbstractLamp lamp = new Lamp();

            matrixLamp.AddLamp(lamp);

            Assert.Throws<IndexOutOfRangeException>(() => matrixLamp.TurnOffLamp(5, 4));
        }

        [Fact]
        public void TurnOffLamp_WhenLampInPositionWithColumnOutsideA5x5MatrixIsTurnedOff_ExceptionIsThrown()
        {
            MatrixLamp matrixLamp = new MatrixLamp(5, 5);
            AbstractLamp lamp = new Lamp();

            matrixLamp.AddLamp(lamp);

            Assert.Throws<IndexOutOfRangeException>(() => matrixLamp.TurnOffLamp(4, 5));
        }

        [Fact]
        public void TurnOffLamp_WhenLampInPositionRow0Column0InA5x5MatrixIsOnAndIsTurnedOff_ThenTurnedOffAgain_ExceptionIsThrown()
        {
            MatrixLamp matrixLamp = new MatrixLamp(5, 5);
            AbstractLamp lamp = new Lamp();

            matrixLamp.AddLamp(lamp);
            matrixLamp.TurnOnLamp(0, 0);
            matrixLamp.TurnOffLamp(0, 0);

            Assert.Throws<Exception>(() => matrixLamp.TurnOffLamp(0, 0));
        }

        [Fact]
        public void TurnOffLamp_WhenLampInEmptyPositionRow0Column1InA5x5MatrixIsTurnedOff_ExceptionIsThrown()
        {
            MatrixLamp matrixLamp = new MatrixLamp(5, 5);
            AbstractLamp lamp = new Lamp();

            matrixLamp.AddLamp(lamp);

            Assert.Throws<ArgumentException>(() => matrixLamp.TurnOffLamp(0, 1));
        }
    }
}
