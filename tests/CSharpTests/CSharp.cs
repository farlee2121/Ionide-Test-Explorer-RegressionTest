namespace CSharpTests
{
    public class UnitTest1
    {
        
        [Fact]
        public void Test2()
        {

        }

        [Fact]
        public void IShouldFail()
        {
            Assert.True(false);
        }

        public class Nested {
            [Fact]
            public void Test1()
            {

            }
            [Fact]
            public void Test2()
            {

            }   
        }
    }
}