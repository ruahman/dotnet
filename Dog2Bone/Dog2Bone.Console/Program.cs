

namespace Dog2Bone.Console
{
    using System;
    using Dog2Bone;
    using Dog2Bone.Loader;
    using Dog2Bone.Engine;

    class Program
    {
        static Results RunDog2Bone(string initializationFile, string movesFile)
        {
            Results result = Results.StillLooking;

            try
            {
                var game = Loader.LoadDogToBone(initializationFile, movesFile);

                result = game.Run();

                switch (result)
                {
                    case Results.Success:
                        Console.WriteLine("Success, you found the bone.");
                        Console.WriteLine("Press any key to exit.");
                        break;
                    case Results.OutOfBounds:
                        Console.WriteLine("Sorry, but you went out of bounds");
                        break;
                    case Results.CatAwake:
                        Console.WriteLine("You woke up a cat!!!");
                        break;
                    case Results.StillLooking:
                        Console.WriteLine("You didn't find the bone.");
                        break;
                }

                if (result != Results.Success)
                {
                    Console.WriteLine("Try modifying the moves.csv file.");
                    Console.WriteLine("Type Y to continue or N to exit.");
                }

                return result;
            }
            catch (GameEngineException ex)
            {
                Console.WriteLine("Problem with one of your files.");

                if (ex.GetType() == typeof(DogOutOfBounds))
                {
                    Console.WriteLine("The Dog was out of bounds.");
                }
                else if (ex.GetType() == typeof(DogWakeCat))
                {
                    Console.WriteLine("The Dog already woke the cat.");
                }
                else if (ex.GetType() == typeof(DogFoundBone))
                {
                    Console.WriteLine("The Dog already found the bone.");
                }
                else if (ex.GetType() == typeof(CatOutOfBounds))
                {
                    Console.WriteLine("One of the cats were out of bounds.");
                }
                else if (ex.GetType() == typeof(CatFoundBone))
                {
                    Console.WriteLine("One of the cats found the bone???");
                }
                else if (ex.GetType() == typeof(BoneOutOfBounds))
                {
                    Console.WriteLine("The bone was out of bounds.");
                }
                else if (ex.GetType() == typeof(InvalidMove))
                {
                    Console.WriteLine("You passed in an invalid move.");
                    Console.WriteLine("Try fixing your moves.csv file.");
                }

                if (ex.GetType() != typeof(InvalidMove))
                {
                    Console.WriteLine("Try fixing your initialization.json file.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("There was a problem with loading Dog2Bone.");
            }

            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Dog2Bone:");

            char conn;

            do
            {
                var res = RunDog2Bone(args[0], args[1]);

                if (res == Results.Success)
                {
                    Console.ReadKey();
                    break;
                }

                conn = (char)Console.ReadKey().Key;
            }
            while (Char.ToUpper(conn) == 'Y');
        }
    }
}
