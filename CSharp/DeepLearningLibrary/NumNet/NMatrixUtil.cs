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
