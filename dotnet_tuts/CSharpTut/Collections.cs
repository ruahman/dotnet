

namespace CSharpTut
{
    public class Collections
    {
        public static (List<int>,List<int>,bool) Lists()
        {
            List<int> grades = new List<int>();
            grades.Add(5);
            grades.Add(4);
            grades.Add(3);
            grades.Add(2);
            grades.Add(1);

            List<int> grades2 = new List<int>() { 1, 2, 3, 5, 8, 13 };

            var found = grades2.Contains(13);

            return (grades, grades2, found);
        }
    }
}
