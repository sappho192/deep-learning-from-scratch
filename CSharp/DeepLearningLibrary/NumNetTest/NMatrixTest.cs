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
    }
}
