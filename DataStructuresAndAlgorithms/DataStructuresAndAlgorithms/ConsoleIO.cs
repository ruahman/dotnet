using System;

namespace DataStructuresAndAlgorithms
{
    public interface IOutput
    {
        void WriteLine(string s);
        string ReadLine();
    }
    public class ConsoleIO : IOutput
    {
        public void WriteLine(string s)
        {
            Console.WriteLine(s);
        }
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }


}
