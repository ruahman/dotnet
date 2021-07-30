using System.IO;
using Xunit;
using Xunit.Abstractions;
using System;
using Dog2Bone.Engine;
using Microsoft.Extensions.Logging;


namespace Dog2Bone.Test
{
    using Dog2Bone.Loader;
    using Moq;

    public class LoaderTest
    {
        private readonly ITestOutputHelper _testOut;

        private readonly Mock<ILogger<Loader>> _logger;


        public LoaderTest(ITestOutputHelper testOutputHelper)
        {
            _testOut = testOutputHelper;

            _logger = new Mock<ILogger<Loader>>();

            _logger.Setup(x => x.Log(
                It.IsAny<LogLevel>(),
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception>(),
                (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()))
                .Callback(new InvocationAction(invocation =>
                {
                    var logLevel = (LogLevel)invocation.Arguments[0];
                    var eventId = (EventId)invocation.Arguments[1];
                    var state = invocation.Arguments[2];
                    var exception = (Exception?)invocation.Arguments[3];
                    var formatter = invocation.Arguments[4];

                    var invokeMethod = formatter.GetType().GetMethod("Invoke");
                    var logMessage = (string)invokeMethod?.Invoke(formatter, new[] { state, exception });

                    _testOut.WriteLine(logMessage);
                }));

        }

        [Fact]
        public void Loader_GivenInitAndMovesFiles_ReturnsGameEngine()
        {


            var loader = new LoderJson(_logger.Object);

            var gameEngine = loader.Load(
                @"fixtures/initialize/initialize0.json",
                @"fixtures/moves/moves0.csv");

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
        public void Loader_GivenInitFile_ThrowsExeption_IfInitFileIsInvalid(string initFile, Type exceptionType)
        {
            var initializePath = @$"fixtures/initialize/{initFile}.json";

            var movesPath = @"fixtures/moves/moves0.csv";

            var loader = new LoderJson(_logger.Object);


            if (exceptionType == null)
            {
                var gameEngine = loader.Load(initializePath, movesPath);
                Assert.NotNull(gameEngine);
            }
            else
            {
                GameEngine gameEngine = null;
                var ex = Assert.ThrowsAny<GameEngineException>(() =>
                {
                    gameEngine = loader.Load(initializePath, movesPath);
                });

                Assert.Equal(ex.GetType(), exceptionType);

                Assert.Null(gameEngine);
            }
        }

        [Fact]
        public void Loader_GivenAnInvalidMovesFile_ThrowsInvalidMove()
        {
            GameEngine gameEngine = null;
            var loader = new LoderJson(_logger.Object);

            var ex = Assert.Throws<InvalidMove>(() =>
            {
                gameEngine = loader.Load(
                    @"fixtures/initialize/initialize0.json",
                    @"fixtures/moves/moves-invalid.csv");
            });


            Assert.Null(gameEngine);
        }

        [Fact]
        public void Loader_GivenYAMLInitFile_ReturnGameEngine()
        {
            GameEngine gameEngine;
            var loader = new LoaderYaml(_logger.Object);

            gameEngine = loader.Load(
                     @"fixtures/initialize/initialize.yaml",
                     @"fixtures/moves/moves-success.csv");
        }
    }
}
