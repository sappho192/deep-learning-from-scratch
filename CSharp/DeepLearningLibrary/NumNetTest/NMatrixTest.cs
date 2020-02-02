using Xunit;
using NumNet;
using System;

namespace NumNetTest
{
    public class NMatrixTest
    {
        [Fact]
        public void MatrixCreationTest()
        {
            Assert.True((new NMatrix(0, 1, null)).Invalid);
            Assert.True((new NMatrix(1, 0, null)).Invalid);
            Assert.True((new NMatrix(1, 1, null)).Invalid);
            Assert.False(
                (new NMatrix(1, 1, new double[] { 1.0 })).Invalid);
            var MatA = new NMatrix(2, 3,
                new double[] { 1, 2, 3, 4, 5, 6 });
            Assert.Equal(1, MatA[0]);
            Assert.Equal(2, MatA[1]);
            Assert.Equal(3, MatA[2]);
            Assert.Equal(4, MatA[3]);
            Assert.Equal(5, MatA[4]);
            Assert.Equal(6, MatA[5]);
            Assert.Equal(1, MatA[0,0]);
            Assert.Equal(2, MatA[0,1]);
            Assert.Equal(3, MatA[0,2]);
            Assert.Equal(4, MatA[1,0]);
            Assert.Equal(5, MatA[1,1]);
            Assert.Equal(6, MatA[1,2]);
            var MatB = new NMatrix(2, 3,
                new double[] { 1, 2, 3, 4, 5, 6 });
            Assert.True(MatA.Equals(MatB));
        }

        [Fact]
        public void MatrixOperatorTest()
        {
            var MatA = new NMatrix(2, 3,
                new double[] { 1, 2, 3, 4, 5, 6 });
            var MatB = new NMatrix(2, 3,
                new double[] { 6, 5, 4, 3, 2, 1 });
            var MatC = new NMatrix(3, 2,
                new double[] { 6, 5, 4, 3, 2, 1 });

            MapTest(MatA);
            AddTest(MatA, MatB, MatC);
            SubTest(MatA, MatB, MatC);
            DotTest(MatA, MatB, MatC);
            MultTest();
            DivTest();
        }

        private void MapTest(NMatrix matA)
        {
            var MatMap = matA.Map((elem) => { return elem * 0.5; });
            Assert.False(MatMap.Invalid);
        }

        private void AddTest(NMatrix MatA, NMatrix MatB, NMatrix MatC)
        {
            var MatSum1 = MatA.Add(MatB);
            Assert.False(MatSum1.Invalid);
            var MatSum2 = MatA.Add(MatC);
            Assert.True(MatSum2.Invalid);
        }

        private void SubTest(NMatrix MatA, NMatrix MatB, NMatrix MatC)
        {
            var MatSum1 = MatA.Sub(MatB);
            Assert.False(MatSum1.Invalid);
            var MatSum2 = MatA.Sub(MatC);
            Assert.True(MatSum2.Invalid);
        }

        private void DotTest(NMatrix MatA, NMatrix MatB, NMatrix MatC)
        {
            var MatDot1 = MatA.Dot(MatB);
            Assert.True(MatDot1.Invalid);

            /*
             * 1 2 3     6 5 
             * 4 5 6  .  4 3
             *           2 1
             */
            var MatDot2 = MatA.Dot(MatC);
            Assert.False(MatDot2.Invalid);
        }

        private void MultTest()
        {
            var MatA = new NMatrix(2, 3,
                new double[]
                {
                    1,2,3,4,5,6
                });
            var MatMult = MatA.Mult(-0.5);
            var MatAnswer = new NMatrix(MatA.Row, MatA.Col,
                new double[] {
                    -0.5, -1, -1.5,
                    -2, -2.5, -3
                });

            Assert.True(MatAnswer.Equals(MatMult));
        }

        private void DivTest()
        {
            var MatA = new NMatrix(2, 3,
                new double[]
                {
                    1,2,3,4,5,6
                });
            var MatDiv = MatA.Div(-2);
            var MatAnswer = new NMatrix(MatA.Row, MatA.Col,
                new double[] {
                    -0.5, -1, -1.5,
                    -2, -2.5, -3
                });

            Assert.True(MatAnswer.Equals(MatDiv));
        }
    }
}
