using System;

namespace Dog2Bone.Dog
{


    public class Dog
    {

        public Position Position;

        public Moves Direction { get; set; }

        public Dog(int x, int y, Moves direction)
        {
            Position.X = x;
            Position.Y = y;

            Direction = direction;
        }

        public void Move(Moves move)
        {
            switch (move)
            {
                case Moves.Forward:
                    switch (Direction)
                    {
                        case Moves.North:
                            Position.Y += 1;
                            break;
                        case Moves.South:
                            Position.Y -= 1;
                            break;
                        case Moves.East:
                            Position.X += 1;
                            break;
                        case Moves.West:
                            Position.X -= 1;
                            break;
                    }
                    break;

                default:
                    Direction = move;
                    break;
            }
        }

        public void Rotate(Moves direction)
        {
            this.Direction = direction;
        }
    }
}
