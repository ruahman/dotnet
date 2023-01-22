using System.Text;

namespace CSharpTut
{
    public class StringBuilderTut
    {
        public static void TestStringBuilder()
        {
            // when you append it doesnt create a new string object,
            // save memory if you plan on doing a lot of appending.
            StringBuilder sb = new StringBuilder();
            sb.Append("Hello ");
            sb.AppendLine("World!");
            sb.AppendLine("Hello C#");
        }
    }
}
