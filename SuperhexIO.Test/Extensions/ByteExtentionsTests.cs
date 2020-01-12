using SuperhexIO.Extensions;
using Xunit;

namespace SuperhexIO.Test.Extensions
{

    public class ByteExtentionsTests
    {
        [Fact]
        public void TestLittleEndian()
        {
            var bytes = new byte[2];
            bytes[0] = 1;
            bytes[1] = 2;

            short expexted = 513;
            short actual = bytes.ToInt16(0, true);
            Assert.Equal(expexted, actual);
        }
    }
}
