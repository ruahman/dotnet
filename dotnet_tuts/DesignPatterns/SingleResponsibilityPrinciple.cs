using System.Runtime.InteropServices;

namespace DesignPatterns
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;
        
        public int AddEntry(string text)
        {
            entries.Add($"{count++}:{text}");
            return count;
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }

    // every class should only have a single reason for change
    public class SingleResponsibilityPrinciple
    {
        public static Journal GetJournal()
        {
            var j = new Journal();

            j.AddEntry("I cried today");
            j.AddEntry("I laughed today");

            Console.WriteLine(j.ToString());


            return j;
        }
    }
}