using System;
using System.Numerics;

namespace TrajectoryCalculator
{
    public class Rectangle
    {
        public Rectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public bool Intersects(int x, int y)
        {
            return x > X && y > Y && x < Width && y < Height;
        }

        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }
    }
}
