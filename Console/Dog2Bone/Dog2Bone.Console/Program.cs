

namespace Dog2Bone.Console
{
    using System;
    using Dog2Bone;
    using Dog2Bone.Loader;
    using System.IO;
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    class Dog2BoneApp
    {
        private readonly ILogger<Dog2BoneApp> _logger;
        private readonly Loader _loader;

        public Dog2BoneApp(Loader loader, ILogger<Dog2BoneApp> logger)
        {
            _loader = loader;
            _logger = logger;
        }

        public Results Dog2BoneRun(string initializationFile, string movesFile)
        {
            Results result = Results.StillLooking;

            try
            {
                string initializationPath = new Uri(
                    Path.Combine(
                        Path.GetDirectoryName(
                            Assembly.GetExecutingAssembly().Location),
                            "../../../" + initializationFile
                            )
                        ).LocalPath;

                string movesPath = new Uri(
                    Path.Combine(
                        Path.GetDirectoryName(
                            Assembly.GetExecutingAssembly().Location),
                            "../../../" + movesFile
                            )
                        ).LocalPath;

                var game = _loader.Load(initializationPath, movesPath);

                result = game.Run();

                switch (result)
                {
                    case Results.Success:
                        _logger.LogInformation("Success, you found the bone.");
                        _logger.LogInformation("Press any key to exit.");
                        break;
                    case Results.OutOfBounds:
                        _logger.LogInformation("Sorry, but you went out of bounds");
                        break;
                    case Results.CatAwake:
                        _logger.LogInformation("You woke up a cat!!!");
                        break;
                    case Results.StillLooking:
                        _logger.LogInformation("You didn't find the bone.");
                        break;
                }

                if (result != Results.Success)
                {
                    _logger.LogInformation("Try modifying the moves.csv file.");
                }

                return result;

            }
            catch (GameEngineException ex)
            {
                _logger.LogInformation("Problem with one of your files.");

                if (ex.GetType() == typeof(DogOutOfBounds))
                {
                    _logger.LogInformation("The Dog was out of bounds.");
                }
                else if (ex.GetType() == typeof(DogWakeCat))
                {
                    _logger.LogInformation("The Dog already woke the cat.");
                }
                else if (ex.GetType() == typeof(DogFoundBone))
                {
                    _logger.LogInformation("The Dog already found the bone.");
                }
                else if (ex.GetType() == typeof(CatOutOfBounds))
                {
                    _logger.LogInformation("One of the cats were out of bounds.");
                }
                else if (ex.GetType() == typeof(CatFoundBone))
                {
                    _logger.LogInformation("One of the cats found the bone???");
                }
                else if (ex.GetType() == typeof(BoneOutOfBounds))
                {
                    _logger.LogInformation("The bone was out of bounds.");
                }
                else if (ex.GetType() == typeof(InvalidMove))
                {
                    _logger.LogInformation("You passed in an invalid move.");
                    _logger.LogInformation("Try fixing your moves.csv file.");
                }

                if (ex.GetType() != typeof(InvalidMove))
                {
                    _logger.LogInformation("Try fixing your initialization.json file.");
                }
            }
            catch (Exception)
            {
                _logger.LogInformation("There was a problem with loading Dog2Bone.");
            }
            finally
            {
                if (result != Results.Success)
                {
                    _logger.LogInformation("Type Y to continue or N to exit.");
                }
            }

            return result;
        }

        public void Run(string init, string moves)
        {
            char input;

            _logger.LogInformation("Welcome to Dog2Bone:");

            do
            {
                var res = Dog2BoneRun(init, moves);

                if (res == Results.Success)
                {
                    Console.ReadKey();
                    break;
                }

                input = (char)Console.ReadKey().Key;
                Console.WriteLine();
            }
            while (Char.ToUpper(input) == 'Y');
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                Dog2BoneApp app = serviceProvider.GetService<Dog2BoneApp>();

                app.Run(args[0], args[1]);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services
                .AddLogging(configure => configure.AddConsole())
                .AddSingleton<Loader, LoderJson>()
                .AddTransient<Dog2BoneApp>();

        }


    }
}
