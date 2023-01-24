using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace UnitTests
{
    public class Converter : TextWriter
    {
        ITestOutputHelper _output;
        public Converter(ITestOutputHelper output)
        {
            _output = output;
        }
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
        public override void WriteLine(string? message)
        {
            _output.WriteLine(message);
        }
        public override void WriteLine(string? format, params object?[] args)
        {
            _output.WriteLine(format, args);
        }

        public override void Write(char value)
        {
            _output.WriteLine(value.ToString());
        }
    }
}
