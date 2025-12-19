using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Domain.LuminousDevices
{
    public class MatrixLamp
    {
        // Attributes
        public AbstractLamp[,] matrixLamp { get; private set; }

        // Constructor
        public MatrixLamp(int rowLength, int columnLength)
        {
            matrixLamp = new AbstractLamp[rowLength, columnLength];
        }

        // Methods        
        public void AddLamp(AbstractLamp lamp)
        {
            
        }
    }
}
