using Xunit;
using DataStructuresAndAlgorithms.SingleLinkList;
using Xunit.Abstractions;
using System;
using System.IO;
using Moq;
using DataStructuresAndAlgorithms;

namespace UnitTests
{
    class ConsoleOutputHelper : IOutput
    {
        private readonly ITestOutputHelper _testOut;

        public ConsoleOutputHelper(ITestOutputHelper testOut)
        {
            _testOut = testOut;
        }


        public void WriteLine(string s)
        {
            _testOut.WriteLine(s);
        }

        public string ReadLine()
        {
            throw new NotImplementedException();
        }
    }

    class EmptyConsole : IOutput
    {

        public void WriteLine(string s)
        {
            throw new NotImplementedException();
        }

        public string ReadLine()
        {
            throw new NotImplementedException();
        }
    }

    public class SingleLinkListTests
    {
        private readonly ITestOutputHelper _testOut;

        public SingleLinkListTests(ITestOutputHelper testOut)
        {
            _testOut = testOut;
        }

        [Fact]
        public void DisplayListTest()
        {
            var mockConsoleIO = new Mock<IOutput>();
            SingleLinkList list = new(mockConsoleIO.Object);

            //var output = new StringWriter();
            //Console.SetOut(output);

            list.DisplayList();


            mockConsoleIO.Verify(t => t.WriteLine("List is empty"), Times.Once());

            //_testOut.WriteLine(output.ToString());
        }

        [Fact]
        public void InsertAtBeginning()
        {
            var mockConsoleIO = new Mock<IOutput>(MockBehavior.Strict);
            var sequence = new MockSequence();

            mockConsoleIO.InSequence(sequence).Setup(x => x.WriteLine("33 "));
            mockConsoleIO.InSequence(sequence).Setup(x => x.WriteLine("11 "));
            mockConsoleIO.InSequence(sequence).Setup(x => x.WriteLine("23 "));

            SingleLinkList list = new(mockConsoleIO.Object);

            list.InsertInBeginning(23);
            list.InsertInBeginning(11);
            list.InsertInBeginning(33);

            list.DisplayList();



        }

        [Fact]
        public void InsertAtEnd()
        {
            var mockConsoleIO = new Mock<IOutput>(MockBehavior.Strict);
            var sequence = new MockSequence();

            mockConsoleIO.InSequence(sequence).Setup(x => x.WriteLine("23 "));
            mockConsoleIO.InSequence(sequence).Setup(x => x.WriteLine("11 "));
            mockConsoleIO.InSequence(sequence).Setup(x => x.WriteLine("33 "));

            SingleLinkList list = new(mockConsoleIO.Object);

            list.InsertAtEnd(23);
            list.InsertAtEnd(11);
            list.InsertAtEnd(33);

            list.DisplayList();



        }

        [Fact]
        public void TestMerge1()
        {

            var outputHelper = new ConsoleOutputHelper(_testOut);
            var mockConsoleIO = new Mock<IOutput>(MockBehavior.Strict);

            var sequence = new MockSequence();

            mockConsoleIO.InSequence(sequence).Setup(x => x.WriteLine("22 "));
            mockConsoleIO.InSequence(sequence).Setup(x => x.WriteLine("23 "));
            mockConsoleIO.InSequence(sequence).Setup(x => x.WriteLine("33 "));
            mockConsoleIO.InSequence(sequence).Setup(x => x.WriteLine("34 "));
            mockConsoleIO.InSequence(sequence).Setup(x => x.WriteLine("44 "));
            mockConsoleIO.InSequence(sequence).Setup(x => x.WriteLine("45 "));

            SingleLinkList list1 = new(mockConsoleIO.Object);

            list1.InsertAtEnd(22);
            list1.InsertAtEnd(33);
            list1.InsertAtEnd(44);



            SingleLinkList list2 = new(new EmptyConsole());

            list2.InsertAtEnd(23);
            list2.InsertAtEnd(34);
            list2.InsertAtEnd(45);


            SingleLinkList merge = list1.Merge1(list2);

            merge.DisplayList();

        }

    }
}
