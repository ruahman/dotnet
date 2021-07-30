using System;
using Newtonsoft.Json;
using System.IO;
using Dog2Bone.Engine;

namespace Dog2Bone.Loader
{
    using CsvHelper;
    using CsvHelper.Configuration;
    using Dog2Bone.Dog;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json.Serialization;
    using System.Globalization;
    using YamlDotNet.Serialization;
    using YamlDotNet.Serialization.NamingConventions;

    public abstract class Loader
    {
        protected readonly ILogger<Loader> _logger;
        protected GameEngine _engine;

        public Loader(ILogger<Loader> logger)
        {
            _logger = logger;
        }


        public virtual GameEngine Load(string initializePath, string movesPath)
        {
            try
            {
                _engine = new();

                using (StreamReader initReader = new(initializePath),
                       movesReader = new(movesPath))
                {
                    Initialize(initReader.ReadToEnd());
                    Moves(movesReader);
                }

                return _engine;

            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "There was an exception");
                throw;
            }

        }

        public abstract void Initialize(String initStr);

        public virtual void Moves(StreamReader reader)
        {
            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false,
                };

                using (var csv = new CsvReader(reader, config))
                {
                    var records = csv.GetRecords<dynamic>();
                    foreach (var moves in records)
                    {
                        foreach (var move in moves)
                        {
                            _engine.Moves.Add((Moves)Enum.Parse(typeof(Moves), move.Value));
                        }
                    }
                }
            }
            catch (ArgumentException ex)
            {
                throw new InvalidMove(ex);
            }
        }

    }


    public class LoderJson : Loader
    {
        public LoderJson(ILogger<Loader> logger) : base(logger) { }

        public override void Initialize(string initStr)
        {
            var dogToBoneJson = JsonConvert.DeserializeObject<Dog2BoneData>(
                initStr,
                new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    }
                });

            _engine.Board = (dogToBoneJson.Board[0], dogToBoneJson.Board[1]);

            _engine.Dog = new Dog(
                Convert.ToInt32(dogToBoneJson.Start[0]),
                Convert.ToInt32(dogToBoneJson.Start[1]),
                (Moves)Enum.Parse(typeof(Moves), (string)dogToBoneJson.Start[2]));

            _engine.Bone = (dogToBoneJson.Bone[0], dogToBoneJson.Bone[1]);

            foreach (var cat in dogToBoneJson.Cats)
            {
                _engine.Cats.Add((cat[0], cat[1]));
            }

            _engine.IsValid();
        }


    }

    public class LoaderYaml : Loader
    {
        public LoaderYaml(ILogger<Loader> logger) : base(logger) { }

        public override void Initialize(string initStr)
        {
            var yamlDeserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            var dogToBoneYaml = yamlDeserializer.Deserialize<Dog2BoneData>(initStr);

            _engine.Board = (dogToBoneYaml.Board[0], dogToBoneYaml.Board[1]);

            _engine.Dog = new Dog(
                Convert.ToInt32(dogToBoneYaml.Start[0]),
                Convert.ToInt32(dogToBoneYaml.Start[1]),
                (Moves)Enum.Parse(typeof(Moves), (string)dogToBoneYaml.Start[2]));

            _engine.Bone = (dogToBoneYaml.Bone[0], dogToBoneYaml.Bone[1]);

            foreach (var cat in dogToBoneYaml.Cats)
            {
                _engine.Cats.Add((cat[0], cat[1]));
            }

            _engine.IsValid();
        }
    }
}
