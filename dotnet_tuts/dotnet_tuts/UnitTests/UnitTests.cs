using CSharpTut;
using Moq;
using System.Reflection;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace UnitTests
{
    // so that we dont recreate Calc for each test
    public class CalculatorFixture
    {
        public Calculator Calc => new();
    }

    public static class TestData
    {
        public static IEnumerable<object[]> Data
        {
            get
            {
                yield return new object[] { 1, 2, 3 };
                yield return new object[] { 2, 2, 4 };
                yield return new object[] { 3, 2, 5 };
            }
        }

    }

    public class TestDataAttribute : DataAttribute
    {

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 1, 2, 3 };
            yield return new object[] { 2, 2, 4 };
            yield return new object[] { 3, 2, 5 };
        }
    }

    public class UnitTests : IClassFixture<CalculatorFixture>
    {
        private readonly ITestOutputHelper output;
        private readonly CalculatorFixture _fixture;

        public UnitTests(ITestOutputHelper output, CalculatorFixture fixture)
        {
            this.output = output;
            _fixture = fixture;

            // console now outputs to xUnit
            var converter = new Converter(output);
            Console.SetOut(converter);
        }

        [Fact]
        [Trait("Category", "HelloWorld")]
        public void HelloWorld_GivenNothing_ReturnString()
        {
            var res = HelloWorld.Hello();
            Assert.Equal("Hello World", res);
            output.WriteLine("Hello from xUnit");
        }

        [Fact]
        [Trait("Category", "Goodbye")]
        public void Goodbye_GivenNothing_ReturnString()
        {
            var res = HelloWorld.Goodbye();
            Assert.Equal("Goodbye", res);
            output.WriteLine("test goodbye");
        }

        [Fact]
        [Trait("Category", "Calculator")]
        public void Add_GivenOneAndTwo_ReturnThree()
        {
            var res = _fixture.Calc.Add(1, 2);
            Assert.Equal(3, res);
        }


        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(2, 2, 4)]
        [InlineData(2, 3, 5)]
        [Trait("Category", "Calculator")]
        public void Add_GivenTwoNumbers_ReturnNumber(int a, int b, int res)
        {
            int result = _fixture.Calc.Add(a, b);
            Assert.Equal(res, result);
        }

        [Theory]
        [MemberData(nameof(TestData.Data), MemberType = typeof(TestData))]
        [Trait("Category", "Calculator")]
        public void AddData_GivenTwoNumbers_ReturnNumber(int x, int y, int answer)
        {
            int result = _fixture.Calc.Add(x, y);
            Assert.Equal(answer, result);
        }

        [Theory]
        [TestDataAttribute]
        [Trait("Category", "Calculator")]
        public void AddDataAttribute_GivenTwoNumbers_ReturnNumber(int x, int y, int answer)
        {
            int result = _fixture.Calc.Add(x, y);
            Assert.Equal(answer, result);
        }

        [Fact]
        [Trait("Category", "Calculator")]
        public void AddMock()
        {
            Mock<Calculator> mock = new Mock<Calculator>();
            mock.Setup(x => x.Add(1, 2)).Returns(3);

            var res = mock.Object.Add(1, 2);
            Assert.Equal(3, res);
            mock.Object.Add(1, 2);
            mock.Object.Add(1, 2);

            mock.Verify(x => x.Add(It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(3));

            var mock2 = Mock.Of<Calculator>();
            Mock.Get(mock2).Setup(x => x.Add(It.IsAny<int>(), It.IsAny<int>())).Returns(4);
            var res2 = mock2.Add(1, 2);
            Assert.Equal(4, res2);

            var res3 = mock2.Add(3, 3);
            Assert.Equal(4, res3);

            var res4 = mock2.Add(4, 4);
            Assert.Equal(4, res4);

            var res5 = mock2.Add(5, 5);
            Assert.Equal(4, res5);

            Mock.Get(mock2).Verify(x => x.Add(It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(4));
        }


    }
}