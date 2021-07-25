using System.IO;
using Xunit;
using Dog2Bone.Engine;

namespace Dog2Bone.Test
{
    using Dog2Bone.Loader;

    public class GameEngineFixture
    {
        public GameEngine Load(string initFile, string movesFile)
        {
            var initializePath = @$"fixtures/initialize/{initFile}.json";

            var movesPath = @$"fixtures/moves/{movesFile}.csv";

            var gameEngine = Loader.LoadDogToBone(initializePath, movesPath);

            return gameEngine;

        }

    }
    public class GameEngineTest : IClassFixture<GameEngineFixture>
    {
        private readonly GameEngineFixture _fixture;
        public GameEngineTest(GameEngineFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [InlineData("initialize-success", "moves-success", Results.Success)]
        [InlineData("initialize-success", "moves-outofbounds-top", Results.OutOfBounds)]
        [InlineData("initialize-success", "moves-outofbounds-bottom", Results.OutOfBounds)]
        [InlineData("initialize-success", "moves-outofbounds-left", Results.OutOfBounds)]
        [InlineData("initialize-success", "moves-outofbounds-right", Results.OutOfBounds)]
        [InlineData("initialize-success", "moves-cat1", Results.CatAwake)]
        [InlineData("initialize-success", "moves-cat2", Results.CatAwake)]
        [InlineData("initialize-success", "moves-cat3", Results.CatAwake)]
        [InlineData("initialize-success", "moves-stilllooking-top", Results.StillLooking)]
        [InlineData("initialize-success", "moves-stilllooking-bottom", Results.StillLooking)]
        [InlineData("initialize-success", "moves-stilllooking-left", Results.StillLooking)]
        [InlineData("initialize-success", "moves-stilllooking-right", Results.StillLooking)]
        [InlineData("initialize-success", "moves-stilllooking-cat1", Results.StillLooking)]
        [InlineData("initialize-success", "moves-stilllooking-cat2", Results.StillLooking)]
        [InlineData("initialize-success", "moves-stilllooking-cat3", Results.StillLooking)]
        [InlineData("initialize-success", "moves-foundbone", Results.Success)]
        public void Run_Successfuly(string initFile, string movesFile, Results expected)
        {
            var eng = _fixture.Load(initFile, movesFile);
            var res = eng.Run();
            Assert.Equal(expected, res);
        }
    }
}
