using Xunit;
using NumNet;

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

            AddTest(MatA, MatB, MatC);
            DotTest(MatA, MatB, MatC);
        }

        private void AddTest(NMatrix MatA, NMatrix MatB, NMatrix MatC)
        {
            var MatSum1 = MatA.Add(MatB);
            Assert.False(MatSum1.Invalid);
            var MatSum2 = MatA.Add(MatC);
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
    }
}
