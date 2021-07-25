

namespace Dog2Bone.Console
{
    using System;
    using Dog2Bone;
    using Dog2Bone.Loader;
    using Dog2Bone.Engine;

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var game = Loader.LoadDogToBone(args[0], args[1]);

                var res = game.Run();

                switch (res)
                {
                    case Results.Success:
                        Console.WriteLine("Success");
                        break;
                    case Results.OutOfBounds:
                        Console.WriteLine("Sorry but your out of bounds");
                        break;
                    case Results.CatAwake:
                        Console.WriteLine("You woke up a cat");
                        break;
                    case Results.StillLooking:
                        Console.WriteLine("You didn't find the bone");
                        break;
                }
            }
            catch (GameEngineException)
            {
                Console.WriteLine("Problem with your initialization file");
            }



            Console.ReadKey();
        }
    }
}
