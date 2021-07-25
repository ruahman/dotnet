using System.IO;
using Xunit;
using Xunit.Abstractions;
using System;
using Dog2Bone.Engine;


namespace Dog2Bone.Test
{
    using Dog2Bone.Loader;

    public class LoaderTest
    {
        private readonly ITestOutputHelper _testOut;

        public LoaderTest(ITestOutputHelper testOutputHelper)
        {
            _testOut = testOutputHelper;

        }

        [Fact]
        public void ReadInInitializeInputForDogToBone()
        {
            Loader.Logger = _testOut;

            var initializePath = Path.GetRelativePath(
                Directory.GetCurrentDirectory(),
                @"fixtures/initialize/initialize0.json");

            var movesPath = Path.GetRelativePath(
                Directory.GetCurrentDirectory(),
                @"fixtures/moves/moves0.csv");


            var gameEngine = Loader.LoadDogToBone(initializePath, movesPath);

            Assert.NotNull(gameEngine);

            Assert.Equal(5, gameEngine.Board.Item1);
            Assert.Equal(4, gameEngine.Board.Item2);

            Assert.Equal(0, gameEngine.Dog.Position.X);
            Assert.Equal(2, gameEngine.Dog.Position.Y);
            Assert.Equal(Moves.North, gameEngine.Dog.Direction);

            Assert.Equal(4, gameEngine.Bone.Item1);
            Assert.Equal(1, gameEngine.Bone.Item2);

            Assert.Equal(3, gameEngine.Cats.Count);

            Assert.Equal(9, gameEngine.Moves.Count);

        }

        [Theory]
        [InlineData("initialize-success", null)]
        [InlineData("initialize-dogoutofbounds", typeof(DogOutOfBounds))]
        [InlineData("initialize-dogwakecat", typeof(DogWakeCat))]
        [InlineData("initialize-dogfoundbone", typeof(DogFoundBone))]
        [InlineData("initialize-catoutofbounds", typeof(CatOutOfBounds))]
        [InlineData("initialize-catfoundbone", typeof(CatFoundBone))]
        [InlineData("initialize-boneoutofbounds", typeof(BoneOutOfBounds))]
        public void TestForSuccess(string initFile, Type exceptionType)
        {
            var initializePath = Path.GetRelativePath(
                Directory.GetCurrentDirectory(),
                @$"fixtures/initialize/{initFile}.json");

            var movesPath = Path.GetRelativePath(
                Directory.GetCurrentDirectory(),
                @"fixtures/moves/moves0.csv");

            if (exceptionType == null)
            {
                var gameEngine = Loader.LoadDogToBone(initializePath, movesPath);
                Assert.NotNull(gameEngine);
            }
            else
            {
                GameEngine gameEngine = null;
                var ex = Assert.ThrowsAny<GameEngineException>(() =>
                {
                    gameEngine = Loader.LoadDogToBone(initializePath, movesPath);
                });

                Assert.Equal(ex.GetType(), exceptionType);

                Assert.Null(gameEngine);
            }
        }
    }
}
