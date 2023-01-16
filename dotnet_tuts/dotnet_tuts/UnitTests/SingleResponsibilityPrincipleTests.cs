using DesignPatterns;
using System.Text;
using System;
using Xunit.Abstractions;

namespace UnitTests
{
    
    public class SingleResponsibilityPrincipleTests
    {
       
        public SingleResponsibilityPrincipleTests(ITestOutputHelper output) { 
            // console now outputs to xUnit
            var converter = new Converter(output);
            Console.SetOut(converter);
        }

        [Fact]
        [Trait("DesignPatterns","SingleResponsibility")]
        public void GetJournal()
        {
            var res = SingleResponsibilityPrinciple.GetJournal();
            Console.WriteLine("from xUnit");
        }
    }
}
