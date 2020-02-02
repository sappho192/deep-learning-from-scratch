using System;
using System.Linq;

namespace NumNet
{
    public static class NMath
    {
        public static double UnitStep(double x)
        {
            return x > 0 ? 1 : 0;
        }

        public static double Signum(double x)
        {
            if (x > 0)  return 1;
            if (x == 0) return 0;
            return -1;
        }

        public static double Ramp(double x)
        {
            return x > 0 ? x : 0;
        }

        public static double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        public static double[] Softmax(double[] matrix)
        {
            var maxElem = matrix.Max();
            var expMatrix = new double[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                expMatrix[i] = Math.Exp(matrix[i] - maxElem);
            }

            double expSum = expMatrix.Sum();

            var resultMatrix = new double[matrix.Length];
            for (uint i = 0; i < resultMatrix.Length; i++)
            {
                resultMatrix[i] = expMatrix[i] / expSum;
            }
            return resultMatrix;
        }

        public static NMatrix Softmax(NMatrix matrix)
        {
            var maxElem = matrix.Max();
            var expMatrix = matrix.Map(
                (elem) => { return Math.Exp(elem - maxElem); });

            double expSum = 0;
            for (uint i = 0; i < expMatrix.Row * expMatrix.Col; i++)
            {
                expSum += expMatrix[i];
            }

            var resultMatrix = new NMatrix(expMatrix);
            for (uint i = 0; i < resultMatrix.Row * resultMatrix.Col; i++)
            {
                resultMatrix[i] = expMatrix[i] / expSum;
            }
            return resultMatrix;
        }

        public static double Perceptron(
            double w1, double w2, double theta,
            double x1, double x2)
        {
            //return 22; // for unit test
            return w1 * x1 + w2 * x2 - theta <= 0 ? 0 : 1;
        }

        public static double AND(double x1, double x2)
        {
            return Perceptron(0.5, 0.5, 0.6, x1, x2);
        }

        public static double OR(double x1, double x2)
        {
            return Perceptron(0.5, 0.5, 0.4, x1, x2);
        }

        public static double NAND(double x1, double x2)
        {
            return Perceptron(-0.5, -0.5, -0.6, x1, x2);
        }

        public static double XOR(double x1, double x2)
        {
            return AND(OR(x1, x2), NAND(x1, x2));
        }
    }
}
