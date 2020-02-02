using System;
using Xunit;
using NumNet;

namespace NumNetTest
{
    public class NMathTest
    {
        [Fact]
        [Fact]
        public void NeuralFunctionTest()
        {
            PerceptronTest();
        }

        private void PerceptronTest()
        {
            var resultAND = NMath.Perceptron(
                0.5, 0.5, 0.6, 1, 1);
            Assert.Equal(1, resultAND);
        }

        [Fact]
        public void LogicGateTest()
        {
            ANDTest();
            ORTest();
            NANDTest();
            XORTest();
        }

        private static void ANDTest()
        {
            Assert.Equal(0, NMath.AND(0, 0));
            Assert.Equal(0, NMath.AND(0, 1));
            Assert.Equal(0, NMath.AND(0, 1));
            Assert.Equal(1, NMath.AND(1, 1));
        }

        private static void ORTest()
        {
            Assert.Equal(0, NMath.OR(0, 0));
            Assert.Equal(1, NMath.OR(0, 1));
            Assert.Equal(1, NMath.OR(0, 1));
            Assert.Equal(1, NMath.OR(1, 1));
        }

        private static void NANDTest()
        {
            Assert.Equal(1, NMath.NAND(0, 0));
            Assert.Equal(1, NMath.NAND(0, 1));
            Assert.Equal(1, NMath.NAND(0, 1));
            Assert.Equal(0, NMath.NAND(1, 1));
        }

        private static void XORTest()
        {
            Assert.Equal(0, NMath.XOR(0, 0));
            Assert.Equal(1, NMath.XOR(0, 1));
            Assert.Equal(1, NMath.XOR(0, 1));
            Assert.Equal(0, NMath.XOR(1, 1));
        }
    }
}
