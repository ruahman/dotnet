
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

    public class Interface
    {
        public static ITalk Interfaces()
        {
            ITalk talk = new TalkingPerson();
            return talk;
        }
    }
}
