using System;
using NumNet;

namespace PerceptronTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SigmoidNetworkExample();
            SoftmaxExample();
        }

        private static void SoftmaxExample()
        {
            var matA = new NMatrix(1, 3,
                new double[] { 0.3, 2.9, 4.0 });
            Console.WriteLine($"A: {matA.ToString()}");

            var matResult = NMath.Softmax(matA);
            Console.WriteLine($"Softmax(A): {matResult.ToString()}");
        }

        private static void SigmoidNetworkExample()
        {
            var X = new NMatrix(1, 2,
                new double[] { 1.0, 0.5 });

            SigmoidNetwork(ref X);
        }

        private static NMatrix SigmoidNetwork(ref NMatrix X)
        {
            var W1 = new NMatrix(2, 3,
                            new double[]
                            {
                    0.1, 0.3, 0.5,
                    0.2, 0.4, 0.6
                            });
            var B1 = new NMatrix(1, 3,
                new double[] { 0.1, 0.2, 0.3 });
            var A1 = X.Dot(W1).Add(B1);
            Console.WriteLine($"A1: {A1.ToString()}");

            var Z1 = A1.Map(
                (elem) => { return NMath.Sigmoid(elem); });
            Console.WriteLine($"Z1: {Z1.ToString()}");

            var W2 = new NMatrix(3, 2,
                new double[]
                {
                    0.1, 0.4,
                    0.2, 0.5,
                    0.3, 0.6
                });
            var B2 = new NMatrix(1, 2,
                new double[] { 0.1, 0.2 });

            var A2 = Z1.Dot(W2).Add(B2);
            Console.WriteLine($"A2: {A2.ToString()}");
            var Z2 = A2.Map(
                (elem) => { return NMath.Sigmoid(elem); });
            Console.WriteLine($"Z2: {Z2.ToString()}");

            var W3 = new NMatrix(2, 2,
                new double[]
                {
                    0.1, 0.3,
                    0.2, 0.4
                });
            var B3 = new NMatrix(1, 2,
                new double[] { 0.1, 0.2 });

            var A3 = Z2.Dot(W3).Add(B3);
            Console.WriteLine($"Y(=A3): {A3.ToString()}");
            return A3;
        }
    }
}
