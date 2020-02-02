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
            if (array == null) Invalid = true;
            else
            {
                if (row != 0 && column != 0 && array.Length != 0)
                {
                    if (array.Length == (row * column))
                    {
                        Row = row;
                        Col = column;
                        arr = array;
                        Invalid = false;
                    }
                    else { Invalid = true; }
                }
                else { Invalid = true; }
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

        public bool Invalid { get; }

        public uint Row { get; }
        public uint Col { get; }
        private double[] arr;
    }
}
