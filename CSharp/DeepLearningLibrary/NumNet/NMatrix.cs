using System;
using System.Collections.Generic;
using System.Text;

namespace NumNet
{
    /// <summary>
    /// 2 dimensional matrix
    /// </summary>
    public partial class NMatrix
    {
        public NMatrix(uint row, uint column, double[] array)
        {
            if (row != 0 && column != 0 && array.Length != 0)
            {
                if (array.Length.Equals(row * column))
                {
                    Row = row;
                    Col = column;
                    arr = array;
                }
            }
        }

        public double this[uint i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }
        }

        public double this[uint i, uint j]
        {
            get { return arr[i * Col + j]; }
            set { arr[i * Col + j] = value; }
        }

        public uint Row { get; }
        public uint Col { get; }
        private double[] arr;
    }
}
