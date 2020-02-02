using System;
using Xunit;
using NumNet;

namespace NumNetTest
{
    public class NMathTest
    {
        [Fact]
        public void ActivationFunctionTest()
        {
            SigmoidTest();
        }

        private void SigmoidTest()
        {
            Assert.True(Equals(0.047425873177566781, NMath.Sigmoid(-3)));
        }

        [Fact]
        public void SignalFunctionTest()
        {
            UnitStepTest();
            SignumTest();
            RampTest();
        }

        private void UnitStepTest()
        {
            Assert.Equal(0, NMath.UnitStep(double.MinValue));
            Assert.Equal(0, NMath.UnitStep(0));
            Assert.Equal(1, NMath.UnitStep(1));
            Assert.Equal(1, NMath.UnitStep(double.MaxValue));
        }

        private void SignumTest()
        {
            Assert.Equal(-1, NMath.Signum(double.MinValue));
            Assert.Equal(-1, NMath.Signum(-1));
            Assert.Equal(0,  NMath.Signum(0));
            Assert.Equal(1,  NMath.Signum(1));
            Assert.Equal(1,  NMath.Signum(double.MaxValue));
        }

        private void RampTest()
        {
            Assert.Equal(0, NMath.Ramp(double.MinValue));
            Assert.Equal(0, NMath.Ramp(0));
            Assert.Equal(1, NMath.Ramp(1));
            Assert.Equal(double.MaxValue, NMath.Ramp(double.MaxValue));
        }

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
