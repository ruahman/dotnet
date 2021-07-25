using System;
using Newtonsoft.Json;
using System.IO;
using Dog2Bone.Engine;

namespace Dog2Bone.Loader
{

    using Dog2Bone.Dog;


    public static class Loader
    {
        public static dynamic Logger;

        public static GameEngine LoadDogToBone(string initializePath, string movesPath)
        {
            try
            {
                GameEngine engine = new();

                using (StreamReader initReader = new(initializePath),
                       movesReader = new(movesPath))
                {
                    //// initialize game engine

                    string initTxt = initReader.ReadToEnd();

                    var dogToBoneJson = JsonConvert.DeserializeObject<Dog2BoneJson>(initTxt);

                    engine.Board = (dogToBoneJson.Board[0], dogToBoneJson.Board[1]);

                    engine.Dog = new Dog(
                        Convert.ToInt32(dogToBoneJson.Start[0]),
                        Convert.ToInt32(dogToBoneJson.Start[1]),
                        (Moves)Enum.Parse(typeof(Moves), (string)dogToBoneJson.Start[2]));

                    engine.Bone = (dogToBoneJson.Bone[0], dogToBoneJson.Bone[1]);

                    foreach (var cat in dogToBoneJson.Cats)
                    {
                        engine.Cats.Add((cat[0], cat[1]));
                    }

                    //// validate game engine

                    engine.IsValid();

                    //// load moves and validate

                    string movesTxt = movesReader.ReadToEnd();

                    var moves = movesTxt.Split(',');

                    try
                    {
                        foreach (string move in moves)
                        {
                            engine.Moves.Add((Moves)Enum.Parse(typeof(Moves), move));
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        throw new InvalidMove(ex);
                    }

                }

                return engine;

            }
            catch (Exception ex)
            {
                Logger?.WriteLine(ex.Message);
                throw;
            }

        }

    }
}
