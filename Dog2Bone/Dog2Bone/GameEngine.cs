using System;
using System.Collections.Generic;


namespace Dog2Bone.Engine
{
    using Dog2Bone.Dog;

    public class GameEngine
    {
        public (int, int) Board { get; set; }

        public Dog Dog { get; set; }

        public (int, int) Bone { get; set; }

        public List<(int, int)> Cats { get; set; } = new();

        public List<Moves> Moves { get; set; } = new();


        public Results Run()
        {
            Results res = Results.StillLooking;
            foreach (var move in Moves)
            {
                res = Step(move);
                if (res != Results.StillLooking)
                    break;
            }

            return res;
        }

        public Results Step(Moves move)
        {
            Dog.Move(move);

            if (DogOutOfBounds())
            {
                return Results.OutOfBounds;
            }
            else if (DogWakeCat())
            {
                return Results.CatAwake;
            }
            else if (DogFoundBone())
            {
                return Results.Success;
            }
            else
            {
                return Results.StillLooking;
            }
        }

        public bool DogOutOfBounds()
        {
            return Dog.Position.X >= Board.Item1 || Dog.Position.X < 0 ||
                   Dog.Position.Y >= Board.Item2 || Dog.Position.Y < 0;
        }

        public bool DogWakeCat()
        {
            foreach (var cat in Cats)
            {
                if (Dog.Position.X == cat.Item1 && Dog.Position.Y == cat.Item2)
                    return true;
            }

            return false;
        }

        public bool DogFoundBone()
        {
            return Dog.Position.X == Bone.Item1 && Dog.Position.Y == Bone.Item2;
        }

        public bool CatOutOfBounds()
        {
            bool res = false;

            foreach (var cat in Cats)
            {
                res = cat.Item1 >= Board.Item1 || cat.Item1 < 0 ||
                      cat.Item2 >= Board.Item2 || cat.Item2 < 0;

                if (res)
                    break;
            }

            return res;
        }

        public bool BoneOutOfBounds()
        {
            return Bone.Item1 >= Board.Item1 || Bone.Item1 < 0 ||
                   Bone.Item2 >= Board.Item2 || Bone.Item2 < 0;
        }

        public bool CatFoundBone()
        {
            bool res = false;
            foreach (var cat in Cats)
            {
                res = cat.Item1 == Bone.Item1 && cat.Item2 == Bone.Item2;
                if (res)
                    break;
            }

            return res;
        }

        public void IsValid()
        {
            if (DogOutOfBounds())
            {
                throw new DogOutOfBounds();
            }
            else if (DogWakeCat())
            {
                throw new DogWakeCat();
            }
            else if (DogFoundBone())
            {
                throw new DogFoundBone();
            }
            else if (CatOutOfBounds())
            {
                throw new CatOutOfBounds();
            }
            else if (CatFoundBone())
            {
                throw new CatFoundBone();
            }
            else if (BoneOutOfBounds())
            {
                throw new BoneOutOfBounds();
            }

        }
    }
}
