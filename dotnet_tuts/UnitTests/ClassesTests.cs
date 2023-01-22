using CSharpTut.Classes;


namespace UnitTests
{
    public class ClassesTests
    {
        [Fact]
        [Trait("CSharp","Classes")]
        public void CreateBook()
        {
            var res = Classes.CreateBook();
            Assert.Equal("Dune", res.title);
        }

        [Fact]
        [Trait("CSharp", "Classes")]
        public void HasHonors()
        {
            var res = Classes.HasHonors();
            Assert.True(res);
        }

        [Fact]
        [Trait("CSharp", "Classes")]
        public void GetMovie()
        {
            var res = Classes.GetMovie();
            Assert.Equal("PG",res.Rating);
        }

        [Fact]
        [Trait("CSharp", "Classes")]
        public void GetItalianChef()
        {
            var res = Classes.GetItalianChef();
            Assert.Equal("I cook bacon the italian way", res.CookBacon());
            Assert.Equal("I can do some other things", ((ItalianChef)res).CookPizza());
        }
    }
}
