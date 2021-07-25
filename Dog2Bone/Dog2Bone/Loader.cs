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
                    var dataInit = JsonConvert.DeserializeObject<dynamic>(initTxt);


                    engine.Board = (dataInit.board[0].ToObject<int>(), dataInit.board[1].ToObject<int>());

                    engine.Dog = new Dog(
                        dataInit.start[0].ToObject<int>(),
                        dataInit.start[1].ToObject<int>(),
                        Enum.Parse(typeof(Moves), dataInit.start[2].ToString()));

                    engine.Bone = (dataInit.bone[0].ToObject<int>(), dataInit.bone[1].ToObject<int>());

                    foreach (var cat in dataInit.cats)
                    {
                        engine.Cats.Add((cat[0].ToObject<int>(), cat[1].ToObject<int>()));
                    }

                    //// validate game engine
                    engine.IsValid();


                    //// load moves
                    string movesTxt = movesReader.ReadToEnd();
                    var moves = movesTxt.Split(',');

                    foreach (string move in moves)
                    {
                        engine.Moves.Add((Moves)Enum.Parse(typeof(Moves), move));
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
