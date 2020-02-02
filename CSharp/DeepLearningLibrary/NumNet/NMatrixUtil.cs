using System;
using System.Collections.Generic;
using System.Text;

namespace NumNet
{
    public static class NMatrixUtil
    {
        public static NMatrix Add(this NMatrix A, NMatrix B)
        {
            if (A.Row != B.Row || A.Col != B.Col) return NMatrix.Empty;
            uint length = A.Row * A.Col;
            double[] array = new double[length];
            for (uint i = 0; i < length; i++)
            {
                array[i] = A[i] + B[i];
            }
            NMatrix matrix = new NMatrix(A.Row, A.Col, array);
            return matrix;
        }

        public static NMatrix Sub(this NMatrix A, NMatrix B)
        {
            if (A.Row != B.Row || A.Col != B.Col) return NMatrix.Empty;
            uint length = A.Row * A.Col;
            double[] array = new double[length];
            for (uint i = 0; i < length; i++)
            {
                array[i] = A[i] - B[i];
            }
            NMatrix matrix = new NMatrix(A.Row, A.Col, array);
            return matrix;
        }

        public static NMatrix Mult(this NMatrix A, double value)
        {
            double[] array = new double[A.Row * A.Col];
            for (uint i = 0; i < array.Length; i++)
            {
                array[i] = A[i] * value;
            }
            return new NMatrix(A.Row, A.Col, array);
        }

        public static NMatrix Div(this NMatrix A, double value)
        {
            if (value == 0)
            {
                return NMatrix.Empty;
            }

            double[] array = new double[A.Row * A.Col];
            for (uint i = 0; i < array.Length; i++)
            {
                array[i] = A[i] / value;
            }
            return new NMatrix(A.Row, A.Col, array);
        }

        public static NMatrix Dot(this NMatrix A, NMatrix B)
        {
            /*
             * a b c .  0 1 2
             * d e f    3 4 5
             *          6 7 8
             * 
             * => [a0+b3+c6, a1+b4+c7, a2+b5+c8,
             *     d0+e3+f6, d1+e4+f7, d2+e5+f8]
             */
            if (A.Col != B.Row) return NMatrix.Empty;
            uint length = A.Row * B.Col;
            double[] array = new double[length];
            uint arrIdx = 0;

            for (uint i = 0; i < A.Row; i++)
            {
                for (uint k = 0; k < B.Col; k++)
                {
                    for (uint j = 0; j < A.Col; j++)
                    {
                        array[arrIdx] += A[i, j] * B[j, k];
                    }
                    arrIdx++;
                }
            }
            var result = new NMatrix(A.Row, B.Col, array);
            return result;
        }

        public static NMatrix I(uint size)
        {// TODO: Should be optimized
            if (size == 0) return NMatrix.Empty;
            double[] array = new double[size * size];
            for (int i = 0; i < size * size; i++)
            {
                /*
                 * 1 0
                 * 0 1
                 * 0, 3 (2*2)
                 * 
                 * 1 0 0
                 * 0 1 0
                 * 0 0 1
                 * 0, 4, 8 (3*3)
                 * 
                 * 1 0 0 0
                 * 0 1 0 0
                 * 0 0 1 0
                 * 0 0 0 1
                 * 0, 5, 10, 15 (4*4)
                 * 
                 * => (idx % (size+1) == 0)
                 */
                if ((array[i] % (size + 1)) == 0)
                {
                    array[i] = 1;
                }
                else
                {
                    array[i] = 0;
                }
            }
            var matrix = new NMatrix(size, size, array);
            return matrix;
        }
    }
}
