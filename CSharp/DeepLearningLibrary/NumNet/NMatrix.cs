using System;
using System.Collections;
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

        public NMatrix(NMatrix B)
        {
            if (B.Invalid)
            {
                Invalid = true;
            } else
            {
                Row = B.Row;
                Col = B.Col;
                arr = new double[B.arr.Length];
                B.arr.CopyTo(arr, 0);
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

        public override bool Equals(object obj)
        {
            return Equals(obj as NMatrix);
        }

        public bool Equals(NMatrix B)
        {
            // If parameter is null, return false.
            if (ReferenceEquals(B, null))
            {
                return false;
            }

            // Optimization for a common success case.
            if (ReferenceEquals(this, B))
            {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (GetType() != B.GetType())
            {
                return false;
            }

            if (Row != B.Row || Col != B.Col
                || Invalid || B.Invalid)
            {
                return false;
            }

            for (uint i = 0; i < (Row * Col); i++)
            {
                if (this[i] != B[i]) return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            //return base.GetHashCode();
            int hashResult = Row.GetHashCode();
            hashResult ^= Col.GetHashCode();
            hashResult ^= 
                ((IStructuralEquatable)this.arr)
                .GetHashCode(EqualityComparer<double>.Default);
            return hashResult;
        }

        public bool Invalid { get; }

        public uint Row { get; }
        public uint Col { get; }
        private double[] arr;
    }
}
