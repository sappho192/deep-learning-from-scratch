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
                        RawArray = array;
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
            }
            else
            {
                Row = B.Row;
                Col = B.Col;
                RawArray = new double[B.RawArray.Length];
                B.RawArray.CopyTo(RawArray, 0);
            }
        }

        public double this[uint i]
        {
            get { return RawArray[i]; }
            set { RawArray[i] = value; }
        }

        public double this[uint i, uint j]
        {
            get { return RawArray[i * Col + j]; }
            set { RawArray[i * Col + j] = value; }
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
                ((IStructuralEquatable)this.RawArray)
                .GetHashCode(EqualityComparer<double>.Default);
            return hashResult;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
            for (uint i = 0; i < RawArray.Length; i++)
            {
                stringBuilder.Append(RawArray[i]);
                if (i == (RawArray.Length - 1)) break;
                stringBuilder.Append(", ");
                if (i % Col == Col - 1)
                {
                    stringBuilder.Append(Environment.NewLine);
                }
            }
            stringBuilder.Append("]");
            return stringBuilder.ToString();
        }

        public bool Invalid { get; }

        public uint Row { get; }
        public uint Col { get; }
        public double[] RawArray { get; }
    }
}
