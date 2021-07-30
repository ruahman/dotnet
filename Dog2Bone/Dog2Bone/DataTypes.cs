using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Dog2Bone
{
    public class Dog2BoneData
    {
        public int[] Board { get; set; }

        public object[] Start { get; set; }

        public int[] Bone { get; set; }

        public List<int[]> Cats { get; set; }
    }

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

        public GameEngineException(string message, Exception innerException) :
            base(message, innerException)
        { }
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

    public class InvalidMove : GameEngineException
    {
        public InvalidMove() : base("") { }

        public InvalidMove(Exception ex) : base("", ex) { }
    }
}
