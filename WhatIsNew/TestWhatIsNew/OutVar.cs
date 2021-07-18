using System;
using Xunit;
using Xunit.Abstractions;

namespace TestWhatIsNew
{
    public class OutVar
    {
        private readonly ITestOutputHelper output;

        public OutVar(ITestOutputHelper output) => this.output = output;
        

        [Fact]
        public void Test1()
        {
            DateTime dt;

            DateTime.TryParse("2/22/1981", out dt);

            output.WriteLine(dt.ToString());

            DateTime.TryParse("2/10/1984", out DateTime dt2);

            output.WriteLine(dt2.Hour.ToString());

            // no need to declar type, kinda redundant
            DateTime.TryParse("2/10/1984", out var dt3);

            output.WriteLine(dt3.ToString());
        }
    }
}
