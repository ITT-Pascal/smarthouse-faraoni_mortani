using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.LuminousDevices
{
    public class MatrixLamp
    {
        public int RowLength { get; private set; }
        public int ColumnLength { get; private set; }

        // Attributes
        public AbstractLamp[,] matrix { get; private set; }

        // Constructor
        public MatrixLamp(int rowLength, int columnLength)
        {
            matrix = new AbstractLamp[rowLength, columnLength];
            RowLength = rowLength;
            ColumnLength = columnLength;
        }

        // Methods        
        public void AddLamp(AbstractLamp lamp)
        {
            bool lampAdded = false;
            for(int i=0; i<RowLength && lampAdded == false; i++)
            {
                for(int l=0; l<ColumnLength && lampAdded == false; l++)
                {
                    if (matrix[i, l] == null)
                    {
                        matrix[i, l] = lamp;
                        lampAdded = true;
                    }
                }
            }
        }

        public void AddLampInPosition(AbstractLamp lamp, int row, int column)
        {
            if(row > RowLength || column > ColumnLength)
            {
                throw new ArgumentException("Input row/column position is outside the matrix's bounds");
            }
            else
            {
                if (matrix[row, column] == null)
                {
                    matrix[row, column] = lamp;
                }
                else
                {
                    throw new ArgumentException("Input row/column position is already occupied by another lamp");
                }
            }
        }

        public void RemoveLamp(int row, int column)
        {
            if (row > RowLength || column > ColumnLength)
            {
                throw new ArgumentException("Input row/column position is outside the matrix's bounds");
            }
            else
            {
                if (matrix[row, column] != null)
                {
                    matrix[row, column] = null;
                }
                else
                {
                    throw new ArgumentException("Input row/column position is empty, therefore no lamp can be removed");
                }
            }
        }

        public void TurnOnLamp(int row, int column)
        {
            if (row > RowLength || column > ColumnLength)
            {
                throw new ArgumentException("Input row/column position is outside the matrix's bounds");
            }
            else
            {
                if (matrix[row, column] != null)
                {
                    if (matrix[row, column].Status == DeviceStatus.On)
                    {
                        matrix[row, column].Switch();
                    }
                    else
                    {
                        throw new Exception("Lamp is already on");
                    }
                }
                else
                {
                    throw new ArgumentException("Input row/column position is empty, therefore no lamp can be turned on");
                }
            }
        }

        public void TurnOffLamp(int row, int column)
        {
            if (row > RowLength || column > ColumnLength)
            {
                throw new ArgumentException("Input row/column position is outside the matrix's bounds");
            }
            else
            {
                if (matrix[row, column] != null)
                {
                    if (matrix[row, column].Status == DeviceStatus.On)
                    {
                        matrix[row, column].Switch();
                    }
                    else
                    {
                        throw new Exception("Lamp is already off");
                    }
                }
                else
                {
                    throw new ArgumentException("Input row/column position is empty, therefore no lamp can be turned on");
                }
            }
        }
    }
}
