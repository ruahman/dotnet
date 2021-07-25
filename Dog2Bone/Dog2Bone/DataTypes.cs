using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dog2Bone
{
    public struct Position
    {
        public int X;
        public int Y;
    }

    public enum Moves { Forward, North, East, South, West };

    public enum Results { Success, CatAwake, StillLooking, OutOfBounds }

    public class GameEngineException : Exception
    {
        public GameEngineException(string message) : base(message) { }
    }

    public class DogOutOfBounds : GameEngineException
    {
        public DogOutOfBounds() : base("") { }
    }

    public class DogWakeCat : GameEngineException
    {
        public DogWakeCat() : base("") { }
    }

    public class DogFoundBone : GameEngineException
    {
        public DogFoundBone() : base("") { }
    }

    public class CatOutOfBounds : GameEngineException
    {
        public CatOutOfBounds() : base("") { }
    }

    public class CatFoundBone : GameEngineException
    {
        public CatFoundBone() : base("") { }
    }

    public class BoneOutOfBounds : GameEngineException
    {
        public BoneOutOfBounds() : base("") { }
    }
}
