
using System;

namespace CSharpTut
{
    public interface ITalk
    {
        void HelloToConsole();
    }

    public class TalkingPerson: ITalk
    {
        public void HelloToConsole()
        {
            Console.WriteLine("Hello From Interface");
        }
    }

    public interface IFirstInterface
    {
        void myMethod(); // interface method
    }

    public interface ISecondInterface
    {
        void myOtherMethod(); // interface method
    }

    // Implement multiple interfaces
    public class DemoClass : IFirstInterface, ISecondInterface
    {
        public void myMethod()
        {
            Console.WriteLine("Some text..");
        }
        public void myOtherMethod()
        {
            Console.WriteLine("Some other text...");
        }
    }

    public static class Interface
    {
        public static TalkingPerson SingleIhertance()
        {
            var res = new TalkingPerson();
            return res;
        }

        public static DemoClass MultipleInheritance()
        {
            var res = new DemoClass();
            return res;
        }
    }
}
