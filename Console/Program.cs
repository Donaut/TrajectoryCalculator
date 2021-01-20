using System;
using System.Numerics;
using TrajectoryCalculator;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            float gravity = 9.81f;
            Vector2 initalVelocity = new Vector2(50, 20);
            
            // Kezdő szög. nekünk radián kell a számoláshoz szóval át kell konvetálni
            // 45* a jelenlegi szögünk
            double angle = 45 * (180 / Math.PI);

            // The total time in the Air!
            double totalTimeInAir = (2 * initalVelocity.Y * Math.Sin(angle)) / gravity;

            // Max height!
            double height = Math.Pow(initalVelocity.Y, 2) * Math.Pow(Math.Sin(angle), 2);

            Vector2 Position = new Vector2(0, 0);
            for (double t = 0; t < 1000; t += 0.05)
            {
                var h = Console.WindowHeight;
                var w = Console.WindowWidth;
               
                // Dont forget to add the inital position.
                //x = Vx * t
                //y = Vy * t - g * t² 
                double x = initalVelocity.X * t;
                double y = initalVelocity.Y * t - gravity * Math.Pow(t, 2);
                var currentPosition = new Vector2((float)x, (float)y);

                Rectangle rectangle = new Rectangle(0, 0, w, h);
                if (rectangle.Intersects((int)x, (int)y))
                {
                    // The problem is that the vector2(0, 0) position is the top left corner and so our path is upsidedown. So we need to rotate it.
                    // This is a fast solution only. In a real application we using matrixes. (Translate and scale)
                    var result = new Vector2((float)x, (float)y);
                    result -= new Vector2(0, h);
                    result *= new Vector2(1, -1);

                    Console.SetCursorPosition((int)result.X, (int)result.Y);
                    Console.Write('#');
                }
            }
            Console.ReadLine();
        }
    }
}
